using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaudioExample
{
    public partial class Form1 : Form
    {
        int gSampleRate = 44100;
        int gBitRate = 16;
        int gChannels = 1;
        int gBufferMilliseconds = 20;

        bool gPlotDataX_flag = false;

        public Form1()
        {
            InitializeComponent();
            ScanSoundCards();
            PlotInitialize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ScanSoundCards()
        {
            cbDevice.Items.Clear();
            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
                cbDevice.Items.Add(NAudio.Wave.WaveIn.GetCapabilities(i).ProductName);
            if (cbDevice.Items.Count > 0)
                cbDevice.SelectedIndex = 0;
            else
                MessageBox.Show("ERROR: no recording devices available");
        }

        double[] dataX;
        private void PlotInitialize()
        {
            if (dataFft != null)
            {
                double fftSpacing = (double)wvin.WaveFormat.SampleRate / dataFft.Length;
                dataX = new double[dataFft.Length];

                for(int i=0; i<dataFft.Length;i++)
                {
                    dataX[i] = fftSpacing * i;
                }
                gPlotDataX_flag = true;
            }
        }

        private NAudio.Wave.WaveInEvent wvin;
        private void AudioMonitorInitialize(
                int DeviceIndex, int sampleRate = 44100,
                int bitRate = 16, int channels = 1,
                int bufferMilliseconds = 100, bool start = true
            )
        {
            if (wvin == null)
            {
                wvin = new NAudio.Wave.WaveInEvent();
                wvin.DeviceNumber = DeviceIndex;
                wvin.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, bitRate, channels);
                wvin.DataAvailable += OnDataAvailable;
                wvin.BufferMilliseconds = bufferMilliseconds;
                if (start)
                    wvin.StartRecording();
            }
        }

        Int16[] dataPcm;
        private int buffersRead = 0;
        private void OnDataAvailable(object sender, NAudio.Wave.WaveInEventArgs args)
        {
            int bytesPerSample = wvin.WaveFormat.BitsPerSample / 8;
            int samplesRecorded = args.BytesRecorded / bytesPerSample;
            if (dataPcm == null)
                dataPcm = new Int16[samplesRecorded];
            for (int i = 0; i < samplesRecorded; i++)
                dataPcm[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);
            /*
            int sampleRate = 44100;
            short[] buffer = new short[2205];
            double amplitude = 0.25 * short.MaxValue;
            double frequency = 1000;
            for (int n = 0; n < buffer.Length; n++)
            {
                dataPcm[n] = (short)(amplitude * Math.Sin((2 * Math.PI * n * frequency) / sampleRate));
            }
            */
        }

        double[] dataFft;

        private void updateFFT()
        {
            // the PCM size to be analyzed with FFT must be a power of 2
            int fftPoints = 2;
            while (fftPoints * 2 <= dataPcm.Length)
                fftPoints *= 2;

            // apply a Hamming window function as we load the FFT array then calculate the FFT
            NAudio.Dsp.Complex[] fftFull = new NAudio.Dsp.Complex[fftPoints];
            for (int i = 0; i < fftPoints; i++)
                fftFull[i].X = (float)(dataPcm[i] * NAudio.Dsp.FastFourierTransform.HammingWindow(i, fftPoints));
            NAudio.Dsp.FastFourierTransform.FFT(true, (int)Math.Log(fftPoints, 2.0), fftFull);

            // copy the complex values into the double array that will be plotted
            if (dataFft == null)
                dataFft = new double[fftPoints];
            for (int i = 0; i < fftPoints; i++)
            {
                double fftLeft = Math.Abs(fftFull[i].X + fftFull[i].Y);
                double fftRight = Math.Abs(fftFull[fftPoints - i - 1].X + fftFull[fftPoints - i - 1].Y);
                dataFft[i] = fftLeft + fftRight;
                //dataFft[i] = Math.Sqrt(fftFull[i].X * fftFull[i].X + fftFull[i].Y * fftFull[i].Y);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            AudioMonitorInitialize(cbDevice.SelectedIndex, gSampleRate, gBitRate, gChannels, gBufferMilliseconds, true);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (wvin != null)
            {
                wvin.StopRecording();
                wvin = null;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (dataPcm == null)
                return;

            if (!gPlotDataX_flag)
            {
                PlotInitialize();
            }

            updateFFT();

            if (cbAutoAxis.Checked)
            {

            }
            if (dataX != null)
            {
                PlotModel model = new PlotModel();
                PlotModel t_model = new PlotModel();

                var line = new OxyPlot.Series.LineSeries()
                {
                    Title = $"Series 1",
                    Color = OxyPlot.OxyColors.Blue,
                    StrokeThickness = 1,
                    MarkerSize = 2,
                    MarkerType = OxyPlot.MarkerType.Circle
                };

                var line2 = new OxyPlot.Series.LineSeries()
                {
                    Title = $"Series t",
                    Color = OxyPlot.OxyColors.Blue,
                    StrokeThickness = 1,
                    MarkerSize = 2,
                    MarkerType = OxyPlot.MarkerType.Circle
                };

                for (int i = 0; i < dataX.Length; i++)
                    line.Points.Add(new OxyPlot.DataPoint(dataX[i], dataFft[i]));

                for (int i = 0; i < dataPcm.Length; i++)
                    line2.Points.Add(new OxyPlot.DataPoint(i, dataPcm[i]));

                model.Series.Add(line);
                oxyPlot1.Model = model;

                t_model.Series.Add(line2);
                oxyPlot2.Model = t_model;
            }
        }
    }
}

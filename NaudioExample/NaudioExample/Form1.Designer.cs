namespace NaudioExample
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.cbAutoAxis = new System.Windows.Forms.CheckBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.oxyPlot1 = new OxyPlot.WindowsForms.PlotView();
            this.oxyPlot2 = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "InputAudioDevice";
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(12, 24);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(121, 20);
            this.cbDevice.TabIndex = 2;
            // 
            // cbAutoAxis
            // 
            this.cbAutoAxis.AutoSize = true;
            this.cbAutoAxis.Location = new System.Drawing.Point(168, 26);
            this.cbAutoAxis.Name = "cbAutoAxis";
            this.cbAutoAxis.Size = new System.Drawing.Size(71, 16);
            this.cbAutoAxis.TabIndex = 3;
            this.cbAutoAxis.Text = "AutoAxis";
            this.cbAutoAxis.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(245, 9);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(70, 43);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(333, 9);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(68, 43);
            this.btStop.TabIndex = 5;
            this.btStop.Text = "stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // oxyPlot1
            // 
            this.oxyPlot1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.oxyPlot1.Location = new System.Drawing.Point(14, 68);
            this.oxyPlot1.Name = "oxyPlot1";
            this.oxyPlot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.oxyPlot1.Size = new System.Drawing.Size(752, 274);
            this.oxyPlot1.TabIndex = 6;
            this.oxyPlot1.Text = "plotView1";
            this.oxyPlot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.oxyPlot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.oxyPlot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // oxyPlot2
            // 
            this.oxyPlot2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.oxyPlot2.Location = new System.Drawing.Point(14, 348);
            this.oxyPlot2.Name = "oxyPlot2";
            this.oxyPlot2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.oxyPlot2.Size = new System.Drawing.Size(752, 278);
            this.oxyPlot2.TabIndex = 7;
            this.oxyPlot2.Text = "plotView1";
            this.oxyPlot2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.oxyPlot2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.oxyPlot2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 638);
            this.Controls.Add(this.oxyPlot2);
            this.Controls.Add(this.oxyPlot1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.cbAutoAxis);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.CheckBox cbAutoAxis;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Timer timer1;
        private OxyPlot.WindowsForms.PlotView oxyPlot1;
        private OxyPlot.WindowsForms.PlotView oxyPlot2;
    }
}


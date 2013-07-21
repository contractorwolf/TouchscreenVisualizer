namespace Touchscreen_Visualizer
{
    partial class DisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.pbTouchPanel = new System.Windows.Forms.PictureBox();
            this.pSerialIndicator = new System.Windows.Forms.Panel();
            this.lStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lTranslated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTouchPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(652, -1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(156, 38);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(293, 38);
            this.txtMessage.TabIndex = 1;
            // 
            // cbPorts
            // 
            this.cbPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(525, -1);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(121, 39);
            this.cbPorts.TabIndex = 2;
            // 
            // pbTouchPanel
            // 
            this.pbTouchPanel.BackColor = System.Drawing.Color.Black;
            this.pbTouchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTouchPanel.Location = new System.Drawing.Point(0, 0);
            this.pbTouchPanel.Name = "pbTouchPanel";
            this.pbTouchPanel.Size = new System.Drawing.Size(811, 574);
            this.pbTouchPanel.TabIndex = 3;
            this.pbTouchPanel.TabStop = false;
            // 
            // pSerialIndicator
            // 
            this.pSerialIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pSerialIndicator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pSerialIndicator.Location = new System.Drawing.Point(762, 197);
            this.pSerialIndicator.Name = "pSerialIndicator";
            this.pSerialIndicator.Size = new System.Drawing.Size(44, 35);
            this.pSerialIndicator.TabIndex = 5;
            // 
            // lStatus
            // 
            this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lStatus.AutoSize = true;
            this.lStatus.BackColor = System.Drawing.Color.Black;
            this.lStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatus.ForeColor = System.Drawing.Color.White;
            this.lStatus.Location = new System.Drawing.Point(696, 198);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(41, 13);
            this.lStatus.TabIndex = 6;
            this.lStatus.Text = "status";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lTranslated
            // 
            this.lTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTranslated.AutoSize = true;
            this.lTranslated.BackColor = System.Drawing.Color.Black;
            this.lTranslated.ForeColor = System.Drawing.Color.White;
            this.lTranslated.Location = new System.Drawing.Point(695, 45);
            this.lTranslated.Name = "lTranslated";
            this.lTranslated.Size = new System.Drawing.Size(55, 13);
            this.lTranslated.TabIndex = 7;
            this.lTranslated.Text = "press start";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 574);
            this.Controls.Add(this.lTranslated);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.pSerialIndicator);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.pbTouchPanel);
            this.Name = "DisplayForm";
            this.Text = "Touchscreen Visualizer ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbTouchPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.PictureBox pbTouchPanel;
        private System.Windows.Forms.Panel pSerialIndicator;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lTranslated;
    }
}


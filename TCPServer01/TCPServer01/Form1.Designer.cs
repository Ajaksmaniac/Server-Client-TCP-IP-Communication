namespace TCPServer01
{
    partial class Form1
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
            this.tbConsoleOutput = new System.Windows.Forms.TextBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.tbPayload = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFindIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbConsoleOutput
            // 
            this.tbConsoleOutput.Location = new System.Drawing.Point(12, 12);
            this.tbConsoleOutput.Multiline = true;
            this.tbConsoleOutput.Name = "tbConsoleOutput";
            this.tbConsoleOutput.Size = new System.Drawing.Size(776, 258);
            this.tbConsoleOutput.TabIndex = 0;
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(72, 292);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(106, 20);
            this.tbIPAddress.TabIndex = 1;
            this.tbIPAddress.Text = "192.168.0.18";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(184, 292);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(46, 20);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "23000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP/Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(72, 318);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(158, 23);
            this.btnStartListening.TabIndex = 4;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbPayload
            // 
            this.tbPayload.Location = new System.Drawing.Point(640, 292);
            this.tbPayload.Name = "tbPayload";
            this.tbPayload.Size = new System.Drawing.Size(100, 20);
            this.tbPayload.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(640, 319);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnFindIP
            // 
            this.btnFindIP.Location = new System.Drawing.Point(270, 318);
            this.btnFindIP.Name = "btnFindIP";
            this.btnFindIP.Size = new System.Drawing.Size(88, 23);
            this.btnFindIP.TabIndex = 7;
            this.btnFindIP.Text = "Look for IPv4 ";
            this.btnFindIP.UseVisualStyleBackColor = true;
            this.btnFindIP.Click += new System.EventHandler(this.btnFindIP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 353);
            this.Controls.Add(this.btnFindIP);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbPayload);
            this.Controls.Add(this.btnStartListening);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.tbConsoleOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsoleOutput;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.TextBox tbPayload;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnFindIP;
    }
}


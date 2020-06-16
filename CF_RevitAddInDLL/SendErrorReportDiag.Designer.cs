namespace SolidworksAddin
{
    partial class SendErrorReportDiag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendErrorReportDiag));
            this.errorReportLabel = new System.Windows.Forms.Label();
            this.dontSendButton = new System.Windows.Forms.Button();
            this.sendErrorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errorReportLabel
            // 
            this.errorReportLabel.AutoSize = true;
            this.errorReportLabel.Location = new System.Drawing.Point(12, 18);
            this.errorReportLabel.Name = "errorReportLabel";
            this.errorReportLabel.Size = new System.Drawing.Size(243, 104);
            this.errorReportLabel.TabIndex = 0;
            this.errorReportLabel.Text = resources.GetString("errorReportLabel.Text");
            // 
            // dontSendButton
            // 
            this.dontSendButton.Location = new System.Drawing.Point(32, 148);
            this.dontSendButton.Name = "dontSendButton";
            this.dontSendButton.Size = new System.Drawing.Size(90, 28);
            this.dontSendButton.TabIndex = 1;
            this.dontSendButton.Text = "Don\'t send";
            this.dontSendButton.UseVisualStyleBackColor = true;
            this.dontSendButton.Click += new System.EventHandler(this.dontSendButton_Click);
            // 
            // sendErrorButton
            // 
            this.sendErrorButton.Location = new System.Drawing.Point(141, 148);
            this.sendErrorButton.Name = "sendErrorButton";
            this.sendErrorButton.Size = new System.Drawing.Size(90, 28);
            this.sendErrorButton.TabIndex = 2;
            this.sendErrorButton.Text = "Send";
            this.sendErrorButton.UseVisualStyleBackColor = true;
            this.sendErrorButton.Click += new System.EventHandler(this.sendErrorButton_Click);
            // 
            // SendErrorReportDiag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 188);
            this.Controls.Add(this.sendErrorButton);
            this.Controls.Add(this.dontSendButton);
            this.Controls.Add(this.errorReportLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendErrorReportDiag";
            this.Text = "CadFaster|Translator for Solidworks R0 beta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label errorReportLabel;
        private System.Windows.Forms.Button dontSendButton;
        private System.Windows.Forms.Button sendErrorButton;
    }
}
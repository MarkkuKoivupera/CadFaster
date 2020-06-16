namespace ExeWriter
{
    partial class Frm_Progress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Progress));
            this.LblProg = new System.Windows.Forms.Label();
            this.ProBarElement = new System.Windows.Forms.ProgressBar();
            this.ProBarFace = new System.Windows.Forms.ProgressBar();
            this.LblFace = new System.Windows.Forms.Label();
            this.ProBarData = new System.Windows.Forms.ProgressBar();
            this.LblData = new System.Windows.Forms.Label();
            this.ProBarObjects = new System.Windows.Forms.ProgressBar();
            this.LblObjects = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblProg
            // 
            this.LblProg.AutoSize = true;
            this.LblProg.Location = new System.Drawing.Point(8, 12);
            this.LblProg.Name = "LblProg";
            this.LblProg.Size = new System.Drawing.Size(62, 13);
            this.LblProg.TabIndex = 0;
            this.LblProg.Text = "Progressing";
            // 
            // ProBarElement
            // 
            this.ProBarElement.Location = new System.Drawing.Point(11, 28);
            this.ProBarElement.Name = "ProBarElement";
            this.ProBarElement.Size = new System.Drawing.Size(425, 13);
            this.ProBarElement.TabIndex = 1;
            // 
            // ProBarFace
            // 
            this.ProBarFace.Location = new System.Drawing.Point(11, 102);
            this.ProBarFace.Name = "ProBarFace";
            this.ProBarFace.Size = new System.Drawing.Size(425, 11);
            this.ProBarFace.TabIndex = 3;
            this.ProBarFace.Visible = false;
            // 
            // LblFace
            // 
            this.LblFace.AutoSize = true;
            this.LblFace.Location = new System.Drawing.Point(11, 86);
            this.LblFace.Name = "LblFace";
            this.LblFace.Size = new System.Drawing.Size(39, 13);
            this.LblFace.TabIndex = 2;
            this.LblFace.Text = "Faces:";
            this.LblFace.Visible = false;
            // 
            // ProBarData
            // 
            this.ProBarData.Location = new System.Drawing.Point(11, 132);
            this.ProBarData.Name = "ProBarData";
            this.ProBarData.Size = new System.Drawing.Size(425, 12);
            this.ProBarData.TabIndex = 5;
            this.ProBarData.Visible = false;
            // 
            // LblData
            // 
            this.LblData.AutoSize = true;
            this.LblData.Location = new System.Drawing.Point(11, 116);
            this.LblData.Name = "LblData";
            this.LblData.Size = new System.Drawing.Size(40, 13);
            this.LblData.TabIndex = 4;
            this.LblData.Text = "Vertex:";
            this.LblData.Visible = false;
            // 
            // ProBarObjects
            // 
            this.ProBarObjects.Location = new System.Drawing.Point(11, 72);
            this.ProBarObjects.Name = "ProBarObjects";
            this.ProBarObjects.Size = new System.Drawing.Size(425, 11);
            this.ProBarObjects.TabIndex = 7;
            this.ProBarObjects.Visible = false;
            // 
            // LblObjects
            // 
            this.LblObjects.AutoSize = true;
            this.LblObjects.Location = new System.Drawing.Point(10, 56);
            this.LblObjects.Name = "LblObjects";
            this.LblObjects.Size = new System.Drawing.Size(46, 13);
            this.LblObjects.TabIndex = 6;
            this.LblObjects.Text = "Objects:";
            this.LblObjects.Visible = false;
            // 
            // Frm_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 153);
            this.ControlBox = false;
            this.Controls.Add(this.ProBarObjects);
            this.Controls.Add(this.LblObjects);
            this.Controls.Add(this.ProBarData);
            this.Controls.Add(this.LblData);
            this.Controls.Add(this.ProBarFace);
            this.Controls.Add(this.LblFace);
            this.Controls.Add(this.ProBarElement);
            this.Controls.Add(this.LblProg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Progress";
            this.Text = "Data Progressing...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblProg;
        private System.Windows.Forms.ProgressBar ProBarElement;
        private System.Windows.Forms.ProgressBar ProBarFace;
        private System.Windows.Forms.Label LblFace;
        private System.Windows.Forms.ProgressBar ProBarData;
        private System.Windows.Forms.Label LblData;
        private System.Windows.Forms.ProgressBar ProBarObjects;
        private System.Windows.Forms.Label LblObjects;
    }
}

namespace assertv
{
    partial class Traymassage
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
            this.plBack = new System.Windows.Forms.Panel();
            this.lbResult = new System.Windows.Forms.LinkLabel();
            this.plBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBack
            // 
            this.plBack.BackColor = System.Drawing.Color.White;
            this.plBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plBack.Controls.Add(this.lbResult);
            this.plBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBack.Location = new System.Drawing.Point(0, 0);
            this.plBack.Name = "plBack";
            this.plBack.Size = new System.Drawing.Size(256, 134);
            this.plBack.TabIndex = 0;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(3, 8);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(45, 12);
            this.lbResult.TabIndex = 0;
            this.lbResult.TabStop = true;
            this.lbResult.Text = "할 일 : ";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbResult_LinkClicked);
            // 
            // Traymassage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 134);
            this.Controls.Add(this.plBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Traymassage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "assertv_massage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Traymassage_Load);
            this.plBack.ResumeLayout(false);
            this.plBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plBack;
        private System.Windows.Forms.LinkLabel lbResult;
    }
}
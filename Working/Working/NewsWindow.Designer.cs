﻿namespace Working
{
    partial class NewsWindow
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
            newsLbl = new Label();
            SuspendLayout();
            // 
            // newsLbl
            // 
            newsLbl.AutoSize = true;
            newsLbl.Location = new Point(349, 75);
            newsLbl.Name = "newsLbl";
            newsLbl.Size = new Size(54, 15);
            newsLbl.TabIndex = 0;
            newsLbl.Text = "Новости";
            // 
            // NewsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newsLbl);
            Name = "NewsWindow";
            Text = "AdminWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label newsLbl;
    }
}
namespace Working
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
            firstNew = new Label();
            fisrtNew = new Label();
            thirdNew = new Label();
            SuspendLayout();
            // 
            // newsLbl
            // 
            newsLbl.AutoSize = true;
            newsLbl.Font = new Font("Segoe UI", 29F);
            newsLbl.Location = new Point(263, 18);
            newsLbl.Name = "newsLbl";
            newsLbl.Size = new Size(174, 52);
            newsLbl.TabIndex = 0;
            newsLbl.Text = "Новости";
            // 
            // firstNew
            // 
            firstNew.AutoSize = true;
            firstNew.Font = new Font("Segoe UI", 19F);
            firstNew.Location = new Point(43, 91);
            firstNew.Name = "firstNew";
            firstNew.Size = new Size(205, 36);
            firstNew.TabIndex = 1;
            firstNew.Text = "Первая новость";
            // 
            // fisrtNew
            // 
            fisrtNew.AutoSize = true;
            fisrtNew.Font = new Font("Segoe UI", 19F);
            fisrtNew.Location = new Point(43, 153);
            fisrtNew.Name = "fisrtNew";
            fisrtNew.Size = new Size(199, 36);
            fisrtNew.TabIndex = 2;
            fisrtNew.Text = "Вторая новость";
            // 
            // thirdNew
            // 
            thirdNew.AutoSize = true;
            thirdNew.Font = new Font("Segoe UI", 19F);
            thirdNew.Location = new Point(43, 215);
            thirdNew.Name = "thirdNew";
            thirdNew.Size = new Size(197, 36);
            thirdNew.TabIndex = 3;
            thirdNew.Text = "Третья новость";
            // 
            // NewsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(thirdNew);
            Controls.Add(fisrtNew);
            Controls.Add(firstNew);
            Controls.Add(newsLbl);
            Name = "NewsWindow";
            Text = "AdminWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label newsLbl;
        private Label firstNew;
        private Label fisrtNew;
        private Label thirdNew;
    }
}
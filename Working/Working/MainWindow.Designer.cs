namespace Working
{
    partial class MainWindow
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
            newsBtn = new Button();
            infoLbl = new Label();
            SuspendLayout();
            // 
            // newsBtn
            // 
            newsBtn.Font = new Font("Segoe UI", 19F);
            newsBtn.Location = new Point(245, 185);
            newsBtn.Name = "newsBtn";
            newsBtn.Size = new Size(240, 60);
            newsBtn.TabIndex = 0;
            newsBtn.Text = "Новости";
            newsBtn.UseVisualStyleBackColor = true;
            newsBtn.Click += newsBtn_Click;
            // 
            // infoLbl
            // 
            infoLbl.AutoSize = true;
            infoLbl.Font = new Font("Segoe UI", 29F);
            infoLbl.Location = new Point(213, 28);
            infoLbl.Name = "infoLbl";
            infoLbl.Size = new Size(315, 52);
            infoLbl.TabIndex = 1;
            infoLbl.Text = "Основное меню";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(infoLbl);
            Controls.Add(newsBtn);
            Name = "MainWindow";
            Text = "MainWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button newsBtn;
        private Label infoLbl;
    }
}
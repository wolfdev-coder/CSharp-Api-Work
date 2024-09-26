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
            exitBtn = new Button();
            adminAdd = new Button();
            stopBot = new Button();
            SuspendLayout();
            // 
            // newsBtn
            // 
            newsBtn.Font = new Font("Segoe UI", 19F);
            newsBtn.Location = new Point(253, 112);
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
            // exitBtn
            // 
            exitBtn.Font = new Font("Segoe UI", 19F);
            exitBtn.Location = new Point(633, 371);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(134, 67);
            exitBtn.TabIndex = 2;
            exitBtn.Text = "Выход";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // adminAdd
            // 
            adminAdd.Font = new Font("Segoe UI", 19F);
            adminAdd.Location = new Point(236, 195);
            adminAdd.Name = "adminAdd";
            adminAdd.Size = new Size(292, 74);
            adminAdd.TabIndex = 3;
            adminAdd.Text = "Запустить бота";
            adminAdd.UseVisualStyleBackColor = true;
            adminAdd.Click += adminAdd_Click;
            // 
            // stopBot
            // 
            stopBot.Font = new Font("Segoe UI", 19F);
            stopBot.Location = new Point(236, 296);
            stopBot.Name = "stopBot";
            stopBot.Size = new Size(292, 74);
            stopBot.TabIndex = 4;
            stopBot.Text = "Остановить бота";
            stopBot.UseVisualStyleBackColor = true;
            stopBot.Visible = false;
            stopBot.Click += stopBot_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(stopBot);
            Controls.Add(adminAdd);
            Controls.Add(exitBtn);
            Controls.Add(infoLbl);
            Controls.Add(newsBtn);
            Name = "MainWindow";
            Text = "MyApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button newsBtn;
        private Label infoLbl;
        private Button exitBtn;
        private Button adminAdd;
        private Button stopBot;
    }
}
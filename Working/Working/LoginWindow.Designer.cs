namespace Working
{
    partial class LoginWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            enterBtn = new Button();
            helloLbl = new Label();
            loginTxt = new TextBox();
            passwordBox = new TextBox();
            registerBtn = new Button();
            weatherBtn = new Button();
            weatherTxt = new TextBox();
            getBtn = new Button();
            questionBtn = new Button();
            funnyBtn = new Button();
            howBtn = new Button();
            nameTxt = new TextBox();
            startBtn = new Button();
            SuspendLayout();
            // 
            // enterBtn
            // 
            enterBtn.Font = new Font("Segoe UI", 19F);
            enterBtn.Location = new Point(407, 259);
            enterBtn.Name = "enterBtn";
            enterBtn.Size = new Size(175, 45);
            enterBtn.TabIndex = 0;
            enterBtn.Text = "Войти";
            enterBtn.UseVisualStyleBackColor = true;
            enterBtn.Click += enterBtn_Click;
            // 
            // helloLbl
            // 
            helloLbl.AutoSize = true;
            helloLbl.Font = new Font("Segoe UI", 29F);
            helloLbl.Location = new Point(407, 34);
            helloLbl.Name = "helloLbl";
            helloLbl.Size = new Size(164, 52);
            helloLbl.TabIndex = 1;
            helloLbl.Text = "Привет!";
            // 
            // loginTxt
            // 
            loginTxt.Font = new Font("Segoe UI", 19F);
            loginTxt.Location = new Point(364, 103);
            loginTxt.Name = "loginTxt";
            loginTxt.Size = new Size(254, 41);
            loginTxt.TabIndex = 2;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Segoe UI", 19F);
            passwordBox.Location = new Point(364, 182);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(254, 41);
            passwordBox.TabIndex = 3;
            // 
            // registerBtn
            // 
            registerBtn.Font = new Font("Segoe UI", 19F);
            registerBtn.Location = new Point(332, 326);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(323, 45);
            registerBtn.TabIndex = 4;
            registerBtn.Text = "Зарегистрироваться";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // weatherBtn
            // 
            weatherBtn.Font = new Font("Segoe UI", 19F);
            weatherBtn.Location = new Point(12, 486);
            weatherBtn.Name = "weatherBtn";
            weatherBtn.Size = new Size(228, 53);
            weatherBtn.TabIndex = 5;
            weatherBtn.Text = "Узнать погоду";
            weatherBtn.UseVisualStyleBackColor = true;
            weatherBtn.Click += weatherBtn_Click;
            // 
            // weatherTxt
            // 
            weatherTxt.Font = new Font("Segoe UI", 19F);
            weatherTxt.Location = new Point(45, 439);
            weatherTxt.Name = "weatherTxt";
            weatherTxt.Size = new Size(163, 41);
            weatherTxt.TabIndex = 6;
            weatherTxt.Visible = false;
            // 
            // getBtn
            // 
            getBtn.Font = new Font("Segoe UI", 19F);
            getBtn.Location = new Point(12, 486);
            getBtn.Name = "getBtn";
            getBtn.Size = new Size(228, 53);
            getBtn.TabIndex = 7;
            getBtn.Text = "Запрос";
            getBtn.UseVisualStyleBackColor = true;
            getBtn.Visible = false;
            getBtn.Click += getBtn_Click;
            // 
            // questionBtn
            // 
            questionBtn.Font = new Font("Segoe UI", 19F);
            questionBtn.Location = new Point(246, 486);
            questionBtn.Name = "questionBtn";
            questionBtn.Size = new Size(228, 53);
            questionBtn.TabIndex = 8;
            questionBtn.Text = "Загадка";
            questionBtn.UseVisualStyleBackColor = true;
            questionBtn.Click += questionBtn_Click;
            // 
            // funnyBtn
            // 
            funnyBtn.Font = new Font("Segoe UI", 19F);
            funnyBtn.Location = new Point(480, 486);
            funnyBtn.Name = "funnyBtn";
            funnyBtn.Size = new Size(228, 53);
            funnyBtn.TabIndex = 11;
            funnyBtn.Text = "Анекдот";
            funnyBtn.UseVisualStyleBackColor = true;
            funnyBtn.Click += funnyBtn_Click;
            // 
            // howBtn
            // 
            howBtn.Font = new Font("Segoe UI", 19F);
            howBtn.Location = new Point(725, 486);
            howBtn.Name = "howBtn";
            howBtn.Size = new Size(305, 53);
            howBtn.TabIndex = 12;
            howBtn.Text = "Узнать национальность";
            howBtn.UseVisualStyleBackColor = true;
            howBtn.Click += howBtn_Click;
            // 
            // nameTxt
            // 
            nameTxt.Font = new Font("Segoe UI", 19F);
            nameTxt.Location = new Point(798, 439);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(163, 41);
            nameTxt.TabIndex = 13;
            nameTxt.Visible = false;
            // 
            // startBtn
            // 
            startBtn.Font = new Font("Segoe UI", 19F);
            startBtn.Location = new Point(714, 486);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(305, 53);
            startBtn.TabIndex = 14;
            startBtn.Text = "Начать";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Visible = false;
            startBtn.Click += startBtn_Click;
            // 
            // LoginWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 551);
            Controls.Add(startBtn);
            Controls.Add(nameTxt);
            Controls.Add(howBtn);
            Controls.Add(funnyBtn);
            Controls.Add(questionBtn);
            Controls.Add(weatherTxt);
            Controls.Add(registerBtn);
            Controls.Add(passwordBox);
            Controls.Add(loginTxt);
            Controls.Add(helloLbl);
            Controls.Add(enterBtn);
            Controls.Add(getBtn);
            Controls.Add(weatherBtn);
            Name = "LoginWindow";
            Text = "MyApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button enterBtn;
        private Label helloLbl;
        private TextBox loginTxt;
        private TextBox passwordBox;
        private Button registerBtn;
        private Button weatherBtn;
        private TextBox weatherTxt;
        private Button getBtn;
        private Button questionBtn;
        private Button funnyBtn;
        private Button howBtn;
        private TextBox nameTxt;
        private Button startBtn;
    }
}

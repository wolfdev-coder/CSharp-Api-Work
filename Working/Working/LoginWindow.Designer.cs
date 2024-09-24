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
            SuspendLayout();
            // 
            // enterBtn
            // 
            enterBtn.Font = new Font("Segoe UI", 19F);
            enterBtn.Location = new Point(291, 318);
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
            helloLbl.Location = new Point(291, 30);
            helloLbl.Name = "helloLbl";
            helloLbl.Size = new Size(164, 52);
            helloLbl.TabIndex = 1;
            helloLbl.Text = "Привет!";
            // 
            // loginTxt
            // 
            loginTxt.Font = new Font("Segoe UI", 19F);
            loginTxt.Location = new Point(253, 222);
            loginTxt.Name = "loginTxt";
            loginTxt.Size = new Size(254, 41);
            loginTxt.TabIndex = 2;
            // 
            // LoginWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginTxt);
            Controls.Add(helloLbl);
            Controls.Add(enterBtn);
            Name = "LoginWindow";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button enterBtn;
        private Label helloLbl;
        private TextBox loginTxt;
    }
}

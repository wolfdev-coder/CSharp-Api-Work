namespace Working
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (loginTxt.Text.Contains("Admin"))
            {
                this.Close();
                Thread openForm = new Thread(MainOpen);
                openForm.Start();
            }
        }

        private void MainOpen(object? obj)
        {
            Application.Run(new MainWindow());
        }
    }
}

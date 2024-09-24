using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Working
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newsBtn_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread openForm = new Thread(MainOpen);
            openForm.Start();
        }

        private void MainOpen(object? obj)
        {
            Application.Run(new NewsWindow());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;
using Timer = System.Windows.Forms.Timer;

namespace Working
{
    public partial class NewsWindow : Form
    {
        private Random _random = new Random();
        private Timer _timer;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private delegate int LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID;
        public NewsWindow()
        {
            InitializeComponent();
            if (LoginWindow.permission == "user")
            {
                addBtn.Enabled = false;
            }
            else if (LoginWindow.permission == "admin")
            {
                addBtn.Enabled = true;
            }
            PersonLoad();
        }
        public static SQLiteConnection DB = new SQLiteConnection(Database.connectionString);
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread openForm = new Thread(MainOpen);
            openForm.Start();
        }

        public async void PersonLoad()
        {
            listView1.Clear();
            if (DB.State == ConnectionState.Closed)
            {
                DB.Open();
            }
            SQLiteCommand command = new SQLiteCommand("SELECT content " +
                "FROM News", DB);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader["content"].ToString();
                    ListViewItem item = new ListViewItem(name);
                    listView1.Items.Add(item);
                    DatabaseInsert("Заполнил листвью", "легенда");
                }
            }
            else
            {
                listView1.Items.Add("Нет новостей(");
            }
        }
        private void MainOpen(object? obj)
        {
            System.Windows.Forms.Application.Run(new MainWindow());
        }
        public void DatabaseInsert(string log, string name)
        {
            if (DB.State == System.Data.ConnectionState.Closed)
            {
                DB.Open();
            }
            string time = ActionTime();
            string querry = "INSERT INTO Log " +
                "(name, logMessage, time) " +
                "VALUES (@name, @logMessage, @time)";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(querry, DB);
            sQLiteCommand.Parameters.AddWithValue("@name", name);
            sQLiteCommand.Parameters.AddWithValue("@logMessage", log);
            sQLiteCommand.Parameters.AddWithValue("@time", time);
            sQLiteCommand.ExecuteNonQuery();
        }
        public string ActionTime()
        {
            ClearMemoryCache();
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("dd:MM:yyyyy | HH:mm:ss");
            return time;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ClearMemoryCache();
            newsBoxTxt.Visible = true;
            listView1.Visible = false;
            addBtn.Enabled = false;
            commitBtn.Visible = true;
        }

        private void commitBtn_Click(object sender, EventArgs e)
        {
            ClearMemoryCache();
            if (newsBoxTxt.Text.Length > 0)
            {
                if (DB.State == ConnectionState.Closed)
                {
                    DB.Open();
                }
                string query = "INSERT INTO News" +
                    "(content)" +
                    "VALUES (@content)";
                SQLiteCommand cmd = new SQLiteCommand(query, DB);
                cmd.Parameters.AddWithValue("@content", newsBoxTxt.Text);
                cmd.ExecuteNonQuery();
                DatabaseInsert("Ввел новую новость", LoginWindow.userName);
                addBtn.Enabled = true;
                commitBtn.Visible = false;
                newsBoxTxt.Visible = false;
                listView1.Visible = true;
                PersonLoad();
            }
            else
            {
                MessageBox.Show("Надо бы заполнить данное текстовое поле");
            }
        }
        [DllImport("kernel32")]
        static extern bool SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void ClearMemoryCache()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            listFormsBox.Visible = false;
            backgroundFormsBtn.Visible = true;
            addBtn.Visible = true;
            string formName = listFormsBox.Text;
            if (!string.IsNullOrEmpty(formName))
            {
                openFileDialog1.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog1.InitialDirectory = @"C:\";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (formName == "MainWindow")
                    {
                        string selectedImagePath = openFileDialog1.FileName;
                        MainWindow form = new MainWindow();
                        form.BackgroundImage = Image.FromFile(selectedImagePath);
                        form.ShowDialog();
                    }
                    if (formName == "LoginWindow")
                    {
                        string selectedImagePath = openFileDialog1.FileName;
                        LoginWindow form = new LoginWindow();
                        form.BackgroundImage = Image.FromFile(selectedImagePath);
                        form.ShowDialog();

                    }
                    if (formName == "yes")
                    {
                        string selectedImagePath = openFileDialog1.FileName;
                        this.BackgroundImage = Image.FromFile(selectedImagePath);
                    }
                }
            }
            else
            {
                MessageBox.Show("выберите что нибудь");
            }
        }

        private void backgroundFormsBtn_Click(object sender, EventArgs e)
        {
            backgroundFormsBtn.Visible = false;
            setBtn.Visible = true;
            addBtn.Visible = false;
            listFormsBox.Visible = true;
        }

        private void funnBtn_Click(object sender, EventArgs e)
        {
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += Timer_Tick;
            _timer.Start();

            for (int i = 0; i < 10; i++)
            {
                Button button = new Button();
                button.Text = $"Button {i}";
                button.Location = new Point(_random.Next(0, this.ClientSize.Width), _random.Next(0, this.ClientSize.Height));
                button.Size = new Size(100, 30);
                this.Controls.Add(button);
            }

            for (int i = 0; i < 10; i++)
            {
                Label label = new Label();
                label.Text = $"Label {i}";
                label.Location = new Point(_random.Next(0, this.ClientSize.Width), _random.Next(0, this.ClientSize.Height));
                label.Size = new Size(100, 30);
                this.Controls.Add(label);
            }

            for (int i = 0; i < 10; i++)
            {
                TextBox textBox = new System.Windows.Forms.TextBox();
                textBox.Text = $"TextBox {i}";
                textBox.Location = new Point(_random.Next(0, this.ClientSize.Width), _random.Next(0, this.ClientSize.Height));
                textBox.Size = new Size(100, 30);
                this.Controls.Add(textBox);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Location = new Point(_random.Next(0, this.ClientSize.Width), _random.Next(0, this.ClientSize.Height));
            }
        }

        private void questBtn_Click(object sender, EventArgs e)
        {
            int x = 10;
            int dx = 2;
            Label label = new Label { Text = "!", Location = new System.Drawing.Point(10, 10) };
            this.Controls.Add(label);
            Random random = new Random();
            Timer timer = new Timer { Interval = 50 };
            timer.Tick += (sender, e) =>
            {
                x += dx;
                if (x + label.Width > this.Width || x < 0)
                {
                    dx = -dx;
                }
                label.Location = new System.Drawing.Point(x, 10);
            };
            Timer symbolTimer = new Timer { Interval = 2000 }; // 2 секунды
            symbolTimer.Tick += (sender, e) =>
            {
                char[] symbols = { '!', '@', '#', '$', '%', '^', '&', '*' };
                label.Text = symbols[random.Next(symbols.Length)].ToString();
            };
            timer.Start();
            symbolTimer.Start();
        }

        private void importantBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }
        private int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                string key = ((Keys)vkCode).ToString();
                label1.Text = $"Вы нажали клавишу: {key}";
            }
            return (int)CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
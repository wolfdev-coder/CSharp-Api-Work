using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

namespace Working
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        public static SQLiteConnection DB = new SQLiteConnection(Database.connectionString);
        private static HttpClient client = new HttpClient();
        public static string userName { get; set; }
        public static string password { get; set; }
        public static string permission { get; set; }
        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (DB.State == System.Data.ConnectionState.Closed)
            {
                DB.Open();
                DatabaseInsert("База Данных открыта", "Новый пользователь");

            }
            if (loginTxt.Text.Length > 0 && passwordBox.Text.Length > 0)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * " +
                    "FROM Users", DB);
                SQLiteDataReader reader = cmd.ExecuteReader();
                DatabaseInsert("Пытка входа...", loginTxt.Text);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string password = reader["password"].ToString();
                        string userPermission = reader["permission"].ToString();
                        if (loginTxt.Text == name && passwordBox.Text == password)
                        {
                            userName = loginTxt.Text;
                            permission = userPermission;
                            DatabaseInsert("Вошел такой человек как", userName);
                            this.Close();
                            Thread openForm = new Thread(MainOpen);
                            openForm.Start();
                        }
                    }
                }
                else
                {
                    DatabaseInsert("Пытался зайти", userName);
                    MessageBox.Show("Надо так то заполнить строку");
                }
            }
        }


        private void MainOpen(object? obj)
        {
            Application.Run(new MainWindow());
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (loginTxt.Text.Length > 0 && passwordBox.Text.Length > 0)
            {
                string name = loginTxt.Text;
                string password = passwordBox.Text;
                if (DB.State == System.Data.ConnectionState.Closed)
                {
                    DB.Open();
                }
                SQLiteCommand sQLiteCommand = new SQLiteCommand("INSERT INTO Users " +
                "(name, password) " +
                "VALUES (@name,@password)", DB);
                sQLiteCommand.Parameters.AddWithValue("@name", name);
                sQLiteCommand.Parameters.AddWithValue("@password", name);
                sQLiteCommand.ExecuteNonQuery();
                DatabaseInsert("Регистрация в приложении", name);
                userName = loginTxt.Text;
                permission = "user";
                this.Close();
                Thread openForm = new Thread(MainOpen);
                openForm.Start();
            }
            else
            {
                MessageBox.Show("Заполните поля");
                DatabaseInsert("Неудачная попытка регистрации", "Новый пользователь");
            }
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
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("dd:MM:yyyyy | HH:mm:ss");
            return time;
        }

        private void weatherBtn_Click(object sender, EventArgs e)
        {
            string executablePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = Path.Combine(executablePath, "text.txt");
            weatherTxt.Visible = true;
            getBtn.Visible = true;
            weatherBtn.Visible = false;
            WriteToFile(file, "пипец топовый код");
            string dataFile = ReadFromFile(file);
            DatabaseInsert(dataFile, "мда");

        }

        private void getBtn_Click(object sender, EventArgs e)
        {
            DatabaseInsert("Нажата кнопка getBTN", "Новый пользователь");
            if (weatherTxt.Visible)
            {
                if (weatherTxt.Text.Length > 0)
                {
                    GetWeather(weatherTxt.Text);
                    weatherBtn.Visible = true;
                    weatherTxt.Visible = false;
                    getBtn.Visible = false;
                }
            }
        }
        static async Task GetWeather(string weather)
        {
            string city = weather;
            string apiKey = "5fade9e4bf1dcb0423c134cd4d030ca6";
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=en";
            try
            {
                var response = await client.GetStringAsync(url);
                JObject weatherData = JObject.Parse(response);
                string description = (string)weatherData["weather"][0]["description"];
                double temperature = (double)weatherData["main"]["temp"];
                double tempMin = (double)weatherData["main"]["temp_min"];
                double tempMax = (double)weatherData["main"]["temp_max"];
                MessageBox.Show($"Погода в {city}: {description}");
                MessageBox.Show($"Температура: {temperature}°C");
                MessageBox.Show($"Минимальная температура: {tempMin}°C");
                MessageBox.Show($"Максимальная температура: {tempMax}°C");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
        }

        public static async Task GetRiddleAndTranslate()
        {
            try
            {
                var riddleResponse = await new HttpClient().GetStringAsync("https://riddles-api.vercel.app/random");
                var riddleData = JObject.Parse(riddleResponse);
                string riddle = riddleData["riddle"].ToString();
                string answer = riddleData["answer"].ToString();
                MessageBox.Show($"Загадка:{riddle}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void questionBtn_Click(object sender, EventArgs e)
        {
            GetRiddleAndTranslate();
        }

        private void funnyBtn_Click(object sender, EventArgs e)
        {
            GetRandomAnecdote();
        }

        private async Task GetRandomAnecdote()
        {
            string url = "http://shortiki.com/export/api.php?format=json&type=random&amount=1";

            try
            {
                string response = await client.GetStringAsync(url);
                dynamic jsonData = JsonConvert.DeserializeObject(response);
                foreach (var item in jsonData)
                {
                    string content = item.content;
                    MessageBox.Show(content);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запросе к API: {ex.Message}");
            }
        }

        private void howBtn_Click(object sender, EventArgs e)
        {
            ClearMemoryCache();
            startBtn.Visible = true;
            howBtn.Visible = false;
            nameTxt.Visible = true;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string executablePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = Path.Combine(executablePath, "text.txt");
            GetNationality(nameTxt.Text);
            startBtn.Visible = false;
            howBtn.Visible = true;
            nameTxt.Visible = false;
            DeleteFile(file);
        }
        private async Task GetNationality(string name)
        {
            string url = $"https://api.genderize.io/?name={name}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var genderizeResponse = JsonConvert.DeserializeObject<GenderizeResponse>(responseBody);

                MessageBox.Show($"Имя: {genderizeResponse.Name}" +
                    $"\nПол: {genderizeResponse.Gender}" +
                    $"\nВероятность: {genderizeResponse.Probability}" +
                    $"\nКоличество: {genderizeResponse.Count}");
                CreateFile(@"C:/text.txt");
                WriteToFile(@"C:/text.txt", responseBody);
                string message = ReadFromFile(@"C:/text.txt");
                DatabaseInsert(message, responseBody);
            }
            else
            {
                Console.WriteLine("Failed to retrieve data");
            }
        }
        public void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
        }

        public void WriteToFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }

        public string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
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
    }
    public class GenderizeResponse
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Probability { get; set; }
        public int Count { get; set; }
    }
}
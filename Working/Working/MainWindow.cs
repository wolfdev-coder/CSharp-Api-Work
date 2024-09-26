using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Working
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static HttpClient client = new HttpClient();

        private static TelegramBotClient Bot;
        public static SQLiteConnection DB = new SQLiteConnection(Database.connectionString);
        private void newsBtn_Click(object sender, EventArgs e)
        {
            DatabaseInsert("Нажата кнопка Новости", LoginWindow.userName);
            this.Close();
            Thread openForm = new Thread(MainOpen);
            openForm.Start();
        }

        private void MainOpen(object? obj)
        {
            Application.Run(new NewsWindow());
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DatabaseInsert("Нажата кнопка Выхода", LoginWindow.userName);
            this.Close();
            Thread openForm = new Thread(LoginOpen);
            openForm.Start();
        }


        private void LoginOpen(object? obj)
        {
            Application.Run(new LoginWindow());
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

        private void adminAdd_Click(object sender, EventArgs e)
        {
            stopBot.Visible = true;
            adminAdd.Enabled = false;
            DatabaseInsert("Нажал на старт бота", LoginWindow.userName);
            TelegramBot();
        }

        [Obsolete]
        public static void TelegramBot()
        {
            Bot = new TelegramBotClient("6770920668:AAEbdzi4wO1V1GNDEBeb-jvkhO2EuHqBsn0");
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
        }
        [Obsolete]
        private static async void Bot_OnMessage(object? sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            try
            {
                var message = e.Message;
                Console.WriteLine($"{message.From.Username} ({message.From.Id}) >> {message.Text}\n");
                var starostaBtn = new ReplyKeyboardMarkup
                {
                    Keyboard = new[]
                    {
                    new []
                    {
                        new KeyboardButton("Информация"),
                        new KeyboardButton("Новости"),
                        new KeyboardButton("Мем"),
                        new KeyboardButton("Гороскоп"),
                    },
                    new []
                    {
                        new KeyboardButton("Анекдот от бота"),
                        new KeyboardButton("Очистить память приложения")
                    }
                },
                    ResizeKeyboard = true
                };
                var astrologyBtns = new ReplyKeyboardMarkup
                {
                    Keyboard = new[]
    {
                    new []
                    {
                        new KeyboardButton("Стрелец"),
                        new KeyboardButton("Овен"),
                        new KeyboardButton("Лев"),
                        new KeyboardButton("Телец")
                    },
                    new []
                    {
                        new KeyboardButton("Водолей"),
                        new KeyboardButton("Весы"),
                        new KeyboardButton("Близнецы")
                    }
                },
                    ResizeKeyboard = true
                };
                switch (message.Text)
                {
                    case "Информация":
                        Bot.SendTextMessageAsync(message.From.Id, "Я бот, который выполняет функции по приколу, Ну в общем, надеюсь вам понравится", replyMarkup: starostaBtn);
                        break;
                    case "Новости":
                        SQLiteCommand command = new SQLiteCommand("SELECT content " +
                            "FROM News", DB);
                        SQLiteDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string content = reader["content"].ToString();
                                Bot.SendTextMessageAsync(message.From.Id, "Новость:\n" + content, replyMarkup: starostaBtn);
                            }
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(message.From.Id, "Новостей кажется пока нету(", replyMarkup: starostaBtn);

                        }
                        break;
                    case "Мем":
                        string meme = await GetMeme();
                        Bot.SendTextMessageAsync(message.From.Id, "Мем:\n" + meme, replyMarkup: starostaBtn);
                        break;
                    case "Гороскоп":
                        Bot.SendTextMessageAsync(message.From.Id, "Выберите свой знак зодиака:", replyMarkup: astrologyBtns);
                        break;
                    case "Анекдот от бота":
                        string anecdote = await GetRandomAnecdote();
                        Bot.SendTextMessageAsync(message.From.Id, anecdote, replyMarkup:starostaBtn);
                        break;
                    case "Очистить память приложения":
                        Bot.SendTextMessageAsync(message.From.Id, "Начинаю очистку...", replyMarkup: starostaBtn);
                        ClearMemoryCache();
                        Bot.SendTextMessageAsync(message.From.Id, "Очистка успешна!", replyMarkup: starostaBtn);
                        break;
                }
                if (message.Text.StartsWith("Стрелец"))
                {
                    string zodiak = "Sagittarius";
                    string response = await GetHoroscope(zodiak);
                    Bot.SendTextMessageAsync(message.From.Id, "Ваш гороскоп:\n" +  response, replyMarkup: starostaBtn);
                }
                if (message.Text.StartsWith("Овен"))
                {
                    string zodiak = "Aries";
                    string response = await GetHoroscope(zodiak);
                    Bot.SendTextMessageAsync(message.From.Id, "Ваш гороскоп:\n" + response, replyMarkup: starostaBtn);
                }
                if (message.Text.StartsWith("Лев"))
                {
                    string zodiak = "Leo";
                    string response = await GetHoroscope(zodiak);
                    Bot.SendTextMessageAsync(message.From.Id, "Ваш гороскоп:\n" + response, replyMarkup: starostaBtn);
                }
                if (message.Text.StartsWith("Телец"))
                {
                    string zodiak = "Taurus";
                    string response = await GetHoroscope(zodiak);
                    Bot.SendTextMessageAsync(message.From.Id, "Ваш гороскоп:\n" + response, replyMarkup: starostaBtn);
                }
                if (message.Text.StartsWith("Водолей"))
                {
                    string zodiak = "Aquarius";
                    string response = await GetHoroscope(zodiak);
                    Bot.SendTextMessageAsync(message.From.Id, "Ваш гороскоп:\n" + response, replyMarkup: starostaBtn);
                }
                if (message.Text.StartsWith("Весы"))
                {
                    string zodiak = "Libra";
                    string response = await GetHoroscope(zodiak);
                    Bot.SendTextMessageAsync(message.From.Id, "Ваш гороскоп:\n" + response, replyMarkup: starostaBtn);
                }
                if (message.Text.StartsWith("Близнецы"))
                {
                    string zodiak = "Gemini";
                    string response = await GetHoroscope(zodiak);
                    Bot.SendTextMessageAsync(message.From.Id, "Ваш гороскоп:\n" + response, replyMarkup: starostaBtn);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        static async Task<string> GetHoroscope(string sign)
        {
            string url = $"https://horoscope-app-api.vercel.app/api/v1/get-horoscope/daily?sign={sign}&day=TODAY";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        static async Task<string> GetMeme()
        {
            string url = "https://api.apileague.com/retrieve-random-meme?keywords=rocket";
            string apiKey = "e1a083ce5f414a79a71e157a8fa34ea5";
            try
            {
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                ImageData imageData = JsonConvert.DeserializeObject<ImageData>(responseBody);
                string imageUrl = imageData.Url;
                return imageUrl;
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }

        private void stopBot_Click(object sender, EventArgs e)
        {
            Bot.StopReceiving();
            stopBot.Visible = false;
            adminAdd.Enabled = true;
        }
        static async Task<string> GetRandomAnecdote()
        {
            string content = "Неизвесно";
            string url = "http://shortiki.com/export/api.php?format=json&type=random&amount=1";
            try
            {
                string response = await client.GetStringAsync(url);
                dynamic jsonData = JsonConvert.DeserializeObject(response);
                foreach (var item in jsonData)
                {
                    content = item.content;
                }
                return content;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запросе к API: {ex.Message}");
                return ex.Message;
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
    public class ImageData
    {
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Ratio { get; set; }
    }
}
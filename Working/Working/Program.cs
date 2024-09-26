using System.Data.SQLite;

namespace Working
{
    internal static class Program
    {
        public static SQLiteConnection DB = new SQLiteConnection(Database.connectionString);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB.Open();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new NewsWindow());
            string executablePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = Path.Combine(executablePath, "database.db");

            if (!File.Exists(file))
            {
                File.Create(file);
                DatabaseInsert("Вход в приложение", "Неизвестный пользователь");

            }
        }
        public static void DatabaseInsert(string log, string name)
        {
            if (DB.State == System.Data.ConnectionState.Closed)
            {
                DB.Open();
            }
            string time = ActionTime();
            string querry = "INSERT INTO Log (name, logMessage, time) VALUES (@name, @logMessage, @time)";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(querry, DB);
            sQLiteCommand.Parameters.AddWithValue("@name", name);
            sQLiteCommand.Parameters.AddWithValue("@logMessage", log);
            sQLiteCommand.Parameters.AddWithValue("@time", time);
            sQLiteCommand.ExecuteNonQuery();
        }
        public static string ActionTime()
        {
            DateTime dateTime = DateTime.Now;

            string time = dateTime.ToString("dd:MM:yyyyy | HH:mm:ss");
            return time;
        }
    }
    class Database
    {
        public static string connectionString = @"Data Source=database.db;";
    }
    public class Riddle
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
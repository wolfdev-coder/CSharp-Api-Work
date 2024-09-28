using System;
using System.Collections.Generic;
using System.Text;

public class Cipher
{
    private Dictionary<string, string> _encryptionMap;
    private Dictionary<string, string> _decryptionMap;

    public Cipher(Dictionary<string, string> mapping)
    {
        _encryptionMap = mapping;
        _decryptionMap = new Dictionary<string, string>();

        // Объединяем дубликаты ключей в mapping
        var groupedMapping = mapping.GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.First().Value);

        // Создаем обратную карту для расшифровки
        foreach (var pair in groupedMapping)
        {
            _decryptionMap.Add(pair.Value, pair.Key);
        }
    }


    public string Encrypt(string input)
    {
        StringBuilder encrypted = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            // Проверяем наличие пары символов
            if (i + 1 < input.Length)
            {
                string pair = input.Substring(i, 2);

                // Если пара найдена в карте шифрования, заменяем ее
                if (_encryptionMap.TryGetValue(pair, out string value))
                {
                    encrypted.Append(value);
                    i += 2; // Пропускаем два символа
                    continue;
                }
            }

            // Если пара не найдена, добавляем текущий символ как есть
            encrypted.Append(input[i]);
            i++;
        }

        return encrypted.ToString();
    }

    public string Decrypt(string input)
    {
        StringBuilder decrypted = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            // Проверяем, есть ли текущий символ в карте расшифровки
            if (i + 1 < input.Length && _decryptionMap.TryGetValue(input.Substring(i, 2), out string pair))
            {
                decrypted.Append(pair);
                i += 2; // Пропускаем два символа
                continue;
            }

            // Если не найден, добавляем как есть
            decrypted.Append(input[i]);
            i++;
        }

        return decrypted.ToString();
    }
}

class Program
{
    static void Main()
    {
        // Определяем отображение для шифрования
        var mapping = new Dictionary<string, string>
        {
            { "аа", "жж" },
            { "аб", "ба" },
            { "ав", "ва" },
            { "ад", "да" },
            { "аг", "га" },
            { "ае", "еа" },
            { "аж", "жа" },
            { "ба", "аб" },
            { "бб", "гг" },
            { "бв", "вб" },
            { "бд", "дб" },
            { "бг", "гб" },
            { "бе", "еб" },
            { "бж", "жб" },
            { "ва", "ав" },
            { "вб", "бв" },
            { "вв", "бб" },
            { "вд", "дв" },
            { "вг", "гв" },
            { "ве", "ев" },
            { "вж", "жв" },
            { "да", "ад" },
            { "дб", "бд" },
            { "дв", "вд" },
            { "дд", "ее" },
            { "дг", "гд" },
            { "де", "ед" },
            { "дж", "жд" },
            { "га", "аг" },
            { "гб", "бг" },
            { "гв", "вг" },
            { "гд", "дк" },
            { "гг", "гк" },
            { "ге", "ег" },
            { "гж", "жг" },
            { "еа", "ае" },
            { "еб", "бе" },
            { "ев", "ве" },
            { "ед", "де" },
            { "ег", "ге" },
            { "ее", "дд" },
            { "еж", "же" },
            { "жа", "аж" },
            { "жб", "бж" },
            { "жв", "вж" },
            { "жд", "дж" },
            { "жг", "гж" },
            { "же", "еж" },
            { "жж", "аа" }
        };

        Cipher cipher = new Cipher(mapping);

        // Пример текста для шифрования
        Console.WriteLine("Введите текст для шифрования:");
        string textToEncrypt = Console.ReadLine();

        Console.WriteLine($"Текст для шифрования: {textToEncrypt}");

        string encryptedText = cipher.Encrypt(textToEncrypt);

        Console.WriteLine($"Зашифрованный текст: {encryptedText}");

        Console.WriteLine("Введите текст для расшифровки:");

        string textEnc = Console.ReadLine();

        string decryptedText = cipher.Decrypt(textEnc);

        Console.WriteLine($"Расшифрованный текст: {decryptedText}");
    }
}
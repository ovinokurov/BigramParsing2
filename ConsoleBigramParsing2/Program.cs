using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleBigramParsing2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = "../../../TextFiles/TextFile1.txt";

            if (File.Exists(path))
            {
                var service = new HistogramService();
                try
                {
                    var results = service.ProcessFile(path);

                    foreach (var model in results)
                    {
                        Console.WriteLine($"\"{model.Key}\" \t : {model.Value}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine($"ERROR: File does not exist at {path}");
            }
            Console.ReadLine();
        }
    }
    public class HistogramService
    {
        public Dictionary<string, int> ProcessFile(string path)
        {
            var dictionaryHistogram = new Dictionary<string, int>();

            if (!File.Exists(path)) return dictionaryHistogram;

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var buffered = new BufferedStream(stream))
            using (var reader = new StreamReader(buffered))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var words = RemoveNonLetters(line).ToLower().Split(' ');

                    for (var i = 0; i < words.Length - 1; i++)
                    {
                        var phrase = $"{words[i]} {words[i + 1]}";

                        var ext = dictionaryHistogram.FirstOrDefault(r => r.Key == phrase);

                        if (ext.Value > 0)
                        {
                            dictionaryHistogram[phrase] = ext.Value + 1;
                        }
                        else
                        {
                            dictionaryHistogram.Add(phrase, 1);
                        }
                    }
                }
            }

            return dictionaryHistogram;
        }

        private static string RemoveNonLetters(string input)
        {
            return Regex.Replace(input, "[^A-Za-z0-9 ]", "");
        }
    }
}

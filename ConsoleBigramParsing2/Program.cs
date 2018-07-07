using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


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
    
}

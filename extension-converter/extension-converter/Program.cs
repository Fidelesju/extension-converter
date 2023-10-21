using System;
using System.IO;
using System.Threading;

class Program
{
    static string input_directory = "input_directory";
    static string output_directory = "output_directory";

    static void Main(string[] args)
    {
        if (!Directory.Exists(input_directory) || !Directory.Exists(output_directory))
        {
            Directory.CreateDirectory(input_directory);
            Directory.CreateDirectory(output_directory);
        }

        Thread thread = new Thread(ChangeExtension);
        thread.Start();

    }

    static void ChangeExtension()
    {
        while (true)
        {
            var input_files = Directory.EnumerateFiles(input_directory);

            Console.WriteLine("Digite o número da nova extensão desejada:");
            Console.WriteLine("Lista de extensões:");
            Console.WriteLine("1 - png");
            Console.WriteLine("2 - jpg");
            Console.WriteLine("3 - gif");
            Console.WriteLine("4 - tiff");

            string newExtensionChoice = Console.ReadLine();
            string newExtension = "";

            switch (newExtensionChoice)
            {
                case "1":
                    newExtension = ".png";
                    break;
                case "2":
                    newExtension = ".jpg";
                    break;
                case "3":
                    newExtension = ".gif";
                    break;
                case "4":
                    newExtension = ".tiff";
                    break;
                default:
                    Console.WriteLine("Extensão inválida. Nenhuma mudança será feita.");
                    break;
            }

            if (!string.IsNullOrEmpty(newExtension))
            {
                foreach (var item in input_files)
                {
                    FileInfo fileInfo = new FileInfo(item);
                    string newFileName = Path.ChangeExtension(Path.Combine(output_directory, fileInfo.Name), newExtension);
                    File.Move(item, newFileName);
                }
            }

            Thread.Sleep(new TimeSpan(0, 0, 5));
        }
    }
}

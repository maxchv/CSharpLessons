using System;
using System.IO;
using System.Text;

namespace Lesson12
{
    class Program
    {
        static void Main(string[] args)
        {
            // WriteFileDemo();
            // ReadFileDemo();
            // FileSizeDemo();
            // UsingDemo();
            // StreamReaderDemo();
            using var writer = new StreamWriter(new FileStream("hello.txt", FileMode.Create));
            writer.WriteLine("Hello World");
        }

        private static void StreamReaderDemo()
        {
            using Stream stream = new FileStream("book.txt", FileMode.Open);
            using StreamReader reader = new StreamReader(stream);
            string allBook = reader.ReadToEnd();
            Console.WriteLine($"Lines: {allBook.Split("\n", StringSplitOptions.RemoveEmptyEntries).Length}");
            Console.WriteLine($"Words: {allBook.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length}");
        }

        private static void UsingDemo()
        {
            // using -> try{ ... } finally{ stream.Dispose(); }
            using (Stream stream = new FileStream("book.txt", FileMode.Open))
            {
                // ...
                Console.WriteLine("Read the book");
                Console.WriteLine("Length: " + stream.Length);
            }

            using Stream steam2 = new FileStream("hello.txt", FileMode.Open);
            Console.WriteLine(steam2.Length);
        }

        private static void FileSizeDemo()
        {
            Stream stream = new FileStream("hello.txt", FileMode.Open);
            Console.WriteLine($"After open file Position: ${stream.Position}");
            stream.Seek(0, SeekOrigin.End); // переместиться в конец файла
            long fileSize = stream.Position;
            Console.WriteLine($"Position: {stream.Position}");
            stream.Seek(0, SeekOrigin.Begin); // переместиться в начало файла
            stream.Dispose();
        }

        private static void ReadFileDemo()
        {
            Stream stream = new FileStream("hello.txt", FileMode.Open);
            byte[] buff = new byte[256];
            int count = stream.Read(buff, 0, buff.Length);
            string message = Encoding.UTF8.GetString(buff, 0, count);
            Console.WriteLine(message);
            stream.Close();
        }

        private static void WriteFileDemo()
        {
            Stream stream = new FileStream("hello.txt", FileMode.Create, FileAccess.Write);
            byte[] buff;
            Console.Write("Введите сообщение: ");
            string line = Console.ReadLine();
            buff = Encoding.UTF8.GetBytes(line);
            stream.Write(buff);
            stream.Close();
        }
    }
}
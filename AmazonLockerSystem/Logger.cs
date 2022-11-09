using System;

namespace AmazonLockerSystem

{
    public static class Logger
    {
        public static void Trace(string v)
        {
            Console.WriteLine($"[{DateTime.Now}] {v}\n");
        }

        public static void Info(string v)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now}] {v}\n");
            Console.ResetColor();
        }

        public static void Warn(string v)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[{DateTime.Now}] {v}\n");
            Console.ResetColor();
        }

        public static void Error(string v)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"[{DateTime.Now}] {v}\n");
            Console.ResetColor();
        }
    }
}

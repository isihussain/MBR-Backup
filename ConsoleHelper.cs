namespace MBRCopy
{
    using System;

    public static class ConsoleHelper
    {
        public static void WriteLineWithColor(ConsoleColor color, string Text)
        {
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(Text);
                Console.ResetColor();
            }
            catch { }
        }
        public static void WriteWithOutLine(ConsoleColor color, string Text)
        {
            try
            {
                Console.ForegroundColor = color;
                Console.Write(Text);
                Console.ResetColor();
            }
            catch { }
        }
    }
}
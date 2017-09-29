using System;
using System.IO;
using System.Text;

namespace Model
{
	public static class Log
	{
        private static readonly ILog globalLog = new NLogAdapter();

        public static void Warning(string message)
        {
            globalLog.Warning(message);
#if CONSOLE_LOG
            ConsoleLog(ConsoleColor.Yellow, message);
#endif
        }

        public static void Info(string message)
        {
            globalLog.Info(message);
#if CONSOLE_LOG
            ConsoleLog(ConsoleColor.DarkGreen, message);
#endif
        }

        public static void Debug(string message)
        {
            globalLog.Debug(message);
#if CONSOLE_LOG
            ConsoleLog(ConsoleColor.White, message);
#endif
        }

        public static void Error(string message)
        {
            globalLog.Error(message);
#if CONSOLE_LOG
            ConsoleLog(ConsoleColor.Red, message);
#endif
        }

#if CONSOLE_LOG
        private static void ConsoleLog(ConsoleColor color, string msg)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss")}]  {msg}");
            Console.ResetColor();

        }
#endif
    }
}
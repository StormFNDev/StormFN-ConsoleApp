using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    class Storm
    {
        public static void WriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("STORM");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("] " + message + "\n");
        }

        public static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("] " + message/*+ "\n"*/);
        }
        public static void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("STORM");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("] " + message);
        }
    }
}

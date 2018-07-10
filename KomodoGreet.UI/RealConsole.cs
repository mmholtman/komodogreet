using System;
using System.Diagnostics.CodeAnalysis;
using KomodoGreet.Contracts;

namespace KomodoGreet.UI
{
    [ExcludeFromCodeCoverage]
    public class RealConsole : IConsole
    {
        
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
        public void Write(string message)
        {
            System.Console.Write(message);
        }
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
        public void WriteLine(Object o)
        {
            System.Console.WriteLine(o.ToString());
        }
    }
}
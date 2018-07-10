using System;

namespace KomodoGreet.Contracts
{
    public interface IConsole
    {
        void WriteLine(string message);
        void Write(string message);
        string ReadLine();
        void WriteLine(Object o);
    }
}
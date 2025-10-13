using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    sealed internal class ConsoleOutput : IOutput
    {
        public void ShowOutput(string message)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(message);
            Console.WriteLine(message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInDotnetC_t12
{
    public class Car(string name, string model, int year)
    {
        public void ShowInfo()
        {
            Console.WriteLine($"Car:{name} {model} {year}");
        }
    }
}

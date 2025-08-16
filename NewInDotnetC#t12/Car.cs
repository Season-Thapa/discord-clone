using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInDotnetC_t12
{
    public class Car(string name, string model, int year)
    {
        // With primary constructors, we don't need to write a separate constructor method. It's shorter and cleaner than the old way.
        // this way would reduce boilerplate codes and save more time for creating classes of entities and services on almost all of my past projects.
        public void ShowInfo()
        {
            Console.WriteLine($"Car:{name} {model} {year}");
        }
    }
}

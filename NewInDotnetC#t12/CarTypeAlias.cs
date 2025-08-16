using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSpecs = (string name, string model, int year);
namespace NewInDotnetC_t12
{
    // We can now create an alias for any type, including tuples.
    // This reduces repetitive type declarations and makes code shorter and clearer,
    // which would have simplified code in past projects where I reused complex tuple types frequently.
    public class CarTypeAlias
    {
        public static void Run()
        {
            List<CarSpecs> carsSpecsList = new List<CarSpecs>
            {
                ("Ford", "Mustang", 2024),
                ("Ferrari", "Spider", 1990),
                ("BMW", "M5", 2022)
            };
            List<Car> cars = new List<Car>();
            foreach (var specs in carsSpecsList)
            {
                cars.Add(new Car(specs.name, specs.model, specs.year));
            }
            foreach (var car in cars)
            {
                car.ShowInfo();
            }
        }
    }
}

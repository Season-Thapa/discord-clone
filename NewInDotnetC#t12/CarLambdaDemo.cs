using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInDotnetC_t12
{
    public class CarLambdaDemo
    {
        public static void Run()
        {
            var myCar1 = new Car("Tesla", "Model 3", 2023);
            var myCar2 = new Car("BMW", "M5", 2022);

            var EstimateRental = (Car car,int days = 1) =>
            {
                decimal basePrice = 50m; 
                decimal total = basePrice * days;
                return total;
            };

            Console.WriteLine($"${EstimateRental(myCar1, 3)}"); 
            Console.WriteLine($"${EstimateRental(myCar2)}");

        }
    }

}

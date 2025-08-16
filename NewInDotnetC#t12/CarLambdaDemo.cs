using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInDotnetC_t12
{
    public class CarLambdaDemo
    {
        // We can now set default values directly in lambda parameters.
        // This reduces the need for method overloads for optional parameters, 
        // which would have simplified code in past projects.
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

            Console.WriteLine($"${EstimateRental(myCar1, 3)}"); // 3 days
            Console.WriteLine($"${EstimateRental(myCar2)}");// default 1 day

        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInDotnetC_t12
{
    public class CarCollection
    {
        // Collection expressions let us create lists with [] instead of new List<> { }.
        // spread operator makes it easy to combine lists without needing of writing loops
        // this way make the codes more cleaner and shorter than the old version
        //In past projects, I often merged lists of objects manually this would have saved a lot of time
        public static void ShowCarsCollection()
        {
            List<Car> sedans = [new Car("Bmw", "m3", 2020), new Car("Honda", "Civic", 2025)];
            List<Car> suvs = [new Car("Ford", "Explorer", 2022), new Car("Toyota", "RAV4", 2023), new Car("Mazda", "Cx5", 2021)];

            List<Car> allCars = [..sedans, ..suvs];
            foreach (Car car in allCars)
            {
                car.ShowInfo();
            }
        }
    }
}

using Business.Concrete;

using DataAccess.Concrete;

using Entities.Concrete;

using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            
            carManager.Add(new Car { CarId = 6, BrandId = 6, ColorId = 2, ModelYear = 2016, DailyPrice = 150000, Description = "Audi" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Arabanın ID : {0}",car.CarId);
                Console.WriteLine("Arabanın Markası : {0}",car.BrandName);
                Console.WriteLine("Arabanın Rengi : {0}",car.ColorName);
                Console.WriteLine("Arabanın Üretim Yılı : {0}",car.ModelYear);
                Console.WriteLine("Arabanın Ücreti : {0}",car.DailyPrice);
                Console.WriteLine("Arabanın Açıklaması : {0}",car.Description);
                Console.WriteLine("----------------------------------");
            }



        }
    }
}

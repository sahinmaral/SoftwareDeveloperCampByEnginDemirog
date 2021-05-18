using System;
using System.Collections.Generic;
using System.Drawing;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCarCrudFunctions();
            //GetBrandCrudFunctions();
            //GetColourCrudFunctions();
            //GetCarDetails();
            //RentalTest();
        }

        private static void RentalTest()
        {
            Rental rental1 = new Rental()
            {
                CarId = 3,
                CustomerId = 3,
                RentDate = new DateTime(2021, 05, 14),
                ReturnDate = new DateTime(2021, 05, 30)
            };

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Update(rental1);
            if (!result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(
                        "Car Id : {0} / Brand Name : {1} / Car Name : {2} / Color Name : {3} / Daily Price : {4}",
                        car.CarId, car.BrandName, car.CarName, car.ColourName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void GetColourCrudFunctions()
        {
            ColourManager colourManager = new ColourManager(new EfColourDal());

            //Inserting colour : Working 
            colourManager.Insert(new Colour {ColourName = "Fuşya"});

            //Updating colour : Working
            Colour updatedColour = colourManager.GetById(24).Data;
            updatedColour.ColourName = "Fuchsia";
            colourManager.Update(updatedColour);

            //Deleting colour : Working
            Colour deletedColor = colourManager.GetById(16).Data;
            colourManager.Delete(deletedColor);

            var result = colourManager.GetAll();
            if (result.Success)
            {
                foreach (var colour in colourManager.GetAll().Data)
                {
                    Console.WriteLine("Colour name : {0}", colour.ColourName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void GetBrandCrudFunctions()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Inserting brand : Working 
            brandManager.Insert(new Brand { BrandName = "Ford" });

            //Updating brand : Working
            Brand updatedBrand = brandManager.GetById(15).Data;
            updatedBrand.BrandName = "Mitsubishi";
            brandManager.Update(updatedBrand);

            //Deleting brand : Working
            Brand deletedBrand = brandManager.GetById(15).Data;
            brandManager.Delete(deletedBrand);

            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine("Brand name : {0}", brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void GetCarCrudFunctions()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Inserting car : Working 
            carManager.Insert(new Car { BrandId = 8 , CarName = "Megan" , DailyPrice = 450 , ColourId = 9 , ModelYear = 2015 , Description = "Güzel araba"});

            ////Updating car : Working
            Car searchedCar = carManager.GetById(7).Data;
            searchedCar.ColourId = 5;
            carManager.Update(searchedCar);

            ////Deleting car : Working
            Car deletedCar = carManager.GetById(7).Data;
            carManager.Delete(deletedCar);

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(
                        "Car Id : {0} / Brand Name : {1} / Car Name : {2} / Color Name : {3} / Daily Price : {4}",
                        car.CarId, car.BrandName, car.CarName, car.ColourName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

    }
}

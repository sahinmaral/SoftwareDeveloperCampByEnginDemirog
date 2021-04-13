using GameProject.Concrete;
using GameProject.Entities;
using System;
using System.Collections.Generic;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancing games
            GameLibrary game1 = new GameLibrary() { Id = 1, Name = "CS:GO", Price = 35 };
            GameLibrary game2 = new GameLibrary() { Id = 2, Name = "Grand Theft Auto 5", Price = 105 };
            GameLibrary game3 = new GameLibrary() { Id = 3, Name = "Payday 2", Price = 35 };

            //Instancing discounts
            Discount discount1 = new Discount() { Id = 1, Name = "Black Friday", DiscountValue = 30 };
            Discount discount2 = new Discount() { Id = 2, Name = "Welcome Christmas", DiscountValue = 40 };
            Discount discount3 = new Discount() { Id = 3, Name = "Summer Days", DiscountValue = 20 };

            //Adding discounts
            DiscountManager discountManager = new DiscountManager();
            Discount discount4 = new Discount() { Id = 4, DiscountValue = 20, Name = "Thanksgiving day" };
            discountManager.AddDiscount(discount1);
            discountManager.AddDiscount(discount2);
            discountManager.AddDiscount(discount3);
            discountManager.AddDiscount(discount4);
            discountManager.DeleteDiscount(discount4);
            discountManager.AddDiscount(discount4);
            discountManager.UpdateDiscount(discount4, 15);
            discountManager.RetrieveDiscountList();

            GameLibraryManager gameLibraryManager = new GameLibraryManager();
            gameLibraryManager.AddGame(game1);
            gameLibraryManager.AddGame(game2);
            gameLibraryManager.AddGame(game3);
            gameLibraryManager.RetrieveGameLibraryList();


            Customer customer1 = new Customer()
            {
                Id = 1,
                Name = "Şahin",
                Surname = "Maral",
                DateOfBirth = new DateTime(2000, 02, 11),
                NationalityId = "31241146608",
                Username = "log060"
            };

            CustomerManager customerManager = new CustomerManager();
            customerManager.AddCustomer(customer1);

            TransactionManager transaction1 = new TransactionManager();
            transaction1.AddItemInBasket(customer1, game1, discount1);
            transaction1.AddItemInBasket(customer1, game2, discount2);
            transaction1.RemoveItemInBasket(customer1, game2, discount2);

            transaction1.RetrieveCart(customer1);


        }
    }
}

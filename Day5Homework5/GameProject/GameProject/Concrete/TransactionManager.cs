using GameProject.Entities;

using System;
using System.Collections.Generic;

namespace GameProject.Concrete
{
    class TransactionManager
    {
        List<Item> items;
        public TransactionManager()
        {
            items = new List<Item>();
        }
        public void AddItemInBasket(Customer customer, GameLibrary game, Discount discount)
        {
            game.Price = game.Price * (100 - discount.DiscountValue) / 100;
            Item item1 = new Item { CustomerUsername = customer.Username, GameName = game.Name, GamePrice = game.Price };
            items.Add(item1);
            Console.WriteLine("Your {0} game has been added in basket as {1} TL",game.Name, game.Price); 
        }

        public void RemoveItemInBasket(Customer customer, GameLibrary game, Discount discount)
        {
            game.Price = game.Price * (100 - discount.DiscountValue) / 100;
            Item item1 = new Item { CustomerUsername = customer.Username, GameName = game.Name, GamePrice = game.Price };
            items.Add(item1);
            Console.WriteLine("Your {0} game has been removed in basket ", game.Name);
        }

        public void RetrieveCart(Customer customer)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Account : {0}",customer.Username);
            int counter = 1;
            decimal totalprice = 0;
            foreach (var item in items)
            {
                Console.WriteLine("{0}-) Game : {1} Price : {2}",counter, item.GameName, item.GamePrice);
                totalprice += item.GamePrice;
                counter++;
            }
            Console.WriteLine("Total price : {0}", totalprice);
            Console.WriteLine("**********************************");
        }

        


    }
}

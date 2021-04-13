using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class DiscountManager
    {
        //Discount discount1 = new Discount() { Id = 1, Name = "Black Friday", DiscountValue = 30 };
        //Discount discount2 = new Discount() { Id = 2, Name = "Welcome Christmas", DiscountValue = 40 };
        //Discount discount3 = new Discount() { Id = 3, Name = "Summer Days", DiscountValue = 20 };

        List<Discount> discounts;

        public DiscountManager()
        {
            discounts = new List<Discount>();
        }
        public void AddDiscount(Discount discount)
        {
            discounts.Add(discount);
            Console.WriteLine("Discount of {0} added",discount.Name);
        }

        public void DeleteDiscount(Discount discount)
        {
            discounts.Remove(discount);
            Console.WriteLine("Discount of {0} deleted", discount.Name);
        }
        
        
        public void RetrieveDiscountList()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Discounts\n");
            foreach (var discount in discounts)
            {
                Console.WriteLine("Discount Name : " + discount.Name);
                Console.WriteLine("Discount Value : " + discount.DiscountValue+"%");
            }
            Console.WriteLine("**********************************");
        }

        public void UpdateDiscount(Discount discount , int value)
        {
            discount.DiscountValue = value;
            Console.WriteLine("Discount of {0}'s value is {1}",discount.Name,discount.DiscountValue);
        }


    }
}

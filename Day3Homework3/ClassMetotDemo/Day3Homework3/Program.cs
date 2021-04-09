using System;

namespace Day3Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Customer customer3 = new Customer();

            customer1.CustomerId = 1;
            customer1.CustomerName = "Şahin";
            customer1.CustomerBalance = 10000;            
            customer1.CustomerAccountId = 1320;

            customer2.CustomerId = 2;
            customer2.CustomerName = "Mehmet";
            customer2.CustomerBalance = 30000;
            customer2.CustomerAccountId = 540;

            customer3.CustomerId = 3;
            customer3.CustomerName = "Ayşe";
            customer3.CustomerBalance = 20000;
            customer3.CustomerAccountId = 50;
            */

            Customer customer1 = new Customer { CustomerId = 1, CustomerName = "Ayşe", CustomerBalance = 20000, CustomerAccountId = 50 };

            Customer customer2 = new Customer { CustomerId = 2, CustomerName = "Veli", CustomerBalance = 20000, CustomerAccountId = 1653 };

            Customer customer3 = new Customer { CustomerId = 3, CustomerName = "Şahin", CustomerBalance = 20000, CustomerAccountId = 85342 };

            Customer customer4 = new Customer { CustomerId = 4, CustomerName = "Mehmet", CustomerBalance = 60000, CustomerAccountId = 8543 };

            Customer[] customers = new Customer[] { customer1, customer2, customer3,customer4 };

            CustomerManager customerManager = new CustomerManager();

            customerManager.GetAllCustomers(customers);

            customerManager.AddCustomer(customer1);
            customerManager.DeleteCustomer(customer4);



        }
    }
}

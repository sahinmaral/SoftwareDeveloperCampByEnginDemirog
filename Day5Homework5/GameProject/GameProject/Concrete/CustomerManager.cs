using GameProject.Adapter;
using GameProject.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class CustomerManager
    {

        List<Customer> customers;

        public CustomerManager()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            MernisServiceAdapter adapter = new MernisServiceAdapter();
            if (adapter.CheckIfRealPerson(customer))
            {
                customers.Add(customer);
                Console.WriteLine("Account of {0} added",customer.Username);
            }
            else
            {
                throw new Exception("Not a valid person");
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer);
            Console.WriteLine("Account of {0} removed", customer.Username);
        }
        public void RetrieveGameLibraryList()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Games\n");

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer Username : " + customer.Username);
                Console.WriteLine("Customer Name : " + customer.Name);
                Console.WriteLine("Customer Surname : " + customer.Surname);
                Console.WriteLine("Customer DateOfBirth : " + customer.DateOfBirth);
                Console.WriteLine("Customer NationalityId : " + customer.NationalityId);
            }
            Console.WriteLine("**********************************");

        }
    }
}

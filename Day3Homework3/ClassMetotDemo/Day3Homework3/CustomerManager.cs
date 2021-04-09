using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Homework3
{
    class CustomerManager
    {

        public void AddCustomer(Customer customer)
        {
            Console.WriteLine("\n\nMÜŞTERİ EKLEME");
            Console.WriteLine("Müşteri Id : {0}", customer.CustomerId);
            Console.WriteLine("Müşteri Hesap Numarası : {0}", customer.CustomerAccountId);
            Console.WriteLine("Hesabı eklenmiştir");
            Console.WriteLine("--------------------------------");
        }

        public void DeleteCustomer(Customer customer)
        {
            Console.WriteLine("\n\nMÜŞTERİ SİLME");
            Console.WriteLine("Müşteri Id : {0}", customer.CustomerId);
            Console.WriteLine("Müşteri Hesap Numarası : {0}", customer.CustomerAccountId);
            Console.WriteLine("Hesabı silinmiştir");
            Console.WriteLine("--------------------------------");
        }

        public void GetAllCustomers(Customer[] customers)
        {
            Console.WriteLine("\n\nMÜŞTERİ LİSTESİ");
            Console.WriteLine("--------------------------------");
            foreach (var customer in customers)
            {
                Console.WriteLine("Müşteri Id : {0}", customer.CustomerId);
                Console.WriteLine("Müşteri Adı : {0}", customer.CustomerName);
                Console.WriteLine("Müşteri Bakiyesi : {0}", customer.CustomerBalance);
                Console.WriteLine("Müşteri Hesap Numarası : {0}", customer.CustomerAccountId);
                Console.WriteLine("--------------------------------");
            }
        }




    }
}

using System;

namespace MyDictionaryClass
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionaryClass<int, string> isimler = new MyDictionaryClass<int, string>();
            isimler.Add(150, "Şahin");
            isimler.Add(150, "Şahin");  //We will get error because same key has been already declared
            isimler.Add(151, "Ali");
            isimler.Add(152, "Batuhan");
            isimler.Add(153, "Mehmet");

            for (int i = 0; i < isimler.KeyLength; i++)
            {
                Console.WriteLine("{0} , {1}", isimler.Keys[i],isimler.Values[i]);
            }


        }
    }
}

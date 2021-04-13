using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string NationalityId { get; set; }
        public DateTime DateOfBirth { get; set; }   
    }
}

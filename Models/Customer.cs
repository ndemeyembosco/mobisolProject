using System;
using System.ComponentModel.DataAnnotations;

namespace mobisolProject.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName {get; set;}
        public string Phone {get; set;}
        public string Email { get; set; }
        public string Username {get; set;}
        
        [Key, DataType(DataType.Password)]
        public string Password {get; set;}
    }
}
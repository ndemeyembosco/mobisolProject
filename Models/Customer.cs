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
        [Key]
        public string Username {get; set;}
        public string Password {get; set;}
    }
}
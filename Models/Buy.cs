using System;

namespace mobisolProject.Models
{
    public class Buy
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
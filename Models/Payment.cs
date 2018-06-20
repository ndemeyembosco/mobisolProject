using System;

namespace mobisolProject.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string PayDate { get; set; }
        public int Amount { get; set; }
        public int SaleId { get; set; }
    }
}
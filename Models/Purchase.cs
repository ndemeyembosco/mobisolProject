using System;

namespace mobisolProject.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
    }
}
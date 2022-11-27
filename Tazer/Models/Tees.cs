using System;
using System.ComponentModel.DataAnnotations;




namespace Tazer.Models
{
    public class Tees
    {
        public int ID { get; set; }
        public string? Product { get; set; }
        public int Quantity { get; set; }
        public string? Brand { get; set; }
        public string Color { get; set; }
        public string Design { get; set; }
        public string Sizes { get; set; }
        public string Neckline { get; set; }
        public string Material { get; set; }
        public double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}

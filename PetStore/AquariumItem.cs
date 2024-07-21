using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class AquariumItem:InventoryItem
    {
        public int Capacity { get; set; }
        public string Shape { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: ${Price}, Quantity: {Quantity}");
            Console.WriteLine($"Capacity: {Capacity} gallons, Shape: {Shape}");
        }
    }
}

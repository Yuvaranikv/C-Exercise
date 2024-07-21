using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class AccessoryItem :InventoryItem
    {
        public string Size { get; set; }
        public string Color { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: ${Price}, Quantity: {Quantity}");
            Console.WriteLine($"Size: {Size}, Color: {Color}");
        }
    }
}

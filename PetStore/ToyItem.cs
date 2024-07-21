using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public  class ToyItem :InventoryItem
    {
        public string Material { get; set; }
        public int RecommendedAge { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: ${Price}, Quantity: {Quantity}");
            Console.WriteLine($"Material: {Material}, Recommended Age: {RecommendedAge} months");
        }
    }
}

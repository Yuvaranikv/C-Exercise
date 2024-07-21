using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class FoodItem :InventoryItem
    {
        public string Brand { get; set; }
        public FoodType FoodType { get; set; }
        public string AnimalType { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: ${Price}, Quantity: {Quantity}");
            Console.WriteLine($"Brand: {Brand}, Food Type: {FoodType}, Animal Type: {AnimalType}");
        }
    }
}

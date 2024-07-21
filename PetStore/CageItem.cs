﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class CageItem:InventoryItem
    {
        public string Dimensions { get; set; }
        public string Material { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: ${Price}, Quantity: {Quantity}");
            Console.WriteLine($"Dimensions: {Dimensions}, Material: {Material}");
        }
    }
}

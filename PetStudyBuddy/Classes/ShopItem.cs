// ShopItem.cs - Represents items that can be purchased with XP
// Demonstrates OOP concepts like encapsulation and factory methods

using System;

namespace PetStudyBuddy.Classes
{
    // ItemCategory enum - defines types of shop items
    // Using an enum ensures only valid categories can be assigned
    public enum ItemCategory
    {
        PetFood,
        PetToy,
        StudyTool,
        Decoration,
        Clothing
    }

    public class ShopItem
    {
        // --- PROPERTIES ---
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ItemCategory Category { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }

        // --- CONSTRUCTOR ---
        public ShopItem(string name, string description, int price, ItemCategory category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            IsAvailable = true;
            ImagePath = $"Resources/{category}/{name.ToLower()}.png";
        }

        // Override ToString for list display
        public override string ToString()
        {
            return $"{Name} - {Price} XP";
        }

        // --- FACTORY METHODS ---
        // Factory methods demonstrate the Factory Pattern - creating objects with specific configurations

        // Create a pet food item with default description
        public static ShopItem CreatePetFood(string name, int price)
        {
            return new ShopItem(name, "Nutritious food for your pet", price, ItemCategory.PetFood);
        }

        // Create a pet toy with default description
        public static ShopItem CreatePetToy(string name, int price)
        {
            return new ShopItem(name, "Fun toy to increase pet happiness", price, ItemCategory.PetToy);
        }

        // Create a study tool with default description
        public static ShopItem CreateStudyTool(string name, int price)
        {
            return new ShopItem(name, "Tool to help with studying", price, ItemCategory.StudyTool);
        }
    }
}
// User.cs - Core business class for user data and operations
// Contains the composition relationship between User and Pet, Tasks, ShopItems

using System;
using System.Collections.Generic;

namespace PetStudyBuddy.Classes
{
    public class User
    {
        // --- BASIC PROPERTIES ---
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfileIcon { get; set; }

        // XP has a private setter to enforce proper modification through methods only
        public int XP { get; private set; }
        public int Level { get; private set; }

        // --- COMPOSITION RELATIONSHIPS ---
        // User HAS-A Pet (not IS-A Pet) - demonstrates composition
        public Pet CurrentPet { get; set; }

        // User HAS-A collection of Tasks - demonstrates composition
        // Using List<T> allows for dynamic collection management with type safety
        public List<Task> Tasks { get; private set; }
        public List<Task> CompletedTasks { get; private set; }

        // User HAS-A collection of ShopItems - demonstrates composition
        public List<ShopItem> Inventory { get; private set; }

        // --- EVENTS FOR UI UPDATES ---
        // These events allow UI to be notified when data changes (Observer Pattern)
        public event Action<int>? OnLevelUp;
        public event Action<int>? OnXPChanged;

        // --- CONSTRUCTOR ---
        public User(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            ProfileIcon = "default";
            XP = 0;
            Level = 1;
            Tasks = new List<Task>();
            CompletedTasks = new List<Task>();
            Inventory = new List<ShopItem>();
            CurrentPet = new Puppy(); // Start with puppy for evolution
        }

        // --- XP MANAGEMENT METHODS ---

        // Add XP to the user and check for level up
        public void AddXP(int amount)
        {
            XP += amount;
            OnXPChanged?.Invoke(XP);
            CheckLevelUp();
        }

        // NEW METHOD - Reduce XP (needed for task unchecking)
        public void ReduceXP(int amount)
        {
            XP = Math.Max(0, XP - amount); // Ensure XP doesn't go below 0
            OnXPChanged?.Invoke(XP);
            // Note: We don't check for level down as level progression is one-way
        }

        // --- LEVEL MANAGEMENT ---

        // Check if user has reached a new level
        private void CheckLevelUp()
        {
            // Calculate level based on XP (every 10 XP = 1 level)
            // XP 0-9 = Level 1, XP 10-19 = Level 2, etc.
            int newLevel = (XP / 10) + 1;

            if (newLevel > Level)
            {
                Level = newLevel;
                OnLevelUp?.Invoke(Level); // Notify observers of level change
                CheckPetEvolution();
            }
        }

        // Check if pet should evolve based on user level
        private void CheckPetEvolution()
        {
            // Puppy evolves to Dog at level 5
            if (Level >= 5 && CurrentPet is Puppy)
            {
                CurrentPet = new Dog();
            }
        }

        // --- TASK MANAGEMENT ---

        // Complete a task, award XP, and trigger pet reaction
        public void CompleteTask(Task task)
        {
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
                CompletedTasks.Add(task);
                task.CompletedDate = DateTime.Now;
                AddXP(task.XPReward);
                CurrentPet?.OnTaskCompleted(); // Polymorphic method call
            }
        }

        // Add a new task to the user's task list
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        // --- SHOP FUNCTIONALITY ---

        // Check if user has enough XP to purchase an item
        public bool CanAffordItem(ShopItem item)
        {
            return XP >= item.Price;
        }

        // Purchase an item, reduce XP, and add to inventory
        public bool PurchaseItem(ShopItem item)
        {
            if (CanAffordItem(item))
            {
                XP -= item.Price;
                Inventory.Add(item);
                OnXPChanged?.Invoke(XP);
                return true;
            }
            return false;
        }
    }
}
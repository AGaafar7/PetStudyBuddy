// Pet.cs - Contains the Pet hierarchy with multi-level inheritance
// Demonstrates inheritance, polymorphism, and abstraction

using System;

namespace PetStudyBuddy.Classes
{
    // Abstract base class - demonstrates abstraction
    // Abstract means this class cannot be instantiated directly
    // It serves as a blueprint for derived classes
    public abstract class Pet
    {
        // --- PROPERTIES ---
        public string Name { get; set; }

        // Protected setter allows derived classes to modify but not external code
        public int Happiness { get; protected set; }
        public string Type { get; protected set; }
        public DateTime LastFed { get; protected set; }

        // Protected constructor ensures only derived classes can instantiate
        protected Pet(string name)
        {
            Name = name;
            Happiness = 50;
            LastFed = DateTime.Now;
        }

        // --- VIRTUAL AND ABSTRACT METHODS ---

        // Virtual method - provides default implementation that can be overridden
        public virtual void OnTaskCompleted()
        {
            // Base happiness increase when a task is completed
            Happiness += 1;
            if (Happiness > 100) Happiness = 100;
        }

        // Abstract method - MUST be implemented by derived classes
        // This ensures all pet types will have a reaction
        public abstract string GetReaction();

        // Virtual method with implementation
        public virtual string GetPetType()
        {
            return Type;
        }

        // Common pet behavior
        public virtual void Feed()
        {
            Happiness += 10;
            LastFed = DateTime.Now;
            if (Happiness > 100) Happiness = 100;
        }
    }

    // Dog inherits from Pet - demonstrates inheritance
    // Dog IS-A Pet relationship
    public class Dog : Pet
    {
        // --- DOG-SPECIFIC PROPERTIES ---
        public bool IsTrained { get; set; }

        // Constructor calls the base constructor with name
        public Dog(string name = "Buddy") : base(name)
        {
            Type = "Dog";
            Happiness = 60;
            IsTrained = false;
        }

        // --- OVERRIDE METHODS ---

        // Override virtual method - demonstrates polymorphism
        // Dogs get more happiness from completed tasks than generic pets
        public override void OnTaskCompleted()
        {
            Happiness += 2;
            if (Happiness > 100) Happiness = 100;
        }

        // Implement abstract method - required by the abstract base class
        public override string GetReaction()
        {
            if (Happiness > 80)
                return "Woof! Great job! 🐕";
            else if (Happiness > 50)
                return "Woof woof! 🐕";
            else
                return "Whimper... needs attention 🐕";
        }

        // --- DOG-SPECIFIC METHODS ---
        public void Train()
        {
            IsTrained = true;
            Happiness += 5;
        }
    }

    // Puppy inherits from Dog - demonstrates MULTI-LEVEL inheritance
    // Puppy IS-A Dog which IS-A Pet (transitivity of inheritance)
    public class Puppy : Dog
    {
        // --- PUPPY-SPECIFIC PROPERTIES ---
        public int Energy { get; set; }

        public Puppy(string name = "Little Buddy") : base(name)
        {
            Type = "Puppy";
            Happiness = 70;
            Energy = 100;
        }

        // --- OVERRIDE METHODS ---

        // Override method from Dog - demonstrates polymorphism
        // Puppies get even more happiness from completed tasks but lose energy
        public override void OnTaskCompleted()
        {
            Happiness += 3;
            Energy -= 5;
            if (Happiness > 100) Happiness = 100;
            if (Energy < 0) Energy = 0;
        }

        // Override abstract method with puppy-specific behavior
        public override string GetReaction()
        {
            if (Energy < 20)
                return "Zzz... sleepy puppy 😴🐶";
            else if (Happiness > 90)
                return "Yip yip! Amazing! 🐶✨";
            else if (Happiness > 60)
                return "Yap yap! So happy! 🐶";
            else
                return "Whine... needs love 🐶";
        }

        // --- PUPPY-SPECIFIC METHODS ---
        public void Play()
        {
            Happiness += 15;
            Energy -= 20;
            if (Happiness > 100) Happiness = 100;
            if (Energy < 0) Energy = 0;
        }

        public void Nap()
        {
            Energy += 30;
            if (Energy > 100) Energy = 100;
        }
    }
}
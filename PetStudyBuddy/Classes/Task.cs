// Task.cs - Represents a study task in the application
// Be careful with the namespace to avoid conflict with System.Threading.Tasks.Task

using System;

namespace PetStudyBuddy.Classes
{
    // TaskPriority enum - defines priority levels
    // Enum is a special type that represents a group of constants (named values)
    public enum TaskPriority
    {
        Low = 1,    // Numeric values can be assigned to enum members
        Medium = 2,
        High = 3,
        Urgent = 4
    }

    public class Task
    {
        // --- PROPERTIES ---
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        // Nullable DateTime for completion tracking - null means not completed
        public DateTime? CompletedDate { get; set; }
        public TaskPriority Priority { get; set; }
        public int XPReward { get; set; }

        // Read-only property that calculates whether task is completed
        public bool IsCompleted => CompletedDate.HasValue;

        // --- CONSTRUCTORS ---

        // Main constructor that takes all necessary values
        public Task(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = TaskPriority.Medium;
            CalculateXPReward();
        }

        // Convenience constructor that defaults to tomorrow's due date
        public Task(string title, string description)
            : this(title, description, DateTime.Now.AddDays(1))
        {
            // Calls the main constructor with a default due date
        }

        // --- METHODS ---

        // Calculate XP reward based on priority and other factors
        private void CalculateXPReward()
        {
            // Base XP based on priority
            int baseXP = (int)Priority * 2;

            // Bonus for urgent tasks
            if (Priority == TaskPriority.Urgent)
                baseXP += 3;

            XPReward = baseXP;
        }

        // Mark a task as complete and calculate any bonus XP
        public void Complete()
        {
            CompletedDate = DateTime.Now;

            // Bonus XP for early completion
            if (DateTime.Now < DueDate)
            {
                TimeSpan earlyBy = DueDate - DateTime.Now;
                if (earlyBy.Days > 0)
                    XPReward += earlyBy.Days; // 1 bonus XP per day early
            }
        }

        // Calculate penalty for overdue tasks
        public int GetPenalty()
        {
            if (DateTime.Now > DueDate && !IsCompleted)
            {
                TimeSpan overdue = DateTime.Now - DueDate;
                return Math.Min(overdue.Days, XPReward - 1); // Max penalty is XP-1
            }
            return 0;
        }

        // Override ToString for display in lists
        public override string ToString()
        {
            string status = IsCompleted ? "✓" : "○";
            return $"{status} {Title} (XP: {XPReward})";
        }
    }
}
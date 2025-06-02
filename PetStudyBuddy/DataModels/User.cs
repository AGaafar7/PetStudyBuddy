namespace PetStudyBuddy.DataModels
{
    public class User
    {
        // Database Fields
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePic { get; set; }
        public int PetId { get; set; }
        public int PetLevel { get; set; }

        // COMPOSITION: HAS-A Relationships
        public Pet CurrentPet { get; private set; }
        public List<Task> Tasks { get; } = new List<Task>();
        public List<Task> CompletedTasks { get; } = new List<Task>();

        // Encapsulated XP (linked to XP table)
        private int _xp;
        public int XP
        {
            get => _xp;
            private set
            {
                _xp = value;
                CheckPetEvolution();
            }
        }

        public User(int userId, string firstName, string lastName,
                   string username, string password, string profilePic,
                   int petId, int petLevel)
        {
            // Initialize all fields
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            ProfilePic = profilePic;
            PetId = petId;
            PetLevel = petLevel;
            

            // Initialize pet based on level
            CurrentPet = PetLevel >= 5 ? new Dog() : new Puppy();
        }

        public void CompleteTask(Task task)
        {
            if (Tasks.Remove(task))
            {
                CompletedTasks.Add(task);
                XP += task.XPReward; // Encapsulated XP update
                CurrentPet.ReactToTask();
            }
        }

        private void CheckPetEvolution()
        {
            if (XP >= 500 && CurrentPet is Puppy)
            {
                CurrentPet = new Dog();
                PetLevel = 5;
            }
        }
    }
}
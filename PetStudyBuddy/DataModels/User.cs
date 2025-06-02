using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStudyBuddy.DataModels
{
    internal class User : DatabaseManager
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string ProfilePicture { get; set; }
        public string PetId { get; set; }
        public int PetLevel { get; set; }

        public User(int id, string firstName, string lastName, string username, string password, string petId, int petLevel, string profilePicture)
        {
            Id = id;
            Username = username;
            Password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            ProfilePicture = profilePicture;
            PetId = petId;
            PetLevel = petLevel;
        }

        public User(string firstName, string lastName, string username, string password, string petId, int petLevel, string profilePicture)
        {
            Username = username;
            Password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            ProfilePicture = profilePicture;
            PetId = petId;
            PetLevel = petLevel;
        }


    }
}
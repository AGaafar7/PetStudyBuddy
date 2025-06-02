using PetStudyBuddy.DataModels;
using System.Media;

using System.Media;

namespace PetStudyBuddy.DataModels
{
    public abstract class Pet
    {
        public string Name { get; protected set; }
        public abstract void ReactToTask();
    }

    public class Dog : Pet
    {
        public Dog() => Name = "Dog";
        public override void ReactToTask() => SystemSounds.Beep.Play();
    }

    public class Puppy : Dog
    {
        public Puppy() => Name = "Puppy";
        public override void ReactToTask() => SystemSounds.Asterisk.Play();
    }
}
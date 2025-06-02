
using System;

namespace PetStudyBuddy.DataModels
{
    public class Task
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int XPReward { get; set; } = 10;


        public Task(int taskId, int userId, string taskName, string taskDescription, DateTime dueDate, bool isComplete, int xPReward)
        {
            TaskId = taskId;
            UserId = userId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            DueDate = dueDate;
            IsComplete = isComplete;
            XPReward = xPReward;
        }
    }
}
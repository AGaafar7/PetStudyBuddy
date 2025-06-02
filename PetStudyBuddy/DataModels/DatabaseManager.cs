using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PetStudyBuddy.DataModels
{
    internal class DatabaseManager
    {
        private string dbPath = @"D:\Apps\VisualStudioSource\repos\PetStudyBuddy\PetStudyBuddy\petStudy.db";
        private SqliteConnection connection;

        public DatabaseManager()
        {
            string conString = $"Data Source={dbPath};";
            connection = new SqliteConnection(conString);
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
                Console.WriteLine("Database connection opened.");
            }
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
                Console.WriteLine("Database connection closed.");
            }
        }

        public User GetCurrentUser(string username, string password)
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(1) FROM users WHERE username = @username AND password = @password";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        string userQuery = "SELECT * FROM users WHERE username = @username";
                        using (var userCmd = new SqliteCommand(userQuery, connection))
                        {
                            userCmd.Parameters.AddWithValue("@username", username);
                            using (var reader = userCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new User(
                                        reader.GetInt32(0),    // Id
                                        reader.GetString(1),   // FirstName
                                        reader.GetString(2),   // LastName
                                        reader.GetString(3),   // Username
                                        reader.GetString(4),   // Password
                                        reader.GetString(5),   // petLeve
                                        reader.GetInt32(6),    // PetId
                                        reader.GetString(7)     // ProfilePicture   
                                    );
                                }
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCurrentUser: {ex.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public User CreateNewUser(string firstName, string lastName, string username, string password, string profilePicture, string petId, int petLevel)
        {
            try
            {
                OpenConnection();
                string insertQuery = "INSERT INTO users (firstname, lastname, username, password, petid, petlevel, profilepic) " +
                                     "VALUES (@firstName, @lastName, @username, @password, @petId, @petLevel, @profilePicture)";

                int id = DateTime.Now.Microsecond + DateTime.Now.Year + DateTime.Now.Day;
                using (var cmd = new SqliteCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@petId", petId);
                    cmd.Parameters.AddWithValue("@petLevel", petLevel);
                    cmd.Parameters.AddWithValue("@profilePicture", profilePicture);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        return new User(id,firstName, lastName, username, password, profilePicture, petId ,petLevel);
                    }
                    else
                    {
                        Console.WriteLine("Insert failed: No rows affected.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateNewUser: {ex.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }



        public User UpdateUser(int id, string username, string password, string firstName, string lastName, string profilePicture, string petId, int petLevel)
        {
          try
            {
                OpenConnection();
                string updateQuery = "UPDATE users SET username = @username, password = @password, firstname = @firstName, " +
                                     "lastname = @lastName, profilepic = @profilePicture, petid = @petId, petlevel = @petLevel " +
                                     "WHERE id = @id";
                using (var cmd = new SqliteCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    
                    cmd.Parameters.AddWithValue("@petId", petId);
                    cmd.Parameters.AddWithValue("@petLevel", petLevel);
                    cmd.Parameters.AddWithValue("@profilePicture", profilePicture);
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        return new User(id, firstName, lastName, username, password, profilePicture, petId.Length, petLevel);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateUser: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }

        public string DeleteUser(string id)
        {
            try
            {
                OpenConnection();

                string query = "DELETE FROM users WHERE id = @id";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return "User deleted successfully.";
                    else
                        return "User not found.";
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting user: {ex.Message}";
            }
            finally
            {
                CloseConnection();
            }
        }


        //End of user functions



        //Tasks
        //GetTask

        private Task getTask(int id, String taskname) {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(1) FROM tasks WHERE taskid = @taskid AND taskname = @taskname";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@taskid", id);
                    cmd.Parameters.AddWithValue("@taskname", taskname);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        string userQuery = "SELECT * FROM tasks WHERE taskname = @taskname";
                        using (var userCmd = new SqliteCommand(userQuery, connection))
                        {
                            userCmd.Parameters.AddWithValue("@taskname", taskname);
                            using (var reader = userCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new Task(
                                        reader.GetInt32(0),    // Id
                                        reader.GetInt32(1),   // FirstName
                                        reader.GetString(2),   // LastName
                                        reader.GetString(3),   // Username
                                        DateTime.Parse(reader.GetString(4)),   // Password
                                        Boolean.Parse(reader.GetInt32(5).ToString()),   // petLeve
                                        reader.GetInt32(6)    // PetId
                                    );
                                }
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getTask: {ex.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        //create task
        public Task CreateNewTask(int taskId, int userId, string taskName, string taskDescription, DateTime dueDate, bool isComplete, int xPReward, string userid)
        {
            try
            {
                OpenConnection();
                string insertQuery = "INSERT INTO users (taskid, taskname, taskdecription, duedate, iscomplete, userid) " +
                                     "VALUES (@taskid, @taskname, @taskdecription, @duedate, @iscomplete, @userid)";

                int id = DateTime.Now.Microsecond + DateTime.Now.Year + DateTime.Now.Day;
                using (var cmd = new SqliteCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@taskid", taskId);
                    cmd.Parameters.AddWithValue("@taskname", taskName);
                    cmd.Parameters.AddWithValue("@taskdescription", taskDescription);
                    cmd.Parameters.AddWithValue("@duedate", dueDate);
                    cmd.Parameters.AddWithValue("@iscomplete", isComplete);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        return new Task(taskId, userId, taskName, taskDescription, dueDate, isComplete, xPReward);
                    }
                    else
                    {
                        Console.WriteLine("Insert failed: No rows affected.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateNewTask: {ex.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        //update
        public Task UpdateTask(int taskId, int userId, string taskName, string taskDescription, DateTime dueDate, bool isComplete, int xPReward, string userid)
        {
            try
            {
                OpenConnection();
                string updateQuery = "UPDATE tasks SET taskid = @taskid, taskname = @taskname, taskdescription = @taskdescription, " +
                                     "duedate = @duedate, iscomplete = @iscomplete, userid = @userid" +
                                     "WHERE id = @id";
                using (var cmd = new SqliteCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@taskid", taskId);
                    cmd.Parameters.AddWithValue("@taskname", taskName);
                    cmd.Parameters.AddWithValue("@taskdescription", taskDescription);
                    cmd.Parameters.AddWithValue("@duedate", dueDate);
                    cmd.Parameters.AddWithValue("@iscomplete", isComplete);
                    cmd.Parameters.AddWithValue("@userid", userid);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        return new Task(taskId,int.Parse(userid), taskName, taskDescription,dueDate,isComplete,xPReward);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateTask: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }



        //Delete
        public string DeleteTask(string id)
        {
            try
            {
                OpenConnection();

                string query = "DELETE FROM tasks WHERE id = @id";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return "Task deleted successfully.";
                    else
                        return "Task not found.";
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting Task: {ex.Message}";
            }
            finally
            {
                CloseConnection();
            }
        }


        //End of Tasks
        //Get XP

        private XP getXP(int userid)
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(1) FROM xp WHERE userid = @userid";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userid", userid);
                    
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        string userQuery = "SELECT * FROM xp WHERE userid = @userid";
                        using (var userCmd = new SqliteCommand(userQuery, connection))
                        {
                            userCmd.Parameters.AddWithValue("@userid", userid);
                            using (var reader = userCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new XP(
                                        reader.GetInt32(0),
                                        reader.GetInt32(1)
                                    );
                                }
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getxp: {ex.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        //create task
        public XP AddXP(int xp,int userid)
        {
            try
            {
                OpenConnection();
                string insertQuery = "INSERT INTO xp (xp, userid) " +
                                     "VALUES (@xp, @userid)";
                using (var cmd = new SqliteCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@xp", xp);
                    cmd.Parameters.AddWithValue("@userid",userid);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        return new XP(xp,userid);
                    }
                    else
                    {
                        Console.WriteLine("Insert failed: No rows affected.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in AddTask: {ex.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        //update
        public XP UpdateXP(int xp, int userid)
        {
            try
            {
                OpenConnection();
                string updateQuery = "UPDATE tasks SET xp = @xp" +
                                     "WHERE userid = @userid";
                using (var cmd = new SqliteCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@xp", xp);
                    cmd.Parameters.AddWithValue("@userid", userid);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        return new XP(xp, userid);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateXP: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }



        //Delete
        public string DeleteXP(int userid)
        {
            try
            {
                OpenConnection();

                string query = "DELETE FROM xp WHERE userid = @userid";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userid", userid);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return "user xp deleted successfully.";
                    else
                        return "user xp not found.";
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting xp: {ex.Message}";
            }
            finally
            {
                CloseConnection();
            }
        }



    }
}

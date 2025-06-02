using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        return new User(firstName, username, password, lastName, petId, petLevel, profilePicture);
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
                        return new User(id, firstName, lastName, username, password, petId, petLevel, profilePicture);
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



    }
}
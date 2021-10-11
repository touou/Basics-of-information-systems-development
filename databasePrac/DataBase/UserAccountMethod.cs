using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace databasePrac.DataBase
{
    public static class UserAccountMethod
    {
        private static SqlConnection connection;

        private static SqlCommand command;
        
        public static void Insert(UserAccount<string> AnotherUser)
        {
            var sqlExpression = $"INSERT INTO UsersAndCars (Name, Surname, Car) VALUES ('{AnotherUser.Name}', " +
                                $"'{AnotherUser.Surname}', '{AnotherUser.Car}')";

            connection = DataBaseLauncher.ConnectionReturn();
            
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
                
            
            command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();

            Console.WriteLine("object was added");
            
        }

        public static void Delete(string fieldWhereDelete,string valueForDelete)
        {
            string sqlExpression = null;
            switch (fieldWhereDelete)
            {
                case "Name":
                    sqlExpression = $"DELETE  FROM UsersAndCars WHERE Name='{valueForDelete}'";
                    break;
                case "Surname":
                    sqlExpression = $"DELETE  FROM UsersAndCars WHERE Surname='{valueForDelete}'";
                    break;
                case "Car":
                    sqlExpression = $"DELETE  FROM UsersAndCars WHERE Car='{valueForDelete}'";
                    break;
                default:
                    throw new ArgumentException();
            }
            
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
                
            command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();

            Console.WriteLine("object was deleted");
            
        }

        public static void Update(string fieldToSet,string valueToSet,string fieldWhereSet,string valueWhereSet)
        {
            string sqlExpression = $"UPDATE UsersAndCars SET {fieldToSet}='{valueToSet}' WHERE {fieldWhereSet}='{valueWhereSet}'";

            connection = DataBaseLauncher.ConnectionReturn();
            
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            
            command = new SqlCommand(sqlExpression,connection);
            command.ExecuteNonQuery();
                
            Console.WriteLine("object was updated");
        }

        public static UserAccount<object> FindById(int Id)
        {
            var sqlExpression = $"SELECT * FROM UsersAndCarsDB.dbo.UsersAndCars where Id={Id}";

            var anotherUser = new UserAccount<object>();

            connection = DataBaseLauncher.ConnectionReturn();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = new SqlCommand(sqlExpression, connection);
            var reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        anotherUser.Name = reader.GetValue(2);
                        anotherUser.Surname = reader.GetValue(1);
                        anotherUser.Car = reader.GetValue(3);
                    }
                }

                reader.Close();

                return anotherUser;

        }

        public static UserAccount<object> FindByCar(string Car)
        {
            var sqlExpression = $"SELECT * FROM UsersAndCarsDB.dbo.UsersAndCars where Car='{Car}'";

            var anotherUser = new UserAccount<object>();

            connection = DataBaseLauncher.ConnectionReturn();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = new SqlCommand(sqlExpression, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    anotherUser.Name = reader.GetValue(2);
                    anotherUser.Surname = reader.GetValue(1);
                    anotherUser.Car = reader.GetValue(3);
                }
            }

            reader.Close();

            return anotherUser; 
        }

        public static UserAccount<object> FindByName(string Name)
        {
            var sqlExpression = $"SELECT * FROM UsersAndCarsDB.dbo.UsersAndCars where Name='{Name}'";

            var anotherUser = new UserAccount<object>();

            connection = DataBaseLauncher.ConnectionReturn();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = new SqlCommand(sqlExpression, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    anotherUser.Name = reader.GetValue(2);
                    anotherUser.Surname = reader.GetValue(1);
                    anotherUser.Car = reader.GetValue(3);
                }
            }

            reader.Close();

            return anotherUser;

        }

        public static List<UserAccount<object>> ShowAll()
        {
            var allUsers = new List<UserAccount<object>>();

            var sqlExpression = $"SELECT * FROM UsersAndCarsDB.dbo.UsersAndCars";
            
            connection = DataBaseLauncher.ConnectionReturn();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = new SqlCommand(sqlExpression, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    var anotherUser = new UserAccount<object>();
                    anotherUser.Name = reader.GetValue(2);
                    anotherUser.Surname = reader.GetValue(1);
                    anotherUser.Car = reader.GetValue(3);
                    allUsers.Add(anotherUser);
                }
            }

            reader.Close();
            
            return allUsers;
        }
    }
}
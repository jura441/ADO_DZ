using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO_DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.ConnectionStrings["fandv"].ConnectionString;
            
            SqlConnection connection = new SqlConnection(connString);
            Random random = new Random();
            try
            {
                connection.Open();

                //SqlCommand insertcommand = new SqlCommand();
                //insertcommand.Connection = connection;
                //for (int i = 1; i <= 25; i++)
                //{
                //    insertcommand.CommandText += "insert into fandv" +
                //            "(Id, Name, Type, Color,Calories)" +
                //            " values (" + i + ", 'name" + i + "', 'vegetables', 'red', " + random.Next(100, 500) + "); ";

                //}
                //for (int i = 26; i <=50; i++)
                //{
                //insertcommand.CommandText += "insert into fandv" +
                //        "(Id, Name, Type, Color,Calories)" +
                //        " values ("+i+", 'name" + i + "', 'fruits', 'yellow', "+random.Next(100,500)+"); "; 

                //}

                //insertcommand.ExecuteNonQuery();

                SqlCommand command = new SqlCommand("select * from fandv", connection);
                SqlDataReader reader = command.ExecuteReader();

                int line = 0;
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        Console.WriteLine($"{reader.GetName(0)} | {reader.GetName(1)}" +
                            $"| {reader.GetName(2)} | {reader.GetName(3)}" +
                            $"| {reader.GetName(4)} ");
                     }
                        Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetString(1)}" +
                            $"| {reader.GetString(2)} | {reader.GetString(3)}" +
                            $"| {reader.GetInt32(4)} ");
                        line++;
                }
                reader.Close();
                Console.WriteLine("\n-----------------------------------------------------------\n");
                command.CommandText = "select Name from fandv";
                reader = command.ExecuteReader();

                line = 0;
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        Console.WriteLine(reader.GetName(0));
                    }
                    Console.WriteLine(reader.GetString(0));
                    line++;
                }
                reader.Close();
                Console.WriteLine("\n-----------------------------------------------------------\n");
                command.CommandText = "select DISTINCT(Color) from fandv";
                reader = command.ExecuteReader();

                line = 0;
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        Console.WriteLine(reader.GetName(0));
                    }
                    Console.WriteLine(reader.GetString(0));
                    line++;
                }
                reader.Close();
                Console.WriteLine("\n-----------------------------------------------------------\n");
                command.CommandText = "select MAX(Calories) from fandv";
                Console.WriteLine("Максимальная калорийность: " + (int)command.ExecuteScalar());
                Console.WriteLine("\n-----------------------------------------------------------\n");
                command.CommandText = "select MIN(Calories) from fandv";
                Console.WriteLine("Минимальная калорийность: " + (int)command.ExecuteScalar());
                Console.WriteLine("\n-----------------------------------------------------------\n");
                command.CommandText = "select AVG(Calories) from fandv";
                Console.WriteLine("Средняя калорийность: " + (int)command.ExecuteScalar());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Подключение было закрыто.");

            }
            Console.ReadLine(); 
        }
    }
}

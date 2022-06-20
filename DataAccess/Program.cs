using System;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost, 14033\\sql1;Database=Balta;User Id=sa;Password=@Dotnet123;Trust Server Certificate=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        System.Console.WriteLine(@$"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }

        }
    }
}
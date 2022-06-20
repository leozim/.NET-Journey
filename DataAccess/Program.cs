using System;
using Microsoft.Data.SqlClient;
using Dapper;

using DataAccess.Models;

namespace DataAccess
{
    internal class Program
    {
        static void Main2(string[] args)
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
                        Console.WriteLine(@$"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }

        }

        static void Main(String[] args)
        {
            const string connectionString = @"
                Server=localhost, 14033\\sql1;Database=Balta;
                User Id=sa;Password=@Dotnet123;Trust Server Certificate=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                ListCategories(connection);
                GetCategories(connection);
                CreateCategory(connection);
                UpdateCategory(connection);
                // DeleteCategory(connection);
            }

        }

        private static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>(@"
                SELECT [Id], [Title] 
                FROM [Category]");

            foreach (var item in categories)
            {
                Console.WriteLine($"Id: {item.Id} - Title: {item.Title}");
            }
        }

        private static void GetCategories(SqlConnection connection)
        {
            var category = connection.QueryFirstOrDefault<Category>(
                @"SELECT TOP 1 [Id], [Title] 
                FROM [Category] 
                WHERE [Id]=@Id",
                new
                {
                    Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4")
                });

            Console.WriteLine($"Id: {category.Id} - Title: {category.Title}");
        }

        private static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"
                INSERT INTO [Category]
                VALUES(
                    @Id,
                    @Title,
                    @Url,
                    @Summary,
                    @Order,
                    @Description,
                    @Featured
                )";

            var rows = connection.Execute(insertSql, new
            {
                Id = category.Id,
                Title = category.Title,
                Url = category.Url,
                Summary = category.Summary,
                Order = category.Order,
                Description = category.Description,
                Featured = category.Featured
            });

            Console.WriteLine($"{rows} linha(s) inserida(s)");
        }

        private static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = @"
                UPDATE [Category] 
                SET [Title]=@Title 
                WHERE [Id]=@Id";

            var rows = connection.Execute(updateQuery,
                new
                {
                    Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                    Title = "Frontend 2021"
                });

            Console.WriteLine($"{rows} registro(s) atualizada(s)");
        }

        private static void DeleteCategory(SqlConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
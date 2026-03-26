using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;


namespace ProductApp
{
    internal class ProductRepository
    {
        private readonly string connectionString;
        public ProductRepository()
        {
            var config=new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();
            connectionString = config.GetConnectionString("DefaultConnection");

        }

        //INSERT
        public void AddProduct(Product product)
        {
            using(SqlConnection con=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductName",SqlDbType.VarChar,100).Value=product.ProductName;
                cmd.Parameters.Add("@Category",SqlDbType.VarChar,50).Value=product.Category;
                cmd.Parameters.Add("@Price",SqlDbType.Decimal).Value=product.Price;

                con.Open();
               int rows= cmd.ExecuteNonQuery();
                Console.WriteLine("Rows affected:" + rows);
            }
        }

        //GET ALL
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = reader["ProductName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Price = (decimal)reader["Price"]
                    });
                }
            }
            return list;
        }
        //UPDATE
        public void UpdateProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //DELETE
        public void DeleteProduct(int id)
        {
            using(SqlConnection con=new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con);
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();
                cmd.ExecuteNonQuery();
        }

        }
    }
}

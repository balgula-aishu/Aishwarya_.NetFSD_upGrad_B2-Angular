using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    internal class MainProgram
    {
        static void Main()
        {
            ProductRepository repo = new ProductRepository();

            //INSERT
             repo.AddProduct(new Product { ProductName = "IPhone", Category = "Electronics", Price = 500000 });
            Console.WriteLine("Data Inserted.");

            //VIEW
             Console.WriteLine("Products:");
             var products = repo.GetAllProducts();
            foreach (var p in products)
            {
              Console.WriteLine($"{p.ProductId}-{p.ProductName}-{p.Category}-{p.Price}");

             }
            Console.WriteLine("Data Fetched Successfully!");

            //UPDATE
             repo.UpdateProduct(new Product { ProductId = 2, ProductName = "Laptop pro", Category = "Electronics", Price = 60000 });
             Console.WriteLine("Data Updated.");


            //DELETE
             repo.DeleteProduct(2);
            Console.WriteLine("Data Deleted Successfully!");

            Console.WriteLine("Operations Completed!");
        }
        
    }
}

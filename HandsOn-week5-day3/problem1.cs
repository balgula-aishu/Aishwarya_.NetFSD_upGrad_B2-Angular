using System;
using System.Collections.Generic;
using System.Linq;


namespace Dotnet_C__Demo.HandsOn_week5_day3
{
    class Product
    {
        public int Code {  get; set; }
        public string Name { get; set; }
        public string Category {  get; set; }
        public double Mrp {  get; set; }
    }
    internal class problem1
    {
        static void Main()
        {
            // Sample Data 
            List<Product> products = new List<Product>
        {
            new Product { Code = 101, Name = "Soap", Category = "FMCG", Mrp = 25 },
            new Product { Code = 102, Name = "Rice", Category = "Grain", Mrp = 50 },
            new Product { Code = 103, Name = "Shampoo", Category = "FMCG", Mrp = 120 },
            new Product { Code = 104, Name = "Wheat", Category = "Grain", Mrp = 40 },
            new Product { Code = 105, Name = "Oil", Category = "FMCG", Mrp = 150 }
        };

            // 1. FMCG products
            var fmcgProducts = products.Where(p => p.Category == "FMCG");
            Console.WriteLine("\nFMCG Products:");
            Display(fmcgProducts);

            // 2. Grain products
            var grainProducts = products.Where(p => p.Category == "Grain");
            Console.WriteLine("\nGrain Products:");
            Display(grainProducts);

            // 3. Sort by Code (Ascending)
            var sortByCode = products.OrderBy(p => p.Code);
            Console.WriteLine("\nSorted by Code:");
            Display(sortByCode);

            // 4. Sort by Category (Ascending)
            var sortByCategory = products.OrderBy(p => p.Category);
            Console.WriteLine("\nSorted by Category:");
            Display(sortByCategory);

            // 5. Sort by MRP (Ascending)
            var sortByMrpAsc = products.OrderBy(p => p.Mrp);
            Console.WriteLine("\nSorted by MRP (Ascending):");
            Display(sortByMrpAsc);

            // 6. Sort by MRP (Descending)
            var sortByMrpDesc = products.OrderByDescending(p => p.Mrp);
            Console.WriteLine("\nSorted by MRP (Descending):");
            Display(sortByMrpDesc);

            // 7. Group by Category
            var groupByCategory = products.GroupBy(p => p.Category);
            Console.WriteLine("\nGroup by Category:");
            foreach (var group in groupByCategory)
            {
                Console.WriteLine("Category: " + group.Key);
                Display(group);
            }

            // 8. Group by MRP
            var groupByMrp = products.GroupBy(p => p.Mrp);
            Console.WriteLine("\nGroup by MRP:");
            foreach (var group in groupByMrp)
            {
                Console.WriteLine("MRP: " + group.Key);
                Display(group);
            }

            // 9. Highest price in FMCG
            var highestFmcg = products
                .Where(p => p.Category == "FMCG")
                .OrderByDescending(p => p.Mrp)
                .FirstOrDefault();

            Console.WriteLine("\nHighest Price Product in FMCG:");
            DisplaySingle(highestFmcg);

            // 10. Total products count
            Console.WriteLine("\nTotal Products: " + products.Count());

            // 11. FMCG count
            Console.WriteLine("Total FMCG Products: " + products.Count(p => p.Category == "FMCG"));

            // 12. Max price
            Console.WriteLine("Max Price: " + products.Max(p => p.Mrp));

            // 13. Min price
            Console.WriteLine("Min Price: " + products.Min(p => p.Mrp));

            // 14. All products below Rs.30
            bool allBelow30 = products.All(p => p.Mrp < 30);
            Console.WriteLine("All products below Rs.30: " + allBelow30);

            // 15. Any products below Rs.30
            bool anyBelow30 = products.Any(p => p.Mrp < 30);
            Console.WriteLine("Any product below Rs.30: " + anyBelow30);
        }

        // Helper method to display list
        static void Display(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine($"Code: {p.Code} | Name: {p.Name} | Category: {p.Category} | MRP: {p.Mrp}");
            }
        }

        // Helper method for single product
        static void DisplaySingle(Product p)
        {
            if (p != null)
            {
                Console.WriteLine($"Code: {p.Code} | Name: {p.Name} | Category: {p.Category} | MRP: {p.Mrp}");
            }
        }
    }
    }


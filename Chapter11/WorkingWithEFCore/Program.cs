using static System.Console;
using Packt.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WorkingWithEFCore
{
    class Program
    {
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have:");
                // a query to get all categories and their related products

                IQueryable<Category> cats = db.Categories
               .Include(c => c.Products);

                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }


        }


        static void FilteredIncludes()
        {
            using (var db = new Northwind())
            {
                Write("Enter a minimum for units in stock: ");

                string unitsInStock = ReadLine();
                int stock = int.Parse(unitsInStock);
                IQueryable<Category> cats = db.Categories
                  .Include(c => c.Products.Where(p => p.Stock >= stock));


                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products with aminimum of { stock} units in stock.");

                    foreach (Product p in c.Products)
                    {
                        WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }


        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {

                Write("Enter part of a product name: ");
                string input = ReadLine();
                IQueryable<Product> prods = db.Products
                .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

                foreach (Product item in prods)
                {
                    WriteLine("{0} has {1} units in stock. Discontinued? {2}",
                    item.ProductName, item.Stock, item.Discontinued);
                }
            }
        }

        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {

                var newProduct = new Product
                {

                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                // mark product as added in change tracking
                db.Products.Add(newProduct);
                // save tracked change to database
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                // get first product whose name starts with name
                Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));
                updateProduct.Cost += amount;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }
        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                IEnumerable<Product> products = db.Products.Where(
                p => p.ProductName.StartsWith(name));
                db.Products.RemoveRange(products);
                int affected = db.SaveChanges();
                return affected;
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
                "ID", "Product Name", "Cost", "Stock", "Disc.");
                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                    item.ProductID, item.ProductName, item.Cost,
                    item.Stock, item.Discontinued);
                }
            }
        }
        static void Main(string[] args)
        {
            //QueryingCategories();

            // FilteredIncludes();
            // QueryingProducts();
           //  QueryingWithLike();
            
             /*           if (AddProduct(6, "elias's pitza", 408M))
                        {
                            WriteLine("Add product successful.");
                        }
                        ListProducts();
*/
                      
          /*
                        if (IncreaseProductPrice("elias", 20M))
                        {
                            WriteLine("Update product price successful.");
                        }
                        ListProducts();
        */
             int deleted = DeleteProducts("elias");
             WriteLine($"{deleted} product(s) were deleted.");
             ListProducts(); 

        }
    }

}

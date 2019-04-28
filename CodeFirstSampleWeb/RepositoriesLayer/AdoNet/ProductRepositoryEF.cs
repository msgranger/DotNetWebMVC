using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.Concrete;
using EntitiesLayer.ViewObjects;

namespace RepositoriesLayer.AdoNet
{
    public class ProductRepositoryEF : IProductRepository
    {        
        public Product Find(int? id)
        {
            Product result;

            using (var northwindDbContext = new NorthwindDbContext())
            {
                result = northwindDbContext.Products.Find(id);
            }
            return result;
        }

        public List<Product> GetProducts()
        {
            List<Product> result;
    
            using ( var northwindDbContext = new NorthwindDbContext())
            {
                //products = northwindDbContext.Products
                //     .Include(p => p.Supplier)
                //     .Include(p => p.Category);

                var products = northwindDbContext.Products; // define query
                foreach (var product in products) // query executed and data obtained from database
                {
                    Category prCategori = product.Category;
                }

                result = northwindDbContext.Products.ToList();
            }
            return result;
        }

        public List<Product> GetProductsByName(string productName)
        {
            List<Product> result;

            using (var northwindDbContext = new NorthwindDbContext())
            {
                //var products = from u in northwindDbContext.Products select u;
                //if (!string.IsNullOrWhiteSpace(productName))
                //    products = products.Where(u => u.ProductName.ToLower().Contains(productName.ToLower()));

                IEnumerable<Product> products = new List<Product>();
                if (!string.IsNullOrWhiteSpace(productName))
                    products = northwindDbContext.Products.Where(x => x.ProductName.ToLower().Contains(productName.ToLower()));

                result = products.ToList();
            }
            return result;
        }

        public List<Category> GetCategories()
        {
            List<Category> result;

            using (var northwindDbContext = new NorthwindDbContext())
            {
                IEnumerable<Category> categories = from c in northwindDbContext.Categories
                                                   orderby c.CategoryName
                                                   select c;
                result = categories.ToList();
            }
            return result;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> result;

            using (var northwindDbContext = new NorthwindDbContext())
            {
                IEnumerable<Supplier> suppliers = from s in northwindDbContext.Suppliers
                                                  orderby s.CompanyName
                                                  select s;
                result = suppliers.ToList();
            }
            return result;
        }

        public int CreateProduct(Product product)
        {
            int result;
            using (var northwindDbContext = new NorthwindDbContext())
            {
                northwindDbContext.Products.Add(product);
                result = northwindDbContext.SaveChanges();
            }
            return result;
        }

        public int UpdateProduct(Product product)
        {
            int result;
            using (var northwindDbContext = new NorthwindDbContext())
            {

                northwindDbContext.Entry(product).State = EntityState.Modified;
                result = northwindDbContext.SaveChanges();
            }
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result;
            using (var northwindDbContext = new NorthwindDbContext())
            {

                Product product = northwindDbContext.Products.Find(id);
                if (product != null)
                {
                    northwindDbContext.Products.Remove(product);
                    result = northwindDbContext.SaveChanges();
                }
                else
                    result = -1;                
            }
            return result;
        }

        public List<ProductCategoryGroup> GetStats()
        {
            List<ProductCategoryGroup> result;

            using (var northwindDbContext = new NorthwindDbContext())
            {
                IEnumerable<ProductCategoryGroup> 
                    productCategoryGroups = 
                    from product in northwindDbContext.Products
                        join category in northwindDbContext.Categories
                        on product.CategoryID equals category.CategoryID
                        group product by category.CategoryName into g
                        select new ProductCategoryGroup()
                        {
                            Category = g.Key,
                            ProductCount = g.Count()
                        };

                result = productCategoryGroups.ToList();
            }
            return result;
        }

    }
}

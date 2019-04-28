using EntitiesLayer.Concrete;
using EntitiesLayer.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLayer
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product Find(int? id);

        List<Category> GetCategories();

        List<Supplier> GetSuppliers();

        int CreateProduct(Product product);

        int UpdateProduct(Product product);

        int DeleteProduct(int id);

        List<ProductCategoryGroup> GetStats();

        List<Product> GetProductsByName(string productName);

    }
}

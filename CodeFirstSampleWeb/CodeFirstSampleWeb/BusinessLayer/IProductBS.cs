using EntitiesLayer.Concrete;
using EntitiesLayer.ViewObjects;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IProductBS
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

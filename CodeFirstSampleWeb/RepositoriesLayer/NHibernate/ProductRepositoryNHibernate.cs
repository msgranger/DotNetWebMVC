using System;
using System.Collections.Generic;
using EntitiesLayer.Concrete;
using EntitiesLayer.ViewObjects;

namespace RepositoriesLayer.NHibernate
{
    public class ProductRepositoryNHibernate : IProductRepository
    {
        public int CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public int DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product Find(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryGroup> GetStats()
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

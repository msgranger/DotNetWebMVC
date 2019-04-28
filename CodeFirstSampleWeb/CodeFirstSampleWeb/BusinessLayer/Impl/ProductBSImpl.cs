using System.Collections.Generic;
using EntitiesLayer.Concrete;
using EntitiesLayer.ViewObjects;
using RepositoriesLayer;
using RepositoriesLayer.AdoNet;

namespace BusinessLayer.Impl
{
    class ProductBSImpl : IProductBS
    {

        IProductRepository _productRepository;
        public ProductBSImpl()
        {
            _productRepository = new ProductRepositoryEF();
        }
        public ProductBSImpl(IProductRepository pRepository)
        {
            _productRepository = pRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product Find(int? id)
        {
            return _productRepository.Find(id);
        }

        public List<Category> GetCategories()
        {
            return _productRepository.GetCategories();
        }

        public List<Supplier> GetSuppliers()
        {
            return _productRepository.GetSuppliers();
        }

        public int CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public int UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public List<ProductCategoryGroup> GetStats()
        {
            return _productRepository.GetStats();
        }

        public List<Product> GetProductsByName(string productName)
        {
            return _productRepository.GetProductsByName(productName);
        }

    }
}

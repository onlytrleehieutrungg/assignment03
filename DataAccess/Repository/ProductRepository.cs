
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductByID(int productId) => ProductDAO.Instance.GetProductByID(productId);
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();
        public void InsertProduct(Product product) => ProductDAO.Instance.AddNew(product);
        public void DeleteProduct(int productId) => ProductDAO.Instance.Remove(productId);
        public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
    }
}

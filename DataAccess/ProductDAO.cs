
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        //Using Singleton Pattern
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        //-----
        public IEnumerable<Product> GetProductList()
        {
            var products = new List<Product>();
            try
            {
                using var context = new FStoreDBContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        //--------
        public Product GetProductByID(int productId)
        {
            Product product = null;
            try
            {
                using var context = new FStoreDBContext();
                product = context.Products.SingleOrDefault(c => c.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        //----------
        public void AddNew(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product == null)
                {
                    using var context = new FStoreDBContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------
        public void Update(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product != null)
                {
                    using var context = new FStoreDBContext();
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------
        public void Remove(int memberId)
        {
            try
            {
                Product product = GetProductByID(memberId);
                if (product != null)
                {
                    using var context = new FStoreDBContext();
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

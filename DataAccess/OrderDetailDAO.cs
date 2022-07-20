using DataAccess.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        //Using Singleton Pattern
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        //-----
        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            var orderdetails = new List<OrderDetail>();
            try
            {
                using var context = new FStoreDBContext();
                orderdetails = context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderdetails;
        }
        //--------
        public IEnumerable<OrderDetail> GetOrderDetailListByOrder(int orderId)
        {
            var orderdetails = GetOrderDetailList();
            try
            {
                using var context = new FStoreDBContext();
                orderdetails = orderdetails.Where(orddt => orddt.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderdetails;
        }
        //----------
        public OrderDetail GetOrderDetailByOrder(int orderId)
        {
            OrderDetail orderdetail = null;
            try
            {
                using var context = new FStoreDBContext();
                orderdetail = context.OrderDetails.SingleOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderdetail;
        }
        //----------
        public OrderDetail GetOrderDetailByOrderAndProduct(int orderId, int productId)
        {
            OrderDetail orderdetail = null;
            try
            {
                using var context = new FStoreDBContext();
                orderdetail = context.OrderDetails.SingleOrDefault(o => o.OrderId == orderId && o.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderdetail;
        }
        //----------
        public void AddNew(OrderDetail orderdetail)
        {
            try
            {
                OrderDetail _orderdetail = GetOrderDetailByOrderAndProduct(orderdetail.OrderId, orderdetail.ProductId);
                if (_orderdetail == null)
                {
                    using var context = new FStoreDBContext();
                    context.OrderDetails.Add(orderdetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail is already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------
        public void Update(OrderDetail orderdetail)
        {
            try
            {
                OrderDetail _orderdetail = GetOrderDetailByOrderAndProduct(orderdetail.OrderId, orderdetail.ProductId);
                if (_orderdetail != null)
                {
                    using var context = new FStoreDBContext();
                    context.OrderDetails.Update(orderdetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------       
        public void Remove(int orderId, int productId)
        {
            try
            {
                OrderDetail orderdetail = GetOrderDetailByOrderAndProduct(orderId, productId);
                if (orderdetail != null)
                {
                    using var context = new FStoreDBContext();
                    context.OrderDetails.Remove(orderdetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

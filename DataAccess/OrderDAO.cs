
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        //Using Singleton Pattern
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        //-----
        public IEnumerable<Order> GetOrderList()
        {
            var orders = new List<Order>();
            try
            {
                using var context = new FStoreDBContext();
                orders = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        //--------
        public Order GetOrderByID(int orderId)
        {
            Order order = null;
            try
            {
                using var context = new FStoreDBContext();
                order = context.Orders.SingleOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        //--------
        public IEnumerable<Order> GetOrderListByMemberID(int memberId)
        {
            var orders = new List<Order>();
            try
            {
                using var context = new FStoreDBContext();
                orders = context.Orders.ToList();
                orders = orders.Where(ord => ord.MemberId == memberId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        //----------
        public void AddNew(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order == null)
                {
                    using var context = new FStoreDBContext();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------
        public void Update(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order != null)
                {
                    using var context = new FStoreDBContext();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------
        public void RemoveOrderDetail(int orderId)
        {
            try
            {
                Order order = GetOrderByID(orderId);
                if (order != null)
                {
                    using var context = new FStoreDBContext();
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------
        public void Remove(int orderId)
        {
            try
            {
                Order order = GetOrderByID(orderId);
                if (order != null)
                {
                    using var context = new FStoreDBContext();
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

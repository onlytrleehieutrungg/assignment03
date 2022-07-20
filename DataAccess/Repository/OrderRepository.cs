
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrderByID(int orderId) => OrderDAO.Instance.GetOrderByID(orderId);
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrderList();
        public IEnumerable<Order> GetOrdersByMemberID(int memberId) => OrderDAO.Instance.GetOrderListByMemberID(memberId);
        public void InsertOrder(Order order) => OrderDAO.Instance.AddNew(order);
        public void DeleteOrder(int orderId) => OrderDAO.Instance.Remove(orderId);
        public void UpdateOrder(Order order) => OrderDAO.Instance.Update(order);
    }
}


using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrdersByMemberID(int memberId);
        Order GetOrderByID(int orderId);
        void InsertOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);
    }
}

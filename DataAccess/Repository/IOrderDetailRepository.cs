
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailByOrderAndProduct(int orderId, int productId);
        IEnumerable<OrderDetail> GetOrderDetailListByOrder(int orderId);
        void InsertOrderDetail(OrderDetail orderdetail);
        void DeleteOrderDetail(int orderId, int productId);
        void UpdateOrderDetail(OrderDetail orderdetail);
    }
}

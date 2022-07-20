
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetail GetOrderDetailByOrderAndProduct(int orderId, int productId) => OrderDetailDAO.Instance.GetOrderDetailByOrderAndProduct(orderId, productId);
        public IEnumerable<OrderDetail> GetOrderDetailListByOrder(int orderId) => OrderDetailDAO.Instance.GetOrderDetailListByOrder(orderId);
        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetailList();
        public void InsertOrderDetail(OrderDetail orderdetail) => OrderDetailDAO.Instance.AddNew(orderdetail);
        public void DeleteOrderDetail(int orderId, int productId) => OrderDetailDAO.Instance.Remove(orderId, productId);
        public void UpdateOrderDetail(OrderDetail orderdetail) => OrderDetailDAO.Instance.Update(orderdetail);
    }
}

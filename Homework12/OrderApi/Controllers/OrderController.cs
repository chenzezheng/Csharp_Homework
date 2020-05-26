using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderServiceContext orderDb;

        //OrderServiceContext 作为参数，Asp.net core 框架可以自动注入OrderServiceContext对象
        public OrderController(OrderServiceContext context)
        {
            this.orderDb = context;
        }

        // GET: api/order/query/{id}  id为路径参数,按订单号查询
        [HttpGet("query/{id}")]
        public ActionResult<Order> GetOrderbyID(int id)
        {
            var order = orderDb.Orders.FirstOrDefault(t => t.Order_ID == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        /*List<Order> Decoder(IQueryable<Order> query)
        {
            List<Order> orders = new List<Order>() { };
            foreach (var db_order in query)
            {
                Order order = new Order();
                order.ID = db_order.Order_ID;
                order.User.Name = db_order.Name;
                order.User.Address = db_order.Address;
                order.OrderTime = db_order.OrderTime;
                order.orderItems = GetItems(order.ID);
                orders.Add(order);
            }
            return orders;
        }*/
        List<OrderItem> GetItems(int orderID)
        {
            List<OrderItem> items = new List<OrderItem>() { };
            var query = orderDb.Items
                .Where(i => i.OrderID == orderID);
            foreach (var item in query)
            {
                items.Add(item);
            }
            return items;
        }

        // GET: api/order/query? 按顾客名和商品名查询
        [HttpGet("query")]
        public ActionResult<List<Order>> GetOrders(string user_name, string product_name)
        {
            var query = orderDb.Orders.Include("OrderItems");

            if(user_name!=null)
            {
                query = query.Where(order => order.Name==user_name);
            }
            if(product_name!=null)
            {
                //query = query.Where(order => order.OrderItems.Exists(item => item.Name == product_name));
                var product_query = from order in orderDb.Orders
                            join item in orderDb.Items on order.Order_ID equals item.ItemID
                            where item.Name.Contains(product_name)
                            select order;
                List<Order> result = product_query.ToList();
                foreach (var order in result)
                {
                    order.OrderItems = GetItems(order.Order_ID);
                }
                return result;
            }
            return query.ToList();
        }

        // POST: api/order/add
        [HttpPost("add")]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        // PUT: api/order/update/{id}
        [HttpPut("update/{id}")]
        public ActionResult<Order> PutTodoItem(int id, Order order)
        {
            if (id != order.Order_ID)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // DELETE: api/order/delete/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteTodoItem(int id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Order_ID == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }
}

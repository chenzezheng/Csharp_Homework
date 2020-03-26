using System;
using System.Collections.Generic;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService(new List<Order>());
            Console.Write("请输入订单数量：");
            int totalOrder = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= totalOrder; i ++ )
            {
                Console.Write("请输入订单号：");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("请输入顾客姓名：");
                string name = Console.ReadLine();
                Console.Write("请输入顾客地址：");
                string address = Console.ReadLine();
                Customer customer = new Customer(name, address);
                Console.Write("请输入不同商品的数量：");
                int totalCommodity = Convert.ToInt32(Console.ReadLine());
                List<OrderItem> orderItems = new List<OrderItem>();
                for (int j = 1; j <= totalCommodity; j ++ )
                {
                    Console.Write("请输入商品名：");
                    string commodityName = Console.ReadLine();
                    Console.Write("请输入商品单价：");
                    double commodityPrice = Convert.ToDouble(Console.ReadLine());
                    Commodity commodity = new Commodity(commodityName, commodityPrice);
                    Console.Write("请输入该商品的数量：");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    OrderItem orderItem = new OrderItem(commodity, quantity);
                    orderItems.Add(orderItem);
                }
                Order order = new Order(id, customer, DateTime.Now, orderItems);
                try
                {
                    orderService.AppendOrder(order);
                    Console.WriteLine("\n已添加订单:");
                    Console.WriteLine(order);
                }
                catch (OrderException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}

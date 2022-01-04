using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionProgrammingDemo
{
    public class Program
    {
        //private readonly IDemo _demo;
        //public Program(IDemo demo)
        //{
        //     _demo = demo;
        //}
        private static List<Order> OrdersforProcessing = new List<Order>()
        {
            new Order() { Name= "Product One", Price = 20, Quantity = 30 },
            new Order() { Name= "Product Two", Price = 100, Quantity = 15 },
            new Order() { Name= "Product Three", Price = 50, Quantity = 8 }
        };
        public static void Main(string[] args)
        {            
            var result = new Demo().CalculateDiscounts(OrdersforProcessing);
            PrintOrders(result.ToList(), "final Discounts Declarative");
            var result2 = new DemoImparative().CalculateDiscounts(OrdersforProcessing);
            PrintOrders(result2.ToList(), "final Discounts Imparative");
            var result3 = new DemoImparative2().CalculateDiscounts(OrdersforProcessing);
            PrintOrders(result3.ToList(), "final Discounts Imparative 2");

        }

        private static void PrintOrders(List<Order> items, string textMsg)
        {
            StringBuilder res = new StringBuilder();
            items.ForEach(st =>
            {
                res.Append($"Name: {st.Name} \t => ( Price: {st.Price} LE, Qunatatiy: {st.Quantity}) \n" +
                    $" Discount: {st.Discount} LE \n " +
                    $" ------------------------- \n");
            });
            Console.WriteLine($"{textMsg}: \n {res} \n");
        }
    }
}

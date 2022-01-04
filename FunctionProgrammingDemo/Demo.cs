using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using static System.Tuple;
using static System.ValueTuple;

namespace FunctionProgrammingDemo
{
    public class Demo: IDemo
    {
        public IEnumerable<Order> CalculateDiscounts(IEnumerable<Order> OrdersforProcessing)
        {
            return OrdersforProcessing.Select((x) => GetOrderwithDiscount(x, GetDiscountRules()));
        }
        private Order GetOrderwithDiscount(Order order, List<(Func<Order, bool> QualifyingCondition, Func<Order, double> GetDiscount)> Rules)
        {
            var discounts = Rules.Where(a => a.QualifyingCondition(order)).Select(b => b.GetDiscount(order)).OrderBy(x => x).Take(3);
            order.Discount = discounts.Any() ? discounts.Average() : 0;
            //order.Discount = discounts.LastOrDefault();
            return order;
        }
        private List<(Func<Order, bool> QualifyingCondition, Func<Order, double> GetDiscount)> GetDiscountRules()
        {
            var DiscountRules = new List<(Func<Order, bool> QualifyingCondition, Func<Order, double> GetDiscount)>
            { 
              (isAQualified, A),
              (isBQualified, B),
              (isCQualified, C),
              (isDQualified, D),
              //(isAQualified, C)
            };
            return DiscountRules;
        }



        //if Quantity more than 10 
        public bool isAQualified(Order r)
        {
            return r.Quantity > 10;
        }
        //get 50% Discount
        public double A(Order r)
        {
            return r.Price * 0.5;
        }
        //if Price more than 100 
        public bool isBQualified(Order r)
        {
            return r.Price >= 100;
        }
        //get 40% Discount Up to 40 LE
        public double B(Order r)
        {
            return (r.Price * 0.4) > 40 ? 40 : (r.Price * 0.4);
        }
        //if Price more than 20 and less than 60 
        public bool isCQualified(Order r)
        {
            return r.Price > 20 && r.Price < 60;
        }
        //get 25% Discount Up to 30 LE
        public double C(Order r)
        {
            return (r.Price * 0.25) > 30 ? 30 : (r.Price * 0.25);
        }
        //if Price more than 100 and Quantity more than 14 
        public bool isDQualified(Order r)
        {
            return r.Price >= 100 && r.Quantity > 14;
        }
        //get 70% Discount
        public double D(Order r)
        {
            return r.Price * 0.7;
        }


    }


    public class Order
    {
        public string Name;
        public double Quantity;
        public double Price;
        public double Discount;
    }


}
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
    public class DemoImparative2: IDemo
    {

        public IEnumerable<Order> CalculateDiscounts(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                var listOfDiscount = GetOrderDiscounts(order);
                order.Discount = listOfDiscount.Any() ? listOfDiscount.Take(3).Average() : 0;
                yield return order;
            }
        }
        private List<double> GetOrderDiscounts(Order order)
        {
            var listOfDiscount = new List<double>();
            if (isAQualified(order)) listOfDiscount.Add(A(order));
            if (isBQualified(order)) listOfDiscount.Add(B(order));
            if (isCQualified(order)) listOfDiscount.Add(C(order));
            if (isDQualified(order)) listOfDiscount.Add(D(order));
            return listOfDiscount;
        }


        //if Quantity more than 10 get 50% Discount
        public bool isAQualified(Order r)
        {
            return r.Quantity > 10;
        }
        public double A(Order r)
        {
            return r.Price * 0.5;
        }
        //if Price more than 100 get 40% Discount Up to 40 LE
        public bool isBQualified(Order r)
        {
            return r.Price >= 100;
        }
        public double B(Order r)
        {
            return (r.Price * 0.4) > 40 ? 40 : (r.Price * 0.4);
        }
        //if Price more than 20 and less than 60 get 25% Discount Up to 30 LE
        public bool isCQualified(Order r)
        {
            return r.Price > 20 && r.Price < 60;
        }
        public double C(Order r)
        {
            return (r.Price * 0.25) > 30 ? 30 : (r.Price * 0.25);
        }
        //if Price more than 100 and Quantity more than 14 get 70% Discount
        public bool isDQualified(Order r)
        {
            return r.Price >= 100 && r.Quantity > 14;
        }
        public double D(Order r)
        {
            return r.Price * 0.7;
        }


    }



}
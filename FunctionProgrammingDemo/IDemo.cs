using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionProgrammingDemo
{
    public interface IDemo
    {
        IEnumerable<Order> CalculateDiscounts(IEnumerable<Order> OrdersforProcessing);
    }
}

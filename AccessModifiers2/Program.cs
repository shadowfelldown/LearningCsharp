using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers2
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            Amazon.RateCalculator calculator = new RateCalculator();
        }
    }
}

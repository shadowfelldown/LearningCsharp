using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Text();
            Text text = (Text)shape;

            
            //// StreamReader reader = new StreamReader(new FileStream);
           // var list = new ArrayList();
           // list.Add(1);
           // list.Add("Mosh");
           // list.Add(new Text());

           // var anotherList = new List<int>();
            Console.ReadKey();
        }
    }
}

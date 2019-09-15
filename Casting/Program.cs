using System;

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

using System;

namespace Inheritance
{
    public class Text : PresentationObject
    {
        public int FontSize { get; set; }
        public int FontName { get; set; }
        public void AddHyperlink(string URL)
        {
            Console.WriteLine("Hyperlink Added to " + URL);
        }
    }
}

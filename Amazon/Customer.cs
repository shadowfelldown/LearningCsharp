namespace Amazon
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public void Promote()
        {
            var calculator = new RateCalculator();
            var rating = calculator.Calculate(this);
        }
    }
}

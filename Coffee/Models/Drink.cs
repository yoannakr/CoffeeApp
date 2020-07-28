namespace Coffee.Models
{
    public class Drink
    {
        private string name;
        private decimal price;
        private int count;

        public string Name 
        {
            get => this.name;
            set
            {
                name = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            set
            {
                price = value;
            }
        }

        public int Count
        {
            get => this.count;
            set
            {
                count = value;
            }
        }
    }
}

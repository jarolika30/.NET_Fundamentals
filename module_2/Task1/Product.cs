namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Product)) return false;
            var other = obj as Product;

            return other.Name.Equals(Name) && other.Price == Price;
        }
    }
}

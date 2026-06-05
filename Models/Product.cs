namespace api_demo_e19.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double SuplierCost { get; set; } // expose to client
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

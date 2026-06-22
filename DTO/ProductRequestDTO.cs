namespace api_demo_e19.DTO
{
    public class ProductRequestDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double SuplierCost { get; set; }
        public int CategoryId { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, SuplierCost: {SuplierCost}, CategoryId: {CategoryId}";
        }
    }
}

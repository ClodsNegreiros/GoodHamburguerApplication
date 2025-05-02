namespace GoodHamburguerApplication.Domain.Entities
{
    public class Extra
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}

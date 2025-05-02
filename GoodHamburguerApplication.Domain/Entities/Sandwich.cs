namespace GoodHamburguerApplication.Domain.Entities
{
    public class Sandwich
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}

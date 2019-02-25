namespace Cardcraft.Microservice.Product.BusinessObject
{
    public class Card
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string DescriptionText { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsTrending { get; set; }
    }
}

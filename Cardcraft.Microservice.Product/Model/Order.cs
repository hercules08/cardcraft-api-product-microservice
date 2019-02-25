namespace Cardcraft.Microservice.Product.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Message { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public string UserProfileId { get; set; }
    }
}

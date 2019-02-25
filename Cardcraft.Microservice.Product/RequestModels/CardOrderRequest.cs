namespace Cardcraft.Microservice.Product.RequestModels
{
    public class CardOrderRequest
    {
        public string Email { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Message { get; set; }
        public int CardId { get; set; }
        public string UserProfileId { get; set; }
    }
}

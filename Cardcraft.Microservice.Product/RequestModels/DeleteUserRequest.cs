namespace Cardcraft.Microservice.Product.RequestModels
{
	public class DeleteUserRequest
	{
		public string UserProfileId { get; set; }
		public string AccessToken { get; set; }
	}
}

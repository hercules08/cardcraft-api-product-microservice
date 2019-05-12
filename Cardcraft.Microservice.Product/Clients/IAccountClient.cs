using Cardcraft.Microservice.aCore;
using Cardcraft.Microservice.Product.RequestModels;
using System.Threading.Tasks;

namespace Cardcraft.Microservice.Product.Clients
{
    public interface IAccountClient
    {
        Task<IAPIResponse> UpdateUserCredits(UpdateUserCreditRequest request);
    }
}

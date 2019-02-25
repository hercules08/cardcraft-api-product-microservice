using Cardcraft.Microservice.Product.BusinessObject;
using Cardcraft.Microservice.Product.Model;

namespace Cardcraft.Microservice.Product.Persistance
{
    public interface IProductRepository
    {
        bool AddOrder(Order order);
        void IncrementCardView(int cardId);
    }
}

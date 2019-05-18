using Cardcraft.Microservice.aCore;
using Cardcraft.Microservice.Product.BusinessLogic.Interface;
using Microsoft.Extensions.Logging;

namespace Cardcraft.Microservice.Product.BusinessLogic
{
    public class ProductManager : ActionManagerBase, IProductManager
    {
        public ProductManager(ILogger<ProductManager> logger) : base(logger)
        {
        }
    }
}

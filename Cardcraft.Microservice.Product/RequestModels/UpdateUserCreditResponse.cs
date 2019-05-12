using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardcraft.Microservice.Product.RequestModels
{
    public class UpdateUserCreditResponse
    {
        public int CreditCount { get; set; }
        public int CreditsAdded { get; set; }
    }
}

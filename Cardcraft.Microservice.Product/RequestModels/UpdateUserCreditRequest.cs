using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardcraft.Microservice.Product.RequestModels
{
    public class UpdateUserCreditRequest
    {
        public string UserProfileId { get; set; }
        public int NumOfCreditsToAdd { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardcraft.Microservice.Product.Model
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagValue { get; set; }
        public ICollection<CardTag> CardTags { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardcraft.Microservice.Product.Model
{
    public class CardTag
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

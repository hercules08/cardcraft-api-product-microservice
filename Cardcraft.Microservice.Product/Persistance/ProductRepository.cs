using Cardcraft.Microservice.Product.Context;
using Cardcraft.Microservice.Product.Model;
using System;
using Card = Cardcraft.Microservice.Product.Model.Card;

namespace Cardcraft.Microservice.Product.Persistance
{
    public class ProductRepository : IProductRepository
    {
        private ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public bool AddOrder(Order order)
        {
            bool success = false;

            try
            {
                _context.Add(order);
                _context.SaveChanges();
                success = true;
            }catch(Exception ex)
            {
            }

            return success;
        }

        public void IncrementCardView(int cardId)
        {
            Card foundCard = _context.Cards.Find(cardId);

            try
            {
                if (foundCard != null)
                {
                    foundCard.ViewCount = foundCard.ViewCount + 1;
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            { }
        }
    }
}

using Cardcraft.Microservice.Product.Context;
using Cardcraft.Microservice.Product.Model;
using Cardcraft.Microservice.Product.Persistance;
using Cardcraft.Microservice.Product.RequestModels;
using Cardcraft.Microservice.Product.Stubs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cardcraft.Microservice.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private ProductDbContext _context;

        public ProductController(ProductDbContext context)//(IProductRepository productRepository)
        {
            //_productRepository = productRepository;
            _context = context;
        }

        //[HttpPost]
        //[Route("AddCard")]
        //public ActionResult AddCard()
        //{

        //}

        [HttpGet]
        [Route("GetTrendingCards")]
        public ActionResult GetTrendingCards()
        {
            //
            List<BusinessObject.Card> trendingCards = _context.Cards.OrderByDescending(x => x.ViewCount)
                .Take(50).Select( x => new BusinessObject.Card {
                    Category = x.Category,
                    DescriptionText = x.DescriptionText,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            if (trendingCards == null ||
                trendingCards.Count == 0)
                trendingCards = CardsStub.TrendingCards;

            return Ok(trendingCards);
        }

        [HttpGet]
        [Route("GetAllCards")]
        public ActionResult GetAllCards(int? searchOffset)
        {
            if (searchOffset is null)
                searchOffset = 0;

            //
            List<BusinessObject.Card> trendingCards = _context.Cards.OrderBy(x => x.Id).Skip((int)searchOffset)
                .Take(50).Select(x => new BusinessObject.Card
                {
                    Category = x.Category,
                    DescriptionText = x.DescriptionText,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            if (trendingCards == null ||
                trendingCards.Count == 0)
                trendingCards = CardsStub.TrendingCards;

            return Ok(trendingCards);
        }

        [HttpGet]
        [Route("SearchCards")]
        public ActionResult SearchCards(string searchTerms)
        {
            return Ok();
        }

        [HttpPost]
        [Route("OrderCard")]
        public ActionResult OrderCard([FromBody]CardOrderRequest model)
        {
            Order order = model.Adapt<Order>();
            bool success = _productRepository.AddOrder(order);
            return Ok(success);
        }

        [HttpGet]
        [Route("IncermentView")]
        public ActionResult IncrementView(int cardId)
        {
            _productRepository.IncrementCardView(cardId);
            return Ok();
        }

        [HttpGet]
        [Route("TestHealth")]
        public ActionResult TestHealth(bool throwException)
        {
            if (throwException)
                throw new Exception();

            return Ok();
        }
    }
}
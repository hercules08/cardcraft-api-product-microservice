using Cardcraft.Microservice.Product.Model;
using Cardcraft.Microservice.Product.Persistance;
using Cardcraft.Microservice.Product.RequestModels;
using Cardcraft.Microservice.Product.Stubs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cardcraft.Microservice.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController()//(IProductRepository productRepository)
        {
            //_productRepository = productRepository;
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
            return Ok(CardsStub.TrendingCards);
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
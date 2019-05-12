using Cardcraft.Microservice.aCore;
using Cardcraft.Microservice.Product.Clients;
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
using System.Threading.Tasks;

namespace Cardcraft.Microservice.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private ProductDbContext _context;
        private IAccountClient _accountClient;

        public ProductController(ProductDbContext context
            , IProductRepository productRepository
            , IAccountClient client)
        {
            _productRepository = productRepository;
            _context = context;
            _accountClient = client;
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
            List<BusinessObject.Card> trendingCards = _context.Cards.OrderByDescending(x => x.ViewCount)
                .Where(x => x.ViewCount == 2).Select(x => new BusinessObject.Card
                {
                    Category = x.Category,
                    DescriptionText = x.DescriptionText,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            ////
            //List<BusinessObject.Card> allCards = _context.Cards.OrderBy(x => x.Id).Skip((int)searchOffset)
            //    .Where(x =>
            //    x.Category == "Birthday"
            //    || x.Category == "Graduation"
            //    || x.Category == "Mother's Day"
            //    || x.Category == "Camping").Select(x => new BusinessObject.Card
            //    {
            //        Category = x.Category,
            //        DescriptionText = x.DescriptionText,
            //        ImageUrl = x.ImageUrl,
            //        Id = x.Id,
            //        Name = x.Name
            //    }).ToList();

            //
            List<BusinessObject.Card> BirthdayCards = _context.Cards.OrderBy(x => x.Id).Skip((int)searchOffset)
                .Where(x =>
                x.Category == "Birthday").Select(x => new BusinessObject.Card
                {
                    Category = x.Category,
                    DescriptionText = x.DescriptionText,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            //
            List<BusinessObject.Card> GraduationCards = _context.Cards.OrderBy(x => x.Id).Skip((int)searchOffset)
                .Where(x => x.Category == "Graduation").Select(x => new BusinessObject.Card
                {
                    Category = x.Category,
                    DescriptionText = x.DescriptionText,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            //
            List<BusinessObject.Card> MothersCards = _context.Cards.OrderBy(x => x.Id).Skip((int)searchOffset)
                .Where(x => x.Category == "Mother's Day").Select(x => new BusinessObject.Card
                {
                    Category = x.Category,
                    DescriptionText = x.DescriptionText,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            //
            List<BusinessObject.Card> CampingCards = _context.Cards.OrderBy(x => x.Id).Skip((int)searchOffset)
                .Where(x => x.Category == "Camping").Select(x => new BusinessObject.Card
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


            trendingCards.AddRange(BirthdayCards);
            trendingCards.AddRange(GraduationCards);
            trendingCards.AddRange(MothersCards);
            trendingCards.AddRange(CampingCards);
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
        public async Task<IActionResult> OrderCard([FromBody]CardOrderRequest model)
        {
            Order order = model.Adapt<Order>();
            order.CreatedDate = DateTime.UtcNow;
            bool success = _productRepository.AddOrder(order);

            if (success)
            {
                IAPIResponse response = await _accountClient.UpdateUserCredits(new UpdateUserCreditRequest
                {
                    UserProfileId = model.UserProfileId,
                    NumOfCreditsToAdd = -1
                });

                if(response.Success)
                {
                    APIResponse<UpdateUserCreditResponse> creditResponse = (APIResponse<UpdateUserCreditResponse>)response;
                    return Ok(creditResponse);
                }
            }

            return BadRequest();
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
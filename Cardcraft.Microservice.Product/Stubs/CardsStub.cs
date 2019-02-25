using Cardcraft.Microservice.Product.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardcraft.Microservice.Product.Stubs
{
    public class CardsStub
    {
        public static List<Card> TrendingCards
        { 
            get
            {
                return new List<Card>
                {
                    new Card{ Id = 1, ImageUrl="https://www.cardcraft.io/cards/valentines/we-are-better-together.png", DescriptionText="Like PB&J, let them know you're better when you're together!", Name="WE'RE BETTER TOGETHER - LOVE", Category="Valentine's Day" },
                    new Card{ Id = 2, ImageUrl="https://www.cardcraft.io/cards/valentines/coffee-love.png", DescriptionText="Let them know you love them a \"latte\" with this fun coffee-themed card!", Name="LOVE YOU A LATTE", Category="Valentine's Day" },
                    new Card{ Id = 3, ImageUrl="https://www.cardcraft.io/cards/valentines/rainbowvalentines.png", DescriptionText="Love makes you feel like a Rainbow? Send this card :)", Name="Rainbow Valentine", Category="Valentine's Day" },
                    new Card{ Id = 4, ImageUrl="https://www.cardcraft.io/cards/valentines/happyheartsday.jpg", DescriptionText="Your heart beats faster around them? Send this card", Name="Happy Hearts Day", Category="Valentine's Day" },
                    new Card{ Id = 5, ImageUrl="https://www.cardcraft.io/cards/valentines/heartsonhearts.png", DescriptionText="What's better than love? Love on top of love!", Name="Hearts on Hearts", Category="Valentine's Day" },
                    new Card{ Id = 6, ImageUrl="https://www.cardcraft.io/cards/valentines/heartsstars.png", DescriptionText="Give this card to the one that shines like a star ;)", Name="Hearts & Stars", Category="Valentine's Day" },
                    new Card{ Id = 7, ImageUrl="https://www.cardcraft.io/cards/valentines/ilikeyouiguess.png", DescriptionText="On the fence? This card will do!", Name="Like I Guess?", Category="Valentine's Day" },
                    new Card{ Id = 8, ImageUrl="https://www.cardcraft.io/cards/valentines/loveyou3.png", DescriptionText="Do you Love, Love, Love them? This is the card for you.", Name="Love You 3x", Category="Valentine's Day" },
                    new Card{ Id = 9, ImageUrl="https://www.cardcraft.io/cards/valentines/oneinamillion.png", DescriptionText="Millions of hearts in the world...who is your 1 in a million?", Name="One in a Million", Category="Valentine's Day" },
                    new Card{ Id = 10, ImageUrl="https://www.cardcraft.io/cards/valentines/pastelhearts.png", DescriptionText="Colorful love? They will love this card!", Name="Pastel Hearts", Category="Valentine's Day" },
                };
            }
        }
    }
}

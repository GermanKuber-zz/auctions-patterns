using System;
using System.Collections.Generic;
using System.Linq;
using Auctions.Collections;
using Auctions.Context;
using Auctions.Domain.Interfaces;
using Auctions.Entities;
using Xunit;

namespace Auctions.Tests
{
    public class AuctionsTests
    {
        [Fact]
        public void Should_Add_New_Round()
        {
            var context = new ContextDb();
            IAuction auctionFirst = context.Auctions.FirstOrDefault();


            var listOf = new List<Provider> {new Provider {Id = 1}, new Provider {Id = 2}};
            var providers = new AuctionProviders(listOf);
            auctionFirst.AddProvider(listOf.First());
            auctionFirst.AddProvider(listOf[1]);

            auctionFirst.AddRound(providers);

            Assert.Equal(auctionFirst.Rounds.All().Count(), 1);
        }
        
        [Fact]
        public void Should_Add_New_Round_With_Two_Providers()
        {
            var context = new ContextDb();
            IAuction auctionFirst = context.Auctions.FirstOrDefault();


            var listOf = new List<Provider> {new Provider {Id = 1}, new Provider {Id = 2}};
            var providers = new AuctionProviders(listOf);
            auctionFirst.AddProvider(listOf.First());
            auctionFirst.AddProvider(listOf[1]);

            auctionFirst.AddRound(providers);

            Assert.Equal(auctionFirst.Rounds.All().First().Providers.All().Count(), 2);
        }
        
        [Fact]
        public void Should_Add_Other_Round_More()
        {
            var context = new ContextDb();
            IAuction auctionFirst = context.Auctions.FirstOrDefault();


            var listOf = new List<Provider> {new Provider {Id = 1}, new Provider {Id = 2}};
            var providers = new AuctionProviders(listOf);
            auctionFirst.AddProvider(listOf.First());
            auctionFirst.AddProvider(listOf[1]);

            auctionFirst.AddRound(providers);
            

            Assert.Equal(auctionFirst.Rounds.All().First().Providers.All().Count(), 2);
        }
    }
}
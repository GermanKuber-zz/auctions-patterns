using Auctions.Collections;
using Auctions.Domain;
using Auctions.Domain.Interfaces;
using Auctions.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Auctions.Tests.Strategies
{
    public class InviteWonProviderInPreviousRoundTests
    {
        IInviteStrategy _sut;
        Provider _provider1;
        Provider _providerToAdd;
        private Mock<IHasRound> _mockHasRound;
        private AuctionProviders _auctionProviders;
        private Auction _auction;
        private Round _round;
        private Round _round1;

        public InviteWonProviderInPreviousRoundTests()
        {
            _sut = new InviteProviderToSecondLastRoundStrategy();
            _provider1 = new Provider { Id = 1 };
            _providerToAdd = new Provider { Id = 2 };
            _mockHasRound = new Mock<IHasRound>();
            _mockHasRound.Setup(x => x.Rounds.All());
            _auctionProviders = new AuctionProviders(new List<Provider> { _provider1 });
            _auction = new Auction();
            _round = new Round(_auction, _auctionProviders, _auctionProviders);
            _round1 = new Round(_auction, _auctionProviders, _auctionProviders);
        }

        [Fact]
        public void Should_Get_All_providers()
        {
            var listToReturn = new List<Round> { _round, _round1 };
            _mockHasRound.Setup(x => x.Rounds.All()).Returns(listToReturn);
            _sut.Invite(_mockHasRound.Object, _provider1);

            _mockHasRound.VerifyAll();
        }


        [Fact]
        public void Should_Add_Providers_In_The_Last_Round()
        {
            var listToReturn = new List<Round> { _round, _round1 };
            _mockHasRound.Setup(x => x.Rounds.All()).Returns(listToReturn);
            _sut.Invite(_mockHasRound.Object, _provider1);

            Assert.Equal(2, _round.Providers.All().Count);
        }
    }
}

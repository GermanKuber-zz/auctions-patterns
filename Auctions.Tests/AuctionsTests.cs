using System;
using System.Collections.Generic;
using System.Linq;
using Auctions.Collections;
using Auctions.Context;
using Auctions.Domain.Interfaces;
using Auctions.Entities;
using Auctions.Status;
using Auctions.Status.UpdateStatus.Interfaces;
using Xunit;

namespace Auctions.Tests
{
    public class AuctionsTests
    {
        private Provider _provider1 = new Provider { Id = 1 };
        private Provider _provider2 = new Provider { Id = 2 };
        private Provider _provider3 = new Provider { Id = 3 };
        private List<Provider> _completeListOfProvices;
        private AuctionProviders _providers;

        IAuction _sut;
        public AuctionsTests()
        {
            _sut = AuctionFactory.Create();
            _completeListOfProvices = new List<Provider> { _provider1, _provider2, _provider3 };
            _providers = new AuctionProviders(_completeListOfProvices);
            _sut.AddProvider(_provider1, new CheckWhatInviteStrategy(), new InviteProviderToSecondLastRoundStrategy());

        }
        [Fact]
        public void Should_Add_New_Round()
        {
            _sut.AddProvider(_provider2, new CheckWhatInviteStrategy(), new InviteProviderToSecondLastRoundStrategy());

            _sut.AddRound(_providers);

            Assert.Single(_sut.Rounds.All());
        }

        [Fact]
        public void Should_Add_New_Round_With_Two_Providers()
        {
            var providers = new AuctionProviders(new List<Provider> { _provider1, _provider2 });
            _sut.AddProvider(_provider2, new CheckWhatInviteStrategy(), new InviteProviderToSecondLastRoundStrategy());

            _sut.AddRound(providers);

            Assert.Equal(2, _sut.Rounds.All().First().Providers.All().Count());
        }

        [Fact]
        public void Should_Add_Other_Round_More()
        {

            _sut.AddProvider(_provider2, new CheckWhatInviteStrategy(), new InviteProviderToSecondLastRoundStrategy());

            _sut.AddRound(_providers);

            Assert.Equal(3, _sut.Rounds.All().First().Providers.All().Count());
        }


        [Fact]
        public void Should_Add_Other_Round_More_2()
        {
            _sut.AddProvider(_provider2, new CheckWhatInviteStrategy(), new InviteProviderToSecondLastRoundStrategy());

            _sut.AddRound(_providers);

            Assert.Equal(3, _sut.Rounds.All().First().Providers.All().Count());
        }

        [Fact]
        public void Should_Update_Status_To_Close()
        {
            IAuctionUpdateStatusStrategy closeStatusUpdate = new AuctionUpdateStatusClose(DateTime.Now);
            _sut.ChangeStatus(closeStatusUpdate);
            Assert.Equal(typeof(CloseStatus), _sut.AuctionStatus.GetType());
        }
        [Fact]
        public void Should_Add_Providers_Execute_Alert_Decorator()
        {
            IInviteStrategy closeStatusUpdate = new InviteProviderToSecondLastRoundStrategy();

            DecoratorInviteStrategy docoratorAlert = new AlertDecoratorInviteStrategy();
            _sut.AddRound(_providers);
            docoratorAlert.SetStrategyToDecorator(closeStatusUpdate);
            _sut.AddProvider(_provider3,  new CheckWhatInviteStrategy(), docoratorAlert);
            Assert.Equal(typeof(CloseStatus), _sut.AuctionStatus.GetType());
        }


    


    }
}
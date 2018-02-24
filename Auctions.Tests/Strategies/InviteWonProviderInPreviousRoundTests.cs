using Auctions.Domain.Interfaces;
using Auctions.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Auctions.Tests.Strategies
{
  public  class InviteWonProviderInPreviousRoundTests
    {
        IInviteStrategy _sut;
        Provider _prvovider1;
        Provider _prvovider2;
        public InviteWonProviderInPreviousRoundTests()
        {
            _sut = new InviteProviderToBeforeLastRoundStrategy();
            _prvovider1 = new Provider { Id = 1 };
            _prvovider2 = new Provider { Id = 2 };


        }

        [Fact]
        public void Should_Add_New_Round_With_Two_Providers()
        {
            _sut.

            Assert.Equal(2, _sut.Rounds.All().First().Providers.All().Count());
        }
    }
}

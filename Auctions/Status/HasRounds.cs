using System;
using Auctions.Collections;
using Auctions.Domain;
using Auctions.Entities;

namespace Auctions.Status
{
    public class HasRounds : RoundPattern
    {
        private readonly IHasRound _objectWithRouds;

        public HasRounds(IHasRound objectWithRouds)
        {
            _objectWithRouds = objectWithRouds;
        }

        public void AddProvider(Provider provider, Action<Provider> callBackIfNotHas) =>
            _objectWithRouds.AddProvider(provider);

      

        public RoundPattern AddRoud(Auction auction, AuctionProviders providers)
        {
            _objectWithRouds.Rounds.Add(auction,  providers);
            return this;
        }
    }
}
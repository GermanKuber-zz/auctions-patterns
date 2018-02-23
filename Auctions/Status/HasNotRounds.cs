using System;
using Auctions.Collections;
using Auctions.Domain;
using Auctions.Domain.Interfaces;
using Auctions.Entities;

namespace Auctions.Status
{
    public class HasNotRounds : RoundPattern
    {
        public HasNotRounds()
        {
        }

        public void AddProvider(Provider provider, Action<Provider> callBackIfNotHas) =>
            callBackIfNotHas(provider);

        public RoundPattern AddRoud(Auction auction, AuctionProviders providers)
        {
            var newRound = new HasRounds(auction);
            return newRound.AddRoud(auction,providers);
        }
    }
}
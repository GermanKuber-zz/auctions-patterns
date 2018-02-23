using System;

namespace Auctions
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
using System;

namespace Auctions
{
    public interface RoundPattern
    {
        void AddProvider(Provider provider, Action<Provider> callBackIfNotHas);
        RoundPattern AddRoud(Auction auction, AuctionProviders providers);
    }
}
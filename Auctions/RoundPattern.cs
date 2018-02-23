using System;
using Auctions.Collections;
using Auctions.Domain;
using Auctions.Entities;

namespace Auctions
{
    public interface RoundPattern
    {
        void AddProvider(Provider provider, Action<Provider> callBackIfNotHas);
        RoundPattern AddRoud(Auction auction, AuctionProviders providers);
    }
}
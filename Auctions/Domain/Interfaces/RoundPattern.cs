using System;
using Auctions.Collections;
using Auctions.Entities;

namespace Auctions.Domain.Interfaces
{
    public interface RoundPattern
    {
        void AddProvider(Provider provider, Action<Provider> callBackIfNotHas);
        RoundPattern AddRoud(Auction auction, AuctionProviders providers);
    }
}
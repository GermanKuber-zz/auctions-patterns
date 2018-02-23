using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auctions
{
    public class Round : RoundEntity
    {
        [NotMapped] private RoundAuctionProviders _providers;

        [NotMapped]
        public RoundAuctionProviders Providers
        {
            get
            {
                if (ProvidersC == null)
                    ProvidersC = new List<Provider>();
                _providers = new RoundAuctionProviders(Auction, ProvidersC);
                return _providers;
            }
        }

        public Round(Auction auction, AuctionProviders providers)
        {
            Auction = auction;

            Providers.Add(providers.All());
        }
    }
}
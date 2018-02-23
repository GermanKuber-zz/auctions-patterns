using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auctions
{
    public class Round : RoundEntity,IPreviousRound
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

        public Round(Auction auction, IProviders providers,AuctionProviders providersToAdd)
        {
            Auction = auction;

            Providers.Add(providersToAdd.All());
        }
    }

    public interface IPreviousRound
    {
        RoundAuctionProviders Providers { get; }
    }

    public class VoidPreviousRound : IPreviousRound
    {
        public RoundAuctionProviders Providers { get; }
    }
}
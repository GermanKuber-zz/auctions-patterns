using System;
using System.Collections.Generic;
using System.Linq;
using Auctions.Domain;
using Auctions.Entities;

namespace Auctions.Collections
{
    public class RoundAuctionProviders : IProviders
    {
        readonly Auction _auction;

        readonly List<Provider> _providers;

        public RoundAuctionProviders(Auction auction, List<Provider> providers)
        {
          
            _providers = providers;

            this._auction = auction;
        }
        public void Add(Provider provider)
        {
            _providers.Add(provider);
        }

        public bool HasListOfProviders(IEnumerable<Provider> providers)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<Provider> providers)
        {
            if (!_auction.Providers.HasListOfProviders(providers))
                throw new ArgumentException(nameof(providers));
            
            _providers.AddRange(providers);

        }
        public ICollection<Provider> All() => _providers.ToList();

        public int Count() => _providers.ToList().Count();
    }
}
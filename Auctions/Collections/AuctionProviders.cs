using System;
using System.Collections.Generic;
using System.Linq;
using Auctions.Entities;

namespace Auctions.Collections
{
    public class AuctionProviders : IProviders
    {
        private readonly List<Provider> _providers;


        public AuctionProviders(List<Provider> providers)
        {
            if (providers == null)
                throw new ArgumentNullException(nameof(providers));
            _providers = providers;
        }

        public void Add(Provider provider) => _providers.Add(provider);
        public ICollection<Provider> All() => _providers.ToList();

        public bool HasListOfProviders(IEnumerable<Provider> providers) =>
            _providers.All(x => providers.Any(s => s.Id == x.Id));

        public void Add(IEnumerable<Provider> providers)
        {
            throw new NotImplementedException();
        }

        public int Count() => _providers.Count();
    }
}
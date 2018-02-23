using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public class AuctionProviders :IProviders
    {
        private readonly List<Provider> _providers;


        public AuctionProviders(List<Provider> providers)
        {
            if (providers == null)
                throw new ArgumentNullException(nameof(providers));
            _providers = providers;
        }

        public void Add(Provider provider) => _providers.Add(provider);
        public IEnumerable<Provider> All() => _providers.ToList();

    }

    public interface IProviders
    {
        void Add(Provider provider);
        IEnumerable<Provider> All();
    }
}
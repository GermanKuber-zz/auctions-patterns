using System.Collections.Generic;

namespace Auctions
{
    public interface IProviders
    {
        void Add(Provider provider);
        IEnumerable<Provider> All();
        bool HasListOfProviders(IEnumerable<Provider> providers);
        void Add(IEnumerable<Provider> providers);
    }
}
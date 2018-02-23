using System.Collections.Generic;
using Auctions.Entities;

namespace Auctions.Collections
{
    public interface IProviders
    {
        void Add(Provider provider);
        IEnumerable<Provider> All();
        bool HasListOfProviders(IEnumerable<Provider> providers);
        void Add(IEnumerable<Provider> providers);
    }
}
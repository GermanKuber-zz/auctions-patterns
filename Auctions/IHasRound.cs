using Auctions.Collections;
using Auctions.Entities;

namespace Auctions
{
    public interface IHasRound
    {
        Rounds Rounds { get; }
        void AddProvider(Provider provider);
    }
}
using Auctions.Collections;
using Auctions.Entities;

namespace Auctions.Domain.Interfaces
{
    public interface IHasRound
    {
        Rounds Rounds { get; }
    }
}
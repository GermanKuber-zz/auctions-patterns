using Auctions.Entities;

namespace Auctions.Domain.Interfaces
{
    public interface ICheckWhatInviteStrategy
    {
        bool CanInvite(IHasRound hasRound, Provider provider);
    }
}
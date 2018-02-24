using Auctions.Entities;

namespace Auctions.Domain.Interfaces
{
    public interface IInviteStrategy
    {
        void Invite(IHasRound hasRound, Provider provider);
    }
}
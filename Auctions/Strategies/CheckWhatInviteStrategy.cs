using Auctions.Entities;

namespace Auctions.Domain.Interfaces
{
    public class CheckWhatInviteStrategy : ICheckWhatInviteStrategy
    {
        public bool CanInvite(IHasRound hasRound, Provider provider)
        {
            return true;
        }
    }
}
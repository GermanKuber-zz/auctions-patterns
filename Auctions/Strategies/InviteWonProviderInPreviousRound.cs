using Auctions.Entities;

namespace Auctions.Domain.Interfaces
{
    public class InviteWonProviderInPreviousRound : IInviteStrategy
    {
        public void Invite(IHasRound hasRound, Provider provider)
        {
            var round = hasRound.Rounds.Last();
            round.Providers.Add(provider);
        }
    }
}
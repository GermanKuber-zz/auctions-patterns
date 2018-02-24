using Auctions.Entities;
using System.Linq;

namespace Auctions.Domain.Interfaces
{
    public class InviteProviderToSecondLastRoundStrategy : IInviteStrategy
    {
        public void Invite(IHasRound hasRound, Provider provider)
        {
            var secondLast = hasRound.Rounds.All().Reverse().Skip(1).FirstOrDefault();

            if (secondLast != null)
                secondLast.Providers.Add(provider);
        }
    }
}
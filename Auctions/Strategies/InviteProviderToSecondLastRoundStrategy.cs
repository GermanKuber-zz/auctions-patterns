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

    public class DecoratorInviteStrategy : IInviteStrategy
    {
        private  IInviteStrategy _strategy;
        public void SetStrategyToDecorator(IInviteStrategy strategy) {
            _strategy = strategy;
        }
        public virtual void Invite(IHasRound hasRound, Provider provider)
        {
            _strategy?.Invite(hasRound, provider);
        }
    }

    public class AlertDecoratorInviteStrategy : DecoratorInviteStrategy
    {
        public override void Invite(IHasRound hasRound, Provider provider)
        {
            base.Invite(hasRound, provider);
        }
    }
}
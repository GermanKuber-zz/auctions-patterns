using Auctions.Collections;
using Auctions.Entities;
using Auctions.Status;

namespace Auctions.Domain.Interfaces
{
    public interface IAuction : IHasRound
    {
        IStatus AuctionStatus { get; set; }
        RoundPattern RoundPattern { get; }
        AuctionProviders Providers { get; }
        IRounds Rounds { get; }
        void AddProvider(Provider provider,
             ICheckWhatInviteStrategy checkWhatInviteStrategy,
             IInviteStrategy inviteStrategy);

        void Do();
        void AddRound(AuctionProviders providers);
    }
}
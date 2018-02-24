using Auctions.Collections;
using Auctions.Entities;
using Auctions.Status;
using Auctions.Status.UpdateStatus.Interfaces;

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
        void ChangeStatus(IAuctionUpdateStatusStrategy<IStatus> changeStatusStrategy);
    }
}
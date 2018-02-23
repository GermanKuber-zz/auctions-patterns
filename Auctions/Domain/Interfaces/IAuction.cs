using Auctions.Collections;
using Auctions.Entities;
using Auctions.Status;

namespace Auctions.Domain.Interfaces
{
    public interface IAuction : IHasRound
    {
        IStatus AuctionStatus { get; set; }
        RoundPattern RoundPattern { get;}
        AuctionProviders Providers { get; }
        Rounds Rounds { get; }
        
        void Do();
        void AddProvider(Provider provider);
        void AddRound(AuctionProviders providers);
    }
}
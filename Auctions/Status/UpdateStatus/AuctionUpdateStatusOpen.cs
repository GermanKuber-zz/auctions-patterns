using Auctions.Domain;
using System;

namespace Auctions.Status.UpdateStatus.Interfaces
{
    public class AuctionUpdateStatusOpen : IAuctionUpdateStatusStrategy
    {
        public void Update(Auction auction, Action<IStatus> updateStatusCallBack)
        {
            updateStatusCallBack(auction.AuctionStatus.Open());
        }
    }
}

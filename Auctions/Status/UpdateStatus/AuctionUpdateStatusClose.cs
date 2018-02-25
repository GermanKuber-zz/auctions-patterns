using Auctions.Domain;
using System;

namespace Auctions.Status.UpdateStatus.Interfaces
{
    public class AuctionUpdateStatusClose : IAuctionUpdateStatusStrategy
    {
        private readonly DateTime _dateTimeToClose;

        public AuctionUpdateStatusClose(DateTime dateTimeToClose)
        {
            _dateTimeToClose = dateTimeToClose;
        }


        public void Update(Auction auction,Action<IStatus> updateStatusCallBack)
        {
            updateStatusCallBack(auction.AuctionStatus.Close());
        }
    }
}

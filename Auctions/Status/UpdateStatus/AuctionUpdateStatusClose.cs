using System;

namespace Auctions.Status.UpdateStatus.Interfaces
{
    public class AuctionUpdateStatusClose : IAuctionUpdateStatusStrategy<CloseStatus>
    {
        private readonly DateTime _dateTimeToClose;

        public AuctionUpdateStatusClose(DateTime dateTimeToClose)
        {
            _dateTimeToClose = dateTimeToClose;
        }


        public void Update(Action<CloseStatus> updateStatusCallBack)
        {
            updateStatusCallBack(new CloseStatus());
        }
    }
}

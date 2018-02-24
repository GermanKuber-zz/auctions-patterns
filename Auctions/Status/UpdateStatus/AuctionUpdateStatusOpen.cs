using System;

namespace Auctions.Status.UpdateStatus.Interfaces
{
    public class AuctionUpdateStatusOpen : IAuctionUpdateStatusStrategy<OpenStatus>
    {
        public void Update(Action<OpenStatus> updateStatusCallBack)
        {
            updateStatusCallBack(new OpenStatus());
        }
    }
}

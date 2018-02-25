using Auctions.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auctions.Status.UpdateStatus.Interfaces
{
    public interface IAuctionUpdateStatusStrategy
        //<out TStatusToChange> where TStatusToChange: IStatus
    {
        void Update(Auction auction,Action<IStatus> updateStatusCallBack);
    }
}

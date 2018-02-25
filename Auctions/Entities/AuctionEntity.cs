using System;
using System.Collections.Generic;
using Auctions.Domain;
using Auctions.Domain.Interfaces;

namespace Auctions.Entities
{
    public class AuctionEntity
    {
        public int Id { get;  set; }
        public string Title { get; protected set; }
        public AuctionStatusEnum Status { get; protected set; }
        public List<Round> RoundsC { get; protected set; }
        public List<Provider> ProvidersC { get; protected set; }
        public DateTime ClosedDate { get; protected set; }

    }


    public class AuctionFactory {

        public  static IAuction Create()
        {

            return new Auction();
        }
    }
}
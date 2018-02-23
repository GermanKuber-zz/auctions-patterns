using System.Collections.Generic;

namespace Auctions
{
    public class AuctionEntity
    {
        public int Id { get;  set; }
        public string Title { get; protected set; }
        public AuctionStatusEnum Status { get; protected set; }
        public List<Round> RoundsC { get; protected set; }
        public List<Provider> ProvidersC { get; protected set; }

    }
}
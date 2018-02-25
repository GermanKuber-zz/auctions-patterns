using System;
using Auctions.Domain;

namespace Auctions.Status
{
    public class CloseStatus : IStatus
    {
        public AuctionStatusEnum Status { get; } = AuctionStatusEnum.Closed;

        public CloseStatus()
        {

        }
        public void Do()
        {
            Console.WriteLine("Estoy cerrado");
        }

        public IStatus Open() => new OpenStatus();

        public IStatus Close() => this;
    }
}
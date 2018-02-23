using System;
using Auctions.Status;

namespace Auctions
{
    public class OpenStatus : IStatus
    {
        public AuctionStatusEnum Status { get; } = AuctionStatusEnum.Open;

        public void Do()
        {
            Console.WriteLine("Estoy Abierto");

        }
    }
}
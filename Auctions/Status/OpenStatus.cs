using System;
using Auctions.Domain;

namespace Auctions.Status
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
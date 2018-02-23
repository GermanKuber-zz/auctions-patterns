using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ContextDb();

            IAuction auctionFirst = context.Auctions.FirstOrDefault();
            auctionFirst.Do();

            auctionFirst.AuctionStatus = new OpenStatus();
            auctionFirst.Do();

            var listOf = new List<Provider> {new Provider {Id = 1},new Provider {Id = 2}};
            var providers = new AuctionProviders(listOf);
            auctionFirst.AddProvider(listOf.First());

            auctionFirst.AddRound(providers);
            
//            IAcution auction = new Auction();
//            auction.AuctionStatus = new OpenStatus();
//            auction.Do();
//            auction.AuctionStatus = new CloseStatus();
//
//
//            context.Auctions.Add((Auction)auction);
            context.SaveChanges();
            Console.WriteLine("Hello World!");
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Auctions.Domain;

namespace Auctions.Collections
{
    public class Rounds
    {
        private readonly List<Round> _rounds;

        public Rounds(List<Round> rounds)
        {
            _rounds = rounds;
        }

        public void Add(Auction auction, AuctionProviders providers) =>
            _rounds.Add(new Round(auction,auction.Providers, providers));


        public IEnumerable<Round> All() =>
            _rounds.ToList();
    }
}
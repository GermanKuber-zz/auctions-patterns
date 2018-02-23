using System.Collections.Generic;

namespace Auctions
{
    public class Rounds
    {
        private readonly List<Round> _rounds;

        public Rounds(List<Round> rounds)
        {
            _rounds = rounds;
        }

        public void Add(Auction auction, AuctionProviders providers)
        {
            _rounds.Add(new Round(auction, providers));
        }
    }
}
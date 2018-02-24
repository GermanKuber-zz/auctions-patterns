using System.Collections.Generic;
using System.Linq;
using Auctions.Domain;
using Auctions.Domain.Interfaces;
using Auctions.Entities;

namespace Auctions.Collections
{
    public interface IRounds {
        void Add(Auction auction, AuctionProviders providers);
        void AddProvider(Provider provider, ICheckWhatInviteStrategy checkWhatInviteStrategy, IInviteStrategy inviteStrategy);
        ICollection<Round> All();
        Round Last();
    }
    public class Rounds: IRounds
    {
        private readonly Auction _auction;
        private readonly List<Round> _rounds;

        public Rounds(Auction auction, List<Round> rounds)
        {
            _auction = auction;
            _rounds = rounds;
        }

        public void Add(Auction auction, AuctionProviders providers) =>
            _rounds.Add(new Round(auction, auction.Providers, providers));
        public void AddProvider(Provider provider, ICheckWhatInviteStrategy checkWhatInviteStrategy, IInviteStrategy inviteStrategy)
        {
            if (checkWhatInviteStrategy.CanInvite(_auction,  provider))
                inviteStrategy.Invite(_auction, provider);

        }
        public ICollection<Round> All() =>
            _rounds.ToList();
        public Round Last() =>
                _rounds.Last();
    }
}
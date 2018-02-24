using System;
using Auctions.Collections;
using Auctions.Domain;
using Auctions.Domain.Interfaces;
using Auctions.Entities;

namespace Auctions.Status
{
    public class HasRounds : RoundPattern
    {
        private readonly IHasRound _objectWithRouds;

        public HasRounds(IHasRound objectWithRouds)
        {
            _objectWithRouds = objectWithRouds;
        }

        public void AddProvider(Provider provider, ICheckWhatInviteStrategy checkWhatInviteStrategy, IInviteStrategy inviteStrategy
            , Action<Provider> callBackIfNotHas) =>
            _objectWithRouds.Rounds.AddProvider(provider, checkWhatInviteStrategy, inviteStrategy);
     

        public RoundPattern AddRoud(Auction auction, AuctionProviders providers)
        {
            _objectWithRouds.Rounds.Add(auction,  providers);
            return this;
        }
    }
}
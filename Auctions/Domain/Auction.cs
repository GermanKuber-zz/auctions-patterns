﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Auctions.Collections;
using Auctions.Domain.Interfaces;
using Auctions.Entities;
using Auctions.Status;

namespace Auctions.Domain
{
    [NotMapped]
    public class Auction : AuctionEntity, IAuction
    {
        [NotMapped] private IStatus _auctionStatus;

        [NotMapped] public IRounds _rounds;
        [NotMapped]
        public IRounds Rounds
        {
            get
            {
                if (RoundsC == null)
                    RoundsC = new List<Round>();
                _rounds = new Rounds(this,RoundsC);
                return _rounds;
            }
        }
        [NotMapped] private AuctionProviders _providers;

        [NotMapped]
        public AuctionProviders Providers
        {
            get
            {
                if (ProvidersC == null)
                    ProvidersC = new List<Provider>();
                _providers = new AuctionProviders(ProvidersC);
                return _providers;
            }
        }

        [NotMapped]
        public IStatus AuctionStatus
        {
            get
            {
                if (_auctionStatus == null)
                    switch (Status)
                    {
                        case AuctionStatusEnum.Open:
                            return new OpenStatus();
                        case AuctionStatusEnum.Closed:
                            return new CloseStatus();
                    }
                return _auctionStatus;
            }
            set
            {
                Status = value.Status;
                _auctionStatus = value;
            }
        }

        [NotMapped] private RoundPattern _roundPattern;

        [NotMapped]
        public RoundPattern RoundPattern
        {
            get
            {
                if (_roundPattern == null)
                {
                    if (RoundsC != null && RoundsC.Count != 0)
                        _roundPattern = new HasRounds(this);
                    else
                        _roundPattern = new HasNotRounds(this);
                }
                return _roundPattern;
            }
        }

        public void Do() =>
            AuctionStatus.Do();

        public void AddRound(AuctionProviders providers) =>
            _roundPattern = _roundPattern.AddRoud(this, providers);

        public void AddProvider(Provider provider,
            ICheckWhatInviteStrategy checkWhatInviteStrategy,
             IInviteStrategy inviteStrategy) => RoundPattern.AddProvider(provider, checkWhatInviteStrategy, inviteStrategy,
            p => Providers.Add(provider));


    }
}
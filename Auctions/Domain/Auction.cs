using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Auctions.Collections;
using Auctions.Domain.Interfaces;
using Auctions.Entities;
using Auctions.Status;
using Auctions.Status.UpdateStatus.Interfaces;
using Optional;

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
                _rounds = new Rounds(this, RoundsC);
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

        private Option<DateTime> _closedDate;
        [NotMapped]
        public Option<DateTime> ClosedDates
        {
            get
            {

                if (_closedDate == null)
                    if (this.ClosedDateC == null)
                        _closedDate = Option.None<DateTime>();
                    else
                        _closedDate = Option.Some<DateTime>(ClosedDateC);
                return _closedDate;
            }
            private set
            {
                _closedDate = value;
                ClosedDateC = value.ValueOr(DateTime.Now);
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

        public void ChangeStatus(IAuctionUpdateStatusStrategy<IStatus> changeStatusStrategy) =>
            changeStatusStrategy.Update((newStatus) => this.AuctionStatus = newStatus);
    }
}
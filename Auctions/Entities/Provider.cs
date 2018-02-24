using Auctions.Domain;
using System;

namespace Auctions.Entities
{
    public class Provider
    {
        public int Id { get;  set; }
    }

    public class ProviderAuctionEntity {
        public Provider Provider { get; protected set; }
        public Auction Auction { get; protected set; }
        public bool Winner { get; protected set; }
        public string PurchaseOrderInfo { get; protected set; }
        public DateTime DateOrderInfo { get; protected set; }
        public int BudgetOrderInfo { get; protected set; }

        void Won(string purchaseOrderInfo, int budget, DateTime dateOrderInfo)
        {
            Winner = true;
            PurchaseOrderInfo = purchaseOrderInfo;
            BudgetOrderInfo = budget;
            DateOrderInfo = dateOrderInfo;
        }
    }
}
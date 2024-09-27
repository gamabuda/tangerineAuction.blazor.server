using System;
namespace tangerineAuction.blazor.server.Data
{
	public class Auction
	{
        public int Id { get; set; }              
        public AuctionItem Item { get; set; }  
        public List<Bid> Bids { get; set; }  
        public bool IsClosed { get; set; }      
        public bool PlaceBid(UserAccount user, decimal amount)
        {
            if (IsClosed || DateTime.Now >= Item.EndTime)
            {
                return false;
            }

            if (amount > Item.CurrentPrice)
            {
                Bid newBid = new Bid
                {
                    Amount = amount,
                    TimePlaced = DateTime.Now,
                    Bidder = user,
                    Item = Item
                };

                Bids.Add(newBid);
                Item.CurrentPrice = amount;
                Item.HighestBidder = user;

                return true;
            }

            return false;
        }

        public void CloseAuction()
        {
            if (DateTime.Now >= Item.EndTime)
            {
                IsClosed = true;
            }
        }
    }
}


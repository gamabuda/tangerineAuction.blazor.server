using System;
namespace tangerineAuction.blazor.server.Data
{
	public class Bid
	{
        public int Id { get; set; }       
        public decimal Amount { get; set; }
        public DateTime TimePlaced { get; set; }
        public UserAccount Bidder { get; set; }     
        public AuctionItem Item { get; set; }
    }
}


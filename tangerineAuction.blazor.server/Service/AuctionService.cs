using System;
using System.Threading;
using tangerineAuction.blazor.server.Data;

namespace tangerineAuction.blazor.server.Service
{
    public class AuctionService
    {
        private Timer _dailyResetTimer;
        private MailSenderService _mailSender;
        public List<Auction> Auctions { get; set; } = new List<Auction>();

        public AuctionService(MailSenderService mailSender)
        {
            _mailSender = mailSender;

            AuctionDailyReset();
            CreateDefultAuction();
        }

        public void CreateAuction(AuctionItem item)
        {
            Auction auction = new Auction
            {
                Item = item,
                Bids = new List<Bid>(),
                IsClosed = false
            };
            Auctions.Add(auction);
        }

        public List<Auction> GetActiveAuctions()
        {
            return Auctions.Where(a => !a.IsClosed && DateTime.Now < a.Item.EndTime).ToList();
        }

        private void ClearAllAuctions()
        {
            SendLotsToWinners();
            Auctions.Clear();
            CreateDefultAuction();
        }

        private void AuctionDailyReset()
        {
            var now = DateTime.Now;
            var tomorrow = now.Date.AddDays(1);
            var timeUntilMidnight = tomorrow - now;

            _dailyResetTimer = new Timer(_ =>
            {
                ClearAllAuctions();
                AuctionDailyReset();
            }, null, timeUntilMidnight, Timeout.InfiniteTimeSpan);
        }

        private void CreateDefultAuction()
        {
            var now = DateTime.UtcNow;
            CreateAuction(new AuctionItem()
            {
                Id = Guid.NewGuid().ToString(),
                Name = $"Мандаринка #{Auctions.Count + 1}",
                Description = "Уникальная NFT-картинка мандаринки, символизирующая свежесть.",
                StartingPrice = 0,
                CurrentPrice = 0,
                EndTime = new DateTime(now.Year, now.Month, now.Day).AddDays(1)
            });
        }

        private async void SendLotsToWinners()
        {
            foreach (var auction in Auctions)
            {
                var winner = auction.Bids.Last();

                await _mailSender.SendEmail(winner.Bidder.Email,
                    "Поздравляем с победой в аукционе!",
                    $"Вы успешно выиграли лот {winner.Item.Name}!\n" +
                    $"<img src=\"{winner.Item.Image}\" alt=\"{winner.Item.Image}\"");

                await _mailSender.SendEmail(winner.Bidder.Email,
                    "Чек от онлайн-аукциона Мандаринка",
                    $"Лот: {winner.Item.Name}\n" +
                    $"Описание: {winner.Item.Description}\n" +
                    $"Начальная ставка за лот: {winner.Item.StartingPrice}\n" +
                    $"Выиграшная ставка: {winner.Item.CurrentPrice}\n" +
                    $"Всего торгов за лот: {auction.Bids.Count}\n" +
                    $"Лот закрыт от {winner.Item.EndTime}\n");
            }
        }
    }

}


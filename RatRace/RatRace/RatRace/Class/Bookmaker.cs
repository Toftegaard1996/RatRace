using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Class
{
    class Bookmaker
    {
        public List<Bet> Bets = new List<Bet>();
        public List<Player> Players;
        //public string whichNPCRat = "";
        //public int whichNPCAmount = 0;

        public Bet PlaceBet(Race race, Rat rat, Player player, int money)
        {
            Bet bet = new Bet(race, rat, player, money);
            Bets.Add(bet);
            return bet;
            //for (int i = 0; i < Players.Count; i++)
            //{
            //    int ra = RNG.Range(0, Rats.Count);
            //    whichNPCAmount = RNG.Range(0, 100);
            //    Rats[ra].Name = whichNPCRat;
            //    money = whichNPCAmount;
            //    bets.Add(new Bet(whichNPCRat, whichNPCAmount));
            //}
        }
        public void PayOutWinnings(Bet bet)
        {
            bet.PayWinnings();

        }

    }
}

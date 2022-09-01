using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Class
{
    class Bet
    {
        private int Money;
        public int money
        {
            get { return Money; }
            set { Money = value; }
        }

        private Player Player;
        public Race Race;
        private Rat Rat;
        public bool playerWin = false;

        //Constructor
        public Bet(Race race, Rat rat, Player player, int money)
        {
            Race = race;
            Rat = rat;
            Player = player;
            Money = money;
        }

        public void PayWinnings()
        {
            if (Rat == Race.winner)
            {
                Console.WriteLine("Congrats! The rat you've betted on, won!");
                int MoneyBack = money *= 2;
                Player.Money += MoneyBack;
                playerWin = true;
            }
            else
            {
                Console.WriteLine("Tough luck mate, you didn't win today. \nBetter luck next time!");
            }
            
        }
    }
}

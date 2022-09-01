using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Class
{
    class Player
    {
        public string Name;
        public int Money;
        List<Bet> bets;

        public Player(string name, int money)
        {
            Name = name;
            Money = money;
        }
    }
}

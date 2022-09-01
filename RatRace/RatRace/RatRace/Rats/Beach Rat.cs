using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace.Class;

namespace RatRace.Rats
{
    class Beach_Rat:Rat
    {
        public Beach_Rat(string name, string type) : base(name, type)
        {
            Name = name;
        }
        public override int MoveRat(Track track)
        {
            if (track.Name == "Beach")
            {
                SpacesMoved = RNG.Range(5, 11);
            }
            else
            {
                SpacesMoved = RNG.Range(1, 7);
            }
            return base.MoveRat(track);
        }
    }
}

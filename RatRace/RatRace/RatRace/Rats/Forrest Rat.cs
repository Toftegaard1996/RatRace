using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace.Class;

namespace RatRace.Rats
{
    class Forrest_Rat:Rat
    {
        public Forrest_Rat(string name, string type):base(name, type)
        {
            Name = name;
        }
        public override int MoveRat(Track track)
        {
            if (track.Name == "Forrest")
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

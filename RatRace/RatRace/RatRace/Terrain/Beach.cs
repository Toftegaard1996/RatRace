using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace.Class;

namespace RatRace.Terrain
{
    class Beach:Track
    {
        public Beach(string name, int trackLength):base(name, trackLength)
        {
            TrackLength = trackLength;
            Name = name;
            Terrain = "Sand";
            //+ speed for beach rats
        }
    }
}

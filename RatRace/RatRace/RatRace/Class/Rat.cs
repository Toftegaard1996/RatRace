using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Class
{
    class Rat
    {
        public string Name;
        private int position;
        public int SpacesMoved;
        public IItem item;
        public int speed = 0;
        public string Type;
        public int Position 
        { 
            get { return position; }
            set { position = value; }
        }

        public Rat(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public void ResetRat()
        {
            //Go back to start
            if (Position != 0)
            {
                Position = 0;
            }
        }
        public virtual int MoveRat(Track track)
        {
            //Move x amount of spaces based on a die
            SpacesMoved += speed;
            Position += SpacesMoved;

            return Position;
        }
    }
}

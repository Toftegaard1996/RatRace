using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace.Class;

namespace RatRace.Items
{
    class SpeedShoes:IItem
    {
        public void Equip(Rat rat)
        {
            rat.item = this;
            rat.speed += 2;
        }

        public void Unequip(Rat rat)
        {
            rat.item = null;
            rat.speed -= 2;
        }
    }
}

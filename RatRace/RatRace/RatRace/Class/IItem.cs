using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace.Class
{
    interface IItem
    {
        void Equip(Rat rat);

        void Unequip(Rat rat);
    }
}

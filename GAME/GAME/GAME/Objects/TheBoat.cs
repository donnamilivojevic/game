using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class TheBoat : Thing
    {
        public override bool Use(Person p)
        {
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class MountainStairs : Thing //Ärver från 'Thing'
    {
        public override bool Use(Person p) //Personens agerande gentemot 'MountainStairs'
        {
            return false;
        }
    }
}

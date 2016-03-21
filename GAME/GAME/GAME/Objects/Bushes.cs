using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class Bushes : Thing //Ärver från 'Thing'
    {
        public override bool Use(Person p) //Personens agerade gentemot 'Bushes'
        {
            return false;
        }
    }
}

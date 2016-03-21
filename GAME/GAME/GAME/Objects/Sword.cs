using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    public class Sword : Thing //Ärver från 'Thing'
    {
        public override bool Use(Person p)//Personens agerande gentemot 'Sword'
        {
            return false;
        }            
    }
}

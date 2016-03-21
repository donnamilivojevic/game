using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class JummyGrass : Thing //Ärver från 'Thing'
    {
        public override bool Use(Person theHero)//Hjältens agerande gentemot 'Jummygrass'
        {
            return false;
        }

    }
}


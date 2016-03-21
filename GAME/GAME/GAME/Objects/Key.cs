using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    public class Key : Thing //Ärver från 'Thing'
    {
        public string Material { get; set; } //Keys beskrivning av material, Egenskap

        public override bool Use(Person p) //Personens agerande gentemot 'Key'
        {
            return false;
        }
    }
}


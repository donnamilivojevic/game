using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class CageKey : Thing //Ärver från 'Thing'
    {
        public string Material { get; set; } //CageKeys beskrivning på material

        public override bool Use(Person p) //Personens agerande gentemot 'CageKey'
        {
                if (World.Map[p.Coordinate[0], p.Coordinate[0]].ThingsInArea.Any(o => o.Name.ToLower() == "cage") && p.Name == "Aragorn")//Om birdcage finns i rutan & Aragorn är i samma ruta
                {
                    Console.WriteLine("Yaaaaaaaaaay!!! You have won the game! Congratulations!!!");// Så har du vunnit spelet!!
                    return true;
                }           
            return false;
        }
    }
}

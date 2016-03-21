using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
     public class Environment //Miljön i världen
    {
        public string Description { get; set; } //Miljöns beskrivning i världen

        public List<Thing> ThingsInArea { get; set; } //Objekt som finns i världen

        public List<Person> PersonsInArea { get; set; } // Personer i världen

        public string NotPossibleDirection { get; set; } //Vägar som inte är möjliga att gå i världen

        public Environment()
        {
            ThingsInArea = new List<Thing>();
            PersonsInArea = new List<Person>();

        }
    }
}

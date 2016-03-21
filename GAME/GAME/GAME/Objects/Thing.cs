using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
   public abstract class Thing //Basklass som alla objekt ärver ifrån
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DetailDescription { get; set; }
        public int weight { get; set; }
        public bool IsVisible { get; set; }

        public abstract bool Use(Person p); 
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Actions
{
   public abstract class Action //Basklass som alla handlingsklasser ärver ifrån
    {    
            public abstract StringCollection Verbs { get; } //Hämtar verben som skrivs in

            public abstract bool Execute(Person p, string[] args); // Hämtar Personens kommandon
        
    }
}

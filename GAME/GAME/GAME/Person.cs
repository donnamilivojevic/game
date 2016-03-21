using GAME.Actions;
using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    public class Person
    {
        public string Name { get; set; }//Personens namn
        public string Description { get; set; }//Personens beskrivning
        public string DetailDescription { get; set; }//Personens detaljerade beskrivning
        

        public int[] Coordinate = new int[2];//Hur personen rör sig i matrisen

        public List<Thing> Inventory { get; set; }//Lista på vad personen lagrar på sig
        public bool IsFollowing { get; set; }//När en person följer efter

        public Person()
        {
            // X-kordinator
            Coordinate[0] = 0;
            // Y-kordinator
            Coordinate[1] = 0;

            Inventory = new List<Thing>();
        }

        private List<Actions.Action> actions = new List<Actions.Action>() { new Movement(), new ItemHandling(), new Observation(), new Use(), }; //Personens alla sätt att agera

        internal bool CallAction(string[] inputArray)
        {
            foreach (var action in actions)
            {
                if (action.Verbs.Contains(inputArray[0]))
                {
                    return action.Execute(this, inputArray);
                }
            }

            return false;
        }
    }
}

            

        

        

        
      
    


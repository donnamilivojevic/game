using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Actions
{
    public class Movement : Action
    {
        public object input;

        public override StringCollection verb
{

        }
        public override bool Execute(Person theHero, string [] args)
        {

            if (args[1] == "north")
            {
                if (theHero.Coordinate[1] == 3)
                {
                    Console.WriteLine("EMPTY ROOM!");
                }
                else
                {
                    theHero.Coordinate[1]++;
                }
            }
                if (input.ToLower() == "go south")
                {
                    theHero.Coordinate[1]--;
                }

                if (input.ToLower() == "go east")
                {
                    theHero.Coordinate[0]++;
                }

                if (input.ToLower() == "go west")
                {
                    theHero.Coordinate[0]--;
                }

                Console.WriteLine(theHero.Coordinate[0] + ", " + theHero.Coordinate[1]);

                Console.WriteLine(theWorld[theHero.Coordinate[0], theHero.Coordinate[1]].Description);




                input = Console.ReadLine();
            }
            Console.WriteLine("Good job!PLAY AGAIN!!");
            Console.ReadLine();

        }
    }
}

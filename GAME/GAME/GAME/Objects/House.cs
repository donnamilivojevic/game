using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class House : Thing
    {
        public override bool Use(Person p) //Personens agerande gentemot 'Huset'
        {
            if (World.Persons.Any(o => o.Name.ToLower() == "duddley" && o.Coordinate[0] == 2 && o.Coordinate[1] == 0 && o.IsFollowing == false)) //Söker efter en person som heter 'duddley', har dessa kordinater samt att han inte följer hjälten
            {
                foreach (var item in World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea) //För varje objekt i den rutan som hjälten befinner sig i
                {
                    if (item.Name.ToLower() == "cagekey" || item.Name.ToLower() == "note") //Och OM det finns något av dessa objekt
                    {
                        item.IsVisible = true; //Så görs detta så att objekten blir till 'true' och därmed synliga när Aragorn flytttar på huset
                    }
                }
                Console.WriteLine("You have now pushed the house ");//Gör nyckeln cagekey & note synligt efter att ha puttat undan huset                           
            }
            Console.WriteLine("You cannot push the house without duddley!!!");
            return false;
        }
    }
}


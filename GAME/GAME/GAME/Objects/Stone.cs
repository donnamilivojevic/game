using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class Stone : Thing //Ärver från 'Thing'
    {
        public override bool Use(Person p) //Personens agerande gentemot 'Stone'
        {
            //Hittar svärdet
            Thing itemFound = null;
            foreach (var item in World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea)
            {

                if (item.Name.ToLower() == "sword")
                {
                    itemFound = item;
                    break;
                }

            }
            //Gör svärdet synligt efter att ha puttat undan stenen
            if (itemFound != null)
            {
                itemFound.IsVisible = true;
                Console.WriteLine("You have now pushed the stone. " + itemFound.Description);
            }         
            return false;
        }
    }
}

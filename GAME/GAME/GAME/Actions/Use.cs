using GAME;
using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Actions
{
    public class Use : Action //Ärver från Action
    {
        public override StringCollection Verbs //Skapar en lista med verb
        {
            get
            {
                return new StringCollection() { "push", "use" };//Lista med ord som lagras
            }
        }
        public override bool Execute(Person p, string[] args)
        {

            if (args[0] == "push")
            {
                if (args.Length == 1) //Letar efter den 2:a ordet i listan
                {
                    Console.WriteLine("What do you want to push?");
                    return false;
                }

                return PushItem(p, args);//Anropar metod
            }

            if (args[0] == "use")
            {
                if (args.Length == 1) //Letar efter det 2:a ordet i listan
                {
                    Console.WriteLine("What do you want to use?");
                    return false;
                }

                return UseItem(p, args);//Anropar metod
            }
            return false;
        }

        private bool UseItem(Person p, string[] args)
        {
            Thing itemFound = p.Inventory.FirstOrDefault(o => o.Name.ToLower() == args [1]);//Letar i peronens inventory efter det den ska använda

            foreach (var item in World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea)// Kollar om objektet finns i rutan som du ska använda det mot
            {
                if (item.Name.ToLower() == args[1])// Söker efter objektet på plats 2 i listan
                {
                    itemFound = item;
                    break;
                }
            }

            if (itemFound != null) //Om bjektet inte är ingenting
            {
                return itemFound.Use(p);//Då kan personen avända det hittade objektet
            }
            else
            {
                Console.WriteLine("You cannot use something that does not exist...duuuuh");//Text som kommer upp om det inte finns något att använda
            }

            return false;
        }

        private bool PushItem(Person p, string[] args)
        {

            Thing itemFound = p.Inventory.FirstOrDefault(o => o.Name.ToLower() == args[1]); //Det hittade objektet som finns i personens inventory är 2:a ordet i listan

            foreach (var item in World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea)// Om objektet finns i rutan hjälten befinner sig på
            {

                if (item.Name.ToLower() == args[1])// Om objektet finns som 2:a ordet i listan
                {
                    itemFound = item;
                    break;
                }
            }

            if (itemFound != null)// Om objektet inte är ingenting
            {
                itemFound.Use(p);// Om objektet hittats använder personen det
            }
            else
            {
                Console.WriteLine("You cannot push something that does not exist...duuuuh");// Text som kommer upp om det inte finns något att putta
            }

            return false;
        }
    }
}



                
                 
                
         
    

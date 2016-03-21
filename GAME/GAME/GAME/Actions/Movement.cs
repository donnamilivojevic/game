using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Actions
{
    public class Movement : Action //Ärver från basklassen Action
    {
        public override StringCollection Verbs //Samlingslista för de ord som skrivs in
        {
            get
            {
                return new StringCollection() { "go" }; //Ord som lagras i listan
            }
        }

        public override bool Execute(Person p, string[] args) 
        {
            if (args.Length == 1) //Letar efter det 2:a ordet i listan
            {
                Console.WriteLine("Where do you wanna go?");
                return false;
            }
            bool grassInEnvironment = false;// Gräset finns inte i miljön
            if (World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea.Any(o => o.Name == "grass"))// Kontrollerar om gräset finns i rutan
            {
                grassInEnvironment = true; //Finns gräset så skickas det tillbaks 'sant'
            }

            if (args[1] == "north") //Om andra ordet  i listan är 'north'
            {
                if (p.Coordinate[1] == 3)// Om personen står längst till höger på x-axeln
                {
                    if (p.Name == "Aragorn")// Om personen är hjälten
                    {
                        Console.WriteLine("You're not in the World anymore");// Så kommer denna text upp på skärmen
                    }
                }
                else
                {
                    p.Coordinate[1]++; //Annars så kan du gå vidare som vanligt
                }
            }

            if (args[1] == "south")//Om andra ordet  i listan är 'south'
            {
                if (p.Coordinate[1] == 0)//Om personen står längst till vänster på x-axeln
                {
                    if (p.Name == "Aragorn")//Om personen är hjälten
                    {
                        Console.WriteLine("You're not in the World anymore");//Så kommer denna text upp på skärmen
                    }
                }
                else
                {
                    p.Coordinate[1]--;//Annars så kan du gå vidare som vanligt
                }
            }

            if (args[1] == "east")//Om andra ordet  i listan är 'east'
            {
                if (p.Coordinate[0] == 3)//Om personen står längst upp på y-axeln
                {
                    if (p.Name == "Aragorn")//Om personen är hjälten
                    {
                        Console.WriteLine("You're not in the World anymore");//Så kommer denna text upp på skärmen
                    }
                }
                else
                {
                    p.Coordinate[0]++;//Annars så kan du gå vidare som vanligt
                }
            }

            if (args[1] == "west")//Om andra ordet  i listan är 'west'
            {
                if (p.Coordinate[0] == 0)//Om personen står längst ner på y-axeln
                {
                    if (p.Name == "Aragorn")//Om personen är hjälten
                    {
                        Console.WriteLine("You're not in the World anymore");//Så kommer denna text upp på skärmen
                    }
                }
                else
                {
                    p.Coordinate[0]--;//Annars kan du gå vidare som vanligt
                }
            }

            if (p.Name == "Aragorn") //Om det är Aragorn som plockar upp duddley //Ser till så att det är aragorn och duddley som går med varandra
            {
                if (!p.Inventory.Any(o => o.Name == "grass") && grassInEnvironment) //Om aragorn inte har *grass* i sitt inventory och den finns inte i rutan
                {
                    Console.WriteLine("You died! You didn't eat the grass! "); // Då har han dött och måste starta om
                    return true;
                }

                Person duddley = World.Persons.FirstOrDefault(o => o.Name == "Duddley");// Är för att hitta rätt person
                if (duddley != null)
                {
                    if (duddley.Inventory.FirstOrDefault(o => o.Name == "key") != null)// Har duddley nyckeln i sitt inventory & Hänger duddley med
                    {
                        if (duddley.IsFollowing == true)
                        {
                            duddley.Coordinate[0] = p.Coordinate[0];
                            duddley.Coordinate[1] = p.Coordinate[1]; // Får samma kordinationer som hjälten
                            Console.WriteLine("...Duddley follows you too.");
                            return false; // Går i verk om duddley har kommit till sitt hus
                        }                       
                    }
                }    
            }
            return false;
        }
    }
}





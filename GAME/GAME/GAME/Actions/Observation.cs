using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Actions
{
    public class Observation : Action //Ärver från Action
    {
        public override StringCollection Verbs   //Skapar en lista med verb 
        {
            get
            {
                return new StringCollection() { "inventory", "look", "see" }; //Lista med ord som lagras
            }
        }

        public override bool Execute(Person theHero, string[] args)
        {
            if (args[0] == "inventory")
            {
                return LookInInventory(theHero, args);//Anropar metod
            }

            if (args[0] == "see")
            {
                return SeeItem(theHero, args);//Anropar metod
            }

            if (args[0] == "look")
            {
                return LookAround(theHero, args);//Anropar metod
            }
            return false;
        }

        //Metoder till Observation

        private bool LookInInventory(Person p, string[] args)
        {
            foreach (var ToDo in p.Inventory)// Se i ditt inventory
            {
                Console.WriteLine("In your inventory: " + ToDo.Name); // Det som finns i ditt inventory
            }
            return false;
        }

        private bool SeeItem(Person p, string[] args)// När du skriver see så kommer du närmare objektet, i det här fallet är det den detaljerade beskrivningen som står.
        {
            if (args.Length == 1) // Hanterar om anv. endast skriver 'see'. 
            {
                Console.WriteLine("What do you want to see?"); //Ger ett hjälpmeddelande
                return false;
            }

            Thing itemFound = null;

            foreach (var ToDo in World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea)// Om det finns något att se i din ruta
            {
                if (ToDo.Name.ToLower() == args[1]) // om objektet man har skrivit in finns
                {

                    itemFound = ToDo; // så har det objektet hittats
                    break;
                }
            }

            if (itemFound == null) // om objektet inte är ingenting
            {
                itemFound = World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea //  om objekten som finns i de rutor i världen 
                    .FirstOrDefault(o => o.GetType().Name.ToLower() == args[1]); //Om du skriver in objektets typ så sker detta
            }

            if (itemFound != null)
            {
                Console.WriteLine(itemFound.DetailDescription);// beskrivningen om objektet som kommer upp på skärmen
                return false;
            }
            
            foreach (var person in World.Persons) // Kollar om personen finns i världen
            {
                if (person.Coordinate[0] == p.Coordinate[0] && person.Coordinate[1] == p.Coordinate[1]) // Om hjälten och personen du vill se på står på samma ruta
                {
                    Console.WriteLine(person.DetailDescription);//Då kommer personens detaljerade beskrivning upp på skärmen

                }
            }
            return false;
        }
       
        private bool LookAround(Person p, string[] args) //När du skriver look så ska det komma upp vilka objekt som finns i den rutan.
        {
            foreach (var ToDo in World.Map[p.Coordinate[0], p.Coordinate[1]].ThingsInArea) // för varje objekt i världen där personen befinner sig
            {
                if (ToDo.IsVisible) //om objektet är synlig
                {
                    Console.Write(ToDo.Description);// objektens beskrivningar
                }

            }

            foreach (var persons in World.Persons) // för varje person i världen
            {
                if (persons.Coordinate[0] == p.Coordinate[0] && persons.Coordinate[1] == p.Coordinate[1]) // Om hjälten och personen står på samma ruta som du vill titta på
                {
                    Console.WriteLine(persons.Description); // Då kommer personens beskrivning upp på skärmen
                    
                }
            }
            return false;
        }

    }
}















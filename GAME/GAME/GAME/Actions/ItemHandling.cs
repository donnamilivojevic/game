using GAME.Objects;
using System;
using System.Collections.Specialized;
using System.Linq;

namespace GAME.Actions
{
    public class ItemHandling : Action // Ärver från 'Action'
    {
        private int weightLimit = 50;

        public override StringCollection Verbs // Lista med verb
        {
            get
            {
                return new StringCollection() { "take", "drop", "give", "eat", "talk" }; //Verb som används i spelet
            }
        }

        public override bool Execute(Person theHero, string[] args) // Hjälten agerar på verben som skrivs in i konsolen
        {
            if (args[0] == "take")//Om första ordet i listan är 'take'
            {

                if (args.Length == 1)// Om du inte har skrivit in något objekt att ta
                {
                    Console.WriteLine("What do you want to take?");//Så kommer denna text upp på skärmen
                    return false;
                }


                return PickUpItem(theHero, args);//Metod som anropar 'Pickuppitem'
            }

            if (args[0] == "talk")//Om första ordet i listan är 'talk'
            {
                if (args.Length == 1)//Om du inte har skrivit in vem du ska prata med
                {
                    Console.WriteLine("Who do you want to talk to?");//Så kommer denna text upp på skärmen
                    return false;
                }
                Person pToTalkTo = World.Persons.FirstOrDefault(p => p.Name.ToLower() == args[1]);//Sökning av personer att kunna prata med

                if (pToTalkTo != null)//Om det finns en person att prata med
                {
                    if (pToTalkTo.Coordinate[0] == theHero.Coordinate[0] && pToTalkTo.Coordinate[1] == theHero.Coordinate[1])//Kontrollerar att personen finns på samma x-kordinat och y-kordinat som hjälten
                    {
                        return TalkTo(theHero, pToTalkTo, args);//Metod för 'TalkTo'
                    }
                    else
                    {
                        Console.WriteLine("There's no one to talk to...");// Om det inte finns någon att prata med
                        return false;
                    }
                }
            }

            if (args[0] == "eat")//Om första ordet i listan är 'eat'
            {
                if (args.Length == 1)//Om du inte har skrivit in det andra ordet i listan
                {
                    Console.WriteLine("What do you want to eat?");//Så kommer denna text upp på skärmen
                    return false;
                }

                return EatUpItem(theHero, args);//Metod som anropar 'eatuppitem'
            }

            if (args[0] == "drop")//Om första ordet i listan är 'drop'
            {
                if (args.Length == 1)//Om du inte har skrivit in andra ordet i listan
                {
                    Console.WriteLine("What do you want to drop?");//Så kommer denna text upp
                    return false;
                }

                Person pToDrop = World.Persons.FirstOrDefault(o => o.Name.ToLower() == args[1]);//Sökning av personer att lämna 

                if (pToDrop != null) //Om det finns en person att lämna
                {
                    if (pToDrop.IsFollowing == true)// Om Duddley inte följer med längre
                    {
                        Console.WriteLine("You have now dropped Duddley and he is no longer by your side!!!");//Aragorn har nu lämnat Duddley i den rutan
                        pToDrop.IsFollowing = false; // Ser till att duddley slutar följa efter hjälten
                        return false;
                    }
                }
                return DropIt(theHero, args);//Metod som anropar 'dropit', alltså objekt // retunerar koden ovanför till 'DropIt' metoden
            }

            if (args[0] == "give")
            {
                if (args.Length == 1) //Letar efter 2:a ordet i listan
                {
                    Console.WriteLine("What do you wanna give?");
                    return false;
                }

                if (args.Length == 2) //Letar efter det 3:e ordet i listan
                    {
                        Console.WriteLine("Who do you wanna give it to?");
                        return false;
                    }
                   

                Person pToGiveItemTo = World.Persons.FirstOrDefault(p => p.Name.ToLower() == args[2]);//Sökning av personer att ge objekt till

                if (pToGiveItemTo != null) //Om personen i rutan inte är ingenting
                {
                    if (pToGiveItemTo.Coordinate[0] == theHero.Coordinate[0] && pToGiveItemTo.Coordinate[1] == theHero.Coordinate[1])//Kontrollerar att personen finns på samma x-kordinat och y-kordinat som oss
                    {
                        return GiveItem(theHero, pToGiveItemTo, args); //Metod för 'GiveItem' mellan hjälten och personen att ge till
                    }
                    else
                    {
                        Console.WriteLine("Cannot find the person to give the key to!!!");//Ifall det inte finns någon person att ge nyckeln till
                    }
                }
            }

            return false;
        }

        private bool DropIt(Person theHero, string[] args)// TAPPA SAKER    
        {
            Thing itemFound = null;//Objektet är ingenting

            foreach (var item in theHero.Inventory)//Om objektet finns i hjältens inventory
            {
                if (item.Name.ToLower() == args[1])//Om 2:a ordet i listan är objektets namn
                {

                    itemFound = item;// Då hittas objektet
                    break;
                }
            }

            if (itemFound != null)
            {
                theHero.Inventory.Remove(itemFound);// Objektet tas bort från hjältens inventory
                World.Map[theHero.Coordinate[0], theHero.Coordinate[1]].ThingsInArea.Add(itemFound);// Objektet läggs till i den rutan där hjälten tappade det
                Console.WriteLine("You have now dropped the " + itemFound.Name);
            }
            else
            {
                Console.WriteLine("Pick it up again!");// Om du tappar något som kommer denna text upp på skärmen
            }

            return false;
        }

        private bool TalkTo(Person theHero, Person p, string[] args) // TALK TO PERSON
        {

            if (p.Inventory.Any(o => o.Name == "key")) // Kollar ifall personen i sig har 'Key' i sitt inventory
            {// Konversation mellan hjälten och Duddley
                Console.WriteLine("Aragorn: Hi there you sexy beast! You better not drop the fucking key!");
                Console.WriteLine(" Duddley: No sir, I will not! But you have to take me home...");
                Console.WriteLine("Aragorn: Why the hell would I take you home? You have the bloody key!!!!");
                Console.WriteLine(" Duddley: Because I have some top secret shit for you that you need!!!");
                Console.WriteLine("Aragorn: FUCK, okey then, I will take you home! Now tell me the top secret shit you have!");
                Console.WriteLine(" Duddley: The top secret shit is that you need another key and note, to open the birdcage and you'll get it when I'm home!");
                Console.WriteLine("Aragorn: Okey! Now let's go!!!!!");
                Console.WriteLine(" Duddley: Yaay, awesome! I will now stand by your side, well until I get home!");
                p.IsFollowing = true; //Ser till så att duddley nu verkligen följer med
            }
            else
            {
                Console.WriteLine("You can only talk to him if you have given the key!"); //Ifall hjälten inte har gett nyckeln till Duddley
            }

            return false;
        }

        private bool EatUpItem(Person theHero, string[] args)// EAT ITEM
        {

            Thing itemFound = null;

            foreach (var item in World.Map[theHero.Coordinate[0], theHero.Coordinate[1]].ThingsInArea)//Kontrollerar att objektet finns i rutan 
            {
                //Om objektets namn, oavsett stor eller liten bokstav finns i listan av lagrade objekt
                if (item.Name.ToLower() == "grass")
                {
                    itemFound = item;// Så hittas objektet
                    break;
                }

            }

            if (itemFound != null) // Om aragorn äter gräset
            {
                theHero.Inventory.Add(itemFound); // Den läggs till i hans inventory
                World.Map[theHero.Coordinate[0], theHero.Coordinate[1]].ThingsInArea.Remove(itemFound); //Gräset tas bort från rutan
                Console.WriteLine("You have eaten up " + itemFound.Name); //Skriver ut objektet man har ätit
            }
            return false;
        }

        private bool GiveItem(Person theHero, Person Dwarf, string[] inputArray)   //GIVE ITEM
        {
            Thing itemFound = null;

            foreach (var item in theHero.Inventory)// Kontrollerar att objektet finns i hjältens inventory
            {// Om objektets namn oavsett stor eller liten bokstav finns lagrad i listan på plats 2
                if (item.Name.ToLower() == inputArray[1])
                {
                    itemFound = item; //Så hittas objektet
                    break;
                }
            }

            if (itemFound != null)// Om objektet finns 
            {
                theHero.Inventory.Remove(itemFound);//Så tas det bort från hjältens inventroy
                Dwarf.Inventory.Add(itemFound);//Läggs till i Boatmans inventory
                Console.WriteLine("You have now given the " + itemFound.Name + " to Duddley. You can be a bit social, who knows he might have some important information for you!");
            }
            else
            {
                Console.WriteLine("Can't give if there is nothing to give!"); //Ifall det inte finns något att ge
            }

            return false;
        }

        private bool PickUpItem(Person theHero, string[] inputArray)    //PICK UP ITEM
        {
            Thing itemFound = null; //Om objektet är ingenting

            foreach (var item in World.Map[theHero.Coordinate[0], theHero.Coordinate[1]].ThingsInArea) //För varje objekt i rutan hjälten befinner sig i
            {

                if (item.Name.ToLower() == inputArray[1]) //Om objektet är det 2:a ordet som skrivs ut på konsole
                {

                    itemFound = item; //Så är objektet funnet
                    break;
                }

            }

            if (itemFound != null && itemFound.weight <= weightLimit && itemFound.IsVisible) //Om objektet inte är ingenting Och OM vikten på objektet är mindre eller lika med som viktspärren och är objektet synligt
            {

                theHero.Inventory.Add(itemFound); // Så läggs den i hjältens inventory
                World.Map[theHero.Coordinate[0], theHero.Coordinate[1]].ThingsInArea.Remove(itemFound); //Ta bort objektet från rutan när den har plockats upp
                Console.WriteLine("You have now picked up " + itemFound.Name); //Skriver ut namnet på objektet vi har plockat upp
            }
            else

                Console.WriteLine("You cannot pick up that!!! LOOOOSER"); //Om objektet väger för mycket så skrivs detta ut

            return false;
        }
    }

}




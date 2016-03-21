using GAME.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;// Konsolens bakgrundsfärg
            Console.ForegroundColor = ConsoleColor.Black;// Textens färg i konsolen
            Console.Clear();

            World theWorld = new World();//Matris av världen
            theWorld.InWorld(4, 4);

            Person theHero = new Person();//Hjälten i spelet
            theHero.Name = "Aragorn";
            theHero.Coordinate[0] = 0;
            theHero.Coordinate[1] = 3;

            Person theBadGuy = new Person(); //The Badguy i spelet
            theBadGuy.Name = "Gargamel";
            theBadGuy.Coordinate[0] = 0;
            theBadGuy.Coordinate[1] = 1;

            Person Dwarf = new Person(); //Medhjälpare i spelet
            Dwarf.Name = "Duddley";
            Dwarf.Coordinate[0] = 2;
            Dwarf.Coordinate[1] = 3;

            // När konsolen öppnas
            Console.WriteLine("Welcome my fellow human being! You have come to my World Epic!! My name is Aragorn and I'm a kenatur with black long hair and I'm very strong! But my town have been invaded by the evil Gargamel. Gargamel robbed us from our Beautiful Little Bird! Without the bird in our town there won't be any more sunshine and the town is all in darkness now! Your mission is to save the bird so the town can be like it was before, all green, sunny and joyful! To start the game press Enter. To get the instructions type Help.");
            Console.ReadLine();

            string input = ""; //Läser in det anvädaren skriver in (oberoende av strlk på texten
            string[] inputArray;

            Random rnd = new Random(); // BadGuys directions som slumpas fram
            string[] theBadGuyDirections = new string[4] { "north", "west", "east", "south" };

            bool gameOver = false;
            while (input != "quit" && !gameOver) // När spelet körs
            {
                if (input == "help")
                {
                    Help();   //Metod med instruktioner ifall spelaren fastnar
                }

                Console.WriteLine(World.Map[theHero.Coordinate[0], theHero.Coordinate[1]].Description);// Miljöbeskrivning som kommer upp när du flyttar hjälten
                Console.Write(">");//Skriv in din handling vad du vill göra
                input = Console.ReadLine().ToLower();
                inputArray = input.Split(' ');

                gameOver = theHero.CallAction(inputArray);

                if (theHero.Coordinate[0] == theBadGuy.Coordinate[0] && theHero.Coordinate[1] == theBadGuy.Coordinate[1]) //Om Aragorn och gargamel hamnar på samma kordinater
                {
                    if (theHero.Inventory.Any(o => o.Name.ToLower() == "sword"))//Om Aragorn har svärd i sitt inventory
                    {
                        Console.WriteLine("Gargamel ran for his life when he saw your BIG & SHINY sword!!!!!!!");// Texten som kommer upp, man kan fortsätta spela
                    }
                    else
                    {
                        Console.WriteLine("You lost the Game! Gargamel has defeated you!!!!!!!");// Texten som kommer upp, man förlorade
                        gameOver = true;
                    }
                }


                int theBadGuyDirection = rnd.Next(4); //BadGuys kordinater slumpas fram
                theBadGuy.CallAction(new string[] { "go", theBadGuyDirections[theBadGuyDirection] });

            }
            Console.WriteLine("It's over for this time...You are Welcome to play again!");// Text som kommer upp när spelet avslutas
            Console.ReadLine();

        }

        static void Help() // Instruktioner som kommer upp när användaren skriver 'Help'
        {
            Console.WriteLine("1. To move Aragorn type go and then wich way you want to go ex. north, south, west or east.");
            Console.WriteLine("2. Your mission is to save the Little Bird! ");
            Console.WriteLine("3. To complete the mission you need to find two keys and a sword!");
            Console.WriteLine("4. To survive on your way to save the beautiful bird you have to eat the grass!");
            Console.WriteLine("5. To be able to use the objects you need to type either push, use, take, drop, eat, talk or give.");
            Console.WriteLine("6. You can also type look if you want to see the enviornment around you and type see if you want to have a closer look. ");
            Console.WriteLine("7. Look out for Gargamel. You never know if he's around the corner!!");
            Console.WriteLine("8. If you don't remember what you have picked up type 'inventory'.");
            Console.WriteLine("9. If you want to quit the game type: quit");

        }
    }
}

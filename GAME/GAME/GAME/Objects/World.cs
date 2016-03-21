using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class World //Matrisen
    {
        public static Environment[,] Map; //Beskriver hur matrisen är uppbygd
        
        public static List<Person> Persons { get; set; } //Hämtar Personer att sätta in i matrisen

        public void InWorld(int height, int width) 
        {
            Map = new Environment[height, width];
            Persons = new List<Person>();
            //Beskrivningar av miljön i matrisen för varje ruta
            Map[0, 0] = new Environment();
            Map[0, 1] = new Environment();
            Map[0, 2] = new Environment();
            Map[0, 3] = new Environment();

            Map[0, 0].NotPossibleDirection = "You can't unlock the cage without the cagekey!!! You have to find the cagekey!!!";
            Map[0, 0].Description = "You are on the top of the mountain close to saving the beautiful bird!";
            Map[0, 1].Description = "It's very cloudy here and you cannot see much!!";
            Map[0, 2].Description = "You are in the wood...";
            Map[0, 3].Description = "You are now in the city called Woody. On the way you need to find some keys and weapon. But for now you need to go to the woods to find the narrow path that would lead you closer to Gargamel.";

            Map[1, 0] = new Environment();
            Map[1, 1] = new Environment();
            Map[1, 2] = new Environment();
            Map[1, 3] = new Environment();

            Map[1, 0].Description = "You are next to the misty mountain!";
            Map[1, 1].Description = "You have now reached the mountain, continue on your quest!!";
            Map[1, 2].Description = "You are now in the wood standing on the narrow path. There's a lot of high trees and you can't see much...";
            Map[1, 3].Description = "The trees are so high in the wood that it blockes the sun out.";

            Map[2, 0] = new Environment();
            Map[2, 1] = new Environment();
            Map[2, 2] = new Environment();
            Map[2, 3] = new Environment();

            Map[2, 0].Description = "You have now reached the Rainbowflowerpower meadow. You are in dwarfland. "; 
            Map[2, 1].Description = "You are now standing on the beach, the sun is burning!";
            Map[2, 2].Description = "You can see the beach and the lake and it looks so peacefully, or does it?!";
            Map[2, 3].Description = "Well, this beach looks like shit, garbage everywhere and it smells like poop!!!";

            Map[3, 0] = new Environment();
            Map[3, 1] = new Environment();
            Map[3, 2] = new Environment();
            Map[3, 3] = new Environment();

            Map[3, 0].Description = "You are still on the meadow...";
            Map[3, 1].Description = "You are now standing on the meadow!";
            Map[3, 2].Description = "You are in the lake and getting a bit of a tan... AAAHHHH NICE!!!";
            Map[3, 3].Description = "You are cleaning yourself in the lake now...";
            // Alla objekt i matrisen
            Sword sword = new Sword();
            sword.Name = "Sword";
            sword.Description = "You can see a sword that is very shiny and green with a very sharp edge.";
            sword.DetailDescription = "The sword is very shiny and green with a very sharp edge.";
            sword.weight = 10;           
            sword.IsVisible = false;
            Map[1, 2].ThingsInArea.Add(sword);

            Stone stone = new Stone();
            stone.Name = "stone";
            stone.Description = "You can see a huge, black and heavy stone.";
            stone.DetailDescription = "On the side of the stone you can see something that looks like a handle. Try to push the stone to the side.";
            stone.weight = 100;
            stone.IsVisible = true;
            Map[1, 2].ThingsInArea.Add(stone);

            Key theKey = new Key();
            theKey.Name = "key";
            theKey.Description = "A key.";
            theKey.DetailDescription = "A big shiny silver key.";
            theKey.Material = "Silver";
            theKey.weight = 10;
            theKey.IsVisible = true;
            Map[1, 3].ThingsInArea.Add(theKey);

            Bushes bush = new Bushes();
            bush.Name = "bush";
            bush.Description = "A lot of bushes who are round, big and poisones.";
            bush.DetailDescription = "There are red berries that are poisones hanging on the bush, don't eat it!! You can see something that looks like a key in there...";
            bush.weight = 100;
            bush.IsVisible = true;
            Map[1, 3].ThingsInArea.Add(bush);

            Person Dwarf = new Person();
            Dwarf.Name = "Duddley";
            Dwarf.Description = "You can see a Dwarf, he's your friend and his name Duddley.";
            Dwarf.DetailDescription = "He's a grumpy, fat and hairy dwarf.";
            Dwarf.Coordinate[0] = 2;
            Dwarf.Coordinate[1] = 3;
            World.Persons.Add(Dwarf);

            Person theBadGuy = new Person();
            theBadGuy.Name = "Gargamel";
            theBadGuy.Description = "A short and an old man...";
            theBadGuy.DetailDescription = "He has an ugly big nose and his hair is black and dirty. The most evil eyes you've ever seen, he's not nice to you.";
            theBadGuy.Coordinate[0] = 0;
            theBadGuy.Coordinate[1] = 1;
            World.Persons.Add(theBadGuy);

            TheBoat Ship = new TheBoat();
            Ship.Name = "boat";
            Ship.Description = "Larg boat.";
            Ship.DetailDescription = "Larg boat made of wood and leafs.";
            Ship.weight = 100;
            Ship.IsVisible = true;
            Map[3, 3].ThingsInArea.Add(Ship);

            JummyGrass Food = new JummyGrass();
            Food.Name = "grass";
            Food.Description = "A meadow full of grass.";
            Food.DetailDescription = "Soft and green grass to eat and that that's jummy!!";
            Food.weight = 100;
            Food.IsVisible = true;
            Map[3, 1].ThingsInArea.Add(Food);

            FlowerPower flower = new FlowerPower();
            flower.Name = "flower";
            flower.Description = "Big flowers with colours like the rainbow.";
            flower.DetailDescription = "Big, high flowers that reach over your head.";
            flower.weight = 100;
            flower.IsVisible = true;
            Map[3, 0].ThingsInArea.Add(flower);

            MountainStairs Stairs = new MountainStairs();
            Stairs.Name = "Stairs";
            Stairs.Description = "Staris in the mountain.";
            Stairs.DetailDescription = "Dark scary stairs that you are afraid to go up for";
            Stairs.weight = 100;
            Stairs.IsVisible = true;
            Map[1, 1].ThingsInArea.Add(Stairs);

            BirdCage Cage = new BirdCage();
            Cage.Name = "Cage";
            Cage.Description = "A cage.";
            Cage.DetailDescription = "Golden colour bird cage. There's the Beautiful little Bird!! Go and get him!!";
            Cage.Material = "Gold";
            Cage.weight = 100;
            Cage.IsVisible = true;
            Map[0, 0].ThingsInArea.Add(Cage);

            CageKey BirdKey = new CageKey();
            BirdKey.Name = "Cagekey";
            BirdKey.Description = "An old and thick cagekey.";
            BirdKey.DetailDescription = "Rusty and hard to the touch, it's the key to the cage!";
            BirdKey.Material = "Copper";
            BirdKey.weight = 10;
            BirdKey.IsVisible = false;
            Map[2, 0].ThingsInArea.Add(BirdKey);

            KeyNote Note = new KeyNote();
            Note.Name = "note";
            Note.Description = "Small paper who's stuck to the Key.";
            Note.DetailDescription = "There is information on the note that saids: TO GET BACK THE BIRD OF THE CITY YOU HAVE TO CLIMBE THE MOUNTAIN!!! MOHAHAHAHA!!!";
            Note.weight = 10;
            Note.IsVisible = false;
            Map[2, 0].ThingsInArea.Add(Note);

            House house = new House();
            house.Name = "house";
            house.Description = "Small, cute little house.";
            house.DetailDescription = "This little house belongs to Duddley and it's very pinky and girly!";
            house.weight = 100;
            house.IsVisible = true;
            Map[2, 0].ThingsInArea.Add(house);

        }
    }
}

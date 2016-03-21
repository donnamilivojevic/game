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
            Environment[,] theWorld = new Environment[4, 4];
            InWorld(theWorld);

            Person theHero = new Person();
            Key theKey = new Key();

            Console.WriteLine(theWorld[theHero.Coordinate[0], theHero.Coordinate[1]].Description);
            

            string input = Console.ReadLine();

            while (input != "GAME OVER")
            {

            }

        }

            private static void InWorld(Environment[,] theWorld)
        {
            theWorld[0, 0] = new Environment();
            theWorld[0, 1] = new Environment();
            theWorld[0, 2] = new Environment();
            theWorld[0, 3] = new Environment();

            theWorld[0, 0].Description = "YAAAAAY!! You have defeated Gargamel and now you can free the beautiful bird with the key. Get the key. Unlock the cage with the key.";
            theWorld[0, 1].Description = "You've reached the top and got faced by the horrible Gargamel. gargamel was shocked to see who came up from the stairs. Never in his wildest imagination did he think that his own creation would go against him. You have to know defeat Gargamel so that you can free the beautiful bird!!";
            theWorld[0, 2].Description = "You have found the narrow path. Follow it into the woods and search for a big black stone where you'll find your sword. ";
            theWorld[0, 3].Description = "You are now in the city called Woody. You're mission is to save the beautiful bird from the evil Gargamel. On the way you need to find some keys and weapon. But for now you need to go to the woods to find the narrow path that would lead you closer to gargamel.";

            theWorld[1, 0] = new Environment();
            theWorld[1, 1] = new Environment();
            theWorld[1, 2] = new Environment();
            theWorld[1, 3] = new Environment();

            theWorld[1, 0].Description = "You have now reached the mountain and looking around to see if there are any short cut up the mountain.";
            theWorld[1, 1].Description = "You've found the stairs, now go up for the stairs!";
            theWorld[1, 2].Description = "Yaaay, you have found the sword!! Pick up the sword. Now you have to find the key that's hidden amongst the toxic bushes that are screaming HALLELULJA!.";
            theWorld[1, 3].Description = "Yaaay, you have found the key! You now have to go to the lake and take the boat over the lake, to do that you need to give the key to the boatman.";

            theWorld[2, 0] = new Environment();
            theWorld[2, 1] = new Environment();
            theWorld[2, 2] = new Environment();
            theWorld[2, 3] = new Environment();

            theWorld[2, 0].Description = "You are now seeing the flowers that looks like a rainbow. You have now found the key with a note attached to it. Pick up the key and note. On the note it says: TO GET BACK THE BIRD OF THE CITY YOU HAVE TO CLIMBE THE MOUNTAIN AND DEFET ME, THE ALLMIGHTY GARGAMEL!!! MOHAHAHAHA!!! Now you have to go to the maountain.";
            theWorld[2, 1].Description = "You are now standing on the beach and looking around and found a path. Go to the path.";
            theWorld[2, 2].Description = "You have now reach the other side of the lake. The boatman says: You need to find the flowers that looks like a rainbow. You nodded and got off the boat.";
            theWorld[2, 3].Description = "You have found the lake! Now give the key to the boatman and he will take you to the other side of the lake.";

            theWorld[3, 0] = new Environment();
            theWorld[3, 1] = new Environment();
            theWorld[3, 2] = new Environment();
            theWorld[3, 3] = new Environment();

            theWorld[3, 0].Description = "You are now on the meadow. The beautiful flowers smells so nice so you stopped and smelled on the flowers. But you now rememberd what the boatman said, and continued looking for the other key.";
            theWorld[3, 1].Description = "You are now standing on a field of grass, and suddenly got very hungry. You are now eating gras for dinner. ";
            theWorld[3, 2].Description = "You are now in the boat and enjoying the beautiful weather and even getting a bit of a tan... AAHH nice!";
            theWorld[3, 3].Description = "You are now getting in to the boat. Be careful so you don't fall over into the lake!";
        }
    }
}

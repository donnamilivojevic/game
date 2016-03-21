using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Objects
{
    public class BirdCage : Thing //Ärver från 'Thing'
    {
        public string Material { get; set; }// Birdcages beskrivning på material

        public override bool Use(Person theHero) //Hjältens agerande på birdcage
        {
            if (theHero.Coordinate[0] == 0 && theHero.Coordinate[1] == 0)//Kontrollerar hjältens kordinater
            {
                Thing itemFound = theHero.Inventory.FirstOrDefault(o => o.Name.ToLower() == "cagekey");// Sökning om hjälten har 'CageKey' på sig

                    if (itemFound == null)//Om inte hjälten har på sig objektet så kör programet if-satsen
                    {
                        Console.WriteLine(World.Map[theHero.Coordinate[0], theHero.Coordinate[0]].NotPossibleDirection);//Text som kommer upp om inte hjälten har objektet på sig
                    }
                }
                
                return false;
            }
        }
    }


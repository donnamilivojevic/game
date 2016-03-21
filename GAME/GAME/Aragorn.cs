using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
     class Person
    {
        public string Name { get; set; }

        public int[] Coordinate = new int[2];

        public Person()
        {
            // X-kordinator
            Coordinate[0] = 0;
            // Y-kordinator
            Coordinate[1] = 3;
        }

        public abstract void Action; 


    }
}

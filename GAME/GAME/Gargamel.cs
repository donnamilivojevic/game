using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    class Gargamel
    {
        public string Name { get; set; }

        public int[] Coordinate = new int[2];

        public Gargamel()
        {
            Coordinate[0] = 0;
            Coordinate[1] = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    class Key
    {
        public string Name { get; set; }

        public int[] Coordinate = new int[2];

        public Key()
        {
            // X-kordinator
            Coordinate[0] = 1;
            // Y-kordinator
            Coordinate[1] = 3;
        }

    }
}

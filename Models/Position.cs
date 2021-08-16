using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tttServer.Models
{
    public class Position
    {
        public Position(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public int i { get; set; } 
        public int j { get; set; }

        public override string ToString()
        {
            return i + "," + j;
        }
    }

}

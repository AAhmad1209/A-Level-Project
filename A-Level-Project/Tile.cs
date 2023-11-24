using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    //the Tile class is used to represent a single point on the map
    internal class Tile
    {
        private string _type;


        public Tile(string type)
        {
            Type = type;
        }

        public string Type { get => _type; set => _type = value; }
    }
}

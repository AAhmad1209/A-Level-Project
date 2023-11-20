using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    //the MapEntity class is used to represent objects on the map
    internal class MapEntity
    {
        private Coord _position;

        //constructor
        public MapEntity(Coord position)
        {
            _position = position;
        }
    }
}

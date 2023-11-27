using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    //represents a player
    internal class Player
    {
        private string _name;
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }
    }
}

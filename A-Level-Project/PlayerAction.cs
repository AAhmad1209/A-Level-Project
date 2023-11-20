using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    //the PlayerAction class represents player actions
    internal class PlayerAction
    {
        private string _type;

        //constructor
        public PlayerAction(string type)
        {
            Type = type;
        }

        public string Type { get => _type; set => _type = value; }
    }
}

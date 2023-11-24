using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    internal class WindowData
    {
        private Dictionary<string, string> _string_data;

        public WindowData()
        {
            String_data = new Dictionary<string, string>();
        }

        public Dictionary<string, string> String_data { get => _string_data; set => _string_data = value; }
    }

    //internal class MapWindowData : WindowData
    //{
    //    private Map _map;
    //    public MapWindowData()
    //    {
    //    }
    //    internal Map Map { get => _map; set => _map = value; }
    //}
}

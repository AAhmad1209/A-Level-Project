using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    internal class TurnUI
    {
        List<Window> _windows = new List<Window>();

        public TurnUI()
        {
            _windows.Add(new Window(new Rectangle(new Coord(0, 0), 4, 4), ConsoleColor.White, "Window 1"));

        }

        public void Display()
        {
            foreach (Window window in _windows)
            {
                window.Display_Border();
            }
        }
    }
}

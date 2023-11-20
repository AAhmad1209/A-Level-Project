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
            _windows.Add(new Window(new Rectangle(new Coord(4, 2), 15, 9), ConsoleColor.White, "Window 1"));
            _windows.Add(new Window(new Rectangle(new Coord(23, 2), 15, 9), ConsoleColor.White, "Window 2"));

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

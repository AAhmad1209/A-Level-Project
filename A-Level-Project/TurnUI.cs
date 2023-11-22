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
        Window _current_window;
        int _current_window_pointer;

        public TurnUI()
        {
            _windows.Add(new Window(new Rectangle(new Coord(4, 2), 15, 9), "Window 1"));
            _windows.Add(new Window(new Rectangle(new Coord(23, 2), 15, 9), "Window 2"));
            _windows.Add(new Window(new Rectangle(new Coord(4, 13), 15, 9), "Window 3"));

            _current_window_pointer = 0;
            _current_window = _windows[_current_window_pointer];
            _current_window.Active = true;

        }

        public int Current_window_pointer { get => _current_window_pointer; set => _current_window_pointer = value; }
        internal Window Current_window { get => _current_window; set => _current_window = value; }

        public void Display()
        {
            foreach (Window window in _windows)
            {
                window.Display_Border();
            }
        }

        public void Next_Window()
        {
            _current_window.Active = false;

            if (_current_window_pointer == _windows.Count - 1)
            {
                _current_window_pointer = 0;
            }

            else
            {
            _current_window_pointer++;
            }

            _current_window = _windows[_current_window_pointer];
            _current_window.Active = true;
        }
    }
}

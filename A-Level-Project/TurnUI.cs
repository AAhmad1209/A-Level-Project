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
            InfoWindow info_window = new InfoWindow(new Rectangle(new Coord(4, 2), 15, 9), "Window 1");
            SelectionWindow selection_window = new SelectionWindow(new Rectangle(new Coord(23, 2), 15, 9), "Window 2");
            MapWindow map_window = new MapWindow(new Rectangle(new Coord(4, 13), 15, 9), "Window 3", new Map("map 1", "\\\\sgs-svr-fs01\\studenthome$\\SixthForm\\2022Intake\\st2022132\\My Documents\\Visual Studio 2017\\A-Level-Project\\A-Level-Project\\mapfile.txt"));
            
            info_window.Add_String_Data("Hp", "5");
            selection_window.Add_Selection_Item("Option 1");
            selection_window.Add_Selection_Item("Option 2");
            selection_window.Add_Selection_Item("Option 3");
            selection_window.Add_Selection_Item("Option 4");
            selection_window.Add_Selection_Item("Option 5");

            _windows.Add(info_window);
            _windows.Add(selection_window);
            _windows.Add(map_window);

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
                window.Display_Contents();
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

        public void Update_Active_Window(ConsoleKeyInfo key_info)
        {
            Current_window.Update(key_info);
            Display();
        }
    }
}

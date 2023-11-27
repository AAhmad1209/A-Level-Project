using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    internal class TurnUI
    {
        private List<Window> _windows = new List<Window>();
        private Window _current_window;
        private int _current_window_pointer;
        private Player _current_player;

        public TurnUI()
        {
            InfoWindow map_info_window = new InfoWindow(new Rectangle(new Coord(28, 3), 15, 9), "Man Info");
            SelectionWindow selection_window = new SelectionWindow(new Rectangle(new Coord(4, 14), 20, 14), "Controls");
            MapWindow map_window = new MapWindow(new Rectangle(new Coord(4, 3), 20, 9), "Map", new Map("map 1", "\\\\sgs-svr-fs01\\studenthome$\\SixthForm\\2022Intake\\st2022132\\My Documents\\Visual Studio 2017\\A-Level-Project\\A-Level-Project\\mapfile.txt"));
            InfoWindow update_window = new InfoWindow(new Rectangle(new Coord(28, 14), 15, 9), "Action Info");

            //map_window.Activatable = true;
            //selection_window.Activatable = true;

            //map_info_window.Activatable = false;
            //update_window.Activatable = false;

            map_info_window.Add_String_Data("Hp", "5");
            selection_window.Add_Selection_Item("Summon Unit");
            selection_window.Add_Selection_Item("Disband Unit");
            selection_window.Add_Selection_Item("Move Unit");
            selection_window.Add_Selection_Item("Upgrade Unit");
            selection_window.Add_Selection_Item("Conquer Village");
            selection_window.Add_Selection_Item("Tile Action");
            selection_window.Add_Selection_Item("Diplomacy");
            selection_window.Add_Selection_Item("Tech Tree");
            selection_window.Add_Selection_Item("Game Stats");
            selection_window.Add_Selection_Item("Game Log");
            selection_window.Add_Selection_Item("End Turn");
            selection_window.Add_Selection_Item("Quit Game");

            _windows.Add(map_window);
            _windows.Add(map_info_window);
            _windows.Add(update_window);
            _windows.Add(selection_window);
            

            

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
                Console.ResetColor();
                Console.SetCursorPosition(4, 1);
                Console.WriteLine(@"Current Player: {0}", _current_player.Name);
                window.Display_Border();
                window.Display_Contents();
            }
        }

        public void Update_Info(Player current_player)
        {
            _current_player = current_player;

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

        public PlayerAction Update_Active_Window(ConsoleKeyInfo key_info)
        {
            PlayerAction action = Current_window.Update(key_info);
            //Display();

            return action;
        }

        public void Reset()
        {
            foreach (Window window in _windows)
            {
                window.Reset();
            }
            
            _current_window.Active = false;
            _current_window_pointer = 0;

            _current_window = _windows[_current_window_pointer];
            _current_window.Active = true;
        }
    }

    
}

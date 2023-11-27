using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    internal class Window
    {
        private Rectangle _rectangle;
        protected int _internal_x;
        protected int _internal_y;
        private bool _active;
        private bool _activatable;
        private string _name;
        protected WindowData _data;

        public Window(Rectangle rectangle, string name)
        {
            _rectangle = rectangle;
            Name = name;
            Data = new WindowData();
            _internal_x = _rectangle.Position.X + 1;
            _internal_y = _rectangle.Position.Y + 1;
        }

        public string Name { get => _name; set => _name = value; }
        public bool Active { get => _active; set => _active = value; }
        internal WindowData Data { get => _data; set => _data = value; }
        public bool Activatable { get => _activatable; set => _activatable = value; }

        public void Display()
        {
            Display_Border();
            Display_Contents();
        }

        public void Display_Border()
        {
            //  && Activatable == true
            if (Active == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.SetCursorPosition(_rectangle.Position.X, _rectangle.Position.Y);
            List<Coord> corners = new List<Coord>();

            Coord topleftcorner = new Coord(_rectangle.Position.X, _rectangle.Position.Y);
            Coord toprightcorner = new Coord(_rectangle.Position.X + _rectangle.Width, _rectangle.Position.Y);
            Coord bottomrightcorner = new Coord(_rectangle.Position.X + _rectangle.Width, _rectangle.Position.Y + _rectangle.Height);
            Coord bottomleftcorner = new Coord(_rectangle.Position.X, _rectangle.Position.Y + _rectangle.Height);

            corners.Add(toprightcorner);
            corners.Add(topleftcorner);
            corners.Add(bottomleftcorner);
            corners.Add(bottomrightcorner);

            int width_count = 0;

            for (int i = _rectangle.Position.X; i < _rectangle.Position.X + _rectangle.Width + 1; i++)
            {
                int clearance = _rectangle.Width - 3;


                if (width_count == 2 && clearance - Name.Length >= 0)
                {
                    Console.Write(Name);
                    i = i + Name.Length;
                }
                Coord current = new Coord(i, _rectangle.Position.Y);
                bool iscorner = false;

                foreach (Coord corner in corners)
                {
                    if (corner.X == current.X && corner.Y == current.Y)
                    {
                        iscorner = true;
                    }
                }

                Console.SetCursorPosition(i, _rectangle.Position.Y);

                if (iscorner == true)
                {
                    Console.Write("+");
                }

                else
                {
                    Console.Write("-");
                }

                width_count++;
            }

            for (int i = _rectangle.Position.X; i < _rectangle.Position.X + _rectangle.Width + 1; i++)
            {
                Coord current = new Coord(i, _rectangle.Position.Y + _rectangle.Height);
                bool iscorner = false;

                foreach (Coord corner in corners)
                {
                    if (corner.X == current.X && corner.Y == current.Y)
                    {
                        iscorner = true;
                    }
                }

                Console.SetCursorPosition(i, _rectangle.Position.Y + _rectangle.Height);

                if (iscorner == true)
                {
                    Console.Write("+");
                }

                else
                {
                    Console.Write("-");
                }
            }

            for (int i = _rectangle.Position.Y; i < _rectangle.Position.Y + _rectangle.Height + 1; i++)
            {
                Coord current = new Coord(_rectangle.Position.X, i);
                bool iscorner = false;

                foreach (Coord corner in corners)
                {
                    if (corner.X == current.X && corner.Y == current.Y)
                    {
                        iscorner = true;
                    }
                }

                Console.SetCursorPosition(_rectangle.Position.X, i);

                if (iscorner == true)
                {
                    Console.Write("+");
                }

                else
                {
                    Console.Write("|");
                }
            }

            for (int i = _rectangle.Position.Y; i < _rectangle.Position.Y + _rectangle.Height + 1; i++)
            {
                Coord current = new Coord(_rectangle.Position.X + _rectangle.Width, i);
                bool iscorner = false;

                foreach (Coord corner in corners)
                {
                    if (corner.X == current.X && corner.Y == current.Y)
                    {
                        iscorner = true;
                    }
                }

                Console.SetCursorPosition(_rectangle.Position.X + _rectangle.Width, i);

                if (iscorner == true)
                {
                    Console.Write("+");
                }

                else
                {
                    Console.Write("|");
                }
            }
        }

        public virtual void Display_Contents()
        {
        }

        public virtual PlayerAction Update(ConsoleKeyInfo key_press)
        {
            return null;
        }

        public virtual void Reset()
        {
            
        }


    }
    internal class InfoWindow : Window
    {
        public InfoWindow(Rectangle rectangle, string name) : base(rectangle, name)
        {
        }

        public override void Display_Contents()
        {
            Console.SetCursorPosition(_internal_x, _internal_y);

            foreach (KeyValuePair<string, string> pair in _data.String_data)
            {
                Console.WriteLine(@"{0}: {1}", pair.Key, pair.Value);
            }
        }
        public void Add_String_Data(string key, string value)
        {
            _data.String_data.Add(key, value);
        }
    }

    internal class SelectionWindow : Window
    {
        private List<string> _selection_list;
        private int _current_selection_pointer;

        public SelectionWindow(Rectangle rectangle, string name) : base(rectangle, name)
        {
            _selection_list = new List<string>();

            foreach (KeyValuePair<string, string> pair in _data.String_data)
            {
                _selection_list.Add(pair.Value);
            }
        }

        public override void Reset()
        {
            _current_selection_pointer = 0;
        }

        public override PlayerAction Update(ConsoleKeyInfo key_press)
        {
            if (key_press.Key == ConsoleKey.DownArrow && _current_selection_pointer < _selection_list.Count - 1)
            {
                Increment_Selection_Pointer();
            }

            else if (key_press.Key == ConsoleKey.DownArrow && _current_selection_pointer == _selection_list.Count - 1)
            {
                Increment_Selection_Pointer();
            }

            else if (key_press.Key == ConsoleKey.UpArrow && _current_selection_pointer > 0)
            {
                Decrement_Selection_Pointer();
            }

            else if (key_press.Key == ConsoleKey.UpArrow && _current_selection_pointer == 0)
            {
                Decrement_Selection_Pointer();
            }

            else if (key_press.Key == ConsoleKey.Enter && _selection_list[_current_selection_pointer] == "End Turn")
            {
                return new PlayerAction("End Turn");
            }

            return null;
        }

        public override void Display_Contents()
        {
            Console.SetCursorPosition(_internal_x, _internal_y);

            for (int i = 0; i < _selection_list.Count; i++)
            {
                Console.SetCursorPosition(_internal_x, _internal_y + i);

                Console.ResetColor();

                if (i == _current_selection_pointer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(@"- {0}", _selection_list[i]);

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Increment_Selection_Pointer()
        {
            if (_current_selection_pointer == _selection_list.Count - 1)
            {
                _current_selection_pointer = 0;
            }

            else
            {
                _current_selection_pointer++;
            }
        }

        public void Decrement_Selection_Pointer()
        {
            if (_current_selection_pointer == 0)
            {
                _current_selection_pointer = _selection_list.Count - 1;
            }

            else
            {
                _current_selection_pointer--;
            }
        }

        public void Add_Selection_Item(string item)
        {
            _selection_list.Add(item);
        }
    }

    internal class MapWindow : Window
    {
        private Map _map;
        private Coord _cursor;

        public MapWindow(Rectangle rectangle, string name, Map map) : base(rectangle, name)
        {
            _map = map;

            _cursor = new Coord(0, 0);
        }

        public override void Display_Contents()
        {
            Console.ResetColor();

            Console.SetCursorPosition(_internal_x, _internal_y);

            for (int y = 0; y < _map.Height; y++)
            {


                for (int x = 0; x < _map.Width; x++)
                {
                    Tile tile = _map.GetTile(x, y);

                    if (tile.Type == "grass")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;

                    }

                    else if (tile.Type == "forest")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;

                    }

                    else if (tile.Type == "mountain")
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;

                    }

                    else if (tile.Type == "sand")
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;

                    }

                    else if (tile.Type == "water")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;

                    }

                    /*if (tile.Village != null && tile.Unit != null)
                    {
                        Console.BackgroundColor = tile.Village.Color;
                        Console.ForegroundColor = tile.Unit.Color;
                        Console.Write("W");
                    }

                    else if (tile.Village != null)
                    {
                        Console.BackgroundColor = tile.Village.Color;

                        if (tile.Village.Is_capital == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("*");
                        }

                        else if (tile.Village.Name == "outer village")
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("V");
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("V");
                        }

                    }

                    else if (tile.Unit != null)
                    {
                        Console.ForegroundColor = tile.Unit.Color;
                        Console.Write("W");
                    }

                    //else if ()

                    //else if (tile.Type == "forest")
                    //{

                    //Console.Write("♣");

                    //}

                    

                    else
                    {
                        Console.Write(tile.);
                    }
                    

                    */

                    Console.Write(" ");


                    Console.ResetColor();
                }
                (int x, int y) current_pos = Console.GetCursorPosition();
                Console.SetCursorPosition(_internal_x, current_pos.y + 1);


                //Console.WriteLine();


            }

            Console.SetCursorPosition(_internal_x + _cursor.X, _internal_y + _cursor.Y);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" ");
            Console.ResetColor();
        }

        public override PlayerAction Update(ConsoleKeyInfo key_press)
        {
            if (key_press.Key == ConsoleKey.DownArrow)
            {
                _cursor.Y++;
            }
            else if (key_press.Key == ConsoleKey.UpArrow)
            {
                _cursor.Y--;
            }
            else if (key_press.Key == ConsoleKey.LeftArrow)
            {
                _cursor.X--;
            }
            else if (key_press.Key == ConsoleKey.RightArrow)
            {
                _cursor.X++;
            }


            return null;
        }

        //public bool Cursor_In_Bounds(Coord new_cursor_coord)
        //{
        //    Coord map_coord = new Coord(_internal_x - new_cursor_coord.X, _internal_y - new_cursor_coord.Y);

        //    try
        //    {
        //        Tile next_tile = _map.GetTile(map_coord.X, map_coord.Y);
        //        return true;
        //    }

        //    catch
        //    {
        //        return false; 
        //    }
        //}

        public override void Reset()
        {
            _cursor = new Coord(0, 0);
        }

    }
}

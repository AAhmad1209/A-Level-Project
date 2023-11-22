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
        private bool _active;
        private string _name;

        public Window(Rectangle rectangle, string name)
        {
            _rectangle = rectangle;
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public bool Active { get => _active; set => _active = value; }

        public void Display_Border()
        {
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    internal class Rectangle
    {
        private Coord _position;
        private int _width;
        private int _height;
  
        public Rectangle(Coord pos, int width, int height)
        {
            _position = pos;
            Width = width;
            Height = height;
        }

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        internal Coord Position { get => _position; set => _position = value; }
    }
}

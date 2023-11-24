using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    internal class Map
    {
        private string _name;
        private string _file_name;
        private Tile[,] _terrain;
        private int _width, _height;
        public Map(string name, string file_name)
        {
            _name = name;
            _file_name = file_name;

            //obtain dimensions of map

            using (StreamReader file = new StreamReader(file_name))
            {
                string row;
                Height = 0;

                while ((row = file.ReadLine()) != null)
                {
                    Width = row.Length;

                    Height++;
                }
            }


            //read from mapfile and populate terrain array

            _terrain = new Tile[Width, Height];

            using (StreamReader file = new StreamReader(file_name))
            {
                string row;
                int y = 0;

                while ((row = file.ReadLine()) != null)
                {
                    int x = 0;

                    foreach (char c in row)
                    {

                        string type = "";

                        switch (c)
                        {
                            case '1':
                                type = "grass";
                                break;
                            case '2':
                                type = "forest";
                                break;
                            case '3':
                                type = "mountain";
                                break;
                            case '4':
                                type = "sand";
                                break;
                            case 'V':
                                type = "village";
                                break;
                            default:
                                type = "grass";
                                break;
                        }

                        _terrain[x, y] = new Tile(type);

                        x++;

                        if (x == _width)
                        {
                            break;

                        }
                    }

                    y++;
                }
            }


        }

        public Tile GetTile(int x, int y)
        {
            return _terrain[x, y];
        }

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
    }


}
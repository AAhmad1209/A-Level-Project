using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    //the GameLevel class manages all the information about a game
    internal class GameLevel
    {
        private string _game_mode;
        private Map _map;
        private List<MapEntity> _map_entities;
        private List<Player> _players;
        private Player _current_player;
        private int current_player_pointer;

        //constructor
        public GameLevel(string game_mode, List<Player> players, string map_path)
        {
            _game_mode = game_mode;
            _players = players;

            Game_Setup(map_path);
        }

        //this sets up the game level object
        public void Game_Setup(string map_path)
        {
            Load_Map(map_path);
        }

        //creates map object from file data and assigns it to _map
        public void Load_Map(string map_path)
        {

        }

        //changes current player
        public void Next_Turn()
        {

        }

        //checks if a unit exists on the map
        public bool Unit_Exists(Coord coord)
        {
            return false;
        }

        //checks if a unit can be moved
        public bool Is_Unit_Movable(Coord unit_position, Coord destination)
        {
            return false;
        }

        //moves a unit
        public void Move_unit(Coord unit_position, Coord destination)
        {

        }

        //checks if a unit can be created
        public bool Is_Unit_Creatable(string unit_type, Coord position)
        {
            return false;
        }

        //creates a unit
        public void Create_Unit(string unit_type, Coord position)
        {

        }

        //checks if a unit can be destroyed
        public bool Is_Unit_Destroyable(Coord position)
        {
            return false;
        }

        //destroys a unit
        public void Destroy_Unit(Coord position)
        {

        }

        //checks if a unit can be upgraded
        public bool Is_Unit_Upgradable(Coord position)
        {
            return false;
        }

        //upgrades a unit
        public void Upgrade_Unit(Coord position)
        {

        }

        //checks if capital can be upgraded
        public bool Is_Capital_Upgradable(Coord position)
        {
            return false;
        }

        //upgrades city
        public void Upgrade_City(Coord position)
        {

        }

        //conquers city
        public void Conquer_City(Coord position)
        {

        }


        //execute player actions
        public void Execute_Player_Action(PlayerAction action)
        {
            if (action.Type == "add unit")
            {
                Console.WriteLine("ADDED!");
            }
        }

        //validate player actions
        public bool Validate_Player_Action(PlayerAction action)
        {
            return false;
        }
        
        //returns map
        public Map Get_Map()
        {
            return _map;
        }

        //returns a list of all map entities
        public List<MapEntity> Get_Map_Entites()
        {
            return _map_entities;
        }

        //returns current player
        public Player Get_Current_Player()
        {
            return _current_player;
        }

        //returns list of all players
        public List<Player> Get_Players()
        {
            return _players;
        }

    }
}

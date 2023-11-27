using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    internal class Game
    {
        public Game()
        {
            List<Player> player_list = new List<Player>();
            player_list.Add(new Player("Player 1"));
            player_list.Add(new Player("Player 2"));
            player_list.Add(new Player("Player 3"));

            GameLevel game_level = new GameLevel("game mode here", player_list, "map path here");
            GameUI UI = new GameUI();

            GameManager manager = new GameManager(game_level, UI);
        }
    }
}

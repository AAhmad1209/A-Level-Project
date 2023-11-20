using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    //the GameManager class is used to susbscribe methods in a GameLevel object to delegates in a game_UI object
    internal class GameManager
    {
        private GameLevel _game_level;
        private GameUI _game_UI;

        //constructor
        public GameManager(GameLevel game_level, GameUI game_UI) 
        {
            _game_UI = game_UI;
            _game_level = game_level;

            _game_UI.OnPlayerAction += _game_level.Execute_Player_Action;
            _game_UI.OnPlayerActionValidation += _game_level.Validate_Player_Action;

            _game_UI.OnMapRequest += _game_level.Get_Map;
            _game_UI.OnMapEntitiesRequest += _game_level.Get_Map_Entites;

            _game_UI.OnCurrentPlayerRequest += _game_level.Get_Current_Player;
            _game_UI.OnPlayersRequest += _game_level.Get_Players;

            _game_UI.Turn_UI_Loop();
        }

        
    }
}

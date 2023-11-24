using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfConsoletopiaFinal
{
    //the GameUI class is used to display the game on the console and handle user input
    internal class GameUI
    {
        private TurnUI _turn_UI;
        //constructor
        public GameUI()
        {
            _turn_UI = new TurnUI();
        }

        //used to obtain map from GameLevel class
        public delegate Map MapRequestEventHandler();
        public event MapRequestEventHandler OnMapRequest;

        //used to obtain map entities from GameLevel class
        public delegate List<MapEntity> MapEntitiesRequestEventHandler();
        public event MapEntitiesRequestEventHandler OnMapEntitiesRequest;

        //used to obtain current player from GameLevel class
        public delegate Player CurrentPlayerRequestEventHandler();
        public event CurrentPlayerRequestEventHandler OnCurrentPlayerRequest;

        //used to obtain players from GameLevel class
        public delegate List<Player> PlayersRequestEventHandler();
        public event PlayersRequestEventHandler OnPlayersRequest;

        //used to pass PlayerAction objects to GameLevel class so that they can be executed
        public delegate void PlayerActionEventHandler(PlayerAction action);
        public event PlayerActionEventHandler OnPlayerAction;

        //used to ensure player actions are valid
        public delegate bool PlayerActionValidationEventHandler(PlayerAction action);
        public event PlayerActionValidationEventHandler OnPlayerActionValidation;


        //main UI loop
        public void Turn_UI_Loop()
        {
            
            while (true)
            {
                //Console.WriteLine("Pick and option. 1) Add unit, 2) view units etc..");

                //string input = Console.ReadLine();

                //if (input == "1")
                //{
                //    PlayerAction action = new PlayerAction("add unit");
                //    OnPlayerAction?.Invoke(action);

                //}

                //if (input == "2")
                //{
                //    PlayerAction action = new PlayerAction("add unit");
                //    Console.WriteLine(OnPlayerActionValidation?.Invoke(action));

                //}


                while (true)
                {
                    _turn_UI.Display();

                    ConsoleKeyInfo input_key = Console.ReadKey();

                    if (input_key.Key == ConsoleKey.Tab)
                    {
                        _turn_UI.Next_Window();
                    }

                    else if (input_key.Key == ConsoleKey.DownArrow || input_key.Key == ConsoleKey.UpArrow)
                    {
                        _turn_UI.Update_Active_Window(input_key);
                    }

                }

                
                Console.ReadKey();

            }
        }


    }
}

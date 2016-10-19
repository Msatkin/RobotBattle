using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyal
{
    class GameController
    {
        Board board;
        public GameController()
        {
            board = new Board();
            MainMenu();
        }

        public void MainMenu()
        {
            bool exit = false;
            while (exit)
            {
                Console.Clear();
                Console.Write("Enter Selection(Start/Exit): ");
                switch(Console.ReadLine())
                {
                    case "Start":
                        StartGame();
                        break;

                    case "Exit":
                        exit = true;
                        break;

                    default:
                        break;
                }
            }
        }

        public void StartGame()
        {
            
        }


    }
}

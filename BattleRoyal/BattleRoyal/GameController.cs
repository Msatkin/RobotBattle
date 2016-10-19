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
        MyMath math = new MyMath();
        Robot[] robotList;
        public GameController()
        {
            board = new Board();
            MainMenu();
        }

        public void MainMenu()
        {
            bool exit = false;
            while (!exit)
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
            robotList = new Robot[5];
            SpawnRobots();
            Console.Clear();
            Console.ReadLine();
        }

        public void SpawnRobots()
        {
            for (int i = 0; i < 5; i++)
            {
                int robotType = math.GetRandomNumber(0,2);
                switch(robotType)
                {
                    case 0:
                        RegularRobot robotRegular = new RegularRobot();
                        robotList[i] = robotRegular;
                        Place(robotRegular, i);
                        break;

                    case 1:
                        SuperRobot robotSuper = new SuperRobot();
                        robotList[i] = robotSuper;
                        Place(robotSuper, i);
                        break;

                    case 2:
                        ExtremeRobot robotExtreme = new ExtremeRobot();
                        robotList[i] = robotExtreme;
                        Place(robotExtreme, i);
                        break;
                }
            }
        }

        public void Place(Robot robot, int numberOfRobots)
        {
            bool placed = false;
            int canPlace;
            while (!placed)
            {
                canPlace = 1;
                robot.x = math.GetRandomNumber(0, 10);
                robot.y = math.GetRandomNumber(0, 10);
                int checkX = -1;
                int checkY = -1;
                for (int i = 0; i < numberOfRobots; i++)
                {
                    checkX = robotList[i].x;
                    checkY = robotList[i].y;
                    if (robot.x != checkX && robot.y != checkY)
                    {
                        canPlace++;
                    }
                }
                if (canPlace == numberOfRobots + 1)
                {
                    placed = true;
                }

            }
        }

    }
}

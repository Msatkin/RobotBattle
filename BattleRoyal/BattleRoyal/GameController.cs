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
        List<Robot> robotList;
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
            robotList = new List<Robot>();
            SpawnRobots();
            DrawBoard();
            BeginTurn();
            Console.Clear();
            Console.WriteLine("Robot number " + robotList[0].name + " is the WINNER!!");
            Console.ReadLine();
        }

        public void BeginTurn()
        {
            while (robotList.Count > 1)
            {
                foreach (Robot robot in robotList)
                {
                    DrawBoard();
                    robotList = robot.Turn(robotList);
                    System.Threading.Thread.Sleep(50);
                }
                for (int i = 0; i < robotList.Count; i++)
                {
                    if (robotList[i].powerLevel == 0)
                    {
                        robotList.Remove(robotList[i]);
                    }
                }
            }
        }

        public void DrawBoard()
        {
            Console.Clear();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (i == 0 || i == 11)
                    {
                        Console.Write("---");
                    }
                    else if (j == 0)
                    {
                        Console.Write("|  ");
                    }
                    else if (j == 11)
                    {
                        Console.Write("  |");
                    }
                    else
                    {
                        bool occupied = GetIsSpaceOccupied(j, i);
                        if (occupied)
                        {
                            int type = GetRobotType(j, i);
                            switch (type)
                            {
                                case 0:
                                    Console.Write(" R ");
                                    break;

                                case 1:
                                    Console.Write(" S ");
                                    break;

                                case 2:
                                    Console.Write(" E ");
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }
                }
                Console.Write("\n");
            }
        }

        public int GetRobotType(int x, int y)
        {
            foreach (Robot robot in robotList)
            {
                if (robot.x == x && robot.y == y)
                {
                    return robot.type;
                }
            }
            return -1;
        }

        public bool GetIsSpaceOccupied(int x, int y)
        {
            foreach (Robot robot in robotList)
            {
                if (robot.x == x && robot.y == y)
                {
                    return true;
                }
            }
            return false;
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
                        robotRegular.name = Convert.ToString(i);
                        robotList.Add(robotRegular);
                        Place(robotRegular);
                        break;

                    case 1:
                        SuperRobot robotSuper = new SuperRobot();
                        robotSuper.name = Convert.ToString(i);
                        robotList.Add(robotSuper);
                        Place(robotSuper);
                        break;

                    case 2:
                        ExtremeRobot robotExtreme = new ExtremeRobot();
                        robotExtreme.name = Convert.ToString(i);
                        robotList.Add(robotExtreme);
                        Place(robotExtreme);
                        break;
                }
            }
        }

        public void Place(Robot robot)
        {
            bool placed = false;
            int canPlace;
            while (!placed)
            {
                canPlace = 1;
                robot.x = math.GetRandomNumber(1, 11);
                robot.y = math.GetRandomNumber(1, 11);
                int checkX = -1;
                int checkY = -1;
                int numberOfRobots = robotList.Count - 1;
                for (int i = 0; i < numberOfRobots; i++)
                {
                    checkX = robotList[i].x;
                    checkY = robotList[i].y;
                    if (robot.x != checkX && robot.y != checkY)
                    {
                        canPlace++;
                    }
                }
                if (canPlace == robotList.Count)
                {
                    placed = true;
                }
            }
        }

    }
}

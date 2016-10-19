using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyal
{
    class Robot
    {
        public int x;
        public int y;
        public int powerLevel = 100;
        public string name;
        public int type;
        MyMath math = new MyMath();

        public List<Robot> Turn(List<Robot> robotList)
        {
            Move();
            bool occupied = GetIfSpaceIsOccupied(robotList);
            if (occupied)
            {
                robotList = Attack(robotList);
            }
            return robotList;
        }

        public List<Robot> Attack(List<Robot> robotList)
        {
            Robot robotToDelete = new Robot();
            foreach (Robot robot in robotList)
            {
                if (name != robot.name && robot.x == x && robot.y == y)
                {
                    robot.powerLevel = 0;
                }
            }
            return robotList;
        }

        public void Move()
        {
                bool canMove = false;
                int temporaryX;
                int temporaryY;
                while (!canMove)
                {
                    int moveDirection = math.GetRandomNumber(0, 3);
                    temporaryX = x;
                    temporaryY = y;
                    switch (moveDirection)
                    {
                        case 0:
                            temporaryY += 1;
                            break;

                        case 1:
                            temporaryX += 1;
                            break;

                        case 2:
                            temporaryY -= 1;
                            break;

                        case 3:
                            temporaryX -= 1;
                            break;
                    }
                    if (temporaryX < 1 || temporaryX > 10 || temporaryY < 1 || temporaryY > 10)
                    {
                        canMove = false;
                    }
                    else
                    {
                        canMove = true;
                        x = temporaryX;
                        y = temporaryY;
                    }
                }
        }

        public bool GetIfSpaceIsOccupied(List<Robot> robotList)
        {
            int checkX;
            int checkY;
            for (int i = 0; i < robotList.Count; i++)
            {
                if (name != robotList[i].name)
                {
                    checkX = robotList[i].x;
                    checkY = robotList[i].y;
                    if (x == checkX && y == checkY)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

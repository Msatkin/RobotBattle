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
        public int powerLevel;
        public string name;
        MyMath math = new MyMath();

        public List<Robot> Turn(List<Robot> robotList)
        {
            Move();
            Attack();
            return robotList;
        }

        public void Move()
        {
            int moveDirection = math.GetRandomNumber(0, 3);
            switch (moveDirection)
            {
                case 0:
                    y++;
                    break;

                case 1:
                    x++;
                    break;

                case 2:
                    y -= 1;
                    break;

                case 3:
                    x -= 1;
                    break;
            }
        }

        public void Attack()
        {

        }
    }
}

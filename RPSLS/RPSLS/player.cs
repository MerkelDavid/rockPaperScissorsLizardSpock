using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class player
    {
        protected string name;
        protected int move;
        protected int wins;

        public virtual string getName()
        {
            return name;
        }

        public virtual int getMove()
        {
            return move;
        }

        public virtual void setMove(int move)
        {
            this.move = move;
        }
        
        public virtual void setName(string name)
        {
            this.name = name;
        }

        public int getWins()
        {
            return wins;
        }

        public void incrementWins()
        {
            wins++;
        }

        public string convertIntToString(int playerMove)
        {
            switch (playerMove)
            {
                case 0:
                    return "rock";
                    break;
                case 1:
                    return "paper";
                    break;
                case 2:
                    return "scissors";
                    break;
                case 3:
                    return "lizard";
                    break;
                case 4:
                    return "spock";
                    break;
            }
            return "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Human :player
    {
        public string askForName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public int askForMove()
        {
            Console.WriteLine("what is your move? ('rock','paper','scissors','lizard',or 'spock')\n I promise not to tell the other guy.");
            string playerMove = Console.ReadLine();
            if (isAcceptableInput(playerMove))
                return convertMoveToInt(playerMove.ToLower());
            else
            {
                Console.WriteLine("Please enter a valid move.");
                return askForMove();
            }
        }

        public bool isAcceptableInput(string playerMove)
        {
            if (playerMove == "rock" || playerMove == "paper" || playerMove == "scissors" || playerMove == "lizard" || playerMove == "spock")
            {
                return true;
            }
            else return false;
        }

        public int convertMoveToInt( string playerMove)
        {
            switch (playerMove)
            {
                case "rock":
                    return 0;
                    break;
                case "paper":
                    return 1;
                    break;
                case "scissors":
                    return 2;
                    break;
                case "spock":
                    return 3;
                    break;
                case "lizard":
                    return 4;
                    break;

            }
            return 5;
        }
    }
}

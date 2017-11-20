using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        const int GOALS_TO_WIN = 2;

        public void StartGame()
        {
            Console.WriteLine("Welcome to Rock,Paper,Scissors,Lizard,Spock.\nPress any key to continue");
            Console.ReadLine();
            pickPlayers();
        }

        public void pickPlayers()
        {
            Console.WriteLine("Would you like to play \n 1.player vs. player\n 2.player vs. AI");
            string gameMode = Console.ReadLine();
            if (IsOneOrTwo(gameMode))
            {
                if(gameMode== "1")
                {
                    PlayerVsPlayer();
                }
                if (gameMode == "2")
                {
                    PlayerVsAI();
                }
                else
                {
                    pickPlayers();
                }
            }
            else
            {
                Console.WriteLine("Please enter 1 or 2");
                pickPlayers();
            }
        }

        public bool IsOneOrTwo(string gameMode)
        {
            if (gameMode == "1" || gameMode == "2")
                return true;
            else
                return false;
        }

        public void PlayerVsPlayer()
        {
            Human player1 = new Human();
            Human player2 = new Human();

            Console.WriteLine("Player 1:");
            GetPlayerName(player1);

            Console.WriteLine("Player 2:");
            GetPlayerName(player2);

            displayStartingMessage(player1, player2);

            while (!isWinner(player1,player2))
            {
                GetPlayersMoves(player1, player2);


                player winner = compareChoices(player1, player2);
                if (winner != null)
                {
                    Console.WriteLine(winner.getName() + "wins this round!");
                    winner.incrementWins();
                }
                else
                {
                    Console.WriteLine("It's a tie! I guess great minds do think alike.");
                }
            }

            displayWinner(getWinner(player1, player2));
            AskToRestart();
        }

        public void PlayerVsAI()
        {
            Human player1 = new Human();
            AI player2 = new AI();

            Console.WriteLine("Player 1:");
            GetPlayerName(player1);

            displayStartingMessage(player1, player2);

            while (!isWinner(player1, player2))
            {
                GetPlayerMove(player1);
                player2.generateMove();

                displayChoices(player1, player2);

                player winner = compareChoices(player1, player2);
                if (winner != null)
                {
                    Console.WriteLine(winner.getName() + "wins this round!");
                    winner.incrementWins();
                }
                else
                {
                    Console.WriteLine("It's a tie! I guess great minds do think alike.");
                }
            }

            displayWinner(getWinner(player1, player2));
            AskToRestart();


        }

        public void GetPlayerName(Human Player)
        {
            Player.setName(Player.askForName());
        }

        public void displayStartingMessage(player player1, player player2)
        {
            Console.WriteLine("Alright, "+ player1.getName() +" vs "+ player2.getName() +".Lets get this match underway!");

        }

        public void GetPlayerMove(Human player1)
        {
            player1.setMove(player1.askForMove());
        }

        public void GetPlayersMoves(Human player1, Human player2)
        {
            Console.WriteLine("Ok, it's " + player1.getName() + "'s turn so " + player2.getName() +" look away.\n press any button to continue.");
            Console.ReadKey();

            player1.setMove(player1.askForMove());

            Console.WriteLine("Cool,it's "+ player2.getName() +"'s turn now so "+ player2.getName() +" look away.\n press any button to continue");
            Console.ReadKey();

            player2.setMove(player2.askForMove());
        }

        public player compareChoices(player player1, player player2)
        {
            int winnerValue = (5 + player1.getMove() - player2.getMove()) % 5;

            if (winnerValue == 1 || winnerValue == 3)
            {
                return player1;
            }
            else if (winnerValue == 2 || winnerValue == 4)
            {
                return player2;
            }
            else
                return null;

        }

        public void displayChoices(player player1, player player2)
        {
            Console.WriteLine(player1.getName() + " chose " + player1.convertIntToString(player1.getMove()) + " and " + player2.getName() + " chose " + player2.convertIntToString(player2.getMove()) );

        }

        public bool isWinner(player player1, player player2)
        {
            if (player1.getWins() == GOALS_TO_WIN || player2.getWins() == GOALS_TO_WIN)
                return true;
            else
                return false;
        }

        public void displayWinner(player winner)
        {
            Console.WriteLine("CONGRATULATIONS!\n" + winner.getName() + " you win! To be honest I kind of like you better anyways.");

        }

        public player getWinner(player player1, player player2)
        {
            if (player1.getWins() > player2.getWins())
                return player1;
            else
                return player2;
        }

        public void AskToRestart()
        {
            Console.WriteLine("Thanks For Playing!\n type 'restart' to play again or 'quit' to exit");

            string PlayerChoice = Console.ReadLine();

            if (PlayerChoice == "restart")
            {
                Game gameInstance = new RPSLS.Game();
                gameInstance.StartGame();
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITransitionTask3
{
    public static class Rules
    {
        public static string[,] DefineRules(int optionsNumber)
        {
            var gameRules = new string[optionsNumber, optionsNumber];

            for (int i = 0; i < optionsNumber; i++)
            {
                gameRules[i, i] = "Draw";

                for (int j = i + 1; j < optionsNumber; j++)
                {
                    if (j <= (i + optionsNumber / 2))
                    {
                        gameRules[i, j] = "Win";
                        gameRules[j, i] = "Lose";
                    }
                    else
                    {
                        gameRules[i, j] = "Lose";
                        gameRules[j, i] = "Win";
                    }
                }
            }

            return gameRules; 
        }

        public static string CheckWinner(int pcMove, int playerMove, string[,] gameRules)
        {
            var gameResult = gameRules[pcMove, playerMove];

            switch (gameResult)
            {
                case "Win":
                    return "You won!";
                case "Lose":
                    return "You lose. Try again!";
                default:
                    return "Draw";
            }
        }
    }
}

using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITransitionTask3
{
    public static class RulesTable
    {
        public static void GenerateTable(string[,] gameRules, string[] moves)
        {
            for (int i = -1; i < moves.Length; i++)
            {
                for (int j = -1; j < moves.Length; j++)
                {
                    if (i < 0)
                    {
                        if (j < 0)
                        {
                            Console.Write($"PC/User\t");
                        }
                        else {
                            Console.Write($"|{moves[j]}\t");
                        }        
                    }
                    else
                    {
                        if (j < 0)
                        {
                            Console.Write($"|{moves[i]}\t");
                        }
                        else
                        {
                            Console.Write($"|{gameRules[i, j]}\t");
                        }
                    }
                }
                Console.WriteLine("|\t");
            }
            Console.WriteLine();
        }
    }
}

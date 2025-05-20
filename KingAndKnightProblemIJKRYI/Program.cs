using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    internal class Program
    {
        static void PrintSolution(Queue<KingAndKnightState> solution)
        {
            int step = 0;
            while (solution.Count != 0)
            {
                Console.WriteLine($"{step++}: {solution.Dequeue()}");
            }
        }

        static void PrintSolution(Stack<KingAndKnightState> solution)
        {
            int step = 0;
            while (solution.Count != 0)
            {
                Console.WriteLine($"{step++}: {solution.Pop()}");
            }
        }

        static void Main(string[] args)
        {
            BaseOfGraphSearchAlgorithms solver = new SimpleTrialAndError();
            KingAndKnightNode terminalNode = solver.FindTerminalNode();
            PrintSolution(solver.PathOfSolution(terminalNode));
        }
    }
}


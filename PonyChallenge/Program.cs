using PonyChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace PonyChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mazeWidth = GetInputInt("Input maze-width: ");
            var mazeHeight = GetInputInt("Input maze-height: ");
            Console.WriteLine("Input maze-player-name: ");
            var mazePlayerName = Console.ReadLine();
            var difficulty = GetInputInt("Input difficulty: ");

            MazeService mazeService = new MazeService();

            var createResponse = mazeService.CreateMaze(mazeWidth, mazeHeight, mazePlayerName, difficulty);
            var mazeId = createResponse.MazeId;

            var mazePrintedResponse = mazeService.GetCurrentStatePrint(mazeId);
            Console.WriteLine(mazePrintedResponse);

            var mazeState = mazeService.GetCurrentState(mazeId);

            Console.WriteLine("Calculating path....");
            Path shortestPath = PathFindingService.FindPathWhenDomokunChasing(mazeState);
            Console.WriteLine("Finished calculating");

            if (shortestPath == null)
            {
                Console.WriteLine("Where is no valid path :(");
                shortestPath = PathFindingService.FindPathsForPony(mazeState).First();
            }

            foreach (var move in shortestPath.PathSequence.Skip(1))
            {
                Thread.Sleep(100);
                var moveState = mazeService.Move(mazeId, move.Move);

                var newMazePrintedResponse = mazeService.GetCurrentStatePrint(mazeId);
                Console.WriteLine(newMazePrintedResponse);

                if (moveState.State == "won")
                {
                    Console.WriteLine(moveState.StateResult);
                    break;
                }
                else if (moveState.State == "over")
                {
                    Console.WriteLine(moveState.StateResult);
                    break;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static int GetInputInt(string outputText)
        {
            int inputInt;
            Console.WriteLine(outputText);
            string inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out inputInt) || inputInt < 0)
            {
                Console.WriteLine("Please input valid positive integer!");
                inputString = Console.ReadLine();
            }
            return inputInt;
        }
    }
}

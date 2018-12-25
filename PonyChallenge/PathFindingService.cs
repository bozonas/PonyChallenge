using PonyChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PonyChallenge
{
    public static class PathFindingService
    {
        public static Path FindShortestPathForDomokun(MazeStateResponse maze, int ponyPos, int domokunPos)
        {
            var paths = new List<Path>();
            var firstPath = new Path(domokunPos, ponyPos);

            FindPaths(maze, firstPath, paths);

            return paths.FirstOrDefault();
        }

        public static List<Path> FindPathsForPony(MazeStateResponse maze)
        {
            var list = new List<Path>();
            var firstPath = new Path(maze.Pony[0], maze.EndPoint[0]);

            FindPaths(maze, firstPath, list);

            return list.OrderBy(x => x.PathSequence.Count).ToList();
        }

        public static void FindPaths(MazeStateResponse maze, Path currentPath, List<Path> paths)
        {
            if (currentPath.CurrentPosition == currentPath.EndPosition)
            {
                paths.Add(currentPath);
                return;
            }

            var data = maze.Data;
            var squareWidth = maze.Size[0];
            var squareHeight = maze.Size[1];

            var northPosition = currentPath.CurrentPosition - squareWidth;
            var southPosition = currentPath.CurrentPosition + squareWidth;
            var westPosition = currentPath.CurrentPosition - 1;
            var eastPosition = currentPath.CurrentPosition + 1;

            // Try go North
            if (!currentPath.PathSequence.Any(x => x.Index == northPosition)
                && northPosition >= 0
                && !data[currentPath.CurrentPosition].Any(x => x == "north"))
            {
                var newPath = CreateNewPath(currentPath, northPosition, "north");
                FindPaths(maze, newPath, paths);
            }

            // Try go West
            if (!currentPath.PathSequence.Any(x => x.Index == westPosition)
                && westPosition >= 0
                && !data[currentPath.CurrentPosition].Any(x => x == "west"))
            {
                var newPath = CreateNewPath(currentPath, westPosition, "west");
                FindPaths(maze, newPath, paths);
            }

            // Try go East
            if (!currentPath.PathSequence.Any(x => x.Index == eastPosition)
                && eastPosition <= (squareWidth * squareHeight - 1)
                && !data[eastPosition].Any(x => x == "west"))
            {
                var newPath = CreateNewPath(currentPath, eastPosition, "east");
                FindPaths(maze, newPath, paths);
            }

            // Try go South
            if (!currentPath.PathSequence.Any(x => x.Index == southPosition)
                && southPosition <= (squareWidth * squareHeight - 1)
                && !data[southPosition].Any(x => x == "north"))
            {
                var newPath = CreateNewPath(currentPath, southPosition, "south");
                FindPaths(maze, newPath, paths);
            }
        }

        public static Path FindPathWhenDomokunChasing(MazeStateResponse maze)
        {
            var pathList = FindPathsForPony(maze);
            Path shortestPath = FindPathWhenDomokunChasing(maze, pathList);
            return shortestPath;
        }

        public static Path FindPathWhenDomokunChasing(MazeStateResponse maze, List<Path> pathList)
        {
            foreach (var ponyPath in pathList)
            {
                var newDomokunPos = maze.Domokun[0];

                for (int i = 1; i < ponyPath.PathSequence.Count; i++) // start from 1 because pony moves first
                {
                    // check if pony does not meet Domokun after moving
                    if (newDomokunPos == ponyPath.PathSequence[i].Index)
                        break;

                    var pathDomokun = FindShortestPathForDomokun(maze, ponyPath.PathSequence[i].Index, newDomokunPos);
                    newDomokunPos = pathDomokun.PathSequence[1].Index;

                    // check if domokun does not catch Pony
                    if (newDomokunPos == ponyPath.PathSequence[i].Index)
                        break;

                    if (i != ponyPath.PathSequence.Count - 1)
                        continue;

                    return ponyPath;
                }
            }

            return null;
        }

        private static Path CreateNewPath(Path currentPath, int newPosition, string move)
        {
            var newPath = currentPath.Clone();
            newPath.CurrentPosition = newPosition;
            newPath.PathSequence.Add(new PathSequence(newPath.CurrentPosition, move));

            return newPath;
        }

        public static bool CheckIfDomokunIsTooClose(Path path, int ponyPos, int domokunPos)
        {
            var ponyInList = path.PathSequence.FindIndex(x => x.Index == ponyPos);

            if ((path.PathSequence.Count > ponyInList + 1
                && path.PathSequence[ponyInList + 1].Index == domokunPos)
                || (path.PathSequence.Count > ponyInList + 2
                && path.PathSequence[ponyInList + 2].Index == domokunPos))
            {
                return true;
            }
            return false;
        }
    }
}

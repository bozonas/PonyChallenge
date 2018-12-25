using Microsoft.VisualStudio.TestTools.UnitTesting;
using PonyChallenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace PonyChallenge.Tests
{
    // Possible directions east, west, north, south, stay
    [TestClass]
    public class PathFindingServiceTests
    {
        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | 10  11  12| 13  14|
        /// +---+---+   +   +---+
        /// | 15| 16  17| 18  19|
        /// +   +   +---+   +---+
        /// | 20| 21  22  23  E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void FindAllPathFor5x5Maze_WithCircle()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                EndPoint = new int[] { 24 },
                Size = new int[] { 5, 5 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west", "north" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { },
                    new string[] { "north" },
                }
            };

            // Act
            var pathList = PathFindingService.FindPathsForPony(mazeStateModel);

            // Assert
            Assert.AreEqual(2, pathList.Count);
            CollectionAssert.AreEqual(
                new List<int> { 0, 1, 2, 3, 8, 13, 18, 23, 24 },
                pathList[0].PathSequence.Select(x => x.Index).ToList());
            CollectionAssert.AreEqual(
                new List<int> { 0, 1, 6, 5, 10, 11, 12, 17, 16, 21, 22, 23, 24 },
                pathList[1].PathSequence.Select(x => x.Index).ToList());
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | 10  11  12| 13  14|
        /// +---+---+   +   +---+
        /// | 15| 16  17| 18  19|
        /// +   +   +---+   +---+
        /// | 20| 21  22  23  E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void FindSingleShortestPathFor5x5Maze()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                EndPoint = new int[] { 24 },
                Size = new int[] { 5, 5 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west", "north" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { },
                    new string[] { "north" },
                }
            };

            // Act
            Path shortestPath = PathFindingService.FindPathsForPony(mazeStateModel).First();

            // Assert
            CollectionAssert.AreEqual(
                new List<int> { 0, 1, 2, 3, 8, 13, 18, 23, 24 },
                shortestPath.PathSequence.Select(x => x.Index).ToList());
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | D   11  12| 13  14|
        /// +---+---+   +   +---+
        /// | 15| 16  17| 18  19|
        /// +   +   +---+   +---+
        /// | 20| 21  22  23  E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void FindSingleShortestPathForDomokun()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                Domokun = new int[] { 10 },
                EndPoint = new int[] { 24 },
                Size = new int[] { 5, 5 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west", "north" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { },
                    new string[] { "north" },
                }
            };

            // Act
            Path shortestPath = PathFindingService.FindShortestPathForDomokun(mazeStateModel,
                mazeStateModel.Pony[0], mazeStateModel.Domokun[0]);

            // Assert
            CollectionAssert.AreEqual(
                new List<int> { 10, 5, 6, 1, 0 },
                shortestPath.PathSequence.Select(x => x.Index).ToList());
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | D   11  12| 13  14|
        /// +---+---+   +   +---+
        /// | 15| 16  17| 18  19|
        /// +   +   +---+   +---+
        /// | 20| 21  22  23| E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void TryToFindPathWhenThereIsNoPaths()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                Domokun = new int[] { 10 },
                EndPoint = new int[] { 24 },
                Size = new int[] { 5, 5 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west", "north" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { },
                    new string[] { "west", "north" },
                }
            };

            // Act
            Path shortestPath = PathFindingService.FindPathsForPony(mazeStateModel).FirstOrDefault();

            // Assert
            Assert.IsNull(shortestPath);
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | 10  11  12| D   14|
        /// +---+---+   +   +---+
        /// | 15| 16  17| 18  19|
        /// +   +   +---+   +---+
        /// | 20| 21  22  23| E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void FindSinglePathWhenDomokunChasing()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                Domokun = new int[] { 13 },
                EndPoint = new int[] { 24 },
                Size = new int[] { 5, 5 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west", "north" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { },
                    new string[] { "north" },
                }
            };

            // Act
            var pathList = PathFindingService.FindPathsForPony(mazeStateModel);
            Path shortestPath = PathFindingService.FindPathWhenDomokunChasing(mazeStateModel, pathList);

            // Assert
            CollectionAssert.AreEqual(
                new List<int> { 0, 1, 6, 5, 10, 11, 12, 17, 16, 21, 22, 23, 24 },
                shortestPath.PathSequence.Select(x => x.Index).ToList());
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | 10  11  12| 13  D |
        /// +---+---+   +   +---+
        /// | 15| 16  17| 18  19|
        /// +   +   +---+   +---+
        /// | 20| 21  22  23| E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void FindSinglePathWhenDomokunChasing_BadPathsAreBothEqual()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                Domokun = new int[] { 14 },
                EndPoint = new int[] { 24 },
                Size = new int[] { 5, 5 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west", "north" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { },
                    new string[] { "north" },
                }
            };

            // Act
            var pathList = PathFindingService.FindPathsForPony(mazeStateModel);
            Path shortestPath = PathFindingService.FindPathWhenDomokunChasing(mazeStateModel, pathList);

            // Assert
            CollectionAssert.AreEqual(
                new List<int> { 0, 1, 6, 5, 10, 11, 12, 17, 16, 21, 22, 23, 24 },
                shortestPath.PathSequence.Select(x => x.Index).ToList());
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | 10  11  12| 13  D |
        /// +   +---+   +   +---+
        /// | 15| E   17| 18  19|
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void FindSinglePathWhenDomokunChasing_MazeIsNotSquare()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                Domokun = new int[] { 14 },
                EndPoint = new int[] { 16 },
                Size = new int[] { 5, 4 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },
                }
            };

            // Act
            var pathList = PathFindingService.FindPathsForPony(mazeStateModel);
            Path shortestPath = PathFindingService.FindPathWhenDomokunChasing(mazeStateModel, pathList);

            // Assert
            CollectionAssert.AreEqual(
                new List<int> { 0, 1, 6, 5, 10, 11, 12, 17, 16 },
                shortestPath.PathSequence.Select(x => x.Index).ToList());
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   D   3 | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | 10  11  12| 13  14|
        /// +   +---+   +   +---+
        /// | 15| 16  17| 18  E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void CheckIfDomokunIsTooClose_DomokunIsTooClose()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                Domokun = new int[] { 2 },
                EndPoint = new int[] { 19 },
                Size = new int[] { 5, 4 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },
                }
            };

            // Act
            var pathList = PathFindingService.FindPathsForPony(mazeStateModel);
            Path shortestPath = pathList.FirstOrDefault();

            bool tooClose = PathFindingService.CheckIfDomokunIsTooClose(
                shortestPath, mazeStateModel.Pony[0], mazeStateModel.Domokun[0]);

            // Assert
            Assert.AreEqual(true, tooClose);
        }

        /// <summary>
        /// +---+---+---+---+---+
        /// | P   1   2   D | 4 |
        /// +---+   +   +   +   +
        /// | 5   6 | 7 | 8   9 |
        /// +   +---+---+   +---+
        /// | 10  11  12| 13  14|
        /// +   +---+   +   +---+
        /// | 15| 16  17| 18  E |
        /// +---+---+---+---+---+
        /// </summary>
        [TestMethod]
        public void CheckIfDomokunIsTooClose_DomokunIsNotTooClose()
        {
            // Arrange
            MazeStateResponse mazeStateModel = new MazeStateResponse
            {
                Pony = new int[] { 0 },
                Domokun = new int[] { 3 },
                EndPoint = new int[] { 19 },
                Size = new int[] { 5, 4 },
                Data = new string[][]
                {
                    new string[] { "west", "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west", "north" },

                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "west" },
                    new string[] { },

                    new string[] { "west" },
                    new string[] { "north" },
                    new string[] { "north" },
                    new string[] { "west" },
                    new string[] { "north" },

                    new string[] { "west" },
                    new string[] { "west", "north" },
                    new string[] { },
                    new string[] { "west" },
                    new string[] { "north" },
                }
            };

            // Act
            var pathList = PathFindingService.FindPathsForPony(mazeStateModel);
            Path shortestPath = pathList.FirstOrDefault();

            bool tooClose = PathFindingService.CheckIfDomokunIsTooClose(shortestPath,
                mazeStateModel.Pony[0], mazeStateModel.Domokun[0]);

            // Assert
            Assert.AreEqual(false, tooClose);
        }

        [TestMethod]
        public void CheckIfDomokunIsTooClose_ShouldNotFailIfPathIsShort()
        {
            Path shortestPath = new Path
            {
                PathSequence = new List<PathSequence>
                {
                    new PathSequence(0, ""),
                    new PathSequence(1, ""),
                }
            };

            bool tooClose = PathFindingService.CheckIfDomokunIsTooClose(shortestPath,1,0);

            // Assert
            Assert.AreEqual(false, tooClose);
        }
    }
}

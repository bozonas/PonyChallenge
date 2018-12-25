using PonyChallenge.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace PonyChallenge
{
    public class MazeService
    {
        private readonly IHttpClientHandler httpClient;

        public MazeService()
        {
            httpClient = new HttpClientHandler();
        }

        public MazeService(IHttpClientHandler httpClient)
        {
            this.httpClient = httpClient;
        }

        public CreateMazeResponse CreateMaze(int mazeWidth, int mazeHeight,
            string mazePlayerName, int difficulty)
        {
            var createMazeModel = new CreateMazeRequest
            {
                MazeWidth = mazeWidth,
                MazeHeight = mazeHeight,
                MazePlayerName = mazePlayerName,
                Difficulty = difficulty
            };

            var createResponse = httpClient.PostAsJson<CreateMazeRequest, CreateMazeResponse>(
                    "https://ponychallenge.trustpilot.com/pony-challenge/maze",
                    createMazeModel);

            return createResponse;
        }

        public MazeStateResponse GetCurrentState(Guid mazeId)
        {
            var mazeResponse = httpClient.Get<MazeStateResponse>(
                $"https://ponychallenge.trustpilot.com/pony-challenge/maze/{mazeId}");
            return mazeResponse;
        }

        public string GetCurrentStatePrint(Guid mazeId)
        {
            var mazeResponse = httpClient.Get(
                $"https://ponychallenge.trustpilot.com/pony-challenge/maze/{mazeId}/print");
            return mazeResponse;
        }

        public MoveMazeResponse Move(Guid mazeId, string move)
        {
            var request = new MoveRequest
            {
                Direction = move
            };

            var response = httpClient.PostAsJson<MoveRequest, MoveMazeResponse>(
                        $"https://ponychallenge.trustpilot.com/pony-challenge/maze/{mazeId}",
                       request);
            return response;
        }
    }
}

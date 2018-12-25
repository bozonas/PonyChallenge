using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PonyChallenge.Models
{
    public class MazeStateResponse
    {
        [JsonProperty(PropertyName = "pony")]
        public int[] Pony { get; set; }

        [JsonProperty(PropertyName = "domokun")]
        public int[] Domokun { get; set; }

        [JsonProperty(PropertyName = "end-point")]
        public int[] EndPoint { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int[] Size { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public int Difficulty { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string[][] Data { get; set; }

        [JsonProperty(PropertyName = "maze_id")]
        public Guid MazeId { get; set; }

        [JsonProperty(PropertyName = "game-state")]
        public GameState GameState { get; set; }
    }
}

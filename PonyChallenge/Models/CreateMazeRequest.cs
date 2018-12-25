using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PonyChallenge.Models
{
    public class CreateMazeRequest
    {
        [JsonProperty(PropertyName = "maze-width")]
        public int MazeWidth { get; set; }

        [JsonProperty(PropertyName = "maze-height")]
        public int MazeHeight { get; set; }

        [JsonProperty(PropertyName = "maze-player-name")]
        public string MazePlayerName { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public int Difficulty { get; set; }
    }
}

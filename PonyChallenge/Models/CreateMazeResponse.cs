using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PonyChallenge.Models
{
    public class CreateMazeResponse
    {
        [JsonProperty(PropertyName = "maze_id")]
        public Guid MazeId { get; set; }
    }
}

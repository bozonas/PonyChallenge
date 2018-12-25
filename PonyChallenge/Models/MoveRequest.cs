using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PonyChallenge.Models
{
    public class MoveRequest
    {
        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }
    }
}

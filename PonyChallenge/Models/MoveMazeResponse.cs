﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PonyChallenge.Models
{
    public class MoveMazeResponse
    {
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "state-result")]
        public string StateResult { get; set; }
    }
}

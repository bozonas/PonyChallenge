using System;
using System.Collections.Generic;
using System.Text;

namespace PonyChallenge
{
    public class PathSequence
    {
        public PathSequence(int index, string move)
        {
            Index = index;
            Move = move;
        }

        public PathSequence()
        { }

        public int Index { get; set; }

        public string Move { get; set; }
    }
}

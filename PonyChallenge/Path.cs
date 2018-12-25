using System;
using System.Collections.Generic;
using System.Text;

namespace PonyChallenge
{
    public class Path
    {
        public Path(int initialPosition, int endPosition)
        {
            CurrentPosition = initialPosition;
            EndPosition = endPosition;
            PathSequence = new List<PathSequence>
            {
                new PathSequence(initialPosition, "")
            };
        }

        public Path() { }

        public int CurrentPosition { get; set; }

        public int EndPosition { get; set; }

        public List<PathSequence> PathSequence { get; set; }

        public Path Clone()
        {
            return new Path
            {
                CurrentPosition = this.CurrentPosition,
                EndPosition = this.EndPosition,
                PathSequence = new List<PathSequence>(this.PathSequence),
            };
        }

        public string NextMove(int ponyPos)
        {
            var indexInPath = PathSequence.FindIndex(x => x.Index == ponyPos);
            return PathSequence[indexInPath + 1].Move;
        }

        public string PrevMove(int ponyPos)
        {
            var indexInPath = PathSequence.FindIndex(x => x.Index == ponyPos);
            return PathSequence[indexInPath - 1].Move;
        }
    }
}

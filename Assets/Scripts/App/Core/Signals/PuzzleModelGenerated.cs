using App.Core.Puzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Signals
{
    public class PuzzleModelGenerated
    {
        private PuzzleModel puzzleModel;

        public PuzzleModelGenerated(PuzzleModel puzzleModel)
        {
            this.puzzleModel = puzzleModel;
        }

        public PuzzleModel PuzzleModel { get => puzzleModel; private set => puzzleModel = value; }
    }
}

using App.Core.Puzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Signals
{
    public class OnPuzzleModelGenerated
    {
        private PuzzleModel puzzleModel;

        public OnPuzzleModelGenerated(PuzzleModel puzzleModel)
        {
            this.puzzleModel = puzzleModel;
        }

        public PuzzleModel PuzzleModel { get => puzzleModel; private set => puzzleModel = value; }
    }
}

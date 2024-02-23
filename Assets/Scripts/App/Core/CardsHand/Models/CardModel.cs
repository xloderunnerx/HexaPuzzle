using App.Core.Puzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CardsHand
{
    public class CardModel
    {
        public PuzzleSegmentModel puzzleSegmentModel;

        public CardModel(PuzzleSegmentModel puzzleSegmentModel)
        {
            this.puzzleSegmentModel = puzzleSegmentModel;
        }

        public CardModel()
        {
        }
    }
}

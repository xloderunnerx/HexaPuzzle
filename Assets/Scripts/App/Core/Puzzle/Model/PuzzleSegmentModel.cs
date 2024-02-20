using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Puzzle
{
    public class PuzzleSegmentModel
    {
        public List<PuzzleCellModel> segment;

        public PuzzleSegmentModel()
        {
            segment = new List<PuzzleCellModel>();
        }

        public PuzzleSegmentModel(List<PuzzleCellModel> segment)
        {
            this.segment = segment;
        }

        public void AddCell(PuzzleCellModel puzzleCellModel)
        {
            segment.Add(puzzleCellModel);
        }

        public void RemoveCell(PuzzleCellModel puzzleCellModel)
        {
            segment.Remove(puzzleCellModel);
        }
    }
}

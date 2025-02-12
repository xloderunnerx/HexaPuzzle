﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Puzzle
{
    public class PuzzleModel
    {
        public List<PuzzleSegmentModel> puzzle;
        public int radius;

        public PuzzleModel()
        {
            puzzle = new List<PuzzleSegmentModel>();
        }

        public PuzzleModel(List<PuzzleSegmentModel> puzzle)
        {
            this.puzzle = puzzle;
        }

        public void AddSegment(PuzzleSegmentModel puzzleSegmentModel)
        {
            puzzle.Add(puzzleSegmentModel);
        }

        public void RemoveSegment(PuzzleSegmentModel puzzleSegmentModel)
        {
            puzzle.Remove(puzzleSegmentModel);
        }

        public void Clear()
        {
            puzzle.Clear();
        }

        public void RemoveEmptySegments()
        {
            puzzle = puzzle.Where(segment => segment.segment.Count != 0).ToList();
        }

        public List<PuzzleCellModel> GetCells()
        {
            var cells = new List<PuzzleCellModel>();
            puzzle.ForEach(segment =>
            {
                segment.segment.ForEach(cell =>
                {
                    cells.Add(cell);
                });
            });
            return cells;
        }
    }
}

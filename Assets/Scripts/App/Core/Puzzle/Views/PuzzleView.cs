using Composite.Core;
using System.Collections.Generic;
using UnityEngine;

namespace App.Core.Puzzle
{
    public class PuzzleView : AbstractView
    {
        [SerializeField] private List<PuzzleSegmentView> puzzle;

        private void Awake()
        {
            puzzle = new List<PuzzleSegmentView>();
        }

        public void AddSegment(PuzzleSegmentView puzzleSegmentView) => puzzle.Add(puzzleSegmentView);

        public void RemoveAndDestroySegment(PuzzleSegmentView puzzleSegmentView)
        {
            puzzle.Remove(puzzleSegmentView);
            Destroy(puzzleSegmentView.gameObject);
        }

        public void RemoveAndDestroyAll()
        {
            for (int i = puzzle.Count - 1; i >= 0; i--)
            {
                RemoveAndDestroySegment(puzzle[i]);
            }
        }
    }
}

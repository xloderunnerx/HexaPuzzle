using Composite.Core;
using System.Collections.Generic;
using UnityEngine;

namespace App.Core.Puzzle
{
    public class PuzzleSegmentView : AbstractView
    {
        [SerializeField] private List<PuzzleCellView> segment;

        private void Awake()
        {
            segment = new List<PuzzleCellView>();
        }

        public void AddCell(PuzzleCellView puzzleCellView) => segment.Add(puzzleCellView);

        public void RemoveAndDestroyCell(PuzzleCellView puzzleCellView)
        {
            segment.Remove(puzzleCellView);
            Destroy(puzzleCellView.gameObject);
        }

        public void RemoveAndDestroyAll()
        {
            for (int i = segment.Count - 1; i >= 0; i--)
            {
                RemoveAndDestroyCell(segment[i]);
            }
        }
    }
}

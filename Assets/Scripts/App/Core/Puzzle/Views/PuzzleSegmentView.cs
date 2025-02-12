﻿using Composite.Core;
using System.Collections.Generic;
using System.Linq;
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

        public Vector2 GetSegmentWorldSize()
        {
            var bounds = new Bounds(segment.FirstOrDefault().transform.position, segment.FirstOrDefault().GetWorldBoundsWithoutBorder().size);
            segment.Where(cell => cell != segment.FirstOrDefault())
                .ToList()
                .ForEach(cell => bounds.Encapsulate(cell.GetWorldBoundsWithoutBorder()));
            var worldSize = bounds.size;
            return worldSize;
        }

        public void GenerateSegment(PuzzleSegmentModel puzzleSegmentModel, PuzzleCellView puzzleCellViewPrefab)
        {
            var cardPuzzleCellViewWidth = puzzleCellViewPrefab.GetWidthWithoutBorder();
            var cardPuzzleCellViewHeight = puzzleCellViewPrefab.GetHeightWithoutBorder();
            puzzleSegmentModel.segment.ForEach(cellModel =>
            {
                var cardPuzzleCellView = GameObject.Instantiate(puzzleCellViewPrefab);
                cardPuzzleCellView.transform.SetParent(transform, true);
                cardPuzzleCellView.SetPositionHex(cellModel.transform.position);
                cardPuzzleCellView.SetFillColor(cellModel.fillColor);
                cardPuzzleCellView.transform.position = new Vector3(cellModel.transform.position.x * cardPuzzleCellViewWidth - cellModel.transform.position.x * cardPuzzleCellViewWidth * 0.25f,
                    cellModel.transform.position.y * cardPuzzleCellViewHeight + cellModel.transform.position.x * cardPuzzleCellViewHeight * 0.5f, 0);
                cardPuzzleCellView.gameObject.name = $"X: {cellModel.transform.position.x}; Y: {cellModel.transform.position.y}; Z: {cellModel.transform.position.z}";
                segment.Add(cardPuzzleCellView);
            });

            RecenterSegment();
        }

        private void RecenterSegment()
        {
            segment.ForEach(cardPuzzleCellView => cardPuzzleCellView.transform.parent = null);
            Bounds bounds = new Bounds(segment.FirstOrDefault().transform.position, segment.FirstOrDefault().GetWorldBoundsWithoutBorder().size);
            segment.Where(cardPuzzleCellView => cardPuzzleCellView != segment.FirstOrDefault())
                .ToList()
                .ForEach(cardPuzzleCellView => bounds.Encapsulate(cardPuzzleCellView.GetWorldBoundsWithoutBorder()));
            var centerSegmentPosition = bounds.center;
            transform.position = centerSegmentPosition;
            segment.ForEach(cardPuzzleCellView => cardPuzzleCellView.transform.SetParent(transform, true));
        }

        public int SetSortingOrder(int value)
        {
            segment.ForEach(cardPuzzleCellView => cardPuzzleCellView.SetSortingOrder(value));
            var lastSortingOrder = segment.LastOrDefault().SetSortingOrder(value);
            return lastSortingOrder;
        }
    }
}

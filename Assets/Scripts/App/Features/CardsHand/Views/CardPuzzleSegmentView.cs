using App.Core.Puzzle;
using Composite.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.Features.CardsHand
{
    public class CardPuzzleSegmentView : AbstractView
    {
        [SerializeField] private List<CardPuzzleCellView> segment;

        private void Awake()
        {
            segment = new List<CardPuzzleCellView>();
        }

        public Vector2 GetSegmentWorldSize()
        {
            var cellWidth = segment.FirstOrDefault().GetWidthWithoutBorder();
            var cellHeight = segment.FirstOrDefault().GetHeightWithoutBorder();

            var minX = segment.Select(cell => cell.TransformHex.position.x).Min();
            var maxX = segment.Select(cell => cell.TransformHex.position.x).Max();
            var minY = segment.Select(cell => cell.TransformHex.position.y).Min();
            var maxY = segment.Select(cell => cell.TransformHex.position.y).Max();

            var xSize = maxX - minX + 1;
            var ySize = maxY - minY + 1;

            var worldSize = new Vector2(xSize * (cellWidth / 4 * 3) + cellWidth / 4, ySize * cellHeight - cellHeight / 2);

            return worldSize;
        }

        public void RemoveAndDestroyCell(CardPuzzleCellView cardPuzzleCellView)
        {
            segment.Remove(cardPuzzleCellView);
            Destroy(cardPuzzleCellView.gameObject);
        }

        public void RemoveAndDestroyAll()
        {
            for (int i = segment.Count - 1; i >= 0; i--)
            {
                RemoveAndDestroyCell(segment[i]);
            }
        }

        public void GenerateSegment(PuzzleSegmentModel puzzleSegmentModel, CardsHandConfiguration configuration)
        {
            var cardPuzzleCellViewWidth = configuration.cardPuzzleCellViewPrefab.GetWidthWithoutBorder();
            var cardPuzzleCellViewHeight = configuration.cardPuzzleCellViewPrefab.GetHeightWithoutBorder();
            puzzleSegmentModel.segment.ForEach(cellModel =>
            {
                var cardPuzzleCellView = GameObject.Instantiate(configuration.cardPuzzleCellViewPrefab);
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
            Debug.Log($"{gameObject.name} center Position is = " + centerSegmentPosition);
            transform.position = centerSegmentPosition;
            segment.ForEach(cardPuzzleCellView => cardPuzzleCellView.transform.SetParent(transform, true));
        }

        private void OnDrawGizmos()
        {
            var centerSegmentPosition = Vector2.zero;
            segment.ForEach(cardPuzzleCellView => centerSegmentPosition += (Vector2)cardPuzzleCellView.transform.position);
            centerSegmentPosition /= segment.Count;


            Bounds bounds = new Bounds(transform.position, Vector3.zero);

            segment.ForEach(cardPuzzleCellView => bounds.Encapsulate(cardPuzzleCellView.GetWorldBoundsWithoutBorder()));

            var centerSegmentBoundsPosition = bounds.center;

            Gizmos.DrawSphere(bounds.min, 0.2f);
            Gizmos.DrawSphere(bounds.max, 0.2f);
            Gizmos.DrawSphere(bounds.center, 0.4f);
        }
    }
}

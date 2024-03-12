using App.Core.Puzzle;
using App.Features.HandViewGenerator;
using Composite.Core;
using Shapes;
using UnityEngine;

namespace App.Core.Hand
{
    public class CardView : AbstractView
    {
        [SerializeField] private Rectangle background;
        [SerializeField] private Rectangle border;
        [SerializeField] private RectTransform puzzleSegmentLayout;

        private CardModel cardModel;
        private PuzzleSegmentView puzzleSegmentView;

        public CardModel CardModel { get => cardModel; private set => cardModel = value; }

        public Vector2 GetSize() => new Vector2(background.Width, background.Height);

        public void SetSortingOrder(int value)
        {
            background.SortingOrder = value;
            border.SortingOrder = background.SortingOrder + 1;
            puzzleSegmentView.SetSortingOrder(value);
        }

        public int GetHighestSortingOrder() => border.SortingOrder;

        public void SetCardModel(CardModel value) => cardModel = value;

        public void GeneratePuzzleSegmentView(CardModel value, HandViewGeneratorConfiguration configuration)
        {
            puzzleSegmentView = new GameObject($"CardPuzzleSegmentView + {Random.Range(0, 300)}").AddComponent<PuzzleSegmentView>();
            puzzleSegmentView.transform.SetParent(puzzleSegmentLayout, false);
            puzzleSegmentView.GenerateSegment(value.puzzleSegmentModel, configuration.puzzleCellViewPrefab);
            CenterSegmentToLayout();
            ResizeSegmentToLayout();
        }

        private void CenterSegmentToLayout()
        {
            puzzleSegmentView.transform.position = puzzleSegmentLayout.transform.position;
        }

        private void ResizeSegmentToLayout()
        {
            var segmentWorldSize = puzzleSegmentView.GetSegmentWorldSize();
            var layoutWorldSize = puzzleSegmentLayout.sizeDelta * puzzleSegmentLayout.lossyScale;
            var scaleX = layoutWorldSize.x / segmentWorldSize.x;
            var scaleY = layoutWorldSize.y / segmentWorldSize.y;

            var minScale = Mathf.Min(scaleX, scaleY);

            puzzleSegmentView.transform.localScale = Vector3.one * minScale;
        }
    }
}

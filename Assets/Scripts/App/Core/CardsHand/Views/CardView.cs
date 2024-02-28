using App.Core.Puzzle;
using App.Features.CardsHand;
using Composite.Core;
using Shapes;
using UnityEngine;

namespace App.Core.CardsHand
{
    public class CardView : AbstractView
    {
        [SerializeField] private Rectangle background;
        [SerializeField] private Rectangle border;
        [SerializeField] private RectTransform puzzleSegmentLayout;

        private CardModel cardModel;
        private CardPuzzleSegmentView cardPuzzleSegmentView;

        public CardModel CardModel { get => cardModel; private set => cardModel = value; }

        public Vector2 GetSize() => new Vector2(background.Width, background.Height);

        public void SetSortingOrder(int value)
        {
            background.SortingOrder = value;
            border.SortingOrder = background.SortingOrder + 1;

        }

        public int GetHighestSortingOrder() => border.SortingOrder;

        public void SetCardModel(CardModel value) => cardModel = value;

        public void GeneratePuzzleSegmentView(CardModel value, CardsHandConfiguration configuration)
        {
            cardPuzzleSegmentView = new GameObject($"CardPuzzleSegmentView + {Random.Range(0, 300)}").AddComponent<CardPuzzleSegmentView>();
            cardPuzzleSegmentView.transform.SetParent(puzzleSegmentLayout, false);
            cardPuzzleSegmentView.GenerateSegment(value.puzzleSegmentModel, configuration);
            CenterSegmentToLayout();
            ResizeSegmentToLayout();
        }

        private void CenterSegmentToLayout()
        {
            cardPuzzleSegmentView.transform.position = puzzleSegmentLayout.transform.position;
        }

        private void ResizeSegmentToLayout()
        {
            var segmentWorldSize = cardPuzzleSegmentView.GetSegmentWorldSize();
            Debug.Log($"{cardPuzzleSegmentView.gameObject.name} = " + cardPuzzleSegmentView.GetSegmentWorldSize());
            var layoutWorldSize = puzzleSegmentLayout.sizeDelta * puzzleSegmentLayout.lossyScale;
            Debug.Log("layoutWorld Size = " + layoutWorldSize);
            var scaleX = layoutWorldSize.x / segmentWorldSize.x;
            var scaleY = layoutWorldSize.y / segmentWorldSize.y;

            var minScale = Mathf.Min(scaleX, scaleY);

            cardPuzzleSegmentView.transform.localScale = Vector3.one * minScale;
        }
    }
}

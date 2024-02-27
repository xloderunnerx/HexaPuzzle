using App.Core.Puzzle;
using Composite.Core;
using Shapes;
using UnityEngine;

namespace App.Core.CardsHand
{
    public class CardView : AbstractView
    {
        [SerializeField] private Rectangle background;
        [SerializeField] private Rectangle border;

        private CardModel cardModel;
        private PuzzleSegmentView puzzleSegmentView;

        public CardModel CardModel { get => cardModel; private set => cardModel = value; }

        public Vector2 GetSize() => new Vector2(background.Width, background.Height);

        public void SetSortingOrder(int value)
        {
            background.SortingOrder = value;
            border.SortingOrder = value + 1;
        }

        public int GetHighestSortingOrder() => border.SortingOrder;

        public void SetCardModel(CardModel value) => cardModel = value;

        public void GeneratePuzzleSegmentView(CardModel value)
        {

        }
    }
}

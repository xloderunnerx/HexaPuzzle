using Composite.Core;
using Shapes;
using UnityEngine;

namespace App.Core.CardsHand
{
    public class CardView : AbstractView
    {
        [SerializeField] private Rectangle background;
        [SerializeField] private Rectangle border;

        public Vector2 GetSize() => new Vector2(background.Width, background.Height);

        public void SetSortingOrder(int value)
        {
            background.SortingOrder = value;
            border.SortingOrder = value;
        }
    }
}

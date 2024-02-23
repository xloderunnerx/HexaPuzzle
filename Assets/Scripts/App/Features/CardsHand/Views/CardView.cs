using Composite.Core;
using Shapes;
using UnityEngine;

namespace App.Features.CardsHand
{
    public class CardView : AbstractView
    {
        [SerializeField] private Rectangle background;

        public Vector2 GetSize() => new Vector2(background.Width, background.Height);
    }
}

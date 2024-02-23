using Composite.Core;
using UnityEngine;

namespace App.Features.CardsHand
{
	public class CardsHandView : AbstractView
	{
		[SerializeField] private RectTransform cardsHandPanel;

        public RectTransform CardsHandPanel { get => cardsHandPanel; private set => cardsHandPanel = value; }
    }
}
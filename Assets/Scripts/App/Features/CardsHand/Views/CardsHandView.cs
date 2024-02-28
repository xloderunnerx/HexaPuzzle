using App.Core.Puzzle;
using Composite.Core;
using UnityEngine;

namespace App.Features.CardsHand
{
	public class CardsHandView : AbstractView
	{
		[SerializeField] private RectTransform cardsHandPanel;

		public void GenerateCards(CardsHandModel cardsHandModel, CardsHandConfiguration configuration)
		{
            var lastHighestSortingOrder = configuration.defaultSortingOrder;
            cardsHandModel.cards.ForEach(cardModel => {
                var cardView = GameObject.Instantiate(configuration.cardViewPrefab);
                cardView.gameObject.transform.SetParent(cardsHandPanel, false);
                cardView.SetSortingOrder(configuration.defaultSortingOrder + lastHighestSortingOrder);
                cardView.SetCardModel(cardModel);
                cardView.GeneratePuzzleSegmentView(cardModel, configuration);
                lastHighestSortingOrder = cardView.GetHighestSortingOrder();
            });
        }
    }
}
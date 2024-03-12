using App.Core.Hand;
using Composite.Core;
using UnityEngine;

namespace App.Features.HandViewGenerator
{
	public class HandViewGeneratorView : AbstractView
	{
        [SerializeField] private RectTransform cardsHandPanel;

        public void Generate(HandModel handModel, HandViewGeneratorConfiguration configuration)
        {
            var lastHighestSortingOrder = configuration.defaultSortingOrder;
            handModel.cards.ForEach(cardModel => {
                var cardView = GameObject.Instantiate(configuration.cardViewPrefab);
                cardView.gameObject.transform.SetParent(cardsHandPanel, false);
                cardView.SetCardModel(cardModel);
                cardView.GeneratePuzzleSegmentView(cardModel, configuration);
                cardView.SetSortingOrder(configuration.defaultSortingOrder + lastHighestSortingOrder);
                lastHighestSortingOrder = cardView.GetHighestSortingOrder();
            });
        }
    }
}
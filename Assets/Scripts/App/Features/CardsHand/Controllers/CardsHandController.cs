using App.Core.Signals;
using Composite.Core;
using System;
using UnityEngine;

namespace App.Features.CardsHand
{
	public class CardsHandController : AbstractController
	{
		private CardsHandView view;
		private CardsHandConfiguration configuration;
		private CardsHandModel model;

        public CardsHandController(CardsHandView view, CardsHandConfiguration configuration, CardsHandModel model)
        {
            this.view = view;
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
		}

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<OnPuzzleModelGenerated>(GenerateCardsModel);
        }

        private void GenerateCardsModel(OnPuzzleModelGenerated signal)
        {
            model.GenerateCardModels(signal.PuzzleModel);
            GenerateCardViews();
        }

        private void GenerateCardViews()
        {
            var lastHighestSortingOrder = configuration.defaultSortingOrder;
            model.cards.ForEach(cardModel => {
                var cardView = GameObject.Instantiate(configuration.cardViewPrefab);
                cardView.gameObject.transform.SetParent(view.CardsHandPanel.transform, false);
                cardView.SetSortingOrder(configuration.defaultSortingOrder + lastHighestSortingOrder);
                cardView.SetCardModel(cardModel);
                lastHighestSortingOrder = cardView.GetHighestSortingOrder();
            });
        }
    }
}
using App.Core;
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
            SubscribeToSignal<PuzzleModelGenerated>(GenerateCardsModel);
        }

        private void GenerateCardsModel(PuzzleModelGenerated signal)
        {
            model.GenerateCardModels(signal.PuzzleModel);
            view.GenerateCards(model, configuration);
        }
    }
}
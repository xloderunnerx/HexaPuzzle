using App.Core.Signals;
using Composite.Core;
using System;

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
        }
    }
}
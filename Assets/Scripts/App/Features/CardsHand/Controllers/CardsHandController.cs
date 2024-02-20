using Composite.Core;

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
	}
}
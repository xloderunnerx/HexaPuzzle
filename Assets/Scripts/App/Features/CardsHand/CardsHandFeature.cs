using Composite.Core;

namespace App.Features.CardsHand
{
	public class CardsHandFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<CardsHandModel>();
			CompositionRoot.BindFromHierarchy<CardsHandView>();
			CompositionRoot.BindController<CardsHandController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<CardsHandConfiguration>().isEnabled;
		}
	}
}
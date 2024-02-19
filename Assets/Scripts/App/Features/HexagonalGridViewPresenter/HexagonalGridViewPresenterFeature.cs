using Composite.Core;

namespace App.Features.HexagonalGridViewPresenter
{
	public class HexagonalGridViewPresenterFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<HexagonalGridViewPresenterModel>();
			CompositionRoot.BindFromHierarchy<HexagonalGridViewPresenterView>();
			CompositionRoot.BindController<HexagonalGridViewPresenterController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<HexagonalGridViewPresenterConfiguration>().isEnabled;
		}
	}
}
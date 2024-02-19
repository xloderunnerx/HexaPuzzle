using Composite.Core;

namespace App.Features.HexagonalGridModelCutter
{
	public class HexagonalGridModelCutterFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<HexagonalGridModelCutterModel>();
			CompositionRoot.BindFromHierarchy<HexagonalGridModelCutterView>();
			CompositionRoot.BindController<HexagonalGridModelCutterController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<HexagonalGridModelCutterConfiguration>().isEnabled;
		}
	}
}
using Composite.Core;

namespace App.Features.HexagonalGridModelGenerator
{
	public class HexagonalGridModelGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<HexagonalGridModelGeneratorModel>();
			CompositionRoot.BindController<HexagonalGridModelGeneratorController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<HexagonalGridModelGeneratorConfiguration>().isEnabled;
		}
	}
}
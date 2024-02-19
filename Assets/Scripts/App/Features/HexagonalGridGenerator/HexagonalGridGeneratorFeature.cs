using Composite.Core;

namespace App.Features.HexagonalGridGenerator
{
	public class HexagonalGridGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
            CompositionRoot.Bind<HexagonalGridGeneratorModel>();
            CompositionRoot.BindFromHierarchy<HexagonalGridGeneratorView>();
			CompositionRoot.BindController<HexagonalGridGeneratorController>();
			
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<HexagonalGridGeneratorConfiguration>().isEnabled;
		}
	}
}
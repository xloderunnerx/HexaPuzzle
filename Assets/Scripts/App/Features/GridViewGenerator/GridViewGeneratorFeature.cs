using Composite.Core;

namespace App.Features.GridViewGenerator
{
	public class GridViewGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<GridViewGeneratorModel>();
			CompositionRoot.BindFromHierarchy<GridViewGeneratorView>();
			CompositionRoot.BindController<GridViewGeneratorController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<GridViewGeneratorConfiguration>().isEnabled;
		}
	}
}
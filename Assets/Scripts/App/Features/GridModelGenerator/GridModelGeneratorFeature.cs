using Composite.Core;

namespace App.Features.GridModelGenerator
{
	public class GridModelGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<GridModelGeneratorModel>();
			CompositionRoot.BindFromHierarchy<GridModelGeneratorView>();
			CompositionRoot.BindController<GridModelGeneratorController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<GridModelGeneratorConfiguration>().isEnabled;
		}
	}
}
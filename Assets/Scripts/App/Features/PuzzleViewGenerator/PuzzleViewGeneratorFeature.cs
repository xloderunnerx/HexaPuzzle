using Composite.Core;

namespace App.Features.PuzzleViewGenerator
{
	public class PuzzleViewGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<PuzzleViewGeneratorModel>();
			CompositionRoot.BindFromHierarchy<PuzzleViewGeneratorView>();
			CompositionRoot.BindController<PuzzleViewGeneratorController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<PuzzleViewGeneratorConfiguration>().isEnabled;
		}
	}
}
using Composite.Core;

namespace App.Features.PuzzleModelGenerator
{
	public class PuzzleModelGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<PuzzleModelGeneratorModel>();
			CompositionRoot.BindController<PuzzleModelGeneratorController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<PuzzleModelGeneratorConfiguration>().isEnabled;
		}
	}
}
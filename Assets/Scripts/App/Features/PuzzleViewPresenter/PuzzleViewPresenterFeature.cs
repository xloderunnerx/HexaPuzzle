using Composite.Core;

namespace App.Features.PuzzleViewPresenter
{
	public class PuzzleViewPresenterFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<PuzzleViewPresenterModel>();
			CompositionRoot.BindFromHierarchy<PuzzleViewPresenterView>();
			CompositionRoot.BindController<PuzzleViewPresenterController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<PuzzleViewPresenterConfiguration>().isEnabled;
		}
	}
}
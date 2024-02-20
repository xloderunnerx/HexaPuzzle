using Composite.Core;

namespace App.Features.PuzzlePainter
{
	public class PuzzlePainterFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<PuzzlePainterModel>();
			CompositionRoot.BindController<PuzzlePainterController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<PuzzlePainterConfiguration>().isEnabled;
		}
	}
}
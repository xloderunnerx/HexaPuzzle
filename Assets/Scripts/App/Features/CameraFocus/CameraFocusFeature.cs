using Composite.Core;

namespace App.Features.CameraFocus
{
	public class CameraFocusFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<CameraFocusModel>();
			CompositionRoot.BindFromHierarchy<CameraFocusView>();
			CompositionRoot.BindController<CameraFocusController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<CameraFocusConfiguration>().isEnabled;
		}
	}
}
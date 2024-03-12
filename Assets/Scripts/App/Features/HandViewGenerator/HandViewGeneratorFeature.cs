using Composite.Core;

namespace App.Features.HandViewGenerator
{
	public class HandViewGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<HandViewGeneratorModel>();
			CompositionRoot.BindFromHierarchy<HandViewGeneratorView>();
			CompositionRoot.BindController<HandViewGeneratorController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<HandViewGeneratorConfiguration>().isEnabled;
		}
	}
}
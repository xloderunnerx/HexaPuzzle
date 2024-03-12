using Composite.Core;

namespace App.Features.HandModelGenerator
{
	public class HandModelGeneratorFeature : AbstractFeature
	{
		public override void InstallBindings()
		{
			CompositionRoot.Bind<HandModelGeneratorModel>();
			CompositionRoot.BindController<HandModelGeneratorController>();
		}

		public override bool IsEnabled()
		{
			return CompositionRoot.GetInstance<HandModelGeneratorConfiguration>().isEnabled;
		}
	}
}
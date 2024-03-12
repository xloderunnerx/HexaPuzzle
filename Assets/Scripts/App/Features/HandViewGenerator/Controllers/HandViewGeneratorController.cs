using App.Core.Signals;
using Composite.Core;
using System;

namespace App.Features.HandViewGenerator
{
	public class HandViewGeneratorController : AbstractController
	{
		private HandViewGeneratorConfiguration configuration;
		private HandViewGeneratorView view;
		private HandViewGeneratorModel model;

        public HandViewGeneratorController(HandViewGeneratorConfiguration configuration, HandViewGeneratorView view, HandViewGeneratorModel model)
        {
            this.configuration = configuration;
            this.view = view;
            this.model = model;
        }

        public override void Initialize()
		{
		}

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<HandModelGenerated>(Generate);
        }

        private void Generate(HandModelGenerated signal)
        {
            view.Generate(signal.HandModel, configuration);
        }
    }
}
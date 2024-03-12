using App.Core.Signals;
using Composite.Core;
using System;

namespace App.Features.HandModelGenerator
{
	public class HandModelGeneratorController : AbstractController
	{
        private HandModelGeneratorConfiguration configuration;
        private HandModelGeneratorModel model;

        public HandModelGeneratorController(HandModelGeneratorConfiguration configuration, HandModelGeneratorModel model)
        {
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
		}

        public override void DeclareSignals()
        {
            DeclareSignal<HandModelGenerated>();
        }

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<PuzzleModelGenerated>(Generate);
        }

        private void Generate(PuzzleModelGenerated signal)
        {
            model.Generate(signal.PuzzleModel);
            TryFireSignal(new HandModelGenerated(model.handModel));
        }
    }
}
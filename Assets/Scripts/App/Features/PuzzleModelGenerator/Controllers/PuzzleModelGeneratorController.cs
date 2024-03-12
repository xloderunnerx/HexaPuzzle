using App.Core.Signals;
using Composite.Core;
using System;

namespace App.Features.PuzzleModelGenerator
{
    public class PuzzleModelGeneratorController : AbstractController
    {
        private PuzzleModelGeneratorConfiguration configuration;
        private PuzzleModelGeneratorModel model;

        public PuzzleModelGeneratorController(PuzzleModelGeneratorConfiguration configuration, PuzzleModelGeneratorModel model)
        {
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
        {

        }

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<GridModelGenerated>(GeneratePuzzleModel);
        }

        public override void DeclareSignals()
        {
            DeclareSignal<PuzzleModelGenerated>();
        }

        private void GeneratePuzzleModel(GridModelGenerated signal)
        {
            model.GeneratePuzzleModel(signal.GridModel, configuration);
            TryFireSignal(new PuzzleModelGenerated(model.puzzleModel));
        }
    }
}
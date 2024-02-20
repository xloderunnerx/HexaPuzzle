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
            SubscribeToSignal<OnHexagonalGridModelGenerated>(GeneratePuzzleModel);
        }

        public override void DeclareSignals()
        {
            DeclareSignal<OnPuzzleModelGenerated>();
        }

        private void GeneratePuzzleModel(OnHexagonalGridModelGenerated signal)
        {
            model.GeneratePuzzleModel(signal.HexagonalGridModel, configuration);
            TryFireSignal(new OnPuzzleModelGenerated(model.puzzleModel));
        }
    }
}
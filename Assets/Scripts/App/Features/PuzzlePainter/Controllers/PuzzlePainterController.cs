using App.Core.Signals;
using Composite.Core;
using System;

namespace App.Features.PuzzlePainter
{
	public class PuzzlePainterController : AbstractController
	{
		private PuzzlePainterConfiguration configuration;
		private PuzzlePainterModel model;

        public PuzzlePainterController(PuzzlePainterConfiguration configuration, PuzzlePainterModel model)
        {
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
		}

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<PuzzleModelGenerated>(PaintPuzzle);
        }

        private void PaintPuzzle(PuzzleModelGenerated signal)
        {
            model.PaintPuzzle(signal.PuzzleModel, configuration);
        }
    }
}
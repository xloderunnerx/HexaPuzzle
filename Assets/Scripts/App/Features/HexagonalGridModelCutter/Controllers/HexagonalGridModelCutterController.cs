using App.Core.Hexagonal;
using App.Core.Signals;
using Composite.Core;
using System;

namespace App.Features.HexagonalGridModelCutter
{
	public class HexagonalGridModelCutterController : AbstractController
	{
		private HexagonalGridModelCutterView view;
		private HexagonalGridModelCutterConfiguration configuration;
		private HexagonalGridModelCutterModel model;

        public HexagonalGridModelCutterController(HexagonalGridModelCutterView view, HexagonalGridModelCutterConfiguration configuration, HexagonalGridModelCutterModel model)
        {
            this.view = view;
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
		}

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<OnHexagonalGridModelGenerated>(CutGrid);
        }

        public override void DeclareSignals()
        {
            DeclareSignal<OnHexagonalGridModelCut>();
        }

        private void CutGrid(OnHexagonalGridModelGenerated signal)
        {
            model.Cut(signal.HexagonalGridModel, configuration);
            TryFireSignal(new OnHexagonalGridModelCut(model.hexagonalGridSegments));
        }
    }
}
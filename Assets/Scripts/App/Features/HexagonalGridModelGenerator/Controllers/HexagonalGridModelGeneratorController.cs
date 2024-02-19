using Composite.Core;

namespace App.Features.HexagonalGridModelGenerator
{
	public class HexagonalGridModelGeneratorController : AbstractController
	{
		private HexagonalGridModelGeneratorConfiguration configuration;
		private HexagonalGridModelGeneratorModel model;

        public HexagonalGridModelGeneratorController(HexagonalGridModelGeneratorConfiguration configuration, HexagonalGridModelGeneratorModel model)
        {
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
            TryFireSignal(new OnHexagonalGridModelGenerated(model.grid));
		}

        public override void DeclareSignals()
        {
            DeclareSignal<OnHexagonalGridModelGenerated>();
        }
    }
}
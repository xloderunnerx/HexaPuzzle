using App.Core.Signals;
using Composite.Core;
using UnityEngine;

namespace App.Features.HexagonalGridModelGenerator
{
	public class HexagonalGridModelGeneratorController : AbstractController, IUpdatable
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

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;
            configuration.offset = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
            model.Regenerate(configuration);
            TryFireSignal(new OnHexagonalGridModelGenerated(model.grid));
        }
    }
}
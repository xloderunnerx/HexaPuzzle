using App.Core.Signals;
using Composite.Core;
using UnityEngine;

namespace App.Features.HexagonalGridModelGenerator
{
	public class HexagonalGridModelGeneratorController : AbstractController, IUpdatable
	{
		private HexagonalGridModelGeneratorConfiguration configuration;
		private HexagonalGridModelGeneratorModel model;
        private HexagonalGridModelGeneratorView view;

        public HexagonalGridModelGeneratorController(HexagonalGridModelGeneratorConfiguration configuration, HexagonalGridModelGeneratorModel model, HexagonalGridModelGeneratorView view)
        {
            this.configuration = configuration;
            this.model = model;
            this.view = view;
        }

        public override void Initialize()
		{
            TryFireSignal(new OnHexagonalGridModelGenerated(model.grid));
            view.onRegenerateClick += Regenerate;
		}

        public override void DeclareSignals()
        {
            DeclareSignal<OnHexagonalGridModelGenerated>();
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;
            Regenerate();
        }

        private void Regenerate()
        {
            configuration.offset = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
            model.Regenerate(configuration);
            TryFireSignal(new OnHexagonalGridModelGenerated(model.grid));
        }
    }
}
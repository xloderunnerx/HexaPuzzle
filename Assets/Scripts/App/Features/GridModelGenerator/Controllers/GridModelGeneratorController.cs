using App.Core.Signals;
using Composite.Core;
using UnityEngine;

namespace App.Features.GridModelGenerator
{
	public class GridModelGeneratorController : AbstractController, IUpdatable
	{
		private GridModelGeneratorConfiguration configuration;
		private GridModelGeneratorModel model;
        private GridModelGeneratorView view;

        public GridModelGeneratorController(GridModelGeneratorConfiguration configuration, GridModelGeneratorModel model, GridModelGeneratorView view)
        {
            this.configuration = configuration;
            this.model = model;
            this.view = view;
        }

        public override void Initialize()
		{
            TryFireSignal(new GridModelGenerated(model.grid));
            view.onRegenerateClick += Regenerate;
		}

        public override void DeclareSignals()
        {
            DeclareSignal<GridModelGenerated>();
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
            TryFireSignal(new GridModelGenerated(model.grid));
        }
    }
}
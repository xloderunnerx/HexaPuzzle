using Composite.Core;

namespace App.Features.HexagonalGridGenerator
{
	public class HexagonalGridGeneratorController : AbstractController
	{
		private HexagonalGridGeneratorView view;
		private HexagonalGridGeneratorConfiguration configuration;
		private HexagonalGridGeneratorModel model;

        public HexagonalGridGeneratorController(HexagonalGridGeneratorView view, HexagonalGridGeneratorConfiguration configuration, HexagonalGridGeneratorModel model)
        {
            this.view = view;
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
			InitModel();
            InitView();
        }
		
		public void InitModel()
		{
			model = new HexagonalGridGeneratorModel();
			model.Generate();
			
		}

		public void InitView()
		{
			view.Generate(model.grid, configuration.hexagonalCellViewPrefab);
		}
	}
}
using App.Core.HexagonalGrid;

namespace App.Core.Signals
{
    public class OnHexagonalGridModelGenerated
    {
        private HexagonalGridModel hexagonalGridModel;

        public OnHexagonalGridModelGenerated(HexagonalGridModel hexagonalGridModel)
        {
            this.hexagonalGridModel = hexagonalGridModel;
        }

        public HexagonalGridModel HexagonalGridModel { get => hexagonalGridModel; private set => hexagonalGridModel = value; }
    }
}
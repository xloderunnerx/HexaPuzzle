using App.Core.Hexagonal;

namespace App.Features.HexagonalGridModelGenerator
{
    public class HexagonalGridModelGeneratorModel
    {
        public HexagonalGridModel grid;

        public HexagonalGridModelGeneratorModel(HexagonalGridModelGeneratorConfiguration configuration)
        {
            grid = new HexagonalGridModel();
            GenerateGrid(configuration.radius);
        }

        private void GenerateGrid(int radius)
        {
            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    HexagonalCellModel cellModel = new HexagonalCellModel(new Hexagonal.Vector3Hex(x, y, -x - y));
                    grid.AddCell(cellModel);
                }
            }
        }
    }
}
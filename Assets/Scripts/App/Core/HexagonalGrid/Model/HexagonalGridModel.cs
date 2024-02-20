using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.HexagonalGrid
{
    public class HexagonalGridModel
    {
        public List<HexagonalCellModel> grid;
        public int radius;

        public HexagonalGridModel()
        {
            grid = new List<HexagonalCellModel>();
        }

        public HexagonalGridModel(List<HexagonalCellModel> grid)
        {
            this.grid = grid;
        }

        public void AddCell(HexagonalCellModel cellModel)
        {
            grid.Add(cellModel);
        }

        public void RemoveCell(HexagonalCellModel cellModel)
        {
            if (!grid.Contains(cellModel))
                return;
            grid.Remove(cellModel);
        }
    }
}

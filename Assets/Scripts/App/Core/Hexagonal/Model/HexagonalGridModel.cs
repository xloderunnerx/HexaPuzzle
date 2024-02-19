using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Hexagonal
{
    public class HexagonalGridModel
    {
        public List<HexagonalCellModel> grid;

        public HexagonalGridModel()
        {
            grid = new List<HexagonalCellModel>();
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

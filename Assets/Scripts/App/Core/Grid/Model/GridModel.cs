using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Grid
{
    public class GridModel
    {
        public List<CellModel> grid;
        public int radius;

        public GridModel()
        {
            grid = new List<CellModel>();
        }

        public GridModel(List<CellModel> grid)
        {
            this.grid = grid;
        }

        public void AddCell(CellModel cellModel)
        {
            grid.Add(cellModel);
        }

        public void RemoveCell(CellModel cellModel)
        {
            if (!grid.Contains(cellModel))
                return;
            grid.Remove(cellModel);
        }
    }
}

using App.Core.Puzzle;
using Composite.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Hexagonal
{
    public class HexagonalGridView : AbstractView
    {
        public List<HexagonalCellView> grid;

        private void Awake()
        {
            grid = new List<HexagonalCellView>();
        }

        public void AddCell(HexagonalCellView hexagonalCellView) => grid.Add(hexagonalCellView);

        public void RemoveAndDestroyCell(HexagonalCellView hexagonalCellView)
        {
            grid.Remove(hexagonalCellView);
            Destroy(hexagonalCellView.gameObject);
        }

        public void RemoveAndDestroyAll()
        {
            for(int i = grid.Count - 1; i >=0; i--)
            {
                RemoveAndDestroyCell(grid[i]);
            }
        }
    }
}

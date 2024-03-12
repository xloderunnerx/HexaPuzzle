using App.Core.Puzzle;
using Composite.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.Core.Grid
{
    public class GridView : AbstractView
    {
        public List<CellView> grid;

        private void Awake()
        {
            grid = new List<CellView>();
        }

        public void AddCell(CellView hexagonalCellView) => grid.Add(hexagonalCellView);

        public void RemoveAndDestroyCell(CellView hexagonalCellView)
        {
            grid.Remove(hexagonalCellView);
            Destroy(hexagonalCellView.gameObject);
        }

        public void RemoveAndDestroyAll()
        {
            for (int i = grid.Count - 1; i >= 0; i--)
            {
                RemoveAndDestroyCell(grid[i]);
            }
        }

        public Vector2 GetGridWorldSize()
        {
            var cellWidth = grid.FirstOrDefault().GetWidthWithoutBorder();
            var cellHeight = grid.FirstOrDefault().GetHeightWithoutBorder();

            var minX = grid.Select(cell => cell.TransformHex.position.x).Min();
            var maxX = grid.Select(cell => cell.TransformHex.position.x).Max();
            var minY = grid.Select(cell => cell.TransformHex.position.y).Min();
            var maxY = grid.Select(cell => cell.TransformHex.position.y).Max();

            var xSize = maxX - minX + 1;
            var ySize = maxY - minY + 1;

            var worldSize = new Vector2(xSize * (cellWidth / 4 * 3) + cellWidth / 4, ySize * cellHeight - cellHeight / 2);

            return worldSize;
        }
    }
}

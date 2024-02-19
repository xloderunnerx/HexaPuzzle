using App.Core.Hexagonal;
using System.Collections.Generic;
using UnityEngine;

namespace App.Features.HexagonalGridGenerator
{
    public class HexagonalGridGeneratorModel
    {
        public HexagonalGridModel grid;

        public HexagonalGridGeneratorModel()
        {
            grid = new HexagonalGridModel();
        }

        public void Generate()
        {
            for(int x = 0; x < 45; x++)
            {
                for(int y = 0; y < 45; y++)
                {
                    HexagonalCellModel cellModel = new HexagonalCellModel(new Hexagonal.Vector3Hex(x,y,-x-y));
                    grid.AddCell(cellModel);
                }
            }
        }
    }
}

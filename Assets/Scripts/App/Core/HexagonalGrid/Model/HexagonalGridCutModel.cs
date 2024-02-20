using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.HexagonalGrid
{
    public class HexagonalGridCutModel
    {
        public List<HexagonalGridModel> gridSegments;

        public HexagonalGridCutModel()
        {
            this.gridSegments = new List<HexagonalGridModel>();
        }
    }
}

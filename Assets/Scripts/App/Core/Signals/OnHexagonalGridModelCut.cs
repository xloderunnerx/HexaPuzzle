using App.Core.Hexagonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Signals
{
    public class OnHexagonalGridModelCut
    {
        private HexagonalGridCutModel gridCutModel;

        public OnHexagonalGridModelCut(HexagonalGridCutModel gridCutModel)
        {
            this.gridCutModel = gridCutModel;
        }

        public HexagonalGridCutModel GridCutModel { get => gridCutModel; private set => gridCutModel = value; }
    }
}

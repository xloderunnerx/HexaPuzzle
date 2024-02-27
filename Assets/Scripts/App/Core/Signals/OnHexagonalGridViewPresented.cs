using App.Core.Hexagonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public class OnHexagonalGridViewPresented
    {
        private HexagonalGridView hexagonalGridView;

        public OnHexagonalGridViewPresented(HexagonalGridView hexagonalGridView)
        {
            this.hexagonalGridView = hexagonalGridView;
        }

        public HexagonalGridView HexagonalGridView { get => hexagonalGridView; private set => hexagonalGridView = value; }
    }
}

using Composite.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Features.HexagonalGridGenerator
{
    public class HexagonalGridView : AbstractView
    {
        public List<HexagonalCellView> grid;

        private void Awake()
        {
            grid = new List<HexagonalCellView>();
        }
    }
}

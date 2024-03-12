using App.Core.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Signals
{
    public class GridViewGenerated
    {
        private GridView gridView;

        public GridViewGenerated(GridView gridView)
        {
            this.gridView = gridView;
        }

        public GridView GridView { get => gridView; private set => gridView = value; }
    }
}

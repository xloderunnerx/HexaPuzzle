using App.Core.Grid;

namespace App.Core.Signals
{
    public class GridModelGenerated
    {
        private GridModel gridModel;

        public GridModelGenerated(GridModel gridModel)
        {
            this.gridModel = gridModel;
        }

        public GridModel GridModel { get => gridModel; private set => gridModel = value; }
    }
}
using Composite.Core;
using Shapes;
using UnityEngine;

namespace App.Features.HexagonalGridGenerator
{
    public class HexagonalCellView : AbstractView
    {
        [SerializeField] private RegularPolygon border;
        [SerializeField] private RegularPolygon fill;

        public float GetSize() => fill.Radius + border.Thickness * 0.5f;
    }
}

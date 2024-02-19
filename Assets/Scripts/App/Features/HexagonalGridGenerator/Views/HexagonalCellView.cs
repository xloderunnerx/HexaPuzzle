using Composite.Core;
using Hexagonal;
using Shapes;
using UnityEngine;

namespace App.Features.HexagonalGridGenerator
{
    public class HexagonalCellView : AbstractView
    {
        [SerializeField] private Vector3Hex positionHex;
        [SerializeField] private RegularPolygon border;
        [SerializeField] private RegularPolygon fill;

        public float GetSize() => fill.Radius + border.Thickness * 0.5f;

        public void SetPositionHex(Vector3Hex positionHex) => this.positionHex = positionHex;
    }
}

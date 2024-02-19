using Composite.Core;
using Hexagonal;
using Shapes;
using UnityEngine;

namespace App.Core.Hexagonal
{
    public class HexagonalCellView : AbstractView
    {
        [SerializeField] private Vector3Hex positionHex;
        [SerializeField] private RegularPolygon border;
        [SerializeField] private RegularPolygon fill;

        public float GetSizeWithBorder() => fill.Radius + border.Thickness * 0.5f;

        public float GetSizeWithoutBorder() => fill.Radius;

        public void SetPositionHex(Vector3Hex positionHex) => this.positionHex = positionHex;

        public void SetFillColor(Color value)
        {
            fill.Color = value;
        }
    }
}

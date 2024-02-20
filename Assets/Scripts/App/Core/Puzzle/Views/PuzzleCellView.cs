using Composite.Core;
using Hexagonal;
using Shapes;
using UnityEngine;

namespace App.Core.Puzzle
{
    public class PuzzleCellView : AbstractView
    {
        [SerializeField] private Vector3Hex positionHex;
        [SerializeField] private RegularPolygon border;
        [SerializeField] private RegularPolygon fill;

        public void SetPositionHex(Vector3Hex value) => positionHex = value;

        public void SetFillColor(Color value) => fill.Color = value;

        public Color GetFillColor() => fill.Color;

        public float GetSizeWithoutBorder() => fill.Radius;
    }
}

using Composite.Core;
using Hexagonal;
using Shapes;
using UnityEngine;

namespace App.Core.Puzzle
{
    public class PuzzleCellView : AbstractView
    {
        [SerializeField] private TransformHex transformHex;
        [SerializeField] private RegularPolygon border;
        [SerializeField] private RegularPolygon fill;

        public TransformHex TransformHex { get => transformHex; private set => transformHex = value; }

        private void Awake()
        {
            transformHex = new TransformHex();
        }

        public void SetPositionHex(Vector3Hex value) => transformHex.position = value;

        public void SetFillColor(Color value) => fill.Color = value;

        public Color GetFillColor() => fill.Color;

        public float GetSizeWithoutBorder() => fill.Radius;

        public float GetWidthWithoutBorder() => fill.Radius * 2;

        public float GetHeightWithoutBorder() => fill.Radius * Mathf.Sqrt(3);

        public Bounds GetWorldBoundsWithoutBorder() => fill.GetWorldBounds();

        public int SetSortingOrder(int value)
        {
            fill.SortingOrder = value + 1;
            border.SortingOrder = fill.SortingOrder + 1;
            return border.SortingOrder;
        }
    }
}

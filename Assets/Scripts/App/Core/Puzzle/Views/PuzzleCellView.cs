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

        public Bounds GetWorldBoundsWithoutBorder() => RecalculateCorrectBounds(fill.GetWorldBounds());

        private Bounds RecalculateCorrectBounds(Bounds worldBounds)
        {
            var min = worldBounds.min;
            var max = worldBounds.max;
            var worldWidth = max.x - min.x;
            var size = worldWidth * 0.5f;
            var worldHeight = size * Mathf.Sqrt(3);
            Bounds result = new Bounds(transform.position, Vector2.zero);
            result.min = new Vector3(min.x, transform.position.y - worldHeight * 0.5f);
            result.max = new Vector3(max.x, transform.position.y + worldHeight * 0.5f);
            return result;
        }

        public int SetSortingOrder(int value)
        {
            fill.SortingOrder = value + 1;
            border.SortingOrder = fill.SortingOrder + 1;
            return border.SortingOrder;
        }

        /*private void OnDrawGizmos()
        {
            var bounds = GetWorldBoundsWithoutBorder();
            Gizmos.DrawSphere(bounds.min, 0.1f);
            Gizmos.DrawSphere(bounds.max, 0.1f);
        }*/
    }
}

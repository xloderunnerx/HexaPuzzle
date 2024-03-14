using Composite.Core;
using Hexagonal;
using Shapes;
using UnityEngine;

namespace App.Core.Grid
{
    public class CellView : AbstractView
    {
        [SerializeField] private TransformHex transformHex;
        [SerializeField] private RegularPolygon border;
        [SerializeField] private RegularPolygon fill;

        public Bounds bounds;

        public TransformHex TransformHex { get => transformHex; private set => transformHex = value; }

        private void Awake()
        {
            transformHex = new TransformHex();
        }

        public float GetWidthWithoutBorder() => fill.Radius * 2;

        public float GetWidthWithBorder() => fill.Radius * 2 + border.Thickness;

        public Bounds GetWorldBounds() {
            return fill.GetWorldBounds();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(GetWorldBounds().min, 0.1f);
            Gizmos.DrawSphere(GetWorldBounds().max, 0.1f);
        }

        public float GetHeightWithoutBorder() => fill.Radius * Mathf.Sqrt(3);

        public float GetHeightWitBorder() => fill.Radius * Mathf.Sqrt(3) + border.Thickness;

        public float GetSizeWithBorder() => fill.Radius + border.Thickness;

        public float GetSizeBorder() => fill.Radius;

        public void SetPositionHex(Vector3Hex value) => transformHex.position = value;

        public void SetFillColor(Color value)
        {
            fill.Color = value;
        }
    }
}

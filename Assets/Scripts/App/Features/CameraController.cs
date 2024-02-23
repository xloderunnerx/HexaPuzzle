using App.Core.Hexagonal;
using App.Core.Signals;
using Composite.Core;
using System;
using UnityEngine;


namespace App.Features.CameraController
{
    public class CameraController : AbstractController
    {

        [SerializedField] Camera mainCamera;

        // MARK: - Grid View variable
        private HexagonalGridView gridView;

        // MARK: - Camera variables
        private Camera camera;
        private float cameraSize;
        public float cameraOffsetZ = -10f;

        public float padding = 1f;

        public override void Initialize()
        {
            camera = Camera.main;
            cameraSize = camera.orthographicSize;

            gridView = new GameObject("HexagonalGridView").AddComponent<HexagonalGridView>();
            //gridView.transform.parent = view.transform;
        }

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<OnHexagonalGridModelGenerated>(Present);
        }

        private void Present(OnHexagonalGridModelGenerated signal)
        {
            SetupCameraZoomByBounds(signal.HexagonalGridModel.radius);
        }

        private void SetupCameraZoomByBounds(int radius)
        {  
            Vector3 targetPosition = gridView.gameObject.transform.position;
            Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y, cameraOffsetZ);

            float cameraHeight = 2f * camera.orthographicSize;
            float cameraWidth = cameraHeight * camera.aspect;

            float objectX = gridView.gameObject.transform.position.x;
            float objectY = gridView.gameObject.transform.position.y;

            float minBoundsX = objectX - radius - padding;
            float maxBoundsX = objectX + radius + padding;
            float minBoundsY = objectY - radius - padding;
            float maxBoundsY = objectY + radius + padding;

            float targetX = Mathf.Clamp(objectX, minBoundsX + cameraWidth / 2, maxBoundsX - cameraWidth / 2);
            float targetY = Mathf.Clamp(objectY, minBoundsY + cameraHeight / 2, maxBoundsY - cameraHeight / 2);

            Vector3 cameraPosition = new Vector3(targetX, targetY, cameraOffsetZ);

            mainCamera.transform.position = cameraPosition;
        }

    }
}
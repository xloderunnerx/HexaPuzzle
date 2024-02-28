using App.Core;
using App.Core.Hexagonal;
using App.Core.Signals;
using Composite.Core;
using System;
using UnityEngine;

namespace App.Features.CameraFocus
{
	public class CameraFocusController : AbstractController
	{

        // MARK: - Properties

        private CameraFocusView view;
        private CameraFocusConfiguration configuration;
        private CameraFocusModel model;

        private HexagonalGridView gridView;

        // MARK: - Public methods

        public CameraFocusController(CameraFocusView view, CameraFocusConfiguration configuration, CameraFocusModel model)
        {
           this.view = view;
           this.configuration = configuration;
           this.model = model;
        }

        public override void Initialize()
		{
		}

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<OnHexagonalGridViewPresented>(HandleSignalView);
            SubscribeToSignal<OnHexagonalGridModelGenerated>(HandleSignalModel);
		}

        // MARK: - Private methods

		private void HandleSignalModel(OnHexagonalGridModelGenerated signal)
        {
            SetupCamera(signal);
        }

        private void HandleSignalView(OnHexagonalGridViewPresented signal) 
        {
            this.gridView = signal.HexagonalGridView;
        }

        private void SetupCameraZoomByBounds(OnHexagonalGridModelGenerated gridModel)
        {
            Vector3 targetPosition = gridView.GetGridWorldSize();
            Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y, view.cameraOffsetZ);
            
            float cameraHeight = 2f * view.camera.orthographicSize;
            float cameraWidth = cameraHeight * view.camera.aspect;

            float objectX = gridView.GetGridWorldSize().x;
            float objectY = gridView.GetGridWorldSize().y;

            float minBoundsX = objectX - gridModel.HexagonalGridModel.radius - view.padding;
            float maxBoundsX = objectX + gridModel.HexagonalGridModel.radius + view.padding;
            float minBoundsY = objectY - gridModel.HexagonalGridModel.radius - view.padding;
            float maxBoundsY = objectY + gridModel.HexagonalGridModel.radius + view.padding;

            float targetX = Mathf.Clamp(objectX, minBoundsX + cameraWidth / 2, maxBoundsX - cameraWidth / 2);
            float targetY = Mathf.Clamp(objectY, minBoundsY + cameraHeight / 2, maxBoundsY - cameraHeight / 2);

            Vector3 cameraPosition = new Vector3(targetX, targetY, view.cameraOffsetZ);
            view.camera.transform.position = cameraPosition;
        }

        private void SetupCameraZoom(OnHexagonalGridModelGenerated gridModelGenerated) 
        {
            Vector3 objectPosition = gridView.GetGridWorldSize();

            Vector3 viewportPoint = view.camera.WorldToViewportPoint(objectPosition);

            bool isObjectVisible = viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1 && viewportPoint.z > 0;

            if (!isObjectVisible)
            {
                Vector3 newPosition = view.camera.transform.position;
                newPosition.x = objectPosition.x;
                newPosition.y = objectPosition.y;
                view.camera.transform.position = newPosition;
            }

//            Bounds objectBounds = CalculateObjectBounds(objectPosition);
           // float objectSize = Mathf.Max(objectBounds.size.x, objectBounds.size.y) + view.padding;

            //view.camera.orthographicSize = objectSize * 0.5f * Mathf.Sqrt(2f);
        }

        private void SetupCamera(OnHexagonalGridModelGenerated gridModelGenerated)
        {
            
        } 

        private Bounds CalculateObjectBounds()
        {
            Renderer objectRenderer = gridView.GetComponent<Renderer>();

            if (objectRenderer != null)
            {
                return objectRenderer.bounds;
            }
            else
            {
                Collider objectCollider = gridView.GetComponent<Collider>();

                if (objectCollider != null)
                {
                    return objectCollider.bounds;
                }
                else
                {
                    return new Bounds(gridView.GetGridWorldSize(), Vector3.zero);
                }
            }
        }
    }
}
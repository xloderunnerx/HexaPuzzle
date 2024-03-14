using App.Core.Grid;
using App.Core.Signals;
using App.Features.GridViewGenerator;
using Composite.Core;
using UnityEngine;

namespace App.Features.CameraFocus
{
	public class CameraFocusController : AbstractController
	{

		private CameraFocusView view;
		private CameraFocusConfiguration configuration;
		private CameraFocusModel model;

		private GridView gridView;

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
			SubscribeToSignal<GridViewGenerated>(HandleGrid);
			SubscribeToSignal<GridModelGenerated>(SetCameraFocus);
		}

		private void HandleGrid(GridViewGenerated gridView) 
		{
			this.gridView = gridView.GridView;
		}

		private void SetCameraFocus(GridModelGenerated gridModel) 
		{
			float cameraSize = view.mainCamera.orthographicSize;
			var gridSize = gridView.GetGridWorldSize();

			float objectSize = Mathf.Max(gridSize.x, gridSize.y);
			
			float targetOrthographicSize = (objectSize + view.padding) * 1.2f / 2f;

			view.mainCamera.transform.position = gridView.center;
			view.mainCamera.orthographicSize = targetOrthographicSize;
		}
    }
}
using App.Core.Hexagonal;
using Composite.Core;
using System;
using UnityEngine;

namespace App.Features.HexagonalGridViewPresenter
{
	public class HexagonalGridViewPresenterController : AbstractController
	{
		private HexagonalGridViewPresenterView view;
		private HexagonalGridViewPresenterConfiguration configuration;
		private HexagonalGridViewPresenterModel model;

        private HexagonalGridView gridView;

        public HexagonalGridViewPresenterController(HexagonalGridViewPresenterView view, HexagonalGridViewPresenterConfiguration configuration, HexagonalGridViewPresenterModel model)
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
            SubscribeToSignal<OnHexagonalGridModelGenerated>(Present);
        }

        private void Present(OnHexagonalGridModelGenerated signal)
        {
            var gridModel = signal.HexagonalGridModel;
            gridView = new GameObject("Grid").AddComponent<HexagonalGridView>();
            gridView.gameObject.transform.parent = view.transform;

            var cellViewSize = configuration.hexagonalCellViewPrefab.GetSizeWithoutBorder();

            var cellViewWidth = cellViewSize * 2;
            var cellViewHeight = Mathf.Sqrt(3) * cellViewSize;
            Debug.Log("Size is " + cellViewSize);
            Debug.Log("Width is " + cellViewWidth);
            Debug.Log("Height is " + cellViewHeight);

            gridModel.grid.ForEach(cellModel =>
            {
                var perlin = Mathf.PerlinNoise(cellModel.transform.position.x * 0.1f, cellModel.transform.position.y * 0.1f);
                Debug.Log("Perlin = " + perlin);
                var cellView = GameObject.Instantiate(configuration.hexagonalCellViewPrefab, gridView.gameObject.transform);
                cellView.SetFillColor(new Color(perlin, perlin, perlin, 1.0f));
                cellView.SetPositionHex(cellModel.transform.position);
                cellView.transform.position = new Vector3(cellModel.transform.position.x * cellViewWidth - cellModel.transform.position.x * cellViewWidth * 0.25f,
                    cellModel.transform.position.y * cellViewHeight + cellModel.transform.position.x * cellViewHeight * 0.5f, 0);
                cellView.gameObject.name = $"X: {cellModel.transform.position.x}; Y: {cellModel.transform.position.y}; Z: {cellModel.transform.position.z}";
                gridView.grid.Add(cellView);
            });
        }
    }
}
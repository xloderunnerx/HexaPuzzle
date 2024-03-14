using App.Core.Grid;
using App.Core.Signals;
using Composite.Core;
using System;
using UnityEngine;

namespace App.Features.GridViewGenerator
{
	public class GridViewGeneratorController : AbstractController
	{
		private GridViewGeneratorView view;
		private GridViewGeneratorConfiguration configuration;
		private GridViewGeneratorModel model;

        private GridView gridView;

        public GridViewGeneratorController(GridViewGeneratorView view, GridViewGeneratorConfiguration configuration, GridViewGeneratorModel model)
        {
            this.view = view;
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
            gridView = new GameObject("GridView").AddComponent<GridView>();
            gridView.transform.parent = view.transform;
		}

        public override void DeclareSignals()
        {
            DeclareSignal<GridViewGenerated>();
        }

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<GridModelGenerated>(Generate);
        }

        private void Generate(GridModelGenerated signal)
        {
            Discard();
            var gridModel = signal.GridModel;

            var cellViewSize = configuration.cellViewPrefab.GetSizeBorder();

            var cellViewWidth = cellViewSize * 2;
            var cellViewHeight = Mathf.Sqrt(3) * cellViewSize;

            gridModel.grid.ForEach(cellModel =>
            {
                var cellView = GameObject.Instantiate(configuration.cellViewPrefab, gridView.transform);
                cellView.SetPositionHex(cellModel.transform.position);
                cellView.transform.position = new Vector3(cellModel.transform.position.x * cellViewWidth - cellModel.transform.position.x * cellViewWidth * 0.25f,
                    cellModel.transform.position.y * cellViewHeight + cellModel.transform.position.x * cellViewHeight * 0.5f, 0);
                cellView.gameObject.name = $"X: {cellModel.transform.position.x}; Y: {cellModel.transform.position.y}; Z: {cellModel.transform.position.z}";
                gridView.grid.Add(cellView);
            });

            CalculateCenter(signal);

            TryFireSignal(new GridViewGenerated(gridView));
        }

        private void CalculateCenter(GridModelGenerated signal) 
        {
            var gridViewCenter = Vector3.zero;

            gridView.grid.ForEach(cellView =>
            {
                gridViewCenter += cellView.GetWorldBounds().center;
            });

            gridViewCenter /= gridView.grid.Count;

            gridView.center = gridViewCenter;
        }

        private void Discard()
        {
            gridView.RemoveAndDestroyAll();
        }
    }
}
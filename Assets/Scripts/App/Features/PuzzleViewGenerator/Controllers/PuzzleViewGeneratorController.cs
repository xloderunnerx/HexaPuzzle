using App.Core.Grid;
using App.Core.Puzzle;
using App.Core.Signals;
using Composite.Core;
using System;
using UnityEngine;

namespace App.Features.PuzzleViewGenerator
{
	public class PuzzleViewGeneratorController : AbstractController
	{
		private PuzzleViewGeneratorView view;
		private PuzzleViewGeneratorModel model;
		private PuzzleViewGeneratorConfiguration configuration;

        private PuzzleView puzzleView;

        public PuzzleViewGeneratorController(PuzzleViewGeneratorView view, PuzzleViewGeneratorModel model, PuzzleViewGeneratorConfiguration configuration)
        {
            this.view = view;
            this.model = model;
            this.configuration = configuration;
        }

        public override void Initialize()
		{
            puzzleView = new GameObject("PuzzleView").AddComponent<PuzzleView>();
            puzzleView.transform.parent = view.transform;
		}

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<PuzzleModelGenerated>(Generate);
        }

        private void Generate(PuzzleModelGenerated signal)
        {
            Discard();
            var puzzleModel = signal.PuzzleModel;

            var cellViewSize = configuration.puzzleCellViewPrefab.GetSizeWithoutBorder();

            var cellViewWidth = cellViewSize * 2;
            var cellViewHeight = Mathf.Sqrt(3) * cellViewSize;

            puzzleModel.puzzle.ForEach(segmentModel => {
                var segmentView = new GameObject("PuzzleSegmentView").AddComponent<PuzzleSegmentView>();
                segmentView.transform.parent = puzzleView.transform;
                segmentModel.segment.ForEach(cellModel => {
                    var cellView = GameObject.Instantiate(configuration.puzzleCellViewPrefab, segmentView.transform);
                    cellView.SetPositionHex(cellModel.transform.position);
                    cellView.SetFillColor(cellModel.fillColor);
                    cellView.transform.position = new Vector3(cellModel.transform.position.x * cellViewWidth - cellModel.transform.position.x * cellViewWidth * 0.25f,
                        cellModel.transform.position.y * cellViewHeight + cellModel.transform.position.x * cellViewHeight * 0.5f, 0);
                    cellView.gameObject.name = $"X: {cellModel.transform.position.x}; Y: {cellModel.transform.position.y}; Z: {cellModel.transform.position.z}";
                    segmentView.AddCell(cellView);
                });
                puzzleView.AddSegment(segmentView);
            });
        }

        private void Discard()
        {
            if (puzzleView == null)
                return;
            puzzleView.RemoveAndDestroyAll();
        }
    }
}
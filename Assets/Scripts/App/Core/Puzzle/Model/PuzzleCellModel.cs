using Hexagonal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Core.Puzzle
{
    public class PuzzleCellModel
    {
        public TransformHex transform;

        public PuzzleCellModel()
        {
            transform = new TransformHex();
        }

        public PuzzleCellModel(Vector3Hex position)
        {
            transform = new TransformHex(position);
        }
    }
}
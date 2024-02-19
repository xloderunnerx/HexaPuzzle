﻿using Hexagonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace App.Core.Hexagonal
{
    public class HexagonalCellModel
    {
        public TransformHex transform;
        public Color debugColor;

        public HexagonalCellModel()
        {
            this.transform = new TransformHex();
        }

        public HexagonalCellModel(Vector3Hex position)
        {
            this.transform = new TransformHex();
            this.transform.position = position;
        }
    }
}

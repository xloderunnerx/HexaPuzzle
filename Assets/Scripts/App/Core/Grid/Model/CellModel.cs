using Hexagonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace App.Core.Grid
{
    public class CellModel
    {
        public TransformHex transform;

        public CellModel()
        {
            this.transform = new TransformHex();
        }

        public CellModel(Vector3Hex position)
        {
            this.transform = new TransformHex();
            this.transform.position = position;
        }
    }
}

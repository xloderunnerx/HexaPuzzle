using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagonal
{
    public class TransformHex
    {
        public Vector3Hex position;

        public TransformHex()
        {
        }

        public TransformHex(Vector3Hex position)
        {
            this.position = position;
        }
    }
}

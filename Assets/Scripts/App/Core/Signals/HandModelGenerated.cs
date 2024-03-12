using App.Core.Hand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Signals
{
    public class HandModelGenerated
    {
        private HandModel handModel;

        public HandModel HandModel { get => handModel; private set => handModel = value; }

        public HandModelGenerated(HandModel handModel)
        {
            this.handModel = handModel;
        }
    }
}

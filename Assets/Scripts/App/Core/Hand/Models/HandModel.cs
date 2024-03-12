using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Hand
{
    public class HandModel
    {
        public List<CardModel> cards;

        public HandModel()
        {
            cards = new List<CardModel>();
        }

        public HandModel(List<CardModel> cards)
        {
            this.cards = cards;
        }
    }
}

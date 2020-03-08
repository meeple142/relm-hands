using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public class Army
    {
        public List<Card> Cards = new List<Card>();
        public Army()
        {
            Cards.Add(new LightCavalry());
        }
    }

    public class LightCavalry : Card
    {
        public LightCavalry() : base(
            "Light Cavalry",
            17,
            Suits.Army,
            new NoAction(),
            new PenalityMinusForEachSuit(-2, new List<Suits> { Suits.Land }),
            new NoBonus()
            )
        {

        }
    }
}
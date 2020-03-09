using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public class Deck : List<Card>
    {
        public Deck() : base()
        {

            this.AddRange(new Army().Cards);


            var card = new Card(
                "Nothing",
              1,
              Suits.Land,
              new NoAction(),
              new NoPenalty(),
              new NoBonus()
            );

            this.Add(card);
        }
    }
}
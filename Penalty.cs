using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public interface IPenalty
    {
        int RunPenalty(List<Card> hand);
    }

    public class NoPenalty : IPenalty
    {
        public int RunPenalty(List<Card> hand)
        {
            return 0;
        }
    }

    public class PenalityMinusForEachSuit : IPenalty
    {
        readonly int MinusValue;
        readonly List<Suits> SuitList;

        public PenalityMinusForEachSuit(int minusValue, List<Suits> suitList)
        {
            MinusValue = minusValue;
            SuitList = suitList;
        }

        public int RunPenalty(List<Card> hand)
        {
            int badCardCount = hand.Count(card => SuitList.Any(suit => suit == card.Suit));
            return badCardCount * MinusValue;
        }
    }
}
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public class Hand : List<Card>
    {
        public Hand() : base()
        {

        }
        public Hand(List<Card> hand)
        {
            this.AddRange(hand);
        }

        public int Score()
        {

            int penalty;
            int score;
            int bonus;

            // run all the actions
            this.ForEach(card => card.RunAction(this));
            
            // run the penalties
            penalty = this.Aggregate(0, (penalty, card) =>
                {
                    if (card.PenaltyActive)
                    {
                        penalty += card.RunPenalty(this);
                    }

                    return penalty;
                });


            // run the bonuses
            bonus = this.Aggregate(0, (bonus, card) =>
                {
                    if (!card.IsBlank)
                    {
                        bonus += card.RunBonus(this);
                    }

                    return bonus;
                });

            this.Aggregate(0, (bonus, card) => bonus + card.RunBonus(this));

            // sum the base values
            score = this.Aggregate(0, (score, card) =>
                {
                    if (!card.IsBlank)
                    {
                        score += card.BaseValue;
                    }

                    return score;
                });

			
            return score + bonus + penalty;
        }
    }
}
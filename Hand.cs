using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{   
	public class ScoreData
    {
	   readonly int BaseValue;
	   readonly int Penalty;
	   readonly int Bonus;
	   readonly int Total;
	   public ScoreData(int baseValue, int penalty, int bonus)
	   {
	   	  BaseValue = baseValue;
	   	  Penalty = penalty;
	   	  Bonus = bonus;
	   	  Total = BaseValue + Penalty + Bonus;
	   }
	   public void Print()
	   {
	   	   Console.WriteLine("Base:    "+BaseValue.ToString("D3"));
	   	   Console.WriteLine("Penalty:"+Penalty.ToString("D3"));
	   	   Console.WriteLine("Bonus:   "+Bonus.ToString("D3"));
	   	   Console.WriteLine("Total:   "+Total.ToString("D3"));
	   }
	   
    }

    public class Hand : List<Card>
    {
       	ScoreData Score;
       	
        public Hand() : base()
        {

        }
        public Hand(List<Card> hand)
        {
            this.AddRange(hand);
        }

        public void ScoreHand()
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

			
            Score = new ScoreData(score, penalty,bonus);
        }
        
        public void Print()
        {
        	//print all the card names
        	var names =	this.Select(card=>card.Name).ToList();
        	Console.WriteLine(String.Join(", ",names));
        	
        	//make sure its up to date
        	this.ScoreHand();
        	
            Score.Print();
        	
        }
    }
}
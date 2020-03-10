using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{   
	public class ScoreData
    {
	   public readonly int BaseValue;
	   public readonly int Penalty;
	   public readonly int Bonus;
	   public readonly int Total;
	   public ScoreData(Hand hand)
	   {
	   	 runActions(hand);
	   	 
	   	  
	   	  Penalty = GetPenalty(hand);
	   	  Bonus = GetBonus(hand);
	   	  BaseValue = GetBaseValue(hand);
	   	  
	   	  Total = BaseValue + Penalty + Bonus;
	   }
	   private void runActions(Hand hand)
	   {
	   	hand.ForEach(card => card.RunAction(hand));
	   }
	   
	   private int GetPenalty(Hand hand)
	   {
	   	return hand.Aggregate(0, (penalty, card) =>
                {
                    if (card.PenaltyActive)
                    {
                        penalty += card.RunPenalty(hand);
                    }

                    return penalty;
                });
	   }
	   
	   private int GetBonus(Hand hand)
	   {
	   	return hand.Aggregate(0, (bonus, card) =>
                {
                    if (!card.IsBlank)
                    {
                        bonus += card.RunBonus(hand);
                    }

                    return bonus;
                });
	   }
	   
	   private int GetBaseValue(Hand hand)
	   {
	   return hand.Aggregate(0, (score, card) =>
                {
                    if (!card.IsBlank)
                    {
                        score += card.BaseValue;
                    }

                    return score;
                });
	   }
	   
	   public void Print()
	   {
	   	   Console.WriteLine("Base:   "+BaseValue.ToString().PadLeft(4));
	   	   Console.WriteLine("Penalty:"+Penalty.ToString().PadLeft(4));
	   	   Console.WriteLine("Bonus:  "+Bonus.ToString().PadLeft(4));
	   	   Console.WriteLine("Total:  "+Total.ToString().PadLeft(4));
	   }
	   
    }

    public class Hand : List<Card>
    {
       	
        public Hand() : base()
        {

        }
        public Hand(List<Card> hand)
        {
            this.AddRange(hand);
        }

        
        
        public void Print()
        {
        	//print all the card names
        	var names =	this.Select(card=>card.Name).ToList();
        	Console.WriteLine(String.Join(", ",names));
        }
    }
}
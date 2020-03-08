using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public enum Suits
    {
    	Army,
    	Artifact,
        Beast,
        Flame,
        Flood,
        Land,
        Leader, 
    	Weapon,
    	Weather,
    	Wild,
    	Wizard
    };
    
    public class Card 
    {
         public readonly int BaseValue;
         public readonly string Name;
         public readonly Suits Suit;
         
         public Suits SubSuit;
         public bool IsBlank = false;
         public bool PenaltyRemoved = false;
         
         private IAction Action;
         private IPenalty Penalty;
         private IBonus Bonus;
         
         public Card(
         	string name,
         	int baseValue, 
            Suits suit,
            IAction action,
            IPenalty penalty,
            IBonus bonus
         )
         {
            BaseValue = baseValue;
            Name = name;
            Suit = suit;
            Action = action;
            Penalty = penalty;
            Bonus = bonus;
         }
         
         public void RunAction(List<Card> hand)
         {
         	Action.RunAction(hand);
         }
         
         public void RunPenalty(List<Card> hand)
         {
         	Penalty.RunPenalty(hand);
         }
         
         public void RunBonus(List<Card> hand)
         {
         	Bonus.RunBonus(hand);
         }
    }
}
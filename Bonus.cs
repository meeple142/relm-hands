using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{
    public interface IBonus
    {
        public int RunBonus(List<Card> hand);
    }


    class NoBonus : IBonus
    {
        public int RunBonus(List<Card> hand)
        {
            return 0;
        }
    }
    
    class BonusMaxOr
    {
        List<IBonus> Bonuses;
        
        public BonusMaxOr(List<IBonus> bonuses)
        {
        	Bonuses = bonuses;
        }
        
    	public int RunBonus(List<Card> hand)
    	{
    		return Bonuses.Max(bonus => bonus.RunBonus(hand));
    	}
    }
}
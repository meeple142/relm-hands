using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{
    public interface IBonus
    {
    	public void RunBonus(List<Card> hand);
    }

    
    class NoBonus : IBonus
    {
      public void RunBonus(List<Card> hand )
       {
          return;
       }
    }
}
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{
	public interface IAction 
    {
    	void RunAction(List<Card> hand);
    }

    public class NoAction: IAction
    {
        public void  RunAction(List<Card> hand)
        {
         	return;
        }
    
    }
}
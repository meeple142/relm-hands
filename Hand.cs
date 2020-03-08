using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

      public class Hand : List<Card>
    {
    	public Hand() : base ()
    	{
    		
    	}
    	 public Hand(List<Card> hand)
    	 {
    	 	this.AddRange(hand);
    	 }
    	
    	public int Score()
    	{
    		
    	}
    }
}
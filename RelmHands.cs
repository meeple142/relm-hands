using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public class RelmHands 
    {
           public void Main()
           {
           	var deck= new Deck();
           	deck.ForEach(card => Console.WriteLine(card.Name));
           }
           
    }
}
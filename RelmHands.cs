using System;

namespace CSharp_Shell
{
    public class RelmHands
    {
        static void Main()
        {
            var deck = new Deck();
            var thing = 2;
            deck.ForEach(card => Console.WriteLine(card.Name));
        }
    }
}

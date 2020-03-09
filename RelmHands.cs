using System;

namespace CSharp_Shell
{
    public class RelmHands
    {
        static void Main()
        {
            var deck = new Deck();
            deck.ForEach(card => Console.WriteLine(card.Name));
        }
    }
}

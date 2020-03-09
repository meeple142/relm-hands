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
}
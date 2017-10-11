using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    public class FactorySave
    {
       
        public static StrategyRanking CreateClassement(int choix)
        {
            switch (choix)
            {
                case 1:
                    return new BinaryRanking();

                case 2:
                    return new XMLRanking();

                default:
                    return new JSONRanking();
            }

        }

    }
}

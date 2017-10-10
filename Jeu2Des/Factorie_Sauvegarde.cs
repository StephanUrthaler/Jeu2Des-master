using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    public class FactorySauvegarde
    {
       
        public static Classement ChoixSauvegarde(int choix)
        {
            switch (choix)
            {
                case 1:
                    return new Binary();

                case 2:
                    return new XML();

                default:
                    return new JSON();
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    public abstract class StrategyRanking
    {

        public abstract Object Load(Type Type);
        public abstract void  Save(Object objet);
    }
}

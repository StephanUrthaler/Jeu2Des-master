using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Jeu2Des
{
    public class BinaryRanking : StrategyRanking
    {


        //method serialize binary
        public override void Save(Object objet)
        {
            Stream fichier = File.Create("sérializatiobinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichier, objet);
            fichier.Close();

        }


        public override Object Load(Type Type)
        {
            if (File.Exists("sérializatiobinaire.txt"))
            {
                Stream fichier = File.OpenRead("sérializatiobinaire.txt");
                BinaryFormatter serializer = new BinaryFormatter();
                object obj = serializer.Deserialize(fichier);
                fichier.Close();
                return obj;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Jeu2Des
{
    public class JSONRanking : StrategyRanking
    {
        public override void Save(Object objet)
        {
            Stream fichier = File.Create("sérializationJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(objet.GetType());
            serializer.WriteObject(fichier, objet);
            fichier.Close();
        }
        public override Object Load(Type Type)
        {
            if (File.Exists("sérializationJson.json"))
            {
                Stream fichier = File.OpenRead("sérializationJson.json");
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(Type);

                Object listerecupjson = serializer.ReadObject(fichier);
                fichier.Close();
                return listerecupjson;
            }
            return null;
        }
    }
}

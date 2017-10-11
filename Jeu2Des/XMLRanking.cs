using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Jeu2Des
{
    public class XMLRanking : StrategyRanking
    {

        public override void Save(Object objet)
        {
            Stream fichier = File.Create("sérializationXML.xml");
            XmlSerializer serializer = new XmlSerializer(objet.GetType());
            serializer.Serialize(fichier, objet);
            fichier.Close();
        }
        public override Object Load(Type type)
        {
            if (File.Exists("sérializationXML.xml"))
            {
                Stream fichier = File.OpenRead("sérializationXML.xml");
                XmlSerializer serializer = new XmlSerializer(type);
                Object obj = serializer.Deserialize(fichier);
                fichier.Close();
                return obj;
            }
            return null;
        }
    }
}

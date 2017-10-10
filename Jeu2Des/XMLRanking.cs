using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Jeu2Des
{
    class XMLRanking : Classement
    {
        public override void Save()
        {
            Stream fichier = File.Create("sérializationXML.xml");
            XmlSerializer serializer = new XmlSerializer(ListeEntrees.GetType());
            serializer.Serialize(fichier, ListeEntrees);
            fichier.Close();
        }
        public override void Load()
        {
            if (File.Exists("sérializationXML.xml"))
            {
                Stream fichier = File.OpenRead("sérializationXML.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entree>));
                Object obj = serializer.Deserialize(fichier);
                List<Entree> listerecupxml = (List<Entree>)obj;
                foreach (Entree joueur1 in listerecupxml)
                {
                    AjouterEntree(joueur1.Nom, joueur1.Score);
                }
                fichier.Close();
            }
        }
    }
}

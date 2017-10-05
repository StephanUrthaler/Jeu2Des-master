using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Jeu2Des
{
    [DataContract]
    [Serializable]
    public class Classement
    {
        //Relation class Entree
        private List<Entree> _ListeEntrees;
        [DataMember]
        public List<Entree> ListeEntrees
        {
            get { return _ListeEntrees; }
            set { _ListeEntrees = value; }
        }

        public Classement()
        {
            _ListeEntrees = new List<Entree>();
        }

        public void AjouterEntree(string nom, int score)
        {
            _ListeEntrees.Add(new Entree(nom, score));
        }

        public void TopN()
        {
            _ListeEntrees.Sort();
            _ListeEntrees.Reverse();
            //Utiliser countains pour afficher nla liste complète
            foreach (Entree joueur in _ListeEntrees)
            {
                Console.WriteLine(joueur);
            }

        }
        //method serialize binary
        public void Loadbinaire()
        {
            Stream fichier = File.Create("sérializatiobinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichier, _ListeEntrees);
            fichier.Close();
        }
        public void LoadXml()
        {
            Stream fichier = File.Create("sérializationXML.xml");
            XmlSerializer serializer = new XmlSerializer(_ListeEntrees.GetType());
            serializer.Serialize(fichier, _ListeEntrees);
            fichier.Close();
        }
        public void LoadJson()
        {
            Stream fichier = File.Create("sérializationJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(_ListeEntrees.GetType());
            serializer.WriteObject(fichier, _ListeEntrees);
            fichier.Close();
        }
        public void Savebinaire()
        {
            if (File.Exists("sérializatiobinaire.txt"))
            {
                Stream fichier = File.OpenRead("sérializatiobinaire.txt");
                BinaryFormatter serializer = new BinaryFormatter();
                Object obj = serializer.Deserialize(fichier);

                //L'objet doit être casté pour qu'on puisse accéder à ces méthodes
                Console.WriteLine("Dessous la liste récuperer");
                List<Entree> listerecupbinaire = (List<Entree>)obj;
                foreach (Entree joueur1 in listerecupbinaire)
                {
                    AjouterEntree(joueur1.Nom, joueur1.Score);
                }
                fichier.Close();
            }


        }
        public void SaveXml()
        {
            if (File.Exists("sérializatiobinaire.txt"))
            {
                Stream fichier = File.OpenRead("sérializationXML.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entree>));
                Object obj = serializer.Deserialize(fichier);
                Console.WriteLine("L'/objet récupéré par désérialisation Xml " + obj);

                List<Entree> listerecupxml = (List<Entree>)obj;
                foreach (Entree joueur1 in listerecupxml)
                {
                    AjouterEntree(joueur1.Nom, joueur1.Score);
                }
                fichier.Close();
            }
        }

        public void SaveJson()
        {
            if (File.Exists("sérializationJson.json"))
            {
                Stream fichier = File.OpenRead("sérializationJson.json");
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Entree>));

                List<Entree> listerecupjson = (List<Entree>)serializer.ReadObject(fichier);
                foreach (Entree joueur1 in listerecupjson)
                {
                    AjouterEntree(joueur1.Nom, joueur1.Score);
                }
                fichier.Close();
            }
        }
    }
}


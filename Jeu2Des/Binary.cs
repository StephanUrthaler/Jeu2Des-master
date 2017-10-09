using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Jeu2Des
{
    public class Binary : Classement
    {

        //method serialize binary
        public override void Load()
        {
            Stream fichier = File.Create("sérializatiobinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichier, ListeEntrees);
            fichier.Close();
        }

        public override void Save()
        {
            if (File.Exists("sérializatiobinaire.txt"))
            {
                Stream fichier = File.OpenRead("sérializatiobinaire.txt");
                BinaryFormatter serializer = new BinaryFormatter();
                Object obj = serializer.Deserialize(fichier);
                //L'objet doit être casté pour qu'on puisse accéder à ces méthodes
                List<Entree> listerecupbinaire = (List<Entree>)obj;
                foreach (Entree joueur1 in listerecupbinaire)
                {
                    AjouterEntree(joueur1.Nom, joueur1.Score);
                }
                fichier.Close();
            }
        }
    }
}

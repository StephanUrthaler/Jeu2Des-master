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

        public virtual void AjouterEntree(string nom, int score)
        {
            _ListeEntrees.Add(new Entree(nom, score));
        }

        public virtual void TopN()
        {
            _ListeEntrees.Sort();
            _ListeEntrees.Reverse();
            Console.WriteLine("La nouvelle liste triée avec la liste sauvegardée");
            Console.WriteLine("");
            //Utiliser countains pour afficher la liste complète
            foreach (Entree joueur in _ListeEntrees)
            {
                Console.WriteLine(joueur);
            }
        }

    }
}


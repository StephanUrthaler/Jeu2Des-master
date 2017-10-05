using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;



namespace Jeu2Des
{
    //Implement "Icompare"

    [Serializable]
    public class Entree : IComparable
    {
        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }
        private int _Score;

        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        public Entree()
        {
            this.Nom = "nom";
            this.Score = 0;
        }
        public Entree(string nom, int score)
        {
            this.Nom = nom;
            this.Score = score;
        }
        //Defining method "ToString"
        public override string ToString()
        {
            return "Le joueur est " + Nom + " et sont score est de " + Score;
        }

        //defining the method "CompareTo"
        public int CompareTo(Object obj)
        {
            //Verifies object
            Entree other = obj as Entree;
            if (obj != null)
            {
                //Compares scores
                return this.Score.CompareTo(other.Score);
            }
            else
                //Call exeption
                throw new ArgumentException("L'/entrée est nulle");
        }
    }

}


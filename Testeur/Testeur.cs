using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Jeu2Des;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;

namespace Testeur
{
    class Testeur
    {

        public static void Main(string[] args)
        {

            //Le jeu est crée (avec ses 2 des et son classement)
            Jeu MonJeu = new Jeu(8);
            Console.WriteLine("Quel est votre prénom ?");
            string prenom = Console.ReadLine();
            Console.WriteLine("Bonjour " + prenom + ", voulez-vous jouer ? O/N");
            string reponse = Console.ReadLine();
            string attente = "o";

            if (reponse.ToLower() == attente)
            {
                while (reponse.ToLower() == attente)
                {
                    Console.WriteLine("");
                    //Jouons quelques parties ....

                    MonJeu.JouerPartie(prenom); //Joueur console
                    MonJeu.JouerPartie("David"); //Joueur supplémentaire
                    MonJeu.JouerPartie("Sarah"); //Joueur supplémentaire

                    Console.WriteLine("");
                    Console.WriteLine("");
                    MonJeu.VoirClassement();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Voulez-vous rejouer ? O/N");
                    reponse = Console.ReadLine();
                }
            }
            MonJeu.Quitter();

            Console.ReadKey();
        }
    }
}

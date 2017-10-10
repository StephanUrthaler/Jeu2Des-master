﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Jeu2Des
{
    class JSON : Classement
    {
        public override void Save()
        {
            Stream fichier = File.Create("sérializationJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(ListeEntrees.GetType());
            serializer.WriteObject(fichier, ListeEntrees);
            fichier.Close();
        }
        public override void Load()
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

using GestionMaison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteMaison
{
    class Configuration
    {
        private static Database _instance;

        // Méthode pour récupérer la chaîne de connexion
        public static string GetConnexion()
        {
            if (_instance == null)
            {
                // Initialisation une seule fois
                _instance = new Database("localhost", "gestion_maison", "root", "");
                _instance.OpenConnection();
            }

            return _instance.valeurconnexion();
        }

        // Si besoin d’accéder directement à l’objet Database
        public static Database GetDatabaseInstance()
        {
            if (_instance == null)
            {
                _instance = new Database("localhost", "gestion_maison", "root", "");
                _instance.OpenConnection();
            }

            return _instance;
        }


    }
}

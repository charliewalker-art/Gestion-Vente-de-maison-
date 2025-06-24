using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace GestionMaison
{
    public class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string userId;
        private string password;

        // Constructeur avec paramètres
        public Database(string server, string database, string userId, string password)
        {
            this.server = server;
            this.database = database;
            this.userId = userId;
            this.password = password;

            string connstr = $"server={server};database={database};uid={userId};pwd={password};";
            connection = new MySqlConnection(connstr);
        }

        // Méthode pour ouvrir la connexion
        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                // MessageBox.Show("connexion reussi");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur lors de l'ouverture de la connexion : " + ex.Message);
            }
        }

        // Méthode pour fermer la connexion
        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur lors de la fermeture de la connexion : " + ex.Message);
            }
        }

        // Accès direct à l'objet MySqlConnection (pour exécuter des requêtes)
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        // Méthode pour obtenir la chaîne de connexion
        public string valeurconnexion()
        {
            return $"server={server};database={database};uid={userId};pwd={password};";
        }
    }
}

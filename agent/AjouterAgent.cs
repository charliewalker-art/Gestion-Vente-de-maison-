using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenteMaison
{
    public partial class AjouterAgent: Form
    {
        public AjouterAgent()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjouteAgent_Click(object sender, EventArgs e)
        {
            // Récupération des valeurs saisies
            string nom = txtnom.Text.Trim();
            string prenom = txtprenom.Text.Trim();
            string contact = txtcontact.Text.Trim();

            // Vérification basique que les champs ne sont pas vides
            if (string.IsNullOrWhiteSpace(nom) ||
                string.IsNullOrWhiteSpace(prenom) ||
                string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show(
                    "Tous les champs (Nom, Prénom, Contact) doivent être remplis.",
                    "Champs manquants",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Construction du dictionnaire des données à insérer
            var data = new Dictionary<string, object>
            {
                { "nom", nom },
                { "prenom", prenom },
                { "contact", contact }
            };

            try
            {
                // 1) On récupère la chaîne de connexion depuis votre Configuration
                string connexionString = Configuration.GetConnexion();

                // 2) On crée un MySqlConnection à partir de cette chaîne
                using (MySqlConnection conn = new MySqlConnection(connexionString))
                {
                    // 3) On instancie Agent en passant l'objet MySqlConnection
                    Agent nouveauAgent = new Agent(conn);

                    // 4) On appelle la méthode Inserer
                    nouveauAgent.Inserer(data);

                    // 5) (Optionnel) : si vous avez un DataGridView nommé dataGridViewAgents,
                    //     vous pouvez le rafraîchir immédiatement :
                    // Agent.AfficherAgents(conn, dataGridViewAgents);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'ajout de l'agent : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            // Pas besoin de finally pour fermer la connexion manuellement :
            // la partie "using (MySqlConnection conn = …)" s'en charge automatiquement.
        }
    }

}


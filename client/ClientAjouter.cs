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
    public partial class ClientAjouter: Form
    {
        public ClientAjouter()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ajouter_Client_Click(object sender, EventArgs e)
        {
            string cin = txtcin.Text.Trim();
            string nom = txtnom.Text.Trim();
            string prenom = txtprenom.Text.Trim();
            string contact = txtcontact.Text.Trim();
            string adresse = txtadresse.Text.Trim();
            string dateInscription = DateTime.Now.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(cin) || string.IsNullOrWhiteSpace(nom))
            {
                MessageBox.Show("Le champ CIN et Nom sont obligatoires.");
                return;
            }

            try
            {
                string connStr = Configuration.GetConnexion();
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    Client client = new Client(connection);
                //    string id_client = Client.GenererIdClient(connection);

                    var data = new Dictionary<string, object>
            {
               // { "id_client", id_client },
                { "CIN", cin },
                { "nom", nom },
                { "prenom", prenom },
                { "contact", contact },
                { "adresse", adresse },
                { "date_inscription", dateInscription }
            };

                    client.Inserer(data);
                }

                // 🔄 Rafraîchir les données dans la fenêtre parente
                if (this.Owner is ClientForm parentForm)
                {
                    parentForm.Affiche_Donne_client();
                }

                // Nettoyage
                txtcin.Clear();
                txtnom.Clear();
                txtprenom.Clear();
                txtcontact.Clear();
                txtadresse.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du client : " + ex.Message);
            }
        }



    }
}

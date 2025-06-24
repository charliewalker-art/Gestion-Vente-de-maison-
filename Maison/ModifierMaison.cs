using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VenteMaison
{
    public partial class ModifierMaison: Form
    {
        public ModifierMaison(string id, string adresse, string quartier, string ville, string surface, string prix)
        {
            InitializeComponent();

            txtidmaison.Text = id;
            txtadresse.Text = adresse;
            txtquatrie.Text = quartier;
            txtville.Text = ville;
            txtsurface.Text = surface;
            txtprix.Text = prix;

            // Si tu veux désactiver la modification de l’ID :
            txtidmaison.ReadOnly = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            // Récupération et validation des entrées utilisateur
            string id_maison = txtidmaison.Text.Trim();
            string adresse = txtadresse.Text.Trim();
            string quartier = txtquatrie.Text.Trim();
            string ville = txtville.Text.Trim();
            string surface_str = txtsurface.Text.Trim();
            string prix_str = txtprix.Text.Trim();

            // Vérification de la surface
            if (!double.TryParse(surface_str, out double surface))
            {
                MessageBox.Show("Surface invalide.");
                return;
            }

            // Vérification du prix
            if (!decimal.TryParse(prix_str, out decimal prixInitial))
            {
                MessageBox.Show("Prix invalide.");
                return;
            }

            // Connexion à la base de données
            string connectionString = Configuration.GetConnexion();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    Maison maison = new Maison(connection);
                    bool success = maison.ModifierMaison(id_maison, adresse, quartier, ville, surface, prixInitial);

                    if (success)
                    {
                        MessageBox.Show("Maison modifiée avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Échec de la modification de la maison.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }


    }
}

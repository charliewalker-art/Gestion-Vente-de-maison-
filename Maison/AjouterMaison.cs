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
    public partial class AjouterMaison: Form
    {
        public AjouterMaison()
        {
            InitializeComponent();
        }

        private void btnAjouterMaison_Click(object sender, EventArgs e)
        {
            string adresse = txtadresse.Text.Trim();
            string quartier = txtquartier.Text.Trim();
            string ville = txtville.Text.Trim();
            string surfaceStr = txtsurface.Text.Trim();
            string prixStr = txtprix.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(adresse) || string.IsNullOrEmpty(quartier) ||
                string.IsNullOrEmpty(ville) || string.IsNullOrEmpty(surfaceStr) || string.IsNullOrEmpty(prixStr))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(surfaceStr, out float surface))
            {
                MessageBox.Show("Surface invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(prixStr, out int prix))
            {
                MessageBox.Show("Prix invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Création de la connexion et de l'objet Maison
         
            string connectionString = Configuration.GetConnexion();
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                Maison maison = new Maison(connection);

                var data = new Dictionary<string, object>
        {
            { "adresse", adresse },
            { "quartier", quartier },
            { "ville", ville },
            { "surface", surface },
            { "prix_initial", prix }
            // Ne pas ajouter "statut", laissé à la valeur par défaut : 'disponible'
        };

                maison.InsererMaison(data);
            }

            // Optionnel : vider les champs après insertion
            txtadresse.Text = "";
            txtquartier.Text = "";
            txtville.Text = "";
            txtsurface.Text = "";
            txtprix.Text = "";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

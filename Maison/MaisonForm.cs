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
    public partial class MaisonForm: Form
    {
        public MaisonForm()
        {
            InitializeComponent();
            Affiche_Maison();
            //double clique
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

            //style
            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);

            style.AppliquerStyleH1(Title);

            style.StyliserBouton(btn_recherche_maison);
            style.StyliserBouton(btnshowajouter);
        }


        private void btnshowajouter_Click(object sender, EventArgs e)
        {
              
        
            AjouterMaison maison_ajouter = new AjouterMaison();
            maison_ajouter.StartPosition = FormStartPosition.CenterParent;
            maison_ajouter.Owner = this;


            maison_ajouter.ShowDialog();
           Affiche_Maison();
           

        }

        public void Affiche_Maison()
        {
            try
            {
                string connectionString = Configuration.GetConnexion();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Nettoyer les colonnes pour éviter la duplication
                    dataGridView1.Columns.Clear();

                    // Appel correct de la méthode statique
                    Maison.Affichage_Maison(connection, dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }



        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1) Vérifier qu'une ligne est bien sélectionnée
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une maison à modifier.", "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2) Récupérer la ligne sélectionnée
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            // 3) Extraire les valeurs (adapter les noms des colonnes aux noms réels du DataGridView)
            string id_maison = row.Cells["id_maison"].Value?.ToString() ?? "";
            string adresse = row.Cells["adresse"].Value?.ToString() ?? "";
            string quartier = row.Cells["quartier"].Value?.ToString() ?? "";
            string ville = row.Cells["ville"].Value?.ToString() ?? "";
            string surface = row.Cells["surface"].Value?.ToString() ?? "";
            string prix = row.Cells["prix_initial"].Value?.ToString() ?? "";

            // 4) Créer le formulaire de modification avec ces données
            ModifierMaison modForm = new ModifierMaison(id_maison, adresse, quartier, ville, surface, prix)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            // 5) Afficher le formulaire en modal
            modForm.ShowDialog();

            // 6) Après fermeture, recharger les données du DataGridView
            Affiche_Maison(); // ← méthode à adapter si tu l’as sous un autre nom
        }


        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Vérifier qu’une ligne est bien sélectionnée
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une maison à supprimer.");
                    return;
                }

                // 2. Récupérer l'ID de la maison (colonne "id_maison") dans la ligne sélectionnée
                DataGridViewRow ligne = dataGridView1.SelectedRows[0];
                object valeurId = ligne.Cells["id_maison"].Value;
                if (valeurId == null)
                {
                    MessageBox.Show("L'ID de la maison est vide ou invalide.");
                    return;
                }

                string idMaison = valeurId.ToString();

                // 3. Confirmation de la suppression
                DialogResult reponse = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer la maison d'ID « {idMaison} » ?",
                    "Confirmation suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (reponse != DialogResult.Yes)
                    return;

                // 4. Connexion à la base et appel de la méthode statique
                string connectionString = Configuration.GetConnexion();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    Maison.SupprimerPard_id_maison(connection, idMaison);
                }

                // 5. Message de succès et rafraîchissement du DataGridView
                MessageBox.Show("Maison supprimée avec succès.");
                Affiche_Maison(); // Recharge le DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de la maison : " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_recherche_maison_Click(object sender, EventArgs e)
        {
            string valeur_recherche = textBox1.Text.Trim(); // Assure-toi que le nom du TextBox est correct

            if (string.IsNullOrWhiteSpace(valeur_recherche))
            {
                MessageBox.Show("Veuillez entrer un mot-clé pour la recherche.");
                return;
            }

            try
            {
                string chaineConnexion = Configuration.GetConnexion(); // récupère la chaîne de connexion
                using (MySqlConnection connexion = new MySqlConnection(chaineConnexion)) // crée et ouvre la connexion
                {
                    Maison.Rechercher(connexion, dataGridView1, valeur_recherche); // appelle ta méthode statique
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche de maison : " + ex.Message);
            }
        }

    }
}

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
    public partial class VenteForm: Form
    {
        public VenteForm()
        {
            InitializeComponent();
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

            Affichage_Vente();


            //style
            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);

            style.StyliserBouton(AjouterVenteModal);

            style.AppliquerStyleH1(Title);
        }

        private void AjouterVenteModal_Click(object sender, EventArgs e)
        {
            VenteAjouter vente_ajouter = new VenteAjouter();
            vente_ajouter.StartPosition = FormStartPosition.CenterParent;
            vente_ajouter.Owner = this;


            vente_ajouter.ShowDialog();
            Affichage_Vente();
        }

        public void Affichage_Vente()
        {
            try
            {
                string connectionString = Configuration.GetConnexion();
                using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Vider les colonnes pour éviter les duplications éventuelles
                    dataGridView1.Columns.Clear();

                    // Appeler la méthode d'affichage qui remplit automatiquement les colonnes
                    Vente.AfficherVentes(connection, dataGridView1);
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

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Vérifier qu'une ligne est sélectionnée dans le DataGridView des ventes
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une vente à supprimer.");
                    return;
                }

                // 2. Récupérer l'ID de la vente sélectionnée
                DataGridViewRow ligne = dataGridView1.SelectedRows[0];
                object valeurId = ligne.Cells["id_vente"].Value;

                if (valeurId == null)
                {
                    MessageBox.Show("L'ID de la vente est vide ou invalide.");
                    return;
                }

                string idVente = valeurId.ToString();

                // 3. Demander confirmation
                DialogResult confirmation = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer la vente d'ID « {idVente} » ?\nCela annulera le contrat et rendra la maison disponible.",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmation != DialogResult.Yes)
                    return;

                // 4. Connexion et suppression
                string connectionString = Configuration.GetConnexion();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    Vente vente = new Vente(connection);
                    vente.SupprimerVente(idVente);
                }

                // 5. Message de succès et rafraîchissement de l'affichage
                MessageBox.Show("Vente supprimée avec succès.");
                Affichage_Vente(); // Méthode pour rafraîchir le DataGridView (à implémenter si ce n’est pas fait)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de la vente : " + ex.Message);
            }
        }

     
    }
}

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
    public partial class PaimentForm: Form
    {
        public PaimentForm()
        {
            InitializeComponent();
            //menu toulesee
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            //affichage
            Affiche_Paiment();

            //style
            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);

            style.AppliquerStyleH1(Title);
            style.StyliserBouton(ajoute_dialog_ajoute_paiment);


        }

        public void Affiche_Paiment()
        {
            try
            {
                string connectionString = Configuration.GetConnexion();
                using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Vider les colonnes pour éviter les duplications éventuelles
                    dataGridView1.Columns.Clear();

                    // Appeler la méthode d'affichage qui remplit automatiquement les colonnes
                    Paiment.AfficherPaiements(connection, dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }


        private void ajoute_dialog_ajoute_paiment_Click(object sender, EventArgs e)
        {
            AjouterPaiment Paiment_Ajouter = new AjouterPaiment();
            Paiment_Ajouter.StartPosition = FormStartPosition.CenterParent;
            Paiment_Ajouter.Owner = this;


            Paiment_Ajouter.ShowDialog();
        }
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Vérifier qu’une ligne est bien sélectionnée
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un paiement à annuler.");
                    return;
                }

                // 2. Récupérer l'ID du paiement dans la ligne sélectionnée
                DataGridViewRow ligne = dataGridView1.SelectedRows[0];
                object valeurId = ligne.Cells["id_paiement"].Value;
                if (valeurId == null)
                {
                    MessageBox.Show("L'ID du paiement est vide ou invalide.");
                    return;
                }

                string id_paiement = valeurId.ToString();

                // 3. Confirmation de l'annulation
                DialogResult reponse = MessageBox.Show(
                    $"Voulez-vous vraiment annuler le paiement d'ID « {id_paiement} » ?",
                    "Confirmation annulation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (reponse != DialogResult.Yes)
                    return;

                // 4. Connexion à la base et appel de la méthode
                string connectionString = Configuration.GetConnexion();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Paiment paimentManager = new Paiment(connection);

                    bool resultat = paimentManager.Supprimer_PaimentID(id_paiement);

                    if (resultat)
                    {
                        MessageBox.Show("Paiement annulé avec succès.");
                        Affiche_Paiment(); // Recharge le DataGridView des paiements
                    }
                    else
                    {
                        MessageBox.Show("L'annulation du paiement a échoué.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'annulation du paiement : " + ex.Message);
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

    }
}

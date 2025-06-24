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
    public partial class ClientForm: Form
    {
        public ClientForm()
        {
            InitializeComponent();
            Affiche_Donne_client();
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            //style
            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);

          
            style.StyliserBouton(btnajouter);
            style.StyliserBouton(btn_recherche);

            style.AppliquerStyleH1(Title);


        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
           
            ClientAjouter clientAjouterForm = new ClientAjouter();
            clientAjouterForm.StartPosition = FormStartPosition.CenterParent;
            clientAjouterForm.Owner = this;

            
           clientAjouterForm.ShowDialog(); 
        }

        public void Affiche_Donne_client()
        {
            try
            {
                string connectionString = Configuration.GetConnexion();
                using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Vider les colonnes pour éviter les duplications éventuelles
                    dataGridView1.Columns.Clear();

                    // Appeler la méthode d'affichage qui remplit automatiquement les colonnes
                    Client.AfficherClients(connection, dataGridView1);
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

                // Affiche le menu contextuel à la position du curseur
                contextMenuStrip1.Show(Cursor.Position);
            }
        }


        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1) On vérifie qu'une ligne est bien sélectionnée
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Veuillez d'abord sélectionner un client à modifier.",
                    "Aucune sélection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            // 2) On récupère la ligne sélectionnée
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            // 3) On extrait les valeurs des cellules
            //    Il faut que les noms correspondents soient bien ceux des colonnes de votre DataGridView
            //    Ici, on suppose que vos colonnes s'appellent exactement "CIN", "nom", "prenom", "contact", "adresse"
            string cin = row.Cells["CIN"].Value?.ToString() ?? "";
            string nom = row.Cells["nom"].Value?.ToString() ?? "";
            string prenom = row.Cells["prenom"].Value?.ToString() ?? "";
            string contact = row.Cells["contact"].Value?.ToString() ?? "";
            string adresse = row.Cells["adresse"].Value?.ToString() ?? "";

            // 4) On instancie Modifier_client en passant ces valeurs
            Modifier_client clientModifierForm = new Modifier_client(cin, nom, prenom, contact, adresse)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            // 5) On affiche le formulaire en modal
            clientModifierForm.ShowDialog();

            // 6) Après fermeture, on rafraîchit le DataGridView pour voir les modifications
            Affiche_Donne_client();
        }


        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne à supprimer.");
                    return;
                }

                // Récupérer le CIN (première colonne du DataGridView)
                string cin = dataGridView1.SelectedRows[0].Cells["CIN"].Value?.ToString();

                if (string.IsNullOrEmpty(cin))
                {
                    MessageBox.Show("Le CIN est vide ou invalide.");
                    return;
                }

                DialogResult answer = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer le client au CIN « {cin} » ?",
                    "Confirmation suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (answer != DialogResult.Yes)
                    return;

                string connectionString = Configuration.GetConnexion();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    Client.SupprimerParCIN(connection, cin);
                    MessageBox.Show("Client supprimé avec succès.");
                    Affiche_Donne_client(); // rafraîchit le DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_recherche_Click(object sender, EventArgs e)
        {
            string valeur_recherche = txt_recherche_nom.Text.Trim();

            if (string.IsNullOrWhiteSpace(valeur_recherche))
            {
                MessageBox.Show("Veuillez entrer un mot-clé pour la recherche.");
                return;
            }

            try
            {
                string chaineConnexion = Configuration.GetConnexion(); // récupère la chaîne
                using (MySqlConnection connexion = new MySqlConnection(chaineConnexion)) // crée la connexion
                {
                    Client.Rechercher(connexion, dataGridView1, valeur_recherche); // utilise la méthode Rechercher
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche : " + ex.Message);
            }
        }

     

    }

}

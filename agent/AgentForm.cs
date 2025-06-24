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
    public partial class AgentForm: Form
    {
        public AgentForm()
        {
            InitializeComponent();
            Affiche_Agent();
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

            //style
            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);

            style.AppliquerStyleH1(Title);
            style.StyliserBouton(Ajouter_Agent);
            style.StyliserBouton(btn_recherceh_agent);




        }

        private void Ajouter_Agent_Click(object sender, EventArgs e)
        {
            AjouterAgent agent_ajouter = new AjouterAgent();
            agent_ajouter.StartPosition = FormStartPosition.CenterParent;
            agent_ajouter.Owner = this;


            agent_ajouter.ShowDialog();
            Affiche_Agent();
        }

        public void Affiche_Agent()
        {
            try
            {
                string connectionString = Configuration.GetConnexion();
                using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Vider les colonnes pour éviter les duplications éventuelles
                    dataGridView1.Columns.Clear();

                    // Appeler la méthode d'affichage qui remplit automatiquement les colonnes
                    Agent.AfficherAgents(connection, dataGridView1);
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
            // 1) Vérifier qu'il y a bien une ligne sélectionnée
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une ligne à modifier.", "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2) Récupérer la ligne sélectionnée
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            // 3) Extraire les valeurs des cellules (adapter les noms de colonnes exacts de votre DataGridView)
            //    Supposons que vos colonnes s'appellent "id_agent", "nom", "prenom", "contact".
            string id_agent = row.Cells["id_agent"].Value?.ToString() ?? "";
            string nom = row.Cells["nom"].Value?.ToString() ?? "";
            string prenom = row.Cells["prenom"].Value?.ToString() ?? "";
            string contact = row.Cells["contact"].Value?.ToString() ?? "";

            // 4) Instancier ModifierAgent en passant les valeurs récupérées
            ModifierAgent modForm = new ModifierAgent(id_agent, nom, prenom, contact)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            // 5) Afficher en modal pour permettre la modification
            modForm.ShowDialog();

            // 6) Après fermeture de ModifierAgent, on recharge le DataGridView
            Affiche_Agent();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Vérifier qu’une ligne est bien sélectionnée
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un agent à supprimer.");
                    return;
                }

                // 2. Récupérer l'ID de l'agent (colonne "id_agent") dans la ligne sélectionnée
                DataGridViewRow ligne = dataGridView1.SelectedRows[0];
                object valeurId = ligne.Cells["id_agent"].Value;
                if (valeurId == null)
                {
                    MessageBox.Show("L'ID de l'agent est vide ou invalide.");
                    return;
                }

                string idAgent = valeurId.ToString();

                // 3. Confirmation de la suppression
                DialogResult reponse = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer l'agent d'ID « {idAgent} » ?",
                    "Confirmation suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (reponse != DialogResult.Yes)
                    return;

                // 4. Connexion à la base et appel de la méthode SupprimerParId
                string connectionString = Configuration.GetConnexion();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    Agent.SupprimerParId(connection, idAgent);
                }

                // 5. Message de succès et rafraîchissement du DataGridView
                MessageBox.Show("Agent supprimé avec succès.");
                Affiche_Agent(); // Méthode qui recharge le DataGridView des agents
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de l'agent : " + ex.Message);
            }
        }

        private void btn_recherceh_agent_Click(object sender, EventArgs e)
        {
            string valeur_recherche = txt_recherche_agent.Text.Trim();

            if (string.IsNullOrWhiteSpace(valeur_recherche))
            {
                MessageBox.Show("Veuillez entrer un mot-clé pour la recherche d'un agent.");
                return;
            }

            try
            {
                string chaineConnexion = Configuration.GetConnexion(); // Récupère la chaîne de connexion
                using (MySqlConnection connexion = new MySqlConnection(chaineConnexion)) // Crée la connexion
                {
                    Agent.Rechercher(connexion, dataGridView1, valeur_recherche); // Appelle la méthode Rechercher de la classe Agent
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche d'agent : " + ex.Message);
            }
        }

    }
}

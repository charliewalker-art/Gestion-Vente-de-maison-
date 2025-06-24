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
    public partial class VenteAjouter: Form
    {
        private readonly string _cs = Configuration.GetConnexion();
        public VenteAjouter()
        {
            InitializeComponent();
            //appel de la fonction
            charge_id_contrat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void charge_id_contrat()
        {
            // On efface d'abord les éléments déjà présents
            comboBoxidcontrat.Items.Clear();

            try
            {
                using (var con = new MySqlConnection(_cs))
                {
                    con.Open();
                    // Exemple : on récupère les IDs de maison (ou contrat selon votre besoin)
                    string sql = "SELECT id_contrat FROM contrat;";
                    using (var cmd = new MySqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string idMaison = reader.GetString("id_contrat");
                            comboBoxidcontrat.Items.Add(idMaison);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des ID de maison :\n" + ex.Message,
                    "Erreur de chargement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }



        private void btnajoutervente_Click(object sender, EventArgs e)
        {
            string id_contrat = comboBoxidcontrat.Text.Trim();
            string statutVente = "en_cours";
            string statutContrat = "acte_final";
            DateTime dateVente = DateTime.Now;
            string connexionString = Configuration.GetConnexion();

            using (MySqlConnection conn = new MySqlConnection(connexionString))
            {
                conn.Open();

                // Vérifier que le statut du contrat est "promesse"
                string checkStatutSql = "SELECT statut FROM Contrat WHERE id_contrat = @id_contrat;";
                using (MySqlCommand cmdCheck = new MySqlCommand(checkStatutSql, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@id_contrat", id_contrat);
                    object result = cmdCheck.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Contrat introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string statutActuel = result.ToString();
                    if (statutActuel != "promesse")
                    {
                        MessageBox.Show("Le contrat sélectionné n'est pas au statut 'promesse'.", "Action impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Créer un objet Vente pour générer l'ID
                Vente vente = new Vente(conn);
                string id_vente = vente.GenererIdVente();

                // Mettre à jour le statut du contrat
                string updateContratSql = "UPDATE Contrat SET statut = @statut WHERE id_contrat = @id_contrat;";
                using (MySqlCommand cmdUpdate = new MySqlCommand(updateContratSql, conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@statut", statutContrat);
                    cmdUpdate.Parameters.AddWithValue("@id_contrat", id_contrat);
                    cmdUpdate.ExecuteNonQuery();
                }

                // Insérer la nouvelle vente
                string insertVenteSql = "INSERT INTO Vente (id_vente, id_contrat, statut, date_vente) VALUES (@id_vente, @id_contrat, @statut, @date_vente);";
                using (MySqlCommand cmdInsert = new MySqlCommand(insertVenteSql, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@id_vente", id_vente);
                    cmdInsert.Parameters.AddWithValue("@id_contrat", id_contrat);
                    cmdInsert.Parameters.AddWithValue("@statut", statutVente);
                    cmdInsert.Parameters.AddWithValue("@date_vente", dateVente);
                    cmdInsert.ExecuteNonQuery();
                }

                MessageBox.Show("Vente ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

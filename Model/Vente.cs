using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VenteMaison
{
    public class Vente : Table
    {
        public Vente(MySqlConnection connection)
            : base(
                  connection,
                  "Vente",
                  // Colonnes à insérer : id_vente (fournie manuellement), id_contrat, statut, date_vente
                  new List<string> { "id_vente", "id_contrat", "statut", "date_vente" },
                  "id_vente"  // Clé primaire (VARCHAR)
              )
        {
        }

        //genere id vente
        public string GenererIdVente()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string sqlMax = "SELECT MAX(id_vente) FROM Vente;";
                using (var cmd = new MySqlCommand(sqlMax, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value || result == null)
                        return "VEN001";

                    string idMax = result.ToString();
                    string numericPart = idMax.Substring(3);
                    if (!int.TryParse(numericPart, out int valeur))
                        return "VEN001";

                    int prochain = valeur + 1;
                    string nextNumeric = prochain.ToString("D3");
                    return "VEN" + nextNumeric;
                }
            }
            catch
            {
                return "VEN001";
            }
        }


        public static void AfficherVentes(MySqlConnection connection, DataGridView dgv)
        {
            try
            {
                connection.Open();
                string sql = @"
            SELECT id_vente, id_contrat, statut, date_vente
            FROM Vente;
        ";

                using (var cmd = new MySqlCommand(sql, connection))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgv.AutoGenerateColumns = false;
                    dgv.Columns.Clear();

                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "id_vente",
                        HeaderText = "ID Vente",
                        Name = "id_vente"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "id_contrat",
                        HeaderText = "ID Contrat",
                        Name = "id_contrat"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "statut",
                        HeaderText = "Statut",
                        Name = "statut"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "date_vente",
                        HeaderText = "Date Vente",
                        Name = "date_vente",
                        DefaultCellStyle = { Format = "dd/MM/yyyy" }  // Format date lisible
                    });

                    dgv.DataSource = table;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'affichage des ventes : " + ex.Message);
            }

        }

        public void SupprimerVente(string id_vente)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Étape 1 : récupérer id_contrat à partir de la vente
                string getContratQuery = "SELECT id_contrat FROM Vente WHERE id_vente = @id_vente;";
                string id_contrat = null;

                using (MySqlCommand cmd = new MySqlCommand(getContratQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id_vente", id_vente);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Vente introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    id_contrat = result.ToString();
                }

                // Étape 2 : récupérer id_maison à partir du contrat
                string getMaisonQuery = "SELECT id_maison FROM Contrat WHERE id_contrat = @id_contrat;";
                string id_maison = null;

                using (MySqlCommand cmd = new MySqlCommand(getMaisonQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id_contrat", id_contrat);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Contrat introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    id_maison = result.ToString();
                }

                // Étape 3 : mettre à jour le contrat (statut = annule)
                string updateContratQuery = "UPDATE Contrat SET statut = 'annule' WHERE id_contrat = @id_contrat;";
                using (MySqlCommand cmd = new MySqlCommand(updateContratQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id_contrat", id_contrat);
                    cmd.ExecuteNonQuery();
                }

                // Étape 4 : mettre à jour la maison (statut = disponible)
                string updateMaisonQuery = "UPDATE Maison SET statut = 'disponible' WHERE id_maison = @id_maison;";
                using (MySqlCommand cmd = new MySqlCommand(updateMaisonQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id_maison", id_maison);
                    cmd.ExecuteNonQuery();
                }

                // Étape 5 : supprimer la vente
                string deleteVenteQuery = "DELETE FROM Vente WHERE id_vente = @id_vente;";
                using (MySqlCommand cmd = new MySqlCommand(deleteVenteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id_vente", id_vente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Vente supprimée avec succès, contrat annulé et maison disponible.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

    }
}

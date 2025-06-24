using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;

namespace VenteMaison
{
    public class Paiment : Table
    {
        private MySqlConnection _connection;

        public Paiment(MySqlConnection connection)
            : base(
                  connection,
                  "Paiement",
                  new List<string> { "id_paiement", "id_vente", "date_paiement" },
                  "id_paiement"
              )
        {
            _connection = connection; // On garde la référence localement
        }

        public string GenererIdPaiement()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string sqlMax = "SELECT MAX(id_paiement) FROM Paiement;";
                using (var cmd = new MySqlCommand(sqlMax, _connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value || result == null)
                        return "PAIM0001";

                    string idMax = result.ToString();
                    string numericPart = idMax.Substring(4); // "PAIM" = 4 caractères
                    if (!int.TryParse(numericPart, out int valeur))
                        return "PAIM0001";

                    int prochain = valeur + 1;
                    string nextNumeric = prochain.ToString("D4");
                    return "PAIM" + nextNumeric;
                }
            }
            catch
            {
                return "PAIM0001";
            }
        }

        public static void AfficherPaiements(MySqlConnection connection, DataGridView dgv)
        {
            try
            {
                connection.Open();
                string sql = @"
            SELECT id_paiement, id_vente, date_paiement
            FROM Paiement;
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
                        DataPropertyName = "id_paiement",
                        HeaderText = "ID Paiement",
                        Name = "id_paiement"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "id_vente",
                        HeaderText = "ID Vente",
                        Name = "id_vente"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "date_paiement",
                        HeaderText = "Date Paiement",
                        Name = "date_paiement"
                    });

                    dgv.DataSource = table;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'affichage des paiements : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Supprimer_PaimentID(string id_paiement)
        {
            try
            {
                // Démarrer la transaction
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "START TRANSACTION";
                    cmd.ExecuteNonQuery();
                }

                // 1. Récupérer l'id_vente associé à ce paiement
                string id_vente = null;
                using (MySqlCommand cmd = new MySqlCommand("SELECT id_vente FROM Paiement WHERE id_paiement = @id_paiement", connection))
                {
                    cmd.Parameters.AddWithValue("@id_paiement", id_paiement);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id_vente = reader.GetString("id_vente");
                        }
                        else
                        {
                            throw new Exception("Paiement introuvable pour cet id_paiement.");
                        }
                    }
                }

                // 2. Supprimer le paiement
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Paiement WHERE id_paiement = @id_paiement", connection))
                {
                    cmd.Parameters.AddWithValue("@id_paiement", id_paiement);
                    cmd.ExecuteNonQuery();
                }

                // 3. Mettre à jour le statut de la vente
                using (MySqlCommand cmd = new MySqlCommand("UPDATE Vente SET statut = 'annuler' WHERE id_vente = @id_vente", connection))
                {
                    cmd.Parameters.AddWithValue("@id_vente", id_vente);
                    cmd.ExecuteNonQuery();
                }

                // 4. Récupérer l’id_contrat
                string id_contrat = null;
                using (MySqlCommand cmd = new MySqlCommand("SELECT id_contrat FROM Vente WHERE id_vente = @id_vente", connection))
                {
                    cmd.Parameters.AddWithValue("@id_vente", id_vente);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id_contrat = reader.GetString("id_contrat");
                        }
                        else
                        {
                            throw new Exception("Contrat introuvable pour cette vente.");
                        }
                    }
                }

                // 5. Mise à jour du statut du contrat
                using (MySqlCommand cmd = new MySqlCommand("UPDATE Contrat SET statut = 'annule' WHERE id_contrat = @id_contrat", connection))
                {
                    cmd.Parameters.AddWithValue("@id_contrat", id_contrat);
                    cmd.ExecuteNonQuery();
                }

                // 6. Récupérer l’id_maison à partir du contrat
                string id_maison = null;
                using (MySqlCommand cmd = new MySqlCommand("SELECT id_maison FROM Contrat WHERE id_contrat = @id_contrat", connection))
                {
                    cmd.Parameters.AddWithValue("@id_contrat", id_contrat);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id_maison = reader.GetString("id_maison");
                        }
                        else
                        {
                            throw new Exception("Maison introuvable pour ce contrat.");
                        }
                    }
                }

                // 7. Mise à jour du statut de la maison
                using (MySqlCommand cmd = new MySqlCommand("UPDATE Maison SET statut = 'disponible' WHERE id_maison = @id_maison", connection))
                {
                    cmd.Parameters.AddWithValue("@id_maison", id_maison);
                    cmd.ExecuteNonQuery();
                }

                // 8. Commit de la transaction
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "COMMIT";
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    using (MySqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "ROLLBACK";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }

                MessageBox.Show("Erreur lors de l'annulation de la vente : " + ex.Message);
                return false;
            }
        }


    }

}

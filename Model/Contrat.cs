using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace VenteMaison
{
    public class Contrat : Table
    {
        // Champ privé pour stocker la connexion transmise au constructeur
        private readonly MySqlConnection _connection;

        public Contrat(MySqlConnection connection)
            : base(
                  connection,
                  "Contrat",
                  new List<string>
                  {
                      "id_contrat",
                      "id_maison",
                      "CIN",
                      "id_agent",
                      "date_du_contrat",
                      "montant",
                      "statut"
                  },
                  "id_contrat"
            )
        {
            // On affecte la connexion au champ privé
            _connection = connection;
        }


        public static void AfficherContrats(MySqlConnection connection, DataGridView dgv)
        {
            try
            {
                connection.Open();
                string sql = @"
            SELECT id_contrat, id_maison, CIN, id_agent, date_du_contrat, montant, statut
            FROM Contrat;
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
                        DataPropertyName = "id_contrat",
                        HeaderText = "ID Contrat",
                        Name = "id_contrat"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "id_maison",
                        HeaderText = "ID Maison",
                        Name = "id_maison"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "CIN",
                        HeaderText = "CIN Client",
                        Name = "CIN"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "id_agent",
                        HeaderText = "ID Agent",
                        Name = "id_agent"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "date_du_contrat",
                        HeaderText = "Date de contrat",
                        Name = "date_du_contrat"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "montant",
                        HeaderText = "Montant",
                        Name = "montant"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "statut",
                        HeaderText = "Statut",
                        Name = "statut"
                    });

                    dgv.DataSource = table;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'affichage des contrats : " + ex.Message);
            }
          
        }


        public void ModifierContrat(string idContrat, int nouveauMontant, DateTime nouvelleDateContrat)
        {
            try
            {
                // Ouvre la connexion si nécessaire
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string sql = @"
                    UPDATE Contrat
                    SET montant = @montant,
                        date_du_contrat = @dateContrat
                    WHERE id_contrat = @idContrat;
                ";

                using (var cmd = new MySqlCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@montant", nouveauMontant);
                    cmd.Parameters.AddWithValue("@dateContrat", nouvelleDateContrat);
                    cmd.Parameters.AddWithValue("@idContrat", idContrat);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show(
                            "Aucun contrat modifié. Vérifiez l'ID du contrat.",
                            "Modification échouée",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Contrat modifié avec succès.",
                            "Succès",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification du contrat : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            
        }

        public void SupprimerParId_contrat(string idContrat)
        {
            try
            {
                // 1) Ouvrir la connexion si nécessaire
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                // 2) Récupérer l'id_maison associé à cet id_contrat
                string idMaison;
                string sqlSelectMaison = "SELECT id_maison FROM Contrat WHERE id_contrat = @idContrat;";
                using (var cmdSelect = new MySqlCommand(sqlSelectMaison, _connection))
                {
                    cmdSelect.Parameters.AddWithValue("@idContrat", idContrat);
                    object result = cmdSelect.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show(
                            $"Aucun contrat trouvé pour l’ID '{idContrat}'.",
                            "Suppression impossible",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                    idMaison = result.ToString();
                }

                // 3) Mettre à jour le statut de la maison en "disponible"
                string sqlUpdateMaison = "UPDATE Maison SET statut = 'disponible' WHERE id_maison = @idMaison;";
                using (var cmdUpdate = new MySqlCommand(sqlUpdateMaison, _connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@idMaison", idMaison);
                    cmdUpdate.ExecuteNonQuery();
                }

                // 4) Supprimer le contrat lui-même
                string sqlDeleteContrat = "DELETE FROM Contrat WHERE id_contrat = @idContrat;";
                using (var cmdDelete = new MySqlCommand(sqlDeleteContrat, _connection))
                {
                    cmdDelete.Parameters.AddWithValue("@idContrat", idContrat);
                    int rowsAffected = cmdDelete.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show(
                            "La suppression n’a pas affecté de ligne (vérifiez l’ID du contrat).",
                            "Avertissement",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Le contrat '{idContrat}' a été supprimé\n" +
                            $"et la maison '{idMaison}' est redevenue disponible.",
                            "Suppression réussie",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression du contrat :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }






    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VenteMaison
{
    public class Maison : Table
    {
        public Maison(MySqlConnection connection)
            : base(
                  connection,
                  "Maison",
                  new List<string> {
                      "id_maison",
                      "adresse",
                      "quartier",
                      "ville",
                      "surface",
                      "prix_initial",
                      "statut"
                  },
                  "id_maison" 
              )
        {
        }
        public string GenererIdMaison()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                // On récupère l'identifiant maximal existant (au format "MAIS###")
                string sqlMax = $"SELECT MAX(id_maison) FROM {tableName};";
                using (var cmd = new MySqlCommand(sqlMax, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value || result == null)
                    {
                        // S'il n'y a pas encore de maison, on démarre à MAIS001
                        return "MAIS001";
                    }

                    string idMax = result.ToString(); // ex. "MAIS017"
                    string numericPart = idMax.Substring(4); // "017"
                    if (!int.TryParse(numericPart, out int valeur))
                    {
                        // Si parsing impossible, on repart sur MAIS001
                        return "MAIS001";
                    }

                    int prochain = valeur + 1; // ex. 18
                    string nextNumeric = prochain.ToString("D3"); // "018"
                    return "MAIS" + nextNumeric;
                }
            }
            catch
            {
                // En cas d'erreur, retourne l'identifiant initial
                return "MAIS001";
            }
        }
        public void InsererMaison(Dictionary<string, object> data)
        {
            try
            {
                // Générer un nouvel ID maison
                string nouveauId = GenererIdMaison();
                data["id_maison"] = nouveauId;

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Retirer "statut" si présent (on ne veut pas l'insérer)
                if (data.ContainsKey("statut"))
                    data.Remove("statut");

                // Construction des noms de colonnes et des paramètres
                string colonnes = string.Join(", ", data.Keys);
                string valeurs = "@" + string.Join(", @", data.Keys);

                string sql = $@"
            INSERT INTO {tableName}
                ({colonnes})
            VALUES 
                ({valeurs});
        ";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    foreach (var pair in data)
                    {
                        cmd.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                    }

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show(
                            $"Maison ajoutée avec succès ! (ID = {nouveauId})",
                            "Insertion réussie",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    else
                        MessageBox.Show(
                            "Aucune ligne ajoutée.",
                            "Insertion échouée",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                }
            }
            catch (Exception ex)
            {
                string debugSql = $"Requête SQL : INSERT INTO {tableName} ({string.Join(", ", data.Keys)}) VALUES ({string.Join(", ", data.Keys.Select(k => "@" + k))})";
                MessageBox.Show(
                    $"Erreur d'ajout maison : {ex.Message}\n\n{debugSql}",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public static void Affichage_Maison(MySqlConnection connection, DataGridView dgv)
        {
            try
            {
                connection.Open();
                string sql = @"
            SELECT id_maison, adresse, quartier, ville, surface, prix_initial, statut
            FROM Maison;
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
                        DataPropertyName = "id_maison",
                        HeaderText = "ID Maison",
                        Name = "id_maison"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "adresse",
                        HeaderText = "Adresse",
                        Name = "adresse"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "quartier",
                        HeaderText = "Quartier",
                        Name = "quartier"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "ville",
                        HeaderText = "Ville",
                        Name = "ville"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "surface",
                        HeaderText = "Surface (m²)",
                        Name = "surface"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "prix_initial",
                        HeaderText = "Prix Initial (AR)",
                        Name = "prix_initial"
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
                MessageBox.Show("Erreur d'affichage des maisons : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void SupprimerPard_id_maison(MySqlConnection connection, string idmaison)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string queryDelete = "DELETE FROM Maison WHERE id_maison = @id_maison;";
                using (var cmdDelete = new MySqlCommand(queryDelete, connection))
                {
                    cmdDelete.Parameters.AddWithValue("@id_maison", idmaison);
                    int rows = cmdDelete.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Aucun maison supprimé (ID introuvable).");
                }
            }
            catch (Exception ex)
            {
                // Selon votre usage, vous pouvez remonter l'exception ou afficher le message ici.
                MessageBox.Show("Erreur lors de la suppression de maison : " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public bool ModifierMaison(string idMaison, string adresse, string quartier, string ville, double surface, decimal prixInitial)
        {
            try
            {
                string query = @"
            UPDATE Maison 
            SET 
                adresse = @adresse,
                quartier = @quartier,
                ville = @ville,
                surface = @surface,
                prix_initial = @prixInitial
            WHERE id_maison = @idMaison";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@adresse", adresse);
                    cmd.Parameters.AddWithValue("@quartier", quartier);
                    cmd.Parameters.AddWithValue("@ville", ville);
                    cmd.Parameters.AddWithValue("@surface", surface);
                    cmd.Parameters.AddWithValue("@prixInitial", prixInitial);
                    cmd.Parameters.AddWithValue("@idMaison", idMaison);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification de la maison : " + ex.Message);
                return false;
            }
        }



        public static void Rechercher(MySqlConnection connection, DataGridView dgv, string motCle)
        {
            try
            {
                connection.Open();

                string sql = @"
            SELECT id_maison, adresse, quartier, ville, surface, prix_initial, statut
            FROM Maison
            WHERE id_maison LIKE @motCle
               OR adresse LIKE @motCle
               OR quartier LIKE @motCle
               OR ville LIKE @motCle
               OR surface LIKE @motCle
               OR prix_initial LIKE @motCle
               OR statut LIKE @motCle;
        ";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@motCle", "%" + motCle + "%");

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgv.AutoGenerateColumns = false;
                        dgv.Columns.Clear();

                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "id_maison",
                            HeaderText = "ID Maison",
                            Name = "id_maison"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "adresse",
                            HeaderText = "Adresse",
                            Name = "adresse"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "quartier",
                            HeaderText = "Quartier",
                            Name = "quartier"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "ville",
                            HeaderText = "Ville",
                            Name = "ville"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "surface",
                            HeaderText = "Surface (m²)",
                            Name = "surface"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "prix_initial",
                            HeaderText = "Prix Initial (AR)",
                            Name = "prix_initial"
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche des maisons : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

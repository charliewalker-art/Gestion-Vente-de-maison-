using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace VenteMaison
{
    public class Agent : Table
    {
        public Agent(MySqlConnection connection)
            : base(
                  connection,
                  "Agent",
                  // On ajoute "id_agent" à la liste des colonnes à insérer,
                  // puisqu'on va le fournir manuellement
                  new List<string> { "id_agent", "nom", "prenom", "contact" },
                  "id_agent" // <-- id_agent est désormais PK (type VARCHAR)
              )
        {
        }

        private string GenererIdAgent()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // On récupère l'identifiant maximal existant (au format "AGEN###")
                string sqlMax = $"SELECT MAX(id_agent) FROM {tableName};";
                using (var cmd = new MySqlCommand(sqlMax, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value || result == null)
                    {
                        // S'il n'y a pas encore d'agents, on démarre à AGEN001
                        return "AGEN001";
                    }

                    string idMax = result.ToString(); // ex. "AGEN017"
                    // On extrait la partie numérique (après "AGEN")
                    string numericPart = idMax.Substring(4); // "017"
                    if (!int.TryParse(numericPart, out int valeur))
                    {
                        // Si parsing impossible, on repart sur AGEN001
                        return "AGEN001";
                    }

                    // Incrémentation
                    int prochain = valeur + 1; // 18
                    // Reformatage sur 3 chiffres (ex. 018)
                    string nextNumeric = prochain.ToString("D3");
                    return "AGEN" + nextNumeric;
                }
            }
            catch
            {
                // En cas d'erreur de lecture, on renvoie "AGEN001" par défaut
                return "AGEN001";
            }
        
        }


        public void Inserer(Dictionary<string, object> data)
        {
            try
            {
                string nouveauId = GenererIdAgent();
                data["id_agent"] = nouveauId;

                if (connection.State != ConnectionState.Open)
                    connection.Open();


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
                            $"Agent ajouté avec succès ! (ID = {nouveauId})",
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
                    $"Erreur d'ajout agent : {ex.Message}\n\n{debugSql}",
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


        public static void AfficherAgents(MySqlConnection connection, DataGridView dgv)
        {
            try
            {
                connection.Open();
                string sql = @"
                    SELECT id_agent, nom, prenom, contact
                    FROM Agent;
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
                        DataPropertyName = "id_agent",
                        HeaderText = "ID Agent",
                        Name = "id_agent"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "nom",
                        HeaderText = "Nom",
                        Name = "nom"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "prenom",
                        HeaderText = "Prénom",
                        Name = "prenom"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "contact",
                        HeaderText = "Contact",
                        Name = "contact"
                    });

                    dgv.DataSource = table;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'affichage des agents : " + ex.Message);
            }
           
        }

      
        public void Modifier(string idAgent, Dictionary<string, object> data)
        {
            try
            {
              

                connection.Open();

                // Construire dynamiquement la clause SET
                // Ex. => "nom = @nom, prenom = @prenom, contact = @contact"
                string setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));

                // On modifie en WHERE id_agent = @id_agent
                string sql = $"UPDATE {tableName} SET {setClause} WHERE id_agent = @id_agent;";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    foreach (var pair in data)
                    {
                        cmd.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                    }
                    cmd.Parameters.AddWithValue("@id_agent", idAgent);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Agent modifié avec succès !");
                    else
                        MessageBox.Show("Aucune modification effectuée (ID introuvable).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification de l'agent : " + ex.Message);
            }
         
        }


        public static void SupprimerParId(MySqlConnection connection, string idAgent)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string queryDelete = "DELETE FROM Agent WHERE id_agent = @id_agent;";
                using (var cmdDelete = new MySqlCommand(queryDelete, connection))
                {
                    cmdDelete.Parameters.AddWithValue("@id_agent", idAgent);
                    int rows = cmdDelete.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Aucun agent supprimé (ID introuvable).");
                }
            }
            catch (Exception ex)
            {
                // Selon votre usage, vous pouvez remonter l'exception ou afficher le message ici.
                MessageBox.Show("Erreur lors de la suppression de l'agent : " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public static void Rechercher(MySqlConnection connection, DataGridView dgv, string motCle)
        {
            try
            {
                connection.Open();

                string sql = @"
            SELECT id_agent, nom, prenom, contact
            FROM Agent
            WHERE id_agent LIKE @motCle 
                OR nom LIKE @motCle 
                OR prenom LIKE @motCle 
                OR contact LIKE @motCle;
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
                            DataPropertyName = "id_agent",
                            HeaderText = "ID Agent",
                            Name = "id_agent"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "nom",
                            HeaderText = "Nom",
                            Name = "nom"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "prenom",
                            HeaderText = "Prénom",
                            Name = "prenom"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "contact",
                            HeaderText = "Contact",
                            Name = "contact"
                        });

                        dgv.DataSource = table;
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

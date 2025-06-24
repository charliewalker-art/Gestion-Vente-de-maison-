using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace VenteMaison
{
    public class Client : Table
    {
        public Client(MySqlConnection connection)
            : base(
                connection,
                "Client",
                // On enlève "id_client" de la liste des colonnes,
                // et on déclare "CIN" comme clé primaire
                new List<string> { "CIN", "nom", "prenom", "contact", "adresse", "date_inscription" },
                "CIN" // <-- CIN est maintenant PK
              )
        {
        }

        // Méthode pour ajouter un client (il faut fournir le CIN dans le Dictionary)
        public void Inserer(Dictionary<string, object> data)
        {
            try
            {
                connection.Open();

                // Colonnes dynamiques (ici CIN doit impérativement être présent dans data.Keys)
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
                        MessageBox.Show("Client ajouté avec succès !");
                    else
                        MessageBox.Show("Aucune ligne ajoutée.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'ajout client : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Pas besoin de générer un id_client auto ; CIN est désormais fourni par l'utilisateur,
        // donc on peut supprimer ou commenter GenererIdClient si on ne l'utilise plus.

        // Affichage dans le DataGridView, sans jamais exposer un id auto
        public static void AfficherClients(MySqlConnection connection, DataGridView dgv)
        {
            try
            {
                connection.Open();
                string sql = @"
                    SELECT CIN, nom, prenom, contact, adresse, date_inscription
                    FROM Client;
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
                        DataPropertyName = "CIN",
                        HeaderText = "Numéro CIN",
                        Name = "CIN"
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
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "adresse",
                        HeaderText = "Adresse",
                        Name = "adresse"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "date_inscription",
                        HeaderText = "Date d'inscription",
                        Name = "date_inscription"
                    });

                    dgv.DataSource = table;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'affichage : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Mise à jour des données d'un client identifié par son CIN
        public void Modifier(string cin, Dictionary<string, object> data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cin))
                {
                    MessageBox.Show("Le CIN ne peut pas être vide.");
                    return;
                }

                connection.Open();

                // Construire dynamiquement la clause SET
                // Ex. => "nom = @nom, prenom = @prenom, contact = @contact"
                string setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));

                // On modifie en WHERE CIN = @CIN
                string sql = $"UPDATE {tableName} SET {setClause} WHERE CIN = @CIN;";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    foreach (var pair in data)
                    {
                        cmd.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                    }
                    cmd.Parameters.AddWithValue("@CIN", cin);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Client modifié avec succès !");
                    else
                        MessageBox.Show("Aucune modification effectuée (CIN introuvable).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Suppression directe par CIN (plus besoin de chercher id_client)
        public static void SupprimerParCIN(MySqlConnection connection, string cin)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cin))
                    throw new Exception("Le CIN fourni est vide ou invalide.");

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string queryDelete = "DELETE FROM Client WHERE CIN = @CIN;";
                using (var cmdDelete = new MySqlCommand(queryDelete, connection))
                {
                    cmdDelete.Parameters.AddWithValue("@CIN", cin);
                    int rows = cmdDelete.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Aucun client supprimé (CIN introuvable).");
                }
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
            SELECT CIN, nom, prenom, contact, adresse, date_inscription
            FROM Client
            WHERE CIN LIKE @motCle 
                OR nom LIKE @motCle 
                OR prenom LIKE @motCle 
                OR contact LIKE @motCle 
                OR adresse LIKE @motCle;
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
                            DataPropertyName = "CIN",
                            HeaderText = "Numéro CIN",
                            Name = "CIN"
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
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "adresse",
                            HeaderText = "Adresse",
                            Name = "adresse"
                        });
                        dgv.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "date_inscription",
                            HeaderText = "Date d'inscription",
                            Name = "date_inscription"
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

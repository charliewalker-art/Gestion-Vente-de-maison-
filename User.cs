using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VenteMaison
{
    public class User : Table
    {
        public User(MySqlConnection connection)
            : base(
                  connection,
                  "user",
                  new List<string> { "id_user", "nom", "type", "password" },
                  "id_user"
              )
        {
        }
        public bool InsererUser(string nom, string type, string password)
        {
            try
            {
                string query = "INSERT INTO user (nom, type, password) VALUES (@nom, @type, @password)";
                using (MySqlCommand cmd = new MySqlCommand(query, this.connection))
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@password", password);

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'insertion de l'utilisateur : " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public static void AfficherUsers(MySqlConnection connection, DataGridView dgv)
        {
            try
            {
                connection.Open();
                string sql = @"
            SELECT id_user, nom, type
            FROM user;
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
                        DataPropertyName = "id_user",
                        HeaderText = "ID Utilisateur",
                        Name = "id_user"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "nom",
                        HeaderText = "Nom",
                        Name = "nom"
                    });
                    dgv.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "type",
                        HeaderText = "Type",
                        Name = "type"
                    });


                    dgv.DataSource = table;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'affichage des utilisateurs : " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }


        public bool SupprimerUser(int idUser)
        {
            try
            {
                string sql = "DELETE FROM user WHERE id_user = @id_user";
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    cmd.Parameters.AddWithValue("@id_user", idUser);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de l'utilisateur : " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

    }
}

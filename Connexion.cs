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
    public partial class Connexion: Form
    {
        public Connexion()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;
            Style style = new Style();
            style.StyliserBouton(btnconnexion);
            style.AppliquerStyleH1(label1);

        }

        private void btnconnexion_Click(object sender, EventArgs e)
        {
            string nom = txtnom.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            string connStr = Configuration.GetConnexion();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT * FROM user WHERE nom = @nom AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", nom);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read(); // Lire la première ligne
                                string type = reader["type"].ToString();

                              //  MessageBox.Show("Connexion réussie ! Type : " + type);

                                // Redirection selon le type
                                if (type == "user_simple")
                                {
                                    Form1 accueil = new Form1();
                                    accueil.Show();
                                }
                                else if (type == "admin")
                                {
                                    UserForm adminForm = new UserForm();
                                    adminForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Type d'utilisateur inconnu.");
                                    return;
                                }

                                this.Hide(); // Masquer le formulaire de connexion
                            }
                            else
                            {
                                MessageBox.Show("Nom ou mot de passe incorrect.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }



    }
}


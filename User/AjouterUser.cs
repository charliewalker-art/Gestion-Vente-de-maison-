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
    public partial class AjouterUser : Form
    {
        private MySqlConnection connection;
        private User userTable;

        public AjouterUser()
        {
            InitializeComponent();
            charge_choxi_combox();

            string connStr = Configuration.GetConnexion();
            connection = new MySqlConnection(connStr);
            userTable = new User(connection);
        }

        private void charge_choxi_combox()
        {
            comboBoxchoix_user.Items.Clear();
            comboBoxchoix_user.Items.Add("user_simple");
            comboBoxchoix_user.Items.Add("admin");
            comboBoxchoix_user.SelectedIndex = 0;
        }

        private void btn_AjouterUser_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtnom.Text.Trim();
                string type_user = comboBoxchoix_user.SelectedItem?.ToString();
                string password = txtpassword.Text.Trim();

                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(type_user) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Veuillez remplir tous les champs.");
                    return;
                }

                bool success = userTable.InsererUser(nom, type_user, password);
                if (success)
                    MessageBox.Show("Utilisateur ajouté avec succès !");
                else
                    MessageBox.Show("Erreur lors de l'ajout de l'utilisateur.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    

}
}

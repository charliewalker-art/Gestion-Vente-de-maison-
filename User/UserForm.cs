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
    public partial class UserForm: Form
    {
        public UserForm()
        {
            InitializeComponent();
            Affiche_User();
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            //style
            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);

            style.StyliserBouton(btnshowbtnajouter);
            style.StyliserBouton(button1);
            style.AppliquerStyleH1(labme);

        }
        public void Affiche_User()
        {
            try
            {
                string connectionString = Configuration.GetConnexion();
                using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Vider les colonnes pour éviter les duplications éventuelles
                    dataGridView1.Columns.Clear();

                    // Appeler la méthode d'affichage qui remplit automatiquement les colonnes
                    User.AfficherUsers(connection, dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        
        }

        private void btnshowbtnajouter_Click(object sender, EventArgs e)
        {
            {
                AjouterUser user_ajouter = new AjouterUser();
                user_ajouter.StartPosition = FormStartPosition.CenterParent;
                user_ajouter.Owner = this;


                user_ajouter.ShowDialog();
                Affiche_User();
            }
        }





          private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idUser = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_user"].Value);

                DialogResult confirmation = MessageBox.Show(
                    "Voulez-vous vraiment supprimer cet utilisateur ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmation == DialogResult.Yes)
                {
                    string connStr = Configuration.GetConnexion();
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        User userTable = new User(conn);
                        bool success = userTable.SupprimerUser(idUser);

                        if (success)
                        {
                            MessageBox.Show("Utilisateur supprimé avec succès !");
                            User.AfficherUsers(conn, dataGridView1); // Rafraîchir le DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Échec de la suppression de l'utilisateur.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form_acuille = new Form1();
            form_acuille.StartPosition = FormStartPosition.CenterParent;
            form_acuille.Owner = this;


            form_acuille.ShowDialog();
           

        }
    }
}

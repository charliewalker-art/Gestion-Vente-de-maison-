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
    public partial class AjouterPaiment: Form

    {
        private readonly string _cs = Configuration.GetConnexion();
        public AjouterPaiment()
        {
            InitializeComponent();
            //appel la fonction charge  idvent
            charge_id_vente();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void charge_id_vente()
        {
            {
                // On efface d'abord les éléments déjà présents
                comboBoxidvente.Items.Clear();

                try
                {
                    using (var con = new MySqlConnection(_cs))
                    {
                        con.Open();
                        // Exemple : on récupère les IDs de maison (ou contrat selon votre besoin)
                        string sql = "SELECT id_vente FROM vente;";
                        using (var cmd = new MySqlCommand(sql, con))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string idMaison = reader.GetString("id_vente");
                                comboBoxidvente.Items.Add(idMaison);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur lors du chargement des ID de maison :\n" + ex.Message,
                        "Erreur de chargement",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        public void Affichage_Paiment()
        {

        }


        private void btn_ajouter_paiment_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(_cs))
            {
                try
                {
                    conn.Open();

                    // 1. Récupération de l'ID de vente depuis la comboBox
                    string idVente = comboBoxidvente.Text.Trim();
                    if (string.IsNullOrEmpty(idVente))
                    {
                        MessageBox.Show("Veuillez sélectionner une vente.");
                        return;
                    }

                    // 2. Instanciation de l'objet Paiment
                    Paiment paiment = new Paiment(conn);

                    // 3. Génération d’un nouvel ID paiement
                    string idPaiement = paiment.GenererIdPaiement();

                    // 4. Date du jour
                    string datePaiement = DateTime.Now.ToString("yyyy-MM-dd");

                    // 5. Insertion dans la table Paiement
                    string insertPaiement = "INSERT INTO Paiement (id_paiement, id_vente, date_paiement) VALUES (@id, @vente, @date);";
                    using (MySqlCommand cmdInsert = new MySqlCommand(insertPaiement, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@id", idPaiement);
                        cmdInsert.Parameters.AddWithValue("@vente", idVente);
                        cmdInsert.Parameters.AddWithValue("@date", datePaiement);
                        cmdInsert.ExecuteNonQuery();
                    }

                    // 6. Mettre à jour le statut de la vente à 'paye'
                    string updateVente = "UPDATE Vente SET statut = 'paye' WHERE id_vente = @vente;";
                    using (MySqlCommand cmdUpdateVente = new MySqlCommand(updateVente, conn))
                    {
                        cmdUpdateVente.Parameters.AddWithValue("@vente", idVente);
                        cmdUpdateVente.ExecuteNonQuery();
                    }

                    // 7. Récupérer l'id_contrat depuis la vente
                    string idContrat = "";
                    string getContrat = "SELECT id_contrat FROM Vente WHERE id_vente = @vente;";
                    using (MySqlCommand cmdContrat = new MySqlCommand(getContrat, conn))
                    {
                        cmdContrat.Parameters.AddWithValue("@vente", idVente);
                        object result = cmdContrat.ExecuteScalar();
                        if (result != null)
                            idContrat = result.ToString();
                    }

                    if (!string.IsNullOrEmpty(idContrat))
                    {
                        // 8. Récupérer l'id_maison depuis le contrat
                        string idMaison = "";
                        string getMaison = "SELECT id_maison FROM Contrat WHERE id_contrat = @contrat;";
                        using (MySqlCommand cmdMaison = new MySqlCommand(getMaison, conn))
                        {
                            cmdMaison.Parameters.AddWithValue("@contrat", idContrat);
                            object result = cmdMaison.ExecuteScalar();
                            if (result != null)
                                idMaison = result.ToString();
                        }

                        if (!string.IsNullOrEmpty(idMaison))
                        {
                            // 9. Mettre à jour le statut de la maison à 'vendue'
                            string updateMaison = "UPDATE Maison SET statut = 'vendue' WHERE id_maison = @maison;";
                            using (MySqlCommand cmdUpdateMaison = new MySqlCommand(updateMaison, conn))
                            {
                                cmdUpdateMaison.Parameters.AddWithValue("@maison", idMaison);
                                cmdUpdateMaison.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Paiement enregistré avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }




    }
}

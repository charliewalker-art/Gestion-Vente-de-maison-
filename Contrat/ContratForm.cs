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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace VenteMaison
{
    public partial class ContratForm: Form
    {
        public ContratForm()
        {
            InitializeComponent();
            Affiche_Contrat();
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

            //style
            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);

            style.AppliquerStyleH1(Title);


            style.StyliserBouton(btngenerepdf);
            style.StyliserBouton(Ajoutercontratbox);
            style.StyliserBouton(btnmodifierdialog);


        }
        //fonction affiche contrat
        public void Affiche_Contrat()
        {
            try
            {
                string connectionString = Configuration.GetConnexion();
                using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Vider les colonnes pour éviter les duplications éventuelles
                    dataGridView1.Columns.Clear();

                    // Appeler la méthode d'affichage qui remplit automatiquement les colonnes
                    Contrat.AfficherContrats(connection, dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void Ajoutercontratbox_Click(object sender, EventArgs e)
        {
            AjouterContrat contrat_ajouter = new AjouterContrat();
            contrat_ajouter.StartPosition = FormStartPosition.CenterParent;
            contrat_ajouter.Owner = this;


            contrat_ajouter.ShowDialog();
            Affiche_Contrat();
        }



        private void suppiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           try
            {
                // 1) Vérifier qu’une ligne est sélectionnée
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un contrat à supprimer.", "Aucun contrat sélectionné", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2) Récupérer l'ID du contrat (colonne "id_contrat") dans la ligne sélectionnée
                DataGridViewRow ligne = dataGridView1.SelectedRows[0];
                object valeurId = ligne.Cells["id_contrat"].Value;
                if (valeurId == null)
                {
                    MessageBox.Show("L'ID du contrat est vide ou invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string idContrat = valeurId.ToString();

                // 3) Confirmation de la suppression
                DialogResult reponse = MessageBox.Show(
                    $"Voulez‑vous vraiment supprimer le contrat d’ID « {idContrat} » ?",
                    "Confirmation suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (reponse != DialogResult.Yes)
                    return;

                // 4) Connexion à la base et appel de la méthode SupprimerParId
                string connectionString = Configuration.GetConnexion();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Contrat contratModel = new Contrat(connection);
                    contratModel.SupprimerParId_contrat(idContrat);
                }

                // 5) Message de succès et rafraîchissement du DataGridView
                MessageBox.Show("Contrat supprimé avec succès.", "Supprimé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Contrat.AfficherContrats(new MySqlConnection(Configuration.GetConnexion()), dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du contrat : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        

     
        //fonction modifeir
       private void btnmodifierdialog_Click(object sender, EventArgs e)
        {
            ContratModifier contrat_modifier = new ContratModifier();
            contrat_modifier.StartPosition = FormStartPosition.CenterParent;
            contrat_modifier.Owner = this;


            contrat_modifier.ShowDialog();
            Affiche_Contrat();
        }

        private void btngenerepdf_Click(object sender, EventArgs e)
        {
            string idContrat = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(idContrat))
            {
                MessageBox.Show("Veuillez entrer un ID de contrat.");
                return;
            }

            string connectionString = Configuration.GetConnexion();

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
SELECT c.id_contrat, c.date_du_contrat, c.montant, c.statut,
       cl.nom, cl.prenom, cl.adresse,
       m.adresse AS maison_adresse, m.quartier, m.surface, m.prix_initial
FROM Contrat c
JOIN Client cl ON c.CIN = cl.CIN
JOIN Maison m ON c.id_maison = m.id_maison
WHERE c.id_contrat = @id_contrat";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_contrat", idContrat);

                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nom = reader["nom"].ToString();
                                    string prenom = reader["prenom"].ToString();
                                    string adresse = reader["adresse"].ToString();

                                    string adresseMaison = reader["maison_adresse"].ToString();
                                    string quartier = reader["quartier"].ToString();
                                    string superficie = reader["surface"].ToString();
                                    string prix = reader["prix_initial"].ToString();

                                    string dateContrat = Convert.ToDateTime(reader["date_du_contrat"]).ToString("dd/MM/yyyy");
                                    string montant = reader["montant"].ToString();
                                    string statut = reader["statut"].ToString();

                                    string texteContrat = $@"
CONTRAT DE VENTE DE MAISON

Je soussigné(e), {nom} {prenom}, demeurant à {adresse},
atteste avoir signé un contrat le {dateContrat} pour l'achat de la maison située à :

Adresse : {adresseMaison}
Quartier : {quartier}
Superficie : {superficie} m²
Prix initial : {prix} Ar

Le montant total du contrat s'élève à : {montant} Ar.
Statut du contrat : {statut.ToUpper()}

Fait à __________________________, le {dateContrat}.

Signature du client : _____________________________
Signature de l'agence : ___________________________";

                                    try
                                    {
                                        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Contrat_{idContrat}.pdf");
                                        Document doc = new Document();
                                        PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                                        doc.Open();
                                        iTextSharp.text.Font police = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);
                                        doc.Add(new Paragraph(texteContrat, police));
                                        doc.Close();

                                        MessageBox.Show("Contrat PDF généré sur le bureau.");
                                    }
                                    catch (Exception exPdf)
                                    {
                                        MessageBox.Show("Erreur lors de la génération du PDF : " + exPdf.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Contrat non trouvé.");
                                }
                            }
                        }
                        catch (Exception exReader)
                        {
                            MessageBox.Show("Erreur lors de la lecture des données : " + exReader.Message);
                        }
                    }
                }
            }
            catch (Exception exDb)
            {
                MessageBox.Show("Erreur de connexion ou de requête SQL : " + exDb.Message);
            }
        }



    }
}

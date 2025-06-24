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
using System.Windows.Forms.DataVisualization.Charting;

namespace VenteMaison
{
    public partial class Stat: Form
    {
        public Stat()
        {
            InitializeComponent();

            Style style = new Style();
            style.AppliquerStyleTableau(dataGridView1);
            style.AppliquerStyleH1(label2);
            style.StyliserBouton(affiche_result_mois);
            style.AppliquerStyleH1(label1);
        }


        private void affiche_result_mois_Click(object sender, EventArgs e)
        {
            // Récupérer le texte du mois
            string moisTexte = txtcheckmois.Text.Trim();

            // Vérifier que c'est un nombre valide (1 à 12)
            if (!int.TryParse(moisTexte, out int mois) || mois < 1 || mois > 12)
            {
                MessageBox.Show("Veuillez entrer un numéro de mois valide (1 à 12).");
                return;
            }

            // Appeler la méthode Affiche avec le mois
            Affiche(mois);
        }

        // Méthode pour afficher les résultats dans dataGridView1
        public void Affiche(int mois)
        {
            string connStr = "server=localhost;user=root;database=gestion_maison;password=;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT 
                a.id_agent,
                a.nom,
                a.prenom,
                COUNT(c.id_contrat) AS nombre_contrats,
                SUM(c.montant) AS montant_total
            FROM Agent a
            JOIN Contrat c ON a.id_agent = c.id_agent
            JOIN Vente v ON v.id_contrat = c.id_contrat
            WHERE v.statut = 'paye' AND MONTH(v.date_vente) = @mois
            GROUP BY a.id_agent, a.nom, a.prenom
            ORDER BY montant_total DESC;
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mois", mois);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Afficher dans le tableau
                dataGridView1.DataSource = dt;

                // Maintenant on prépare le graphique
                chart1.Series.Clear();

                // Créer une série (colonne, histogramme)
                Series serieMontant = new Series("Montant total");
                serieMontant.ChartType = SeriesChartType.Column;

                // On peut aussi créer une autre série pour nombre de contrats, si tu veux
                // Series serieNbContrats = new Series("Nombre de contrats");
                // serieNbContrats.ChartType = SeriesChartType.Column;

                foreach (DataRow row in dt.Rows)
                {
                    string agentNom = row["nom"].ToString() + " " + row["prenom"].ToString();
                    int montant = Convert.ToInt32(row["montant_total"]);
                    // int nbContrats = Convert.ToInt32(row["nombre_contrats"]);

                    serieMontant.Points.AddXY(agentNom, montant);
                    // serieNbContrats.Points.AddXY(agentNom, nbContrats);
                }

                chart1.Series.Add(serieMontant);
                // chart1.Series.Add(serieNbContrats);

                // Configurer les axes
                chart1.ChartAreas[0].AxisX.Title = "Agents";
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Pour éviter chevauchement
                chart1.ChartAreas[0].AxisX.Interval = 1;

                chart1.ChartAreas[0].AxisY.Title = "Montant total";

                chart1.Invalidate(); // Rafraîchir le graphique
            }
        }


    }
}

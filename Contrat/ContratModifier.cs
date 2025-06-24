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
    public partial class ContratModifier: Form
    {
        public ContratModifier()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void Modifiercontrat_Click(object sender, EventArgs e)
        {
            // 1) Récupération des saisies utilisateur
            string id_contrat = txtcontrat.Text.Trim();
            string montantTexte = txtmontant.Text.Trim();
            DateTime nouvelleDateContrat = dateducontrat.Value.Date;

            // 2) Vérification minimale
            if (string.IsNullOrEmpty(id_contrat))
            {
                MessageBox.Show(
                    "Veuillez renseigner l’ID du contrat à modifier.",
                    "Champs manquant",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!int.TryParse(montantTexte, out int nouveauMontant))
            {
                MessageBox.Show(
                    "Le montant saisi n’est pas un entier valide.",
                    "Erreur de saisie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            try
            {
                // 3) On crée une connexion, on instancie le modèle Contrat et on appelle la méthode de modification
                using (var con = new MySqlConnection(Configuration.GetConnexion()))
                {
                    var contratModel = new Contrat(con);
                    contratModel.ModifierContrat(
                        idContrat: id_contrat,
                        nouveauMontant: nouveauMontant,
                        nouvelleDateContrat: nouvelleDateContrat
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue lors de la tentative de modification :\n" + ex.Message,
                    "Erreur inattendue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }



    }
}

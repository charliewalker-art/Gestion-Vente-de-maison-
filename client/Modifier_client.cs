using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VenteMaison
{
    public partial class Modifier_client : Form
    {
        // Constructeur par défaut (laisse intact vos InitializeComponent, etc.)
        public Modifier_client()
        {
            InitializeComponent();
        }

        // Nouveau constructeur surchargé pour préremplir les champs
        public Modifier_client(
            string cin,
            string nom,
            string prenom,
            string contact,
            string adresse)
        {
            InitializeComponent();

            // Affecter immédiatement les TextBox avec les valeurs passées en paramètre
            txt_modifier_CIN.Text = cin;
            txt_modifier_nom.Text = nom;
            txt_modifier_prenom.Text = prenom;
            txt_modifier_contact.Text = contact;
            txt_modifier_adresse.Text = adresse;


        }

        private void label3_Click(object sender, EventArgs e)
        {
            // (Évènement inutile si non utilisé, on peut laisser vide)
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // (Évènement inutile si non utilisé, on peut laisser vide)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Fermeture du formulaire (bouton « Annuler » ou « Fermer »)
            this.Close();
        }

        private void modifier2client_Click(object sender, EventArgs e)
        {
            // On récupère les valeurs actuelles dans les TextBox (déjà préremplies)
            string cin = txt_modifier_CIN.Text.Trim();
            string nom = txt_modifier_nom.Text.Trim();
            string prenom = txt_modifier_prenom.Text.Trim();
            string contact = txt_modifier_contact.Text.Trim();
            string adresse = txt_modifier_adresse.Text.Trim();

            if (string.IsNullOrEmpty(cin))
            {
                MessageBox.Show(
                    "Veuillez entrer le CIN du client à modifier.",
                    "CIN manquant",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Préparer les champs à modifier seulement s'ils ne sont pas vides
            var dataToUpdate = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(nom)) dataToUpdate["nom"] = nom;
            if (!string.IsNullOrEmpty(prenom)) dataToUpdate["prenom"] = prenom;
            if (!string.IsNullOrEmpty(contact)) dataToUpdate["contact"] = contact;
            if (!string.IsNullOrEmpty(adresse)) dataToUpdate["adresse"] = adresse;

            if (dataToUpdate.Count == 0)
            {
                MessageBox.Show(
                    "Aucune donnée à modifier.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            try
            {
                string connStr = Configuration.GetConnexion();
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Vérifier que le client existe bien dans la base
                    string checkSql = "SELECT COUNT(*) FROM Client WHERE CIN = @cin";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@cin", cin);
                        long count = (long)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show(
                                "Aucun client trouvé avec ce CIN.",
                                "Client introuvable",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return;
                        }
                    }

                    // Construire dynamiquement la requête UPDATE en fonction des champs fournis
                    List<string> setClauses = new List<string>();
                    foreach (var entry in dataToUpdate)
                    {
                        setClauses.Add($"{entry.Key} = @{entry.Key}");
                    }

                    string updateSql = $"UPDATE Client SET {string.Join(", ", setClauses)} WHERE CIN = @cin";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateSql, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@cin", cin);
                        foreach (var entry in dataToUpdate)
                        {
                            updateCmd.Parameters.AddWithValue($"@{entry.Key}", entry.Value);
                        }

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Client modifié avec succès.",
                                "Succès",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                "La modification a échoué. Aucune ligne affectée.",
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            // Fermer le formulaire une fois la mise à jour réalisée
            this.Close();
        }
    }
}

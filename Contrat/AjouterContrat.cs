using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VenteMaison
{
    public partial class AjouterContrat : Form
    {
        private readonly string _cs = Configuration.GetConnexion();

        
   //     private readonly Timer _tMaison, _tClient, _tAgent;

        public AjouterContrat()
        {
            InitializeComponent();
            Loud_charge();



        }
        public void Loud_charge()
        {
            charge_CIN();
            charge_id_agent();
            charge_id_maison();

        }
        public void charge_CIN()
        {
            comboBoxidCINclient.Items.Clear();

            try
            {
                using (var con = new MySqlConnection(_cs))
                {
                    con.Open();

                    string sql = "SELECT CIN FROM Client;";
                    using (var cmd = new MySqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // On suppose que la colonne CIN est de type VARCHAR
                            string cin = reader.GetString("CIN");
                            comboBoxidCINclient.Items.Add(cin);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des CIN :\n" + ex.Message,
                    "Erreur de chargement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void charge_id_maison()
        {
            comboBoxidmaison.Items.Clear();

            try
            {
                using (var con = new MySqlConnection(_cs))
                {
                    con.Open();

                    string sql = "SELECT id_maison FROM Maison;";
                    using (var cmd = new MySqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string idMaison = reader.GetString("id_maison");
                            comboBoxidmaison.Items.Add(idMaison);
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
        public void charge_id_agent()
        {
            comboBoxidAgent.Items.Clear();

            try
            {
                using (var con = new MySqlConnection(_cs))
                {
                    con.Open();

                    string sql = "SELECT id_agent FROM Agent;";
                    using (var cmd = new MySqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string idAgent = reader.GetString("id_agent");
                            comboBoxidAgent.Items.Add(idAgent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des ID d’agent :\n" + ex.Message,
                    "Erreur de chargement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }









        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void Ajouterrcontrat_Click(object sender, EventArgs e)
        {
            // 1) Récupération des saisies utilisateur
            string id_maison = comboBoxidmaison.Text.Trim();
            string CIN = comboBoxidCINclient.Text.Trim();
            string id_agent = comboBoxidAgent.Text.Trim();
            string montantTexte = txtmontant.Text.Trim();

            // 2) Vérification minimale des champs obligatoires
            if (string.IsNullOrEmpty(id_maison) ||
                string.IsNullOrEmpty(CIN) ||
                string.IsNullOrEmpty(id_agent))
            {
                MessageBox.Show(
                    "Veuillez sélectionner une maison, un client et un agent.",
                    "Champs manquants",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                // 3) Ouverture de la connexion
                string connStr = Configuration.GetConnexion();
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();

                    // ★ NOUVELLE ÉTAPE : vérifier que la maison est bien 'disponible'
                    using (var cmdStatut = new MySqlCommand(
                        "SELECT statut FROM Maison WHERE id_maison = @idMaison", con))
                    {
                        cmdStatut.Parameters.AddWithValue("@idMaison", id_maison);
                        object statObj = cmdStatut.ExecuteScalar();
                        if (statObj == null)
                        {
                            MessageBox.Show(
                                $"Aucune maison trouvée pour l’ID '{id_maison}'.",
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return;
                        }

                        string statutMaison = statObj.ToString();
                        if (!statutMaison.Equals("disponible", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show(
                                $"La maison n'est plus disponible (statut actuel : {statutMaison}).",
                                "Maison indisponible",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            return;
                        }
                    }

                    // 4) Génération du nouvel ID de contrat
                    string id_contrat = GetNextIdContrat();

                    // 5) Calcul du montant à insérer :
                    //    - Si txtmontant est vide, on récupère prix_initial depuis Maison
                    //    - Sinon, on parse la valeur saisie
                    int montantFinal;
                    if (string.IsNullOrEmpty(montantTexte))
                    {
                        using (var cmdPrix = new MySqlCommand(
                            "SELECT prix_initial FROM Maison WHERE id_maison = @idMaison",
                            con))
                        {
                            cmdPrix.Parameters.AddWithValue("@idMaison", id_maison);
                            object result = cmdPrix.ExecuteScalar();
                            montantFinal = Convert.ToInt32(result);
                        }
                    }
                    else
                    {
                        if (!int.TryParse(montantTexte, out montantFinal))
                        {
                            MessageBox.Show(
                                "Le montant saisi n’est pas un entier valide.",
                                "Erreur de saisie",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return;
                        }
                    }

                    // 6) Insertion du nouveau contrat dans la table Contrat
                    using (var cmdInsert = new MySqlCommand(
                        @"INSERT INTO Contrat
                  (id_contrat, id_maison, CIN, id_agent, date_du_contrat, montant, statut)
                  VALUES
                  (@idContrat, @idMaison, @cin, @idAgent, @dateSig, @montant, 'promesse')",
                        con))
                    {
                        cmdInsert.Parameters.AddWithValue("@idContrat", id_contrat);
                        cmdInsert.Parameters.AddWithValue("@idMaison", id_maison);
                        cmdInsert.Parameters.AddWithValue("@cin", CIN);
                        cmdInsert.Parameters.AddWithValue("@idAgent", id_agent);
                        cmdInsert.Parameters.AddWithValue("@dateSig", DateTime.Now.Date);
                        cmdInsert.Parameters.AddWithValue("@montant", montantFinal);

                        cmdInsert.ExecuteNonQuery();
                    }

                    // 7) Mise à jour du statut de la maison en 'reservée'
                    using (var cmdUpdateMaison = new MySqlCommand(
                        "UPDATE Maison SET statut = 'reservée' WHERE id_maison = @idMaison",
                        con))
                    {
                        cmdUpdateMaison.Parameters.AddWithValue("@idMaison", id_maison);
                        cmdUpdateMaison.ExecuteNonQuery();
                    }

                    // 8) Message de confirmation à l’utilisateur
                    MessageBox.Show(
                        $"Le contrat (ID = {id_contrat}) a été créé avec succès.\n" +
                        $"Montant = {montantFinal} AR\n" +
                        $"La maison '{id_maison}' est désormais réservée.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show(
                    "Une erreur est survenue lors de l’accès à la base de données :\n" +
                    sqlEx.Message,
                    "Erreur MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur inattendue est survenue :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        //fonction genere id
        private string GetNextIdContrat()
        {
            try
            {
                string prochaineId = "CONTR001";

                using (var con = new MySqlConnection(_cs))
                {
                    con.Open();

                    // On récupère le plus grand id_contrat déjà présent dans la table Contrat
                    string sqlMax = "SELECT MAX(id_contrat) FROM Contrat;";
                    using (var cmd = new MySqlCommand(sqlMax, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string idMax = result.ToString(); // ex. "CONTR017"
                                                              // Vérifier que la chaîne commence bien par "CONTR" et contient au moins 8 caractères (5 pour "CONTR" + 3 chiffres)
                            if (idMax.StartsWith("CONTR") && idMax.Length >= 8)
                            {
                                // EXTRAIRE la partie numérique après "CONTR"
                                // Il faut sauter les 5 premiers caractères : Substring(5)
                                string numericPart = idMax.Substring(5); // ex. "017"
                                if (int.TryParse(numericPart, out int valeur))
                                {
                                    int suivant = valeur + 1;
                                    // Reformater en 3 chiffres (ex. 18 → "018")
                                    string nextNumeric = suivant.ToString("D3");
                                    prochaineId = "CONTR" + nextNumeric;
                                }
                            }
                        }
                    }
                }

                return prochaineId;
            }
            catch
            {
                // En cas d’erreur (connexion, parse, etc.), on renvoie "CONTR001" par défaut
                return "CONTR001";
            }
        }
    }


}


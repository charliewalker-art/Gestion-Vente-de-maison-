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
    public partial class ModifierAgent : Form
    {
        // CONSTRUCTEUR PAR DÉFAUT
        public ModifierAgent()
        {
            InitializeComponent();

          
        }

        // NOUVEAU CONSTRUCTEUR POUR PRÉREMPLIR L’AGENT
        public ModifierAgent(string id_agent, string nom, string prenom, string contact)
        {
            InitializeComponent();

            // Remplir les TextBox avec les valeurs reçues
            txtidagent.Text = id_agent;
            txtnom.Text = nom;
            txtprenom.Text = prenom;
            txtcontact.Text = contact;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifierAgents_Click(object sender, EventArgs e)
        {
          
            // À ce stade, txtidagent, txtnom, txtprenom, txtcontact sont déjà préremplis à l'ouverture
            string id_agent = txtidagent.Text.Trim();
            string nom = txtnom.Text.Trim();
            string prenom = txtprenom.Text.Trim();
            string contact = txtcontact.Text.Trim();

            if (string.IsNullOrEmpty(id_agent))
            {
                MessageBox.Show("Veuillez entrer un ID d'agent.");
                return;
            }

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(contact))
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
                return;
            }

            var data = new Dictionary<string, object>
            {
                { "nom", nom },
                { "prenom", prenom },
                { "contact", contact }
            };

            string connStr = Configuration.GetConnexion();
            using (var connection = new MySqlConnection(connStr))
            {
                Agent agent = new Agent(connection);
                agent.Modifier(id_agent, data);
            }

           
        }
    }
}

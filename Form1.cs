using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VenteMaison
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Application des styles
      
            StyliserHeader(Menu);      
            StyliserButton(Affiche_Agent);    
            StyliserButton(Affiche_Client);
            StyliserButton(Affiche_Contrat);
            StyliserButton(Affiche_Maison);
            StyliserButton(Affiche_paiment);
            StyliserButton(Affiche_Vente);


            StyliserButton(Affichage_Resutlt);
            //
            Affich();


        }

        public void StyliserButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(25, 42, 86); // Bleu profond
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
                GraphicsPath path = GetRoundedRectPath(rect, 6); // Coins arrondis doux
                btn.Region = new Region(path);
            };

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(36, 60, 120);
                btn.Cursor = Cursors.Hand;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(25, 42, 86);
                btn.Cursor = Cursors.Default;
            };
        }

        public void StyliserHeader(Panel panel)
        {
            // Juste style visuel sans toucher à la taille ou au Dock
            panel.BackColor = Color.FromArgb(25, 42, 86); // Bleu profond
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Si tu veux une légère ombre ou un effet visuel tu peux ajouter un Padding ou une ligne en bas
        }




        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r = radius * 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void Affiche_Client_Click(object sender, EventArgs e)
        {
            // Vider le panel d'abord
            contener.Controls.Clear();

            // Créer une instance du formulaire ClientForm
            ClientForm clientForm = new ClientForm();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            clientForm.TopLevel = false;
            clientForm.FormBorderStyle = FormBorderStyle.None;
            clientForm.Dock = DockStyle.Fill;
            

            // L’ajouter au panel
            contener.Controls.Add(clientForm);
            clientForm.Show();
        }

        private void Affiche_Maison_Click(object sender, EventArgs e)
        {
            // Vider le panel d'abord
            contener.Controls.Clear();

            
            MaisonForm Maison_Form = new MaisonForm();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            Maison_Form.TopLevel = false;
            Maison_Form.FormBorderStyle = FormBorderStyle.None;
            Maison_Form.Dock = DockStyle.Fill;


            // L’ajouter au panel
            contener.Controls.Add(Maison_Form);
            Maison_Form.Show();
        }

        private void Affiche_Agent_Click(object sender, EventArgs e)
        {
            // Vider le panel d'abord
            contener.Controls.Clear();

            // Créer une instance du formulaire ClientForm
            AgentForm Form_Agent = new AgentForm();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            Form_Agent.TopLevel = false;
            Form_Agent.FormBorderStyle = FormBorderStyle.None;
            Form_Agent.Dock = DockStyle.Fill;


            // L’ajouter au panel
            contener.Controls.Add(Form_Agent);
            Form_Agent.Show();
        }

        private void Affiche_Contrat_Click(object sender, EventArgs e)
        {
            // Vider le panel d'abord
            contener.Controls.Clear();

            // Créer une instance du formulaire ClientForm
            ContratForm Form_Contrat = new ContratForm();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            Form_Contrat.TopLevel = false;
            Form_Contrat.FormBorderStyle = FormBorderStyle.None;
            Form_Contrat.Dock = DockStyle.Fill;


            // L’ajouter au panel
            contener.Controls.Add(Form_Contrat);
            Form_Contrat.Show();
        }

        private void Affiche_Vente_Click(object sender, EventArgs e)
        {
            // Vider le panel d'abord
            contener.Controls.Clear();

            // Créer une instance du formulaire ClientForm
            VenteForm Form_Vente = new VenteForm();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            Form_Vente.TopLevel = false;
            Form_Vente.FormBorderStyle = FormBorderStyle.None;
            Form_Vente.Dock = DockStyle.Fill;


            // L’ajouter au panel
            contener.Controls.Add(Form_Vente);
            Form_Vente.Show();
        }

        private void Affiche_paiment_Click(object sender, EventArgs e)
        {
            // Vider le panel d'abord
            contener.Controls.Clear();

            // Créer une instance du formulaire ClientForm
            PaimentForm Form_Paiment = new PaimentForm();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            Form_Paiment.TopLevel = false;
            Form_Paiment.FormBorderStyle = FormBorderStyle.None;
            Form_Paiment.Dock = DockStyle.Fill;


            // L’ajouter au panel
            contener.Controls.Add(Form_Paiment);
            Form_Paiment.Show();
        }

    public void Affich()
        { // Vider le panel d'abord
            contener.Controls.Clear();

            // Créer une instance du formulaire ClientForm
            ClientForm Form_Client = new ClientForm();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            Form_Client.TopLevel = false;
            Form_Client.FormBorderStyle = FormBorderStyle.None;
            Form_Client.Dock = DockStyle.Fill;


            // L’ajouter au panel
            contener.Controls.Add(Form_Client);
            Form_Client.Show();
        }

        private void Affichage_Resutlt_Click(object sender, EventArgs e)
        {
            // Vider le panel d'abord
            contener.Controls.Clear();

            // Créer une instance du formulaire ClientForm
            Stat Form_Stat = new Stat();

            // Le configurer pour qu’il soit un contrôle enfant et non une nouvelle fenêtre
            Form_Stat.TopLevel = false;
            Form_Stat.FormBorderStyle = FormBorderStyle.None;
            Form_Stat.Dock = DockStyle.Fill;


            // L’ajouter au panel
            contener.Controls.Add(Form_Stat);
            Form_Stat.Show();
        }
    }
   

}

namespace VenteMaison
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.Panel();
            this.Affiche_Agent = new System.Windows.Forms.Button();
            this.Affiche_paiment = new System.Windows.Forms.Button();
            this.Affiche_Vente = new System.Windows.Forms.Button();
            this.Affiche_Contrat = new System.Windows.Forms.Button();
            this.Affiche_Maison = new System.Windows.Forms.Button();
            this.Affiche_Client = new System.Windows.Forms.Button();
            this.contener = new System.Windows.Forms.Panel();
            this.Affichage_Resutlt = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Menu.Controls.Add(this.Affichage_Resutlt);
            this.Menu.Controls.Add(this.Affiche_Agent);
            this.Menu.Controls.Add(this.Affiche_paiment);
            this.Menu.Controls.Add(this.Affiche_Vente);
            this.Menu.Controls.Add(this.Affiche_Contrat);
            this.Menu.Controls.Add(this.Affiche_Maison);
            this.Menu.Controls.Add(this.Affiche_Client);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(122, 667);
            this.Menu.TabIndex = 0;
            // 
            // Affiche_Agent
            // 
            this.Affiche_Agent.Location = new System.Drawing.Point(6, 147);
            this.Affiche_Agent.Name = "Affiche_Agent";
            this.Affiche_Agent.Size = new System.Drawing.Size(110, 45);
            this.Affiche_Agent.TabIndex = 0;
            this.Affiche_Agent.Text = "Agent";
            this.Affiche_Agent.UseVisualStyleBackColor = true;
            this.Affiche_Agent.Click += new System.EventHandler(this.Affiche_Agent_Click);
            // 
            // Affiche_paiment
            // 
            this.Affiche_paiment.Location = new System.Drawing.Point(3, 344);
            this.Affiche_paiment.Name = "Affiche_paiment";
            this.Affiche_paiment.Size = new System.Drawing.Size(119, 50);
            this.Affiche_paiment.TabIndex = 0;
            this.Affiche_paiment.Text = "Paiment";
            this.Affiche_paiment.UseVisualStyleBackColor = true;
            this.Affiche_paiment.Click += new System.EventHandler(this.Affiche_paiment_Click);
            // 
            // Affiche_Vente
            // 
            this.Affiche_Vente.Location = new System.Drawing.Point(6, 283);
            this.Affiche_Vente.Name = "Affiche_Vente";
            this.Affiche_Vente.Size = new System.Drawing.Size(116, 41);
            this.Affiche_Vente.TabIndex = 0;
            this.Affiche_Vente.Text = "Vente";
            this.Affiche_Vente.UseVisualStyleBackColor = true;
            this.Affiche_Vente.Click += new System.EventHandler(this.Affiche_Vente_Click);
            // 
            // Affiche_Contrat
            // 
            this.Affiche_Contrat.Location = new System.Drawing.Point(3, 209);
            this.Affiche_Contrat.Name = "Affiche_Contrat";
            this.Affiche_Contrat.Size = new System.Drawing.Size(119, 49);
            this.Affiche_Contrat.TabIndex = 0;
            this.Affiche_Contrat.Text = "Contrat";
            this.Affiche_Contrat.UseVisualStyleBackColor = true;
            this.Affiche_Contrat.Click += new System.EventHandler(this.Affiche_Contrat_Click);
            // 
            // Affiche_Maison
            // 
            this.Affiche_Maison.Location = new System.Drawing.Point(6, 77);
            this.Affiche_Maison.Name = "Affiche_Maison";
            this.Affiche_Maison.Size = new System.Drawing.Size(116, 45);
            this.Affiche_Maison.TabIndex = 0;
            this.Affiche_Maison.Text = "Maison";
            this.Affiche_Maison.UseVisualStyleBackColor = true;
            this.Affiche_Maison.Click += new System.EventHandler(this.Affiche_Maison_Click);
            // 
            // Affiche_Client
            // 
            this.Affiche_Client.Location = new System.Drawing.Point(3, 12);
            this.Affiche_Client.Name = "Affiche_Client";
            this.Affiche_Client.Size = new System.Drawing.Size(119, 48);
            this.Affiche_Client.TabIndex = 0;
            this.Affiche_Client.Text = "Client";
            this.Affiche_Client.UseVisualStyleBackColor = true;
            this.Affiche_Client.Click += new System.EventHandler(this.Affiche_Client_Click);
            // 
            // contener
            // 
            this.contener.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contener.Location = new System.Drawing.Point(122, 0);
            this.contener.Name = "contener";
            this.contener.Size = new System.Drawing.Size(1346, 788);
            this.contener.TabIndex = 1;
            // 
            // Affichage_Resutlt
            // 
            this.Affichage_Resutlt.Location = new System.Drawing.Point(6, 436);
            this.Affichage_Resutlt.Name = "Affichage_Resutlt";
            this.Affichage_Resutlt.Size = new System.Drawing.Size(110, 55);
            this.Affichage_Resutlt.TabIndex = 1;
            this.Affichage_Resutlt.Text = "Resultat";
            this.Affichage_Resutlt.UseVisualStyleBackColor = true;
            this.Affichage_Resutlt.Click += new System.EventHandler(this.Affichage_Resutlt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1336, 667);
            this.Controls.Add(this.contener);
            this.Controls.Add(this.Menu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Button Affiche_Agent;
        private System.Windows.Forms.Button Affiche_paiment;
        private System.Windows.Forms.Button Affiche_Vente;
        private System.Windows.Forms.Button Affiche_Contrat;
        private System.Windows.Forms.Button Affiche_Maison;
        private System.Windows.Forms.Button Affiche_Client;
        private System.Windows.Forms.Panel contener;
        private System.Windows.Forms.Button Affichage_Resutlt;
    }
}


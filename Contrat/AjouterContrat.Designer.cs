namespace VenteMaison
{
    partial class AjouterContrat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxidAgent = new System.Windows.Forms.ComboBox();
            this.comboBoxidCINclient = new System.Windows.Forms.ComboBox();
            this.comboBoxidmaison = new System.Windows.Forms.ComboBox();
            this.txtmontant = new System.Windows.Forms.TextBox();
            this.Ajouterrcontrat = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter un  nouveua Contrat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Indetification Maison";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Indetification Client";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Indetification Agent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Montant";
            // 
            // comboBoxidAgent
            // 
            this.comboBoxidAgent.FormattingEnabled = true;
            this.comboBoxidAgent.Location = new System.Drawing.Point(138, 173);
            this.comboBoxidAgent.Name = "comboBoxidAgent";
            this.comboBoxidAgent.Size = new System.Drawing.Size(121, 21);
            this.comboBoxidAgent.TabIndex = 3;
            // 
            // comboBoxidCINclient
            // 
            this.comboBoxidCINclient.FormattingEnabled = true;
            this.comboBoxidCINclient.Location = new System.Drawing.Point(138, 128);
            this.comboBoxidCINclient.Name = "comboBoxidCINclient";
            this.comboBoxidCINclient.Size = new System.Drawing.Size(121, 21);
            this.comboBoxidCINclient.TabIndex = 3;
            // 
            // comboBoxidmaison
            // 
            this.comboBoxidmaison.FormattingEnabled = true;
            this.comboBoxidmaison.Location = new System.Drawing.Point(138, 85);
            this.comboBoxidmaison.Name = "comboBoxidmaison";
            this.comboBoxidmaison.Size = new System.Drawing.Size(121, 21);
            this.comboBoxidmaison.TabIndex = 3;
            // 
            // txtmontant
            // 
            this.txtmontant.Location = new System.Drawing.Point(138, 229);
            this.txtmontant.Name = "txtmontant";
            this.txtmontant.Size = new System.Drawing.Size(100, 20);
            this.txtmontant.TabIndex = 4;
            // 
            // Ajouterrcontrat
            // 
            this.Ajouterrcontrat.Location = new System.Drawing.Point(199, 307);
            this.Ajouterrcontrat.Name = "Ajouterrcontrat";
            this.Ajouterrcontrat.Size = new System.Drawing.Size(75, 23);
            this.Ajouterrcontrat.TabIndex = 5;
            this.Ajouterrcontrat.Text = "Ajouter";
            this.Ajouterrcontrat.UseVisualStyleBackColor = true;
            this.Ajouterrcontrat.Click += new System.EventHandler(this.Ajouterrcontrat_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(34, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AjouterContrat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 352);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Ajouterrcontrat);
            this.Controls.Add(this.txtmontant);
            this.Controls.Add(this.comboBoxidmaison);
            this.Controls.Add(this.comboBoxidCINclient);
            this.Controls.Add(this.comboBoxidAgent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AjouterContrat";
            this.Text = "AjouterContrat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxidAgent;
        private System.Windows.Forms.ComboBox comboBoxidCINclient;
        private System.Windows.Forms.ComboBox comboBoxidmaison;
        private System.Windows.Forms.TextBox txtmontant;
        private System.Windows.Forms.Button Ajouterrcontrat;
        private System.Windows.Forms.Button button2;
    }
}
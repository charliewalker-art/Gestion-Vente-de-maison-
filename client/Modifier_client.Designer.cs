namespace VenteMaison
{
    partial class Modifier_client
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
            this.txt_modifier_CIN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_modifier_nom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_modifier_prenom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_modifier_contact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_modifier_adresse = new System.Windows.Forms.TextBox();
            this.modifier2client = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modifier un Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CIN";
            // 
            // txt_modifier_CIN
            // 
            this.txt_modifier_CIN.Location = new System.Drawing.Point(127, 50);
            this.txt_modifier_CIN.Name = "txt_modifier_CIN";
            this.txt_modifier_CIN.Size = new System.Drawing.Size(100, 20);
            this.txt_modifier_CIN.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nom";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_modifier_nom
            // 
            this.txt_modifier_nom.Location = new System.Drawing.Point(127, 104);
            this.txt_modifier_nom.Name = "txt_modifier_nom";
            this.txt_modifier_nom.Size = new System.Drawing.Size(100, 20);
            this.txt_modifier_nom.TabIndex = 2;
            this.txt_modifier_nom.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Prenom";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_modifier_prenom
            // 
            this.txt_modifier_prenom.Location = new System.Drawing.Point(127, 155);
            this.txt_modifier_prenom.Name = "txt_modifier_prenom";
            this.txt_modifier_prenom.Size = new System.Drawing.Size(100, 20);
            this.txt_modifier_prenom.TabIndex = 2;
            this.txt_modifier_prenom.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Contact";
            this.label5.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_modifier_contact
            // 
            this.txt_modifier_contact.Location = new System.Drawing.Point(127, 204);
            this.txt_modifier_contact.Name = "txt_modifier_contact";
            this.txt_modifier_contact.Size = new System.Drawing.Size(100, 20);
            this.txt_modifier_contact.TabIndex = 2;
            this.txt_modifier_contact.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Adresse";
            this.label6.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_modifier_adresse
            // 
            this.txt_modifier_adresse.Location = new System.Drawing.Point(127, 262);
            this.txt_modifier_adresse.Name = "txt_modifier_adresse";
            this.txt_modifier_adresse.Size = new System.Drawing.Size(100, 20);
            this.txt_modifier_adresse.TabIndex = 2;
            this.txt_modifier_adresse.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // modifier2client
            // 
            this.modifier2client.Location = new System.Drawing.Point(235, 329);
            this.modifier2client.Name = "modifier2client";
            this.modifier2client.Size = new System.Drawing.Size(75, 23);
            this.modifier2client.TabIndex = 3;
            this.modifier2client.Text = "Modifier";
            this.modifier2client.UseVisualStyleBackColor = true;
            this.modifier2client.Click += new System.EventHandler(this.modifier2client_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Modifier_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 380);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.modifier2client);
            this.Controls.Add(this.txt_modifier_adresse);
            this.Controls.Add(this.txt_modifier_contact);
            this.Controls.Add(this.txt_modifier_prenom);
            this.Controls.Add(this.txt_modifier_nom);
            this.Controls.Add(this.txt_modifier_CIN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modifier_client";
            this.Text = "Modifier_client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_modifier_CIN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_modifier_nom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_modifier_prenom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_modifier_contact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_modifier_adresse;
        private System.Windows.Forms.Button modifier2client;
        private System.Windows.Forms.Button button2;
    }
}
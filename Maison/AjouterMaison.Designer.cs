namespace VenteMaison
{
    partial class AjouterMaison
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnAjouterMaison = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtadresse = new System.Windows.Forms.TextBox();
            this.txtquartier = new System.Windows.Forms.TextBox();
            this.txtville = new System.Windows.Forms.TextBox();
            this.txtsurface = new System.Windows.Forms.TextBox();
            this.txtprix = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter une maison";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adresse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prix";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quartier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ville";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Surface";
            // 
            // btnAjouterMaison
            // 
            this.btnAjouterMaison.Location = new System.Drawing.Point(200, 367);
            this.btnAjouterMaison.Name = "btnAjouterMaison";
            this.btnAjouterMaison.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterMaison.TabIndex = 2;
            this.btnAjouterMaison.Text = "Ajouter";
            this.btnAjouterMaison.UseVisualStyleBackColor = true;
            this.btnAjouterMaison.Click += new System.EventHandler(this.btnAjouterMaison_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtadresse
            // 
            this.txtadresse.Location = new System.Drawing.Point(137, 88);
            this.txtadresse.Name = "txtadresse";
            this.txtadresse.Size = new System.Drawing.Size(100, 20);
            this.txtadresse.TabIndex = 3;
            // 
            // txtquartier
            // 
            this.txtquartier.Location = new System.Drawing.Point(137, 142);
            this.txtquartier.Name = "txtquartier";
            this.txtquartier.Size = new System.Drawing.Size(100, 20);
            this.txtquartier.TabIndex = 3;
            // 
            // txtville
            // 
            this.txtville.Location = new System.Drawing.Point(137, 195);
            this.txtville.Name = "txtville";
            this.txtville.Size = new System.Drawing.Size(100, 20);
            this.txtville.TabIndex = 3;
            // 
            // txtsurface
            // 
            this.txtsurface.Location = new System.Drawing.Point(137, 241);
            this.txtsurface.Name = "txtsurface";
            this.txtsurface.Size = new System.Drawing.Size(100, 20);
            this.txtsurface.TabIndex = 3;
            // 
            // txtprix
            // 
            this.txtprix.Location = new System.Drawing.Point(137, 292);
            this.txtprix.Name = "txtprix";
            this.txtprix.Size = new System.Drawing.Size(100, 20);
            this.txtprix.TabIndex = 3;
            // 
            // AjouterMaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 429);
            this.Controls.Add(this.txtprix);
            this.Controls.Add(this.txtsurface);
            this.Controls.Add(this.txtville);
            this.Controls.Add(this.txtquartier);
            this.Controls.Add(this.txtadresse);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAjouterMaison);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AjouterMaison";
            this.Text = "AjouterMaison";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAjouterMaison;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtadresse;
        private System.Windows.Forms.TextBox txtquartier;
        private System.Windows.Forms.TextBox txtville;
        private System.Windows.Forms.TextBox txtsurface;
        private System.Windows.Forms.TextBox txtprix;
    }
}
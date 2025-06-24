namespace VenteMaison
{
    partial class AjouterPaiment
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
            this.comboBoxidvente = new System.Windows.Forms.ComboBox();
            this.btn_ajouter_paiment = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajoute un Paiment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID vente";
            // 
            // comboBoxidvente
            // 
            this.comboBoxidvente.FormattingEnabled = true;
            this.comboBoxidvente.Location = new System.Drawing.Point(112, 111);
            this.comboBoxidvente.Name = "comboBoxidvente";
            this.comboBoxidvente.Size = new System.Drawing.Size(121, 21);
            this.comboBoxidvente.TabIndex = 2;
            // 
            // btn_ajouter_paiment
            // 
            this.btn_ajouter_paiment.Location = new System.Drawing.Point(158, 238);
            this.btn_ajouter_paiment.Name = "btn_ajouter_paiment";
            this.btn_ajouter_paiment.Size = new System.Drawing.Size(75, 23);
            this.btn_ajouter_paiment.TabIndex = 3;
            this.btn_ajouter_paiment.Text = "Ajouter";
            this.btn_ajouter_paiment.UseVisualStyleBackColor = true;
            this.btn_ajouter_paiment.Click += new System.EventHandler(this.btn_ajouter_paiment_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AjouterPaiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 295);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_ajouter_paiment);
            this.Controls.Add(this.comboBoxidvente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AjouterPaiment";
            this.Text = "AjouterPaiment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxidvente;
        private System.Windows.Forms.Button btn_ajouter_paiment;
        private System.Windows.Forms.Button button2;
    }
}
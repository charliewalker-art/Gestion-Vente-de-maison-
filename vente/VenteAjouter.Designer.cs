﻿namespace VenteMaison
{
    partial class VenteAjouter
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
            this.comboBoxidcontrat = new System.Windows.Forms.ComboBox();
            this.btnajoutervente = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter une vente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID contrat";
            // 
            // comboBoxidcontrat
            // 
            this.comboBoxidcontrat.FormattingEnabled = true;
            this.comboBoxidcontrat.Location = new System.Drawing.Point(123, 105);
            this.comboBoxidcontrat.Name = "comboBoxidcontrat";
            this.comboBoxidcontrat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxidcontrat.TabIndex = 2;
            // 
            // btnajoutervente
            // 
            this.btnajoutervente.Location = new System.Drawing.Point(158, 198);
            this.btnajoutervente.Name = "btnajoutervente";
            this.btnajoutervente.Size = new System.Drawing.Size(75, 23);
            this.btnajoutervente.TabIndex = 3;
            this.btnajoutervente.Text = "Ajouter";
            this.btnajoutervente.UseVisualStyleBackColor = true;
            this.btnajoutervente.Click += new System.EventHandler(this.btnajoutervente_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // VenteAjouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 268);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnajoutervente);
            this.Controls.Add(this.comboBoxidcontrat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VenteAjouter";
            this.Text = "VenteAjouter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxidcontrat;
        private System.Windows.Forms.Button btnajoutervente;
        private System.Windows.Forms.Button button2;
    }
}
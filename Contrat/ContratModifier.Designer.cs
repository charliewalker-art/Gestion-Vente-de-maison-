namespace VenteMaison
{
    partial class ContratModifier
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmontant = new System.Windows.Forms.TextBox();
            this.Modifiercontrat = new System.Windows.Forms.Button();
            this.dateducontrat = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcontrat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modifier un contrat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Date du contrat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "montant";
            // 
            // txtmontant
            // 
            this.txtmontant.Location = new System.Drawing.Point(153, 173);
            this.txtmontant.Name = "txtmontant";
            this.txtmontant.Size = new System.Drawing.Size(100, 20);
            this.txtmontant.TabIndex = 3;
            // 
            // Modifiercontrat
            // 
            this.Modifiercontrat.Location = new System.Drawing.Point(232, 294);
            this.Modifiercontrat.Name = "Modifiercontrat";
            this.Modifiercontrat.Size = new System.Drawing.Size(75, 23);
            this.Modifiercontrat.TabIndex = 4;
            this.Modifiercontrat.Text = "Modifier";
            this.Modifiercontrat.UseVisualStyleBackColor = true;
            this.Modifiercontrat.Click += new System.EventHandler(this.Modifiercontrat_Click);
            // 
            // dateducontrat
            // 
            this.dateducontrat.Location = new System.Drawing.Point(134, 126);
            this.dateducontrat.Name = "dateducontrat";
            this.dateducontrat.Size = new System.Drawing.Size(200, 20);
            this.dateducontrat.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "id contrat";
            // 
            // txtcontrat
            // 
            this.txtcontrat.Location = new System.Drawing.Point(153, 80);
            this.txtcontrat.Name = "txtcontrat";
            this.txtcontrat.Size = new System.Drawing.Size(100, 20);
            this.txtcontrat.TabIndex = 3;
            // 
            // ContratModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 359);
            this.Controls.Add(this.dateducontrat);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Modifiercontrat);
            this.Controls.Add(this.txtcontrat);
            this.Controls.Add(this.txtmontant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "ContratModifier";
            this.Text = "Modifier contrat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmontant;
        private System.Windows.Forms.Button Modifiercontrat;
        private System.Windows.Forms.DateTimePicker dateducontrat;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcontrat;
    }
}
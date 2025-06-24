namespace VenteMaison
{
    partial class ModifierMaison
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
            this.txtidmaison = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtadresse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtquatrie = new System.Windows.Forms.TextBox();
            this.txtville = new System.Windows.Forms.TextBox();
            this.txtsurface = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtprix = new System.Windows.Forms.TextBox();
            this.btn_modifier = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "id maison";
            // 
            // txtidmaison
            // 
            this.txtidmaison.Location = new System.Drawing.Point(128, 76);
            this.txtidmaison.Name = "txtidmaison";
            this.txtidmaison.Size = new System.Drawing.Size(100, 20);
            this.txtidmaison.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adresse";
            // 
            // txtadresse
            // 
            this.txtadresse.Location = new System.Drawing.Point(128, 132);
            this.txtadresse.Name = "txtadresse";
            this.txtadresse.Size = new System.Drawing.Size(100, 20);
            this.txtadresse.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Modifier Maison";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quatrie";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ville";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Surface";
            // 
            // txtquatrie
            // 
            this.txtquatrie.Location = new System.Drawing.Point(128, 190);
            this.txtquatrie.Name = "txtquatrie";
            this.txtquatrie.Size = new System.Drawing.Size(100, 20);
            this.txtquatrie.TabIndex = 1;
            // 
            // txtville
            // 
            this.txtville.Location = new System.Drawing.Point(128, 243);
            this.txtville.Name = "txtville";
            this.txtville.Size = new System.Drawing.Size(100, 20);
            this.txtville.TabIndex = 1;
            // 
            // txtsurface
            // 
            this.txtsurface.Location = new System.Drawing.Point(128, 299);
            this.txtsurface.Name = "txtsurface";
            this.txtsurface.Size = new System.Drawing.Size(100, 20);
            this.txtsurface.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Prix";
            // 
            // txtprix
            // 
            this.txtprix.Location = new System.Drawing.Point(128, 356);
            this.txtprix.Name = "txtprix";
            this.txtprix.Size = new System.Drawing.Size(100, 20);
            this.txtprix.TabIndex = 1;
            // 
            // btn_modifier
            // 
            this.btn_modifier.Location = new System.Drawing.Point(200, 436);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(75, 23);
            this.btn_modifier.TabIndex = 2;
            this.btn_modifier.Text = "Modifier";
            this.btn_modifier.UseVisualStyleBackColor = true;
            this.btn_modifier.Click += new System.EventHandler(this.btn_modifier_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 436);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModifierMaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 492);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_modifier);
            this.Controls.Add(this.txtprix);
            this.Controls.Add(this.txtsurface);
            this.Controls.Add(this.txtville);
            this.Controls.Add(this.txtquatrie);
            this.Controls.Add(this.txtadresse);
            this.Controls.Add(this.txtidmaison);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ModifierMaison";
            this.Text = "ModifierMaison";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidmaison;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtadresse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtquatrie;
        private System.Windows.Forms.TextBox txtville;
        private System.Windows.Forms.TextBox txtsurface;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtprix;
        private System.Windows.Forms.Button btn_modifier;
        private System.Windows.Forms.Button button2;
    }
}
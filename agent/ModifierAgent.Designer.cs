﻿namespace VenteMaison
{
    partial class ModifierAgent
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
            this.txtnom = new System.Windows.Forms.TextBox();
            this.txtprenom = new System.Windows.Forms.TextBox();
            this.txtcontact = new System.Windows.Forms.TextBox();
            this.ModifierAgents = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtidagent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modifier un Agent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prenom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Contact";
            // 
            // txtnom
            // 
            this.txtnom.Location = new System.Drawing.Point(123, 100);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(100, 20);
            this.txtnom.TabIndex = 2;
            // 
            // txtprenom
            // 
            this.txtprenom.Location = new System.Drawing.Point(123, 143);
            this.txtprenom.Name = "txtprenom";
            this.txtprenom.Size = new System.Drawing.Size(100, 20);
            this.txtprenom.TabIndex = 2;
            // 
            // txtcontact
            // 
            this.txtcontact.Location = new System.Drawing.Point(123, 192);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(100, 20);
            this.txtcontact.TabIndex = 2;
            // 
            // ModifierAgents
            // 
            this.ModifierAgents.Location = new System.Drawing.Point(165, 281);
            this.ModifierAgents.Name = "ModifierAgents";
            this.ModifierAgents.Size = new System.Drawing.Size(75, 23);
            this.ModifierAgents.TabIndex = 3;
            this.ModifierAgents.Text = "Modifier";
            this.ModifierAgents.UseVisualStyleBackColor = true;
            this.ModifierAgents.Click += new System.EventHandler(this.ModifierAgents_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Anuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtidagent
            // 
            this.txtidagent.Location = new System.Drawing.Point(123, 64);
            this.txtidagent.Name = "txtidagent";
            this.txtidagent.Size = new System.Drawing.Size(100, 20);
            this.txtidagent.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "idagent";
            // 
            // ModifierAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 340);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ModifierAgents);
            this.Controls.Add(this.txtcontact);
            this.Controls.Add(this.txtprenom);
            this.Controls.Add(this.txtidagent);
            this.Controls.Add(this.txtnom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModifierAgent";
            this.Text = "ModifierAgent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnom;
        private System.Windows.Forms.TextBox txtprenom;
        private System.Windows.Forms.TextBox txtcontact;
        private System.Windows.Forms.Button ModifierAgents;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtidagent;
        private System.Windows.Forms.Label label5;
    }
}
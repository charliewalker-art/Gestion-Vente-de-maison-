namespace VenteMaison
{
    partial class AgentForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ajouter_Agent = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_recherche_agent = new System.Windows.Forms.TextBox();
            this.btn_recherceh_agent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1012, 497);
            this.dataGridView1.TabIndex = 0;
            // 
            // Ajouter_Agent
            // 
            this.Ajouter_Agent.Location = new System.Drawing.Point(789, 12);
            this.Ajouter_Agent.Name = "Ajouter_Agent";
            this.Ajouter_Agent.Size = new System.Drawing.Size(82, 44);
            this.Ajouter_Agent.TabIndex = 1;
            this.Ajouter_Agent.Text = "Ajouter";
            this.Ajouter_Agent.UseVisualStyleBackColor = true;
            this.Ajouter_Agent.Click += new System.EventHandler(this.Ajouter_Agent_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 48);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.modifierToolStripMenuItem.Text = "modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.supprimerToolStripMenuItem.Text = "supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(240, 12);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(44, 13);
            this.Title.TabIndex = 2;
            this.Title.Text = "AGENT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Recherche";
            // 
            // txt_recherche_agent
            // 
            this.txt_recherche_agent.Location = new System.Drawing.Point(499, 19);
            this.txt_recherche_agent.Name = "txt_recherche_agent";
            this.txt_recherche_agent.Size = new System.Drawing.Size(100, 20);
            this.txt_recherche_agent.TabIndex = 4;
            // 
            // btn_recherceh_agent
            // 
            this.btn_recherceh_agent.Location = new System.Drawing.Point(619, 17);
            this.btn_recherceh_agent.Name = "btn_recherceh_agent";
            this.btn_recherceh_agent.Size = new System.Drawing.Size(82, 39);
            this.btn_recherceh_agent.TabIndex = 5;
            this.btn_recherceh_agent.Text = "Recherche";
            this.btn_recherceh_agent.UseVisualStyleBackColor = true;
            this.btn_recherceh_agent.Click += new System.EventHandler(this.btn_recherceh_agent_Click);
            // 
            // AgentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 569);
            this.Controls.Add(this.btn_recherceh_agent);
            this.Controls.Add(this.txt_recherche_agent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Ajouter_Agent);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AgentForm";
            this.Text = "AgentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Ajouter_Agent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_recherche_agent;
        private System.Windows.Forms.Button btn_recherceh_agent;
    }
}
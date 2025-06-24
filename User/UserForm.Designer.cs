namespace VenteMaison
{
    partial class UserForm
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
            this.btnshowbtnajouter = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labme = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(566, 197);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnshowbtnajouter
            // 
            this.btnshowbtnajouter.Location = new System.Drawing.Point(503, 38);
            this.btnshowbtnajouter.Name = "btnshowbtnajouter";
            this.btnshowbtnajouter.Size = new System.Drawing.Size(83, 40);
            this.btnshowbtnajouter.TabIndex = 1;
            this.btnshowbtnajouter.Text = "Ajouter";
            this.btnshowbtnajouter.UseVisualStyleBackColor = true;
            this.btnshowbtnajouter.Click += new System.EventHandler(this.btnshowbtnajouter_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.supprimerToolStripMenuItem.Text = "supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // labme
            // 
            this.labme.AutoSize = true;
            this.labme.Location = new System.Drawing.Point(235, 52);
            this.labme.Name = "labme";
            this.labme.Size = new System.Drawing.Size(78, 13);
            this.labme.TabIndex = 2;
            this.labme.Text = "UTILISATEUR";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 65);
            this.button1.TabIndex = 3;
            this.button1.Text = "Alle a la page Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labme);
            this.Controls.Add(this.btnshowbtnajouter);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserForm";
            this.Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnshowbtnajouter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.Label labme;
        private System.Windows.Forms.Button button1;
    }
}
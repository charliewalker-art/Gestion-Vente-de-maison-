namespace VenteMaison
{
    partial class ContratForm
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
            this.Ajoutercontratbox = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.suppiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmodifierdialog = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btngenerepdf = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ajoutercontratbox
            // 
            this.Ajoutercontratbox.Location = new System.Drawing.Point(663, 78);
            this.Ajoutercontratbox.Name = "Ajoutercontratbox";
            this.Ajoutercontratbox.Size = new System.Drawing.Size(79, 37);
            this.Ajoutercontratbox.TabIndex = 0;
            this.Ajoutercontratbox.Text = "Ajouter";
            this.Ajoutercontratbox.UseVisualStyleBackColor = true;
            this.Ajoutercontratbox.Click += new System.EventHandler(this.Ajoutercontratbox_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1005, 434);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suppiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // suppiToolStripMenuItem
            // 
            this.suppiToolStripMenuItem.Name = "suppiToolStripMenuItem";
            this.suppiToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.suppiToolStripMenuItem.Text = "Supprimer";
            this.suppiToolStripMenuItem.Click += new System.EventHandler(this.suppiToolStripMenuItem_Click);
            // 
            // btnmodifierdialog
            // 
            this.btnmodifierdialog.Location = new System.Drawing.Point(773, 78);
            this.btnmodifierdialog.Name = "btnmodifierdialog";
            this.btnmodifierdialog.Size = new System.Drawing.Size(79, 37);
            this.btnmodifierdialog.TabIndex = 2;
            this.btnmodifierdialog.Text = "Modifier";
            this.btnmodifierdialog.UseVisualStyleBackColor = true;
            this.btnmodifierdialog.Click += new System.EventHandler(this.btnmodifierdialog_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(414, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Genere pdf";
            // 
            // btngenerepdf
            // 
            this.btngenerepdf.Location = new System.Drawing.Point(546, 78);
            this.btngenerepdf.Name = "btngenerepdf";
            this.btngenerepdf.Size = new System.Drawing.Size(78, 37);
            this.btngenerepdf.TabIndex = 5;
            this.btngenerepdf.Text = "Genere ";
            this.btngenerepdf.UseVisualStyleBackColor = true;
            this.btngenerepdf.Click += new System.EventHandler(this.btngenerepdf_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(142, 33);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(59, 13);
            this.Title.TabIndex = 6;
            this.Title.Text = "CONTRAT";
            // 
            // ContratForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 569);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.btngenerepdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnmodifierdialog);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Ajoutercontratbox);
            this.Name = "ContratForm";
            this.Text = "ContratForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ajoutercontratbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem suppiToolStripMenuItem;
        private System.Windows.Forms.Button btnmodifierdialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btngenerepdf;
        private System.Windows.Forms.Label Title;
    }
}
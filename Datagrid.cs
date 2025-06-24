using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenteMaison
{
    public partial class Datagrid : Form
    {
        private int rowHoverIndex = -1;

        public Datagrid()
        {
            InitializeComponent();

            //    StyliserDataGridView();
            AppliquerStyleTableau(dataGridView1);
     
        }

       
        public void AppliquerStyleTableau(DataGridView grid)
        {
            // Palette de couleurs HTML adaptée
            Color fondClair = Color.FromArgb(244, 246, 248);     // #f4f6f8
            Color enTeteBleuFonce = Color.FromArgb(9, 30, 128);   // #091e80
            Color hoverBleu = Color.FromArgb(120, 132, 201);      // #7884c9
            Color fondTable = Color.White;
            Color bordLigne = Color.FromArgb(220, 220, 220);      // #ddd

            // Général
            grid.BackgroundColor = fondClair;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = bordLigne;

            // Style des en-têtes
            grid.ColumnHeadersDefaultCellStyle.BackColor = enTeteBleuFonce;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersHeight = 40;
            grid.EnableHeadersVisualStyles = false;

            // Style des cellules
            grid.DefaultCellStyle.BackColor = fondTable;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            grid.DefaultCellStyle.Padding = new Padding(10);
            grid.DefaultCellStyle.SelectionBackColor = hoverBleu;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Lignes alternées si besoin
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            // Options diverses
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.RowTemplate.Height = 35;

            // Supprimer les bords trop visibles
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DividerWidth = 0;
            }
        }

    }
}

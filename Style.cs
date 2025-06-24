using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenteMaison
{
    class Style
    {

        public void AppliquerStyleTableau(DataGridView grid)
        {
            // Palette Bootstrap-like
            Color fondTable = Color.White;
            Color ligneZebra = Color.FromArgb(248, 249, 250);     // #f8f9fa
            Color bordLigne = Color.FromArgb(222, 226, 230);      // #dee2e6
            Color selectionBleu = Color.FromArgb(173, 216, 230);  // light blue selection color
            Color enTete = Color.FromArgb(248, 249, 250);         // #f8f9fa
            Color texteNoir = Color.Black;

            // Général
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = bordLigne;
            grid.BackgroundColor = fondTable;

            // En-têtes
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = enTete;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = texteNoir;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersHeight = 45;

            // Cellules
            grid.DefaultCellStyle.BackColor = fondTable;
            grid.DefaultCellStyle.ForeColor = texteNoir;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            grid.DefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            grid.DefaultCellStyle.SelectionBackColor = selectionBleu;  // Couleur sélection ligne
            grid.DefaultCellStyle.SelectionForeColor = texteNoir;

            // Lignes alternées (zebra)
            grid.AlternatingRowsDefaultCellStyle.BackColor = ligneZebra;

            // Options
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.RowTemplate.Height = 50;

            // Supprimer les séparateurs visibles
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DividerWidth = 0;
            }

            // Supprimer l’effet focus bleu (halo) autour de la ligne sélectionnée
            grid.RowPrePaint += (s, e) =>
            {
                if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
                {
                    e.PaintParts &= ~DataGridViewPaintParts.Focus;
                }
            };

            // Forcer la couleur des cellules sélectionnées (pour éviter conflits)
            grid.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && grid.Rows[e.RowIndex].Selected)
                {
                    e.CellStyle.SelectionBackColor = selectionBleu;
                    e.CellStyle.SelectionForeColor = texteNoir;
                }
            };

            // Important : assure-toi que le header ne change pas de couleur lors de la sélection
            grid.ColumnHeadersDefaultCellStyle.BackColor = enTete;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = texteNoir;
            grid.EnableHeadersVisualStyles = false;
        }

        public void StyliserBouton(Button btn)
        {
            // Couleur de fond bleu clair
            //  btn.BackColor = Color.FromArgb(173, 216, 230); // LightBlue
            btn.BackColor = Color.FromArgb(13, 110, 253); // DarkBlue


            // Couleur du texte blanc
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            int radius = 6; // rayon des coins arrondis

            btn.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
                using (var path = GetRoundedRectPath(rect, radius))
                {
                    btn.Region = new Region(path);

                    // Remplir le fond arrondi
                    using (var brush = new SolidBrush(btn.BackColor))
                    {
                        g.FillPath(brush, path);
                    }

                    // Dessiner le texte centré
                    TextRenderer.DrawText(
                        g,
                        btn.Text,
                        btn.Font,
                        rect,
                        btn.ForeColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            };

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(135, 206, 250); // LightSkyBlue
                btn.ForeColor = Color.White;
                btn.Cursor = Cursors.Hand;
                btn.Invalidate();
            };

            btn.MouseLeave += (s, e) =>
            {
                //btn.BackColor = Color.FromArgb(173, 216, 230); // LightBlue
                btn.BackColor = Color.FromArgb(13, 110, 253);
                btn.ForeColor = Color.White;
                btn.Cursor = Cursors.Default;
                btn.Invalidate();
            };
        }

        private GraphicsPath GetRoundedRectPath(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        public void AppliquerStyleH1(Label label)
        {
            if (label == null) return;

            // Police grande, moderne et en gras
            label.Font = new Font("Segoe UI", 24, FontStyle.Bold);

            // Couleur moderne, par exemple un bleu vif
            label.ForeColor = Color.FromArgb(0, 120, 215);

            // Optionnel: alignement centré
            label.TextAlign = ContentAlignment.MiddleCenter;

            // Optionnel: fond transparent
            label.BackColor = Color.Transparent;

            // Optionnel: effet de lissage du texte (plus net)
            label.UseCompatibleTextRendering = true;
        }
    }


}


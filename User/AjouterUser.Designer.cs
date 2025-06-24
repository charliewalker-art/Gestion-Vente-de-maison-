namespace VenteMaison
{
    partial class AjouterUser
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
            this.comboBoxchoix_user = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnom = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btn_AjouterUser = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter un User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "mot de passe";
//            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBoxchoix_user
            // 
            this.comboBoxchoix_user.FormattingEnabled = true;
            this.comboBoxchoix_user.Location = new System.Drawing.Point(128, 213);
            this.comboBoxchoix_user.Name = "comboBoxchoix_user";
            this.comboBoxchoix_user.Size = new System.Drawing.Size(121, 21);
            this.comboBoxchoix_user.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "type";
//            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtnom
            // 
            this.txtnom.Location = new System.Drawing.Point(140, 84);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(100, 20);
            this.txtnom.TabIndex = 3;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(140, 153);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(100, 20);
            this.txtpassword.TabIndex = 3;
            // 
            // btn_AjouterUser
            // 
            this.btn_AjouterUser.Location = new System.Drawing.Point(207, 282);
            this.btn_AjouterUser.Name = "btn_AjouterUser";
            this.btn_AjouterUser.Size = new System.Drawing.Size(75, 23);
            this.btn_AjouterUser.TabIndex = 4;
            this.btn_AjouterUser.Text = "Ajouter";
            this.btn_AjouterUser.UseVisualStyleBackColor = true;
            this.btn_AjouterUser.Click += new System.EventHandler(this.btn_AjouterUser_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AjouterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 329);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_AjouterUser);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtnom);
            this.Controls.Add(this.comboBoxchoix_user);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AjouterUser";
            this.Text = "AjouterUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxchoix_user;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnom;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btn_AjouterUser;
        private System.Windows.Forms.Button button2;
    }
}
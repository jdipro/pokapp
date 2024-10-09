using System.Windows.Forms;
using System;

namespace winform
{
    partial class frmPokemonsLoad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxPokemon = new PictureBox();
            dgvPokemons = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPokemon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPokemons).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPokemon
            // 
            pictureBoxPokemon.Location = new System.Drawing.Point(632, 71);
            pictureBoxPokemon.Name = "pictureBoxPokemon";
            pictureBoxPokemon.Size = new System.Drawing.Size(231, 208);
            pictureBoxPokemon.TabIndex = 0;
            pictureBoxPokemon.TabStop = false;
            // 
            // dgvPokemons
            // 
            dgvPokemons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPokemons.Location = new System.Drawing.Point(24, 71);
            dgvPokemons.Name = "dgvPokemons";
            dgvPokemons.RowTemplate.Height = 25;
            dgvPokemons.Size = new System.Drawing.Size(573, 257);
            dgvPokemons.TabIndex = 1;
            // 
            // frmPokemonsLoad
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(928, 465);
            Controls.Add(dgvPokemons);
            Controls.Add(pictureBoxPokemon);
            Name = "frmPokemonsLoad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += form1;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPokemon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPokemons).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPokemon;
        private System.Windows.Forms.DataGridView dgvPokemons;
    }
}

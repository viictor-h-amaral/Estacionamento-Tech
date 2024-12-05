namespace Estacionamento_Tech
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.tabelaValores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaValores)).BeginInit();
            this.SuspendLayout();
            // 
            // tabelaValores
            // 
            this.tabelaValores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tabelaValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaValores.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabelaValores.Location = new System.Drawing.Point(0, 0);
            this.tabelaValores.Name = "tabelaValores";
            this.tabelaValores.Size = new System.Drawing.Size(666, 376);
            this.tabelaValores.TabIndex = 0;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 374);
            this.Controls.Add(this.tabelaValores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Tabela de Valores";
            ((System.ComponentModel.ISupportInitialize)(this.tabelaValores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabelaValores;
    }
}
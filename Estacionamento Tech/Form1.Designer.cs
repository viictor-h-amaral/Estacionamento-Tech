using System.Windows.Forms;

namespace Estacionamento_Tech
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.adicionarHorarioEntrada = new System.Windows.Forms.Button();
            this.adicionarHorarioSaida = new System.Windows.Forms.Button();
            this.tabelaConsulta = new System.Windows.Forms.DataGridView();
            this.mskBuscaPlaca = new System.Windows.Forms.MaskedTextBox();
            this.btmBuscaPlaca = new System.Windows.Forms.Button();
            this.lblBuscaPlaca = new System.Windows.Forms.Label();
            this.btmRefreshConsulta = new System.Windows.Forms.Button();
            this.btmColsutaValores = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Orbitron", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::Estacionamento_Tech.Properties.Resources.logo3_estacionamento_tech;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 69);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estacionamento Tech";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adicionarHorarioEntrada
            // 
            this.adicionarHorarioEntrada.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.adicionarHorarioEntrada.FlatAppearance.BorderSize = 0;
            this.adicionarHorarioEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adicionarHorarioEntrada.Font = new System.Drawing.Font("Artifakt Element", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adicionarHorarioEntrada.ForeColor = System.Drawing.Color.White;
            this.adicionarHorarioEntrada.Location = new System.Drawing.Point(398, 12);
            this.adicionarHorarioEntrada.Name = "adicionarHorarioEntrada";
            this.adicionarHorarioEntrada.Size = new System.Drawing.Size(337, 42);
            this.adicionarHorarioEntrada.TabIndex = 8;
            this.adicionarHorarioEntrada.Text = "Adicionar Veículo/Horário de Entrada";
            this.adicionarHorarioEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adicionarHorarioEntrada.UseVisualStyleBackColor = false;
            this.adicionarHorarioEntrada.Click += new System.EventHandler(this.adicionarHorarioEntrada_Click);
            // 
            // adicionarHorarioSaida
            // 
            this.adicionarHorarioSaida.BackColor = System.Drawing.Color.Brown;
            this.adicionarHorarioSaida.FlatAppearance.BorderSize = 0;
            this.adicionarHorarioSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adicionarHorarioSaida.Font = new System.Drawing.Font("Artifakt Element", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adicionarHorarioSaida.ForeColor = System.Drawing.Color.White;
            this.adicionarHorarioSaida.Location = new System.Drawing.Point(750, 12);
            this.adicionarHorarioSaida.Name = "adicionarHorarioSaida";
            this.adicionarHorarioSaida.Size = new System.Drawing.Size(281, 42);
            this.adicionarHorarioSaida.TabIndex = 9;
            this.adicionarHorarioSaida.Text = "Adicionar Horário de Saída";
            this.adicionarHorarioSaida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adicionarHorarioSaida.UseVisualStyleBackColor = false;
            this.adicionarHorarioSaida.Click += new System.EventHandler(this.adicionarHorarioSaida_Click);
            // 
            // tabelaConsulta
            // 
            this.tabelaConsulta.AllowUserToAddRows = false;
            this.tabelaConsulta.AllowUserToDeleteRows = false;
            this.tabelaConsulta.AllowUserToResizeRows = false;
            this.tabelaConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaConsulta.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.tabelaConsulta.ColumnHeadersHeight = 60;
            this.tabelaConsulta.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabelaConsulta.Location = new System.Drawing.Point(7, 174);
            this.tabelaConsulta.Name = "tabelaConsulta";
            this.tabelaConsulta.ReadOnly = true;
            this.tabelaConsulta.Size = new System.Drawing.Size(1038, 342);
            this.tabelaConsulta.TabIndex = 16;
            // 
            // mskBuscaPlaca
            // 
            this.mskBuscaPlaca.BackColor = System.Drawing.Color.White;
            this.mskBuscaPlaca.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskBuscaPlaca.Font = new System.Drawing.Font("Artifakt Element", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskBuscaPlaca.Location = new System.Drawing.Point(283, 101);
            this.mskBuscaPlaca.Mask = ">L>L>L0>L00";
            this.mskBuscaPlaca.Name = "mskBuscaPlaca";
            this.mskBuscaPlaca.Size = new System.Drawing.Size(292, 59);
            this.mskBuscaPlaca.TabIndex = 18;
            this.mskBuscaPlaca.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // btmBuscaPlaca
            // 
            this.btmBuscaPlaca.BackColor = System.Drawing.Color.White;
            this.btmBuscaPlaca.BackgroundImage = global::Estacionamento_Tech.Properties.Resources._88602_search_icon;
            this.btmBuscaPlaca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btmBuscaPlaca.FlatAppearance.BorderSize = 0;
            this.btmBuscaPlaca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btmBuscaPlaca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmBuscaPlaca.Location = new System.Drawing.Point(468, 106);
            this.btmBuscaPlaca.Margin = new System.Windows.Forms.Padding(6);
            this.btmBuscaPlaca.Name = "btmBuscaPlaca";
            this.btmBuscaPlaca.Size = new System.Drawing.Size(54, 51);
            this.btmBuscaPlaca.TabIndex = 19;
            this.btmBuscaPlaca.UseVisualStyleBackColor = false;
            this.btmBuscaPlaca.Click += new System.EventHandler(this.btmBuscaPlaca_Click);
            // 
            // lblBuscaPlaca
            // 
            this.lblBuscaPlaca.AutoSize = true;
            this.lblBuscaPlaca.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscaPlaca.Font = new System.Drawing.Font("Artifakt Element", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscaPlaca.ForeColor = System.Drawing.Color.White;
            this.lblBuscaPlaca.Location = new System.Drawing.Point(187, 113);
            this.lblBuscaPlaca.Name = "lblBuscaPlaca";
            this.lblBuscaPlaca.Size = new System.Drawing.Size(90, 40);
            this.lblBuscaPlaca.TabIndex = 20;
            this.lblBuscaPlaca.Text = "Placa";
            // 
            // btmRefreshConsulta
            // 
            this.btmRefreshConsulta.BackColor = System.Drawing.Color.White;
            this.btmRefreshConsulta.BackgroundImage = global::Estacionamento_Tech.Properties.Resources._118801_refresh_icon;
            this.btmRefreshConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btmRefreshConsulta.FlatAppearance.BorderSize = 0;
            this.btmRefreshConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btmRefreshConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmRefreshConsulta.Font = new System.Drawing.Font("Artifakt Element", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmRefreshConsulta.Location = new System.Drawing.Point(546, 134);
            this.btmRefreshConsulta.Name = "btmRefreshConsulta";
            this.btmRefreshConsulta.Size = new System.Drawing.Size(24, 23);
            this.btmRefreshConsulta.TabIndex = 21;
            this.btmRefreshConsulta.UseVisualStyleBackColor = false;
            this.btmRefreshConsulta.Click += new System.EventHandler(this.btmRefreshConsulta_Click);
            // 
            // btmColsutaValores
            // 
            this.btmColsutaValores.Location = new System.Drawing.Point(890, 137);
            this.btmColsutaValores.Name = "btmColsutaValores";
            this.btmColsutaValores.Size = new System.Drawing.Size(150, 23);
            this.btmColsutaValores.TabIndex = 22;
            this.btmColsutaValores.Text = "Consultar Valores";
            this.btmColsutaValores.UseVisualStyleBackColor = true;
            this.btmColsutaValores.Click += new System.EventHandler(this.btmColsutaValores_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Estacionamento_Tech.Properties.Resources.servico_de_estacionamento;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1052, 542);
            this.Controls.Add(this.btmColsutaValores);
            this.Controls.Add(this.btmRefreshConsulta);
            this.Controls.Add(this.lblBuscaPlaca);
            this.Controls.Add(this.btmBuscaPlaca);
            this.Controls.Add(this.mskBuscaPlaca);
            this.Controls.Add(this.tabelaConsulta);
            this.Controls.Add(this.adicionarHorarioSaida);
            this.Controls.Add(this.adicionarHorarioEntrada);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estacionamento Tech";
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button adicionarHorarioEntrada;
        private System.Windows.Forms.Button adicionarHorarioSaida;
        private DataGridView tabelaConsulta;
        private MaskedTextBox mskBuscaPlaca;
        private Button btmBuscaPlaca;
        private Label lblBuscaPlaca;
        private Button btmRefreshConsulta;
        private Button btmColsutaValores;
    }
}


namespace Estacionamento_Tech
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.adicionarHorarioSaida = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mskHoraSaida = new System.Windows.Forms.MaskedTextBox();
            this.lblHoraSaida = new System.Windows.Forms.Label();
            this.mskDataSaida = new System.Windows.Forms.MaskedTextBox();
            this.lblDataSaida = new System.Windows.Forms.Label();
            this.lblPlacaSaida = new System.Windows.Forms.Label();
            this.btmRelogioSaida = new System.Windows.Forms.Button();
            this.btmSalvarSaida = new System.Windows.Forms.Button();
            this.cmbPlacaSaida = new System.Windows.Forms.ComboBox();
            this.tabelaConsultaSaida = new System.Windows.Forms.DataGridView();
            this.btmVoltarSaida = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsultaSaida)).BeginInit();
            this.SuspendLayout();
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
            this.adicionarHorarioSaida.TabIndex = 11;
            this.adicionarHorarioSaida.Text = "Adicionar Horário de Saída";
            this.adicionarHorarioSaida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adicionarHorarioSaida.UseVisualStyleBackColor = false;
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
            this.label1.TabIndex = 10;
            this.label1.Text = "Estacionamento Tech";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mskHoraSaida
            // 
            this.mskHoraSaida.BackColor = System.Drawing.Color.White;
            this.mskHoraSaida.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskHoraSaida.ForeColor = System.Drawing.Color.Black;
            this.mskHoraSaida.Location = new System.Drawing.Point(416, 234);
            this.mskHoraSaida.Mask = "00:00:00";
            this.mskHoraSaida.Name = "mskHoraSaida";
            this.mskHoraSaida.Size = new System.Drawing.Size(206, 45);
            this.mskHoraSaida.TabIndex = 33;
            // 
            // lblHoraSaida
            // 
            this.lblHoraSaida.AutoSize = true;
            this.lblHoraSaida.BackColor = System.Drawing.Color.Transparent;
            this.lblHoraSaida.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraSaida.ForeColor = System.Drawing.Color.White;
            this.lblHoraSaida.Location = new System.Drawing.Point(128, 234);
            this.lblHoraSaida.Name = "lblHoraSaida";
            this.lblHoraSaida.Size = new System.Drawing.Size(232, 37);
            this.lblHoraSaida.TabIndex = 36;
            this.lblHoraSaida.Text = "Horário de Saída";
            // 
            // mskDataSaida
            // 
            this.mskDataSaida.BackColor = System.Drawing.Color.White;
            this.mskDataSaida.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataSaida.ForeColor = System.Drawing.Color.Black;
            this.mskDataSaida.Location = new System.Drawing.Point(415, 301);
            this.mskDataSaida.Mask = "00/00/0000";
            this.mskDataSaida.Name = "mskDataSaida";
            this.mskDataSaida.Size = new System.Drawing.Size(206, 45);
            this.mskDataSaida.TabIndex = 34;
            // 
            // lblDataSaida
            // 
            this.lblDataSaida.AutoSize = true;
            this.lblDataSaida.BackColor = System.Drawing.Color.Transparent;
            this.lblDataSaida.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSaida.ForeColor = System.Drawing.Color.White;
            this.lblDataSaida.Location = new System.Drawing.Point(166, 309);
            this.lblDataSaida.Name = "lblDataSaida";
            this.lblDataSaida.Size = new System.Drawing.Size(193, 37);
            this.lblDataSaida.TabIndex = 37;
            this.lblDataSaida.Text = "Data de Saída";
            // 
            // lblPlacaSaida
            // 
            this.lblPlacaSaida.AutoSize = true;
            this.lblPlacaSaida.BackColor = System.Drawing.Color.Transparent;
            this.lblPlacaSaida.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacaSaida.ForeColor = System.Drawing.Color.White;
            this.lblPlacaSaida.Location = new System.Drawing.Point(128, 172);
            this.lblPlacaSaida.Name = "lblPlacaSaida";
            this.lblPlacaSaida.Size = new System.Drawing.Size(269, 37);
            this.lblPlacaSaida.TabIndex = 35;
            this.lblPlacaSaida.Text = "Placa do Automóvel";
            // 
            // btmRelogioSaida
            // 
            this.btmRelogioSaida.BackColor = System.Drawing.Color.Transparent;
            this.btmRelogioSaida.BackgroundImage = global::Estacionamento_Tech.Properties.Resources.clock_icon;
            this.btmRelogioSaida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btmRelogioSaida.FlatAppearance.BorderSize = 0;
            this.btmRelogioSaida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btmRelogioSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmRelogioSaida.Font = new System.Drawing.Font("Artifakt Element", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmRelogioSaida.Location = new System.Drawing.Point(649, 260);
            this.btmRelogioSaida.Name = "btmRelogioSaida";
            this.btmRelogioSaida.Size = new System.Drawing.Size(56, 57);
            this.btmRelogioSaida.TabIndex = 38;
            this.btmRelogioSaida.UseVisualStyleBackColor = false;
            this.btmRelogioSaida.Click += new System.EventHandler(this.btmRelogioSaida_Click);
            // 
            // btmSalvarSaida
            // 
            this.btmSalvarSaida.BackColor = System.Drawing.Color.Green;
            this.btmSalvarSaida.FlatAppearance.BorderSize = 4;
            this.btmSalvarSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmSalvarSaida.Font = new System.Drawing.Font("Artifakt Element Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmSalvarSaida.ForeColor = System.Drawing.Color.Snow;
            this.btmSalvarSaida.Location = new System.Drawing.Point(755, 187);
            this.btmSalvarSaida.Name = "btmSalvarSaida";
            this.btmSalvarSaida.Size = new System.Drawing.Size(178, 130);
            this.btmSalvarSaida.TabIndex = 40;
            this.btmSalvarSaida.Text = "SALVAR";
            this.btmSalvarSaida.UseVisualStyleBackColor = false;
            this.btmSalvarSaida.Click += new System.EventHandler(this.btmSalvarSaida_Click);
            // 
            // cmbPlacaSaida
            // 
            this.cmbPlacaSaida.BackColor = System.Drawing.Color.White;
            this.cmbPlacaSaida.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmbPlacaSaida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlacaSaida.Font = new System.Drawing.Font("Artifakt Element", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlacaSaida.FormattingEnabled = true;
            this.cmbPlacaSaida.Location = new System.Drawing.Point(416, 168);
            this.cmbPlacaSaida.Name = "cmbPlacaSaida";
            this.cmbPlacaSaida.Size = new System.Drawing.Size(206, 41);
            this.cmbPlacaSaida.TabIndex = 39;
            // 
            // tabelaConsultaSaida
            // 
            this.tabelaConsultaSaida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaConsultaSaida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaConsultaSaida.Location = new System.Drawing.Point(25, 371);
            this.tabelaConsultaSaida.Name = "tabelaConsultaSaida";
            this.tabelaConsultaSaida.Size = new System.Drawing.Size(996, 100);
            this.tabelaConsultaSaida.TabIndex = 41;
            // 
            // btmVoltarSaida
            // 
            this.btmVoltarSaida.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btmVoltarSaida.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btmVoltarSaida.FlatAppearance.BorderSize = 0;
            this.btmVoltarSaida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btmVoltarSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmVoltarSaida.Font = new System.Drawing.Font("Artifakt Element", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmVoltarSaida.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btmVoltarSaida.Location = new System.Drawing.Point(919, 489);
            this.btmVoltarSaida.Name = "btmVoltarSaida";
            this.btmVoltarSaida.Size = new System.Drawing.Size(125, 45);
            this.btmVoltarSaida.TabIndex = 42;
            this.btmVoltarSaida.Text = "Voltar";
            this.btmVoltarSaida.UseVisualStyleBackColor = false;
            this.btmVoltarSaida.Click += new System.EventHandler(this.btmVoltarSaida_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Estacionamento_Tech.Properties.Resources.servico_de_estacionamento;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1052, 542);
            this.Controls.Add(this.btmVoltarSaida);
            this.Controls.Add(this.tabelaConsultaSaida);
            this.Controls.Add(this.btmSalvarSaida);
            this.Controls.Add(this.cmbPlacaSaida);
            this.Controls.Add(this.mskHoraSaida);
            this.Controls.Add(this.lblHoraSaida);
            this.Controls.Add(this.mskDataSaida);
            this.Controls.Add(this.lblDataSaida);
            this.Controls.Add(this.lblPlacaSaida);
            this.Controls.Add(this.btmRelogioSaida);
            this.Controls.Add(this.adicionarHorarioSaida);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Horário de Saída";
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsultaSaida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button adicionarHorarioSaida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskHoraSaida;
        private System.Windows.Forms.Label lblHoraSaida;
        private System.Windows.Forms.MaskedTextBox mskDataSaida;
        private System.Windows.Forms.Label lblDataSaida;
        private System.Windows.Forms.Label lblPlacaSaida;
        private System.Windows.Forms.Button btmRelogioSaida;
        private System.Windows.Forms.Button btmSalvarSaida;
        private System.Windows.Forms.ComboBox cmbPlacaSaida;
        private System.Windows.Forms.DataGridView tabelaConsultaSaida;
        private System.Windows.Forms.Button btmVoltarSaida;
    }
}
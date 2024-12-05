namespace Estacionamento_Tech
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.adicionarHorarioEntrada = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btmVoltarEntrada = new System.Windows.Forms.Button();
            this.btmSalvarEntrada = new System.Windows.Forms.Button();
            this.mskHoraEntrada = new System.Windows.Forms.MaskedTextBox();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.mskDataEntrada = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntrada = new System.Windows.Forms.Label();
            this.mskPlacaEntrada = new System.Windows.Forms.MaskedTextBox();
            this.lblPlacaEntrada = new System.Windows.Forms.Label();
            this.btmRelogioEntrada = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.adicionarHorarioEntrada.TabIndex = 10;
            this.adicionarHorarioEntrada.Text = "Adicionar Veículo/Horário de Entrada";
            this.adicionarHorarioEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adicionarHorarioEntrada.UseVisualStyleBackColor = false;
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
            this.label1.TabIndex = 9;
            this.label1.Text = "Estacionamento Tech";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btmVoltarEntrada
            // 
            this.btmVoltarEntrada.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btmVoltarEntrada.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btmVoltarEntrada.FlatAppearance.BorderSize = 0;
            this.btmVoltarEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btmVoltarEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmVoltarEntrada.Font = new System.Drawing.Font("Artifakt Element", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmVoltarEntrada.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btmVoltarEntrada.Location = new System.Drawing.Point(915, 440);
            this.btmVoltarEntrada.Name = "btmVoltarEntrada";
            this.btmVoltarEntrada.Size = new System.Drawing.Size(125, 45);
            this.btmVoltarEntrada.TabIndex = 16;
            this.btmVoltarEntrada.Text = "Voltar";
            this.btmVoltarEntrada.UseVisualStyleBackColor = false;
            this.btmVoltarEntrada.Click += new System.EventHandler(this.btmVoltarEntrada_Click);
            // 
            // btmSalvarEntrada
            // 
            this.btmSalvarEntrada.BackColor = System.Drawing.Color.Green;
            this.btmSalvarEntrada.FlatAppearance.BorderSize = 4;
            this.btmSalvarEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmSalvarEntrada.Font = new System.Drawing.Font("Artifakt Element Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmSalvarEntrada.ForeColor = System.Drawing.Color.Snow;
            this.btmSalvarEntrada.Location = new System.Drawing.Point(755, 187);
            this.btmSalvarEntrada.Name = "btmSalvarEntrada";
            this.btmSalvarEntrada.Size = new System.Drawing.Size(178, 130);
            this.btmSalvarEntrada.TabIndex = 29;
            this.btmSalvarEntrada.Text = "SALVAR";
            this.btmSalvarEntrada.UseVisualStyleBackColor = false;
            this.btmSalvarEntrada.Click += new System.EventHandler(this.btmSalvarEntrada_Click);
            // 
            // mskHoraEntrada
            // 
            this.mskHoraEntrada.BackColor = System.Drawing.Color.White;
            this.mskHoraEntrada.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskHoraEntrada.ForeColor = System.Drawing.Color.Black;
            this.mskHoraEntrada.Location = new System.Drawing.Point(416, 234);
            this.mskHoraEntrada.Mask = "00:00:00";
            this.mskHoraEntrada.Name = "mskHoraEntrada";
            this.mskHoraEntrada.Size = new System.Drawing.Size(206, 45);
            this.mskHoraEntrada.TabIndex = 24;
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.BackColor = System.Drawing.Color.Transparent;
            this.lblHoraEntrada.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraEntrada.ForeColor = System.Drawing.Color.White;
            this.lblHoraEntrada.Location = new System.Drawing.Point(128, 234);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(260, 37);
            this.lblHoraEntrada.TabIndex = 27;
            this.lblHoraEntrada.Text = "Horário de Entrada";
            // 
            // mskDataEntrada
            // 
            this.mskDataEntrada.BackColor = System.Drawing.Color.White;
            this.mskDataEntrada.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataEntrada.ForeColor = System.Drawing.Color.Black;
            this.mskDataEntrada.Location = new System.Drawing.Point(415, 301);
            this.mskDataEntrada.Mask = "00/00/0000";
            this.mskDataEntrada.Name = "mskDataEntrada";
            this.mskDataEntrada.Size = new System.Drawing.Size(206, 45);
            this.mskDataEntrada.TabIndex = 25;
            // 
            // lblDataEntrada
            // 
            this.lblDataEntrada.AutoSize = true;
            this.lblDataEntrada.BackColor = System.Drawing.Color.Transparent;
            this.lblDataEntrada.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEntrada.ForeColor = System.Drawing.Color.White;
            this.lblDataEntrada.Location = new System.Drawing.Point(166, 309);
            this.lblDataEntrada.Name = "lblDataEntrada";
            this.lblDataEntrada.Size = new System.Drawing.Size(221, 37);
            this.lblDataEntrada.TabIndex = 28;
            this.lblDataEntrada.Text = "Data de Entrada";
            // 
            // mskPlacaEntrada
            // 
            this.mskPlacaEntrada.AllowPromptAsInput = false;
            this.mskPlacaEntrada.BackColor = System.Drawing.Color.White;
            this.mskPlacaEntrada.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskPlacaEntrada.ForeColor = System.Drawing.Color.Black;
            this.mskPlacaEntrada.Location = new System.Drawing.Point(416, 168);
            this.mskPlacaEntrada.Mask = ">L>L>L0>L00";
            this.mskPlacaEntrada.Name = "mskPlacaEntrada";
            this.mskPlacaEntrada.Size = new System.Drawing.Size(206, 45);
            this.mskPlacaEntrada.TabIndex = 23;
            this.mskPlacaEntrada.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblPlacaEntrada
            // 
            this.lblPlacaEntrada.AutoSize = true;
            this.lblPlacaEntrada.BackColor = System.Drawing.Color.Transparent;
            this.lblPlacaEntrada.Font = new System.Drawing.Font("Artifakt Element", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacaEntrada.ForeColor = System.Drawing.Color.White;
            this.lblPlacaEntrada.Location = new System.Drawing.Point(128, 172);
            this.lblPlacaEntrada.Name = "lblPlacaEntrada";
            this.lblPlacaEntrada.Size = new System.Drawing.Size(269, 37);
            this.lblPlacaEntrada.TabIndex = 26;
            this.lblPlacaEntrada.Text = "Placa do Automóvel";
            // 
            // btmRelogioEntrada
            // 
            this.btmRelogioEntrada.BackColor = System.Drawing.Color.Transparent;
            this.btmRelogioEntrada.BackgroundImage = global::Estacionamento_Tech.Properties.Resources.clock_icon;
            this.btmRelogioEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btmRelogioEntrada.FlatAppearance.BorderSize = 0;
            this.btmRelogioEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btmRelogioEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmRelogioEntrada.Font = new System.Drawing.Font("Artifakt Element", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmRelogioEntrada.Location = new System.Drawing.Point(649, 260);
            this.btmRelogioEntrada.Name = "btmRelogioEntrada";
            this.btmRelogioEntrada.Size = new System.Drawing.Size(56, 57);
            this.btmRelogioEntrada.TabIndex = 32;
            this.btmRelogioEntrada.UseVisualStyleBackColor = false;
            this.btmRelogioEntrada.Click += new System.EventHandler(this.btmRelogioEntrada_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Estacionamento_Tech.Properties.Resources.servico_de_estacionamento;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1052, 497);
            this.Controls.Add(this.btmSalvarEntrada);
            this.Controls.Add(this.mskHoraEntrada);
            this.Controls.Add(this.lblHoraEntrada);
            this.Controls.Add(this.mskDataEntrada);
            this.Controls.Add(this.lblDataEntrada);
            this.Controls.Add(this.mskPlacaEntrada);
            this.Controls.Add(this.lblPlacaEntrada);
            this.Controls.Add(this.btmRelogioEntrada);
            this.Controls.Add(this.btmVoltarEntrada);
            this.Controls.Add(this.adicionarHorarioEntrada);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Veículo/ Horário Entrada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button adicionarHorarioEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btmVoltarEntrada;
        private System.Windows.Forms.Button btmSalvarEntrada;
        private System.Windows.Forms.MaskedTextBox mskHoraEntrada;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.MaskedTextBox mskDataEntrada;
        private System.Windows.Forms.Label lblDataEntrada;
        private System.Windows.Forms.MaskedTextBox mskPlacaEntrada;
        private System.Windows.Forms.Label lblPlacaEntrada;
        private System.Windows.Forms.Button btmRelogioEntrada;
    }
}
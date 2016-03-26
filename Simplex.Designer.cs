namespace Simplex
{
    partial class Simplex
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simplex));
            this.lblVFolga = new System.Windows.Forms.Label();
            this.lblVBasica = new System.Windows.Forms.Label();
            this.txtVBasica = new System.Windows.Forms.TextBox();
            this.gpVariaveis = new System.Windows.Forms.GroupBox();
            this.txtVFolga = new System.Windows.Forms.TextBox();
            this.gpButton = new System.Windows.Forms.GroupBox();
            this.btResultado = new System.Windows.Forms.Button();
            this.btLimparMatriz = new System.Windows.Forms.Button();
            this.btGerarMatriz = new System.Windows.Forms.Button();
            this.btInteracao = new System.Windows.Forms.Button();
            this.gpSimplex = new System.Windows.Forms.GroupBox();
            this.tabelaMatriz = new System.Windows.Forms.DataGridView();
            this.gpTipo = new System.Windows.Forms.GroupBox();
            this.rdMinimizacao = new System.Windows.Forms.RadioButton();
            this.rdMaximizacao = new System.Windows.Forms.RadioButton();
            this.lstResultado = new System.Windows.Forms.ListBox();
            this.gpResultado = new System.Windows.Forms.GroupBox();
            this.gpVariaveis.SuspendLayout();
            this.gpButton.SuspendLayout();
            this.gpSimplex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaMatriz)).BeginInit();
            this.gpTipo.SuspendLayout();
            this.gpResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVFolga
            // 
            this.lblVFolga.AutoSize = true;
            this.lblVFolga.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVFolga.Location = new System.Drawing.Point(18, 96);
            this.lblVFolga.Name = "lblVFolga";
            this.lblVFolga.Size = new System.Drawing.Size(110, 15);
            this.lblVFolga.TabIndex = 1;
            this.lblVFolga.Text = "Variáveis de Folga:";
            // 
            // lblVBasica
            // 
            this.lblVBasica.AutoSize = true;
            this.lblVBasica.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVBasica.Location = new System.Drawing.Point(18, 47);
            this.lblVBasica.Name = "lblVBasica";
            this.lblVBasica.Size = new System.Drawing.Size(107, 15);
            this.lblVBasica.TabIndex = 4;
            this.lblVBasica.Text = "Variáveis Básicas:";
            // 
            // txtVBasica
            // 
            this.txtVBasica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVBasica.Location = new System.Drawing.Point(134, 44);
            this.txtVBasica.Name = "txtVBasica";
            this.txtVBasica.Size = new System.Drawing.Size(72, 22);
            this.txtVBasica.TabIndex = 3;
            // 
            // gpVariaveis
            // 
            this.gpVariaveis.Controls.Add(this.txtVFolga);
            this.gpVariaveis.Controls.Add(this.txtVBasica);
            this.gpVariaveis.Controls.Add(this.lblVBasica);
            this.gpVariaveis.Controls.Add(this.lblVFolga);
            this.gpVariaveis.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpVariaveis.Location = new System.Drawing.Point(23, 25);
            this.gpVariaveis.Name = "gpVariaveis";
            this.gpVariaveis.Size = new System.Drawing.Size(332, 135);
            this.gpVariaveis.TabIndex = 10;
            this.gpVariaveis.TabStop = false;
            this.gpVariaveis.Text = "Quantidade de Variáveis";
            // 
            // txtVFolga
            // 
            this.txtVFolga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVFolga.Location = new System.Drawing.Point(134, 92);
            this.txtVFolga.Name = "txtVFolga";
            this.txtVFolga.Size = new System.Drawing.Size(72, 22);
            this.txtVFolga.TabIndex = 5;
            // 
            // gpButton
            // 
            this.gpButton.Controls.Add(this.btResultado);
            this.gpButton.Controls.Add(this.btLimparMatriz);
            this.gpButton.Controls.Add(this.btGerarMatriz);
            this.gpButton.Controls.Add(this.btInteracao);
            this.gpButton.Location = new System.Drawing.Point(23, 393);
            this.gpButton.Name = "gpButton";
            this.gpButton.Size = new System.Drawing.Size(570, 66);
            this.gpButton.TabIndex = 11;
            this.gpButton.TabStop = false;
            // 
            // btResultado
            // 
            this.btResultado.Location = new System.Drawing.Point(383, 22);
            this.btResultado.Name = "btResultado";
            this.btResultado.Size = new System.Drawing.Size(99, 23);
            this.btResultado.TabIndex = 14;
            this.btResultado.Text = "Gerar Resultados";
            this.btResultado.UseVisualStyleBackColor = true;
            this.btResultado.Click += new System.EventHandler(this.btResultado_Click);
            // 
            // btLimparMatriz
            // 
            this.btLimparMatriz.Location = new System.Drawing.Point(280, 22);
            this.btLimparMatriz.Name = "btLimparMatriz";
            this.btLimparMatriz.Size = new System.Drawing.Size(87, 23);
            this.btLimparMatriz.TabIndex = 13;
            this.btLimparMatriz.Text = "Limpar Matriz";
            this.btLimparMatriz.UseVisualStyleBackColor = true;
            this.btLimparMatriz.Click += new System.EventHandler(this.btLimparMatriz_Click);
            // 
            // btGerarMatriz
            // 
            this.btGerarMatriz.Location = new System.Drawing.Point(102, 22);
            this.btGerarMatriz.Name = "btGerarMatriz";
            this.btGerarMatriz.Size = new System.Drawing.Size(75, 23);
            this.btGerarMatriz.TabIndex = 11;
            this.btGerarMatriz.Text = "Gerar Matriz";
            this.btGerarMatriz.UseVisualStyleBackColor = true;
            this.btGerarMatriz.Click += new System.EventHandler(this.btGerarMatriz_Click);
            // 
            // btInteracao
            // 
            this.btInteracao.Location = new System.Drawing.Point(191, 22);
            this.btInteracao.Name = "btInteracao";
            this.btInteracao.Size = new System.Drawing.Size(75, 23);
            this.btInteracao.TabIndex = 12;
            this.btInteracao.Text = "Iteração";
            this.btInteracao.UseVisualStyleBackColor = true;
            this.btInteracao.Click += new System.EventHandler(this.btInteracao_Click);
            // 
            // gpSimplex
            // 
            this.gpSimplex.Controls.Add(this.tabelaMatriz);
            this.gpSimplex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpSimplex.Location = new System.Drawing.Point(23, 177);
            this.gpSimplex.Name = "gpSimplex";
            this.gpSimplex.Size = new System.Drawing.Size(570, 204);
            this.gpSimplex.TabIndex = 12;
            this.gpSimplex.TabStop = false;
            this.gpSimplex.Text = "Tabela Simplex";
            // 
            // tabelaMatriz
            // 
            this.tabelaMatriz.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.tabelaMatriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N1";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tabelaMatriz.DefaultCellStyle = dataGridViewCellStyle1;
            this.tabelaMatriz.Location = new System.Drawing.Point(10, 20);
            this.tabelaMatriz.Name = "tabelaMatriz";
            this.tabelaMatriz.Size = new System.Drawing.Size(550, 165);
            this.tabelaMatriz.TabIndex = 8;
            // 
            // gpTipo
            // 
            this.gpTipo.Controls.Add(this.rdMinimizacao);
            this.gpTipo.Controls.Add(this.rdMaximizacao);
            this.gpTipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpTipo.Location = new System.Drawing.Point(407, 25);
            this.gpTipo.Name = "gpTipo";
            this.gpTipo.Size = new System.Drawing.Size(186, 135);
            this.gpTipo.TabIndex = 13;
            this.gpTipo.TabStop = false;
            this.gpTipo.Text = "Tipo";
            // 
            // rdMinimizacao
            // 
            this.rdMinimizacao.AutoSize = true;
            this.rdMinimizacao.Location = new System.Drawing.Point(25, 93);
            this.rdMinimizacao.Name = "rdMinimizacao";
            this.rdMinimizacao.Size = new System.Drawing.Size(106, 20);
            this.rdMinimizacao.TabIndex = 3;
            this.rdMinimizacao.TabStop = true;
            this.rdMinimizacao.Text = "Minimização";
            this.rdMinimizacao.UseVisualStyleBackColor = true;
            // 
            // rdMaximizacao
            // 
            this.rdMaximizacao.AutoSize = true;
            this.rdMaximizacao.Location = new System.Drawing.Point(25, 42);
            this.rdMaximizacao.Name = "rdMaximizacao";
            this.rdMaximizacao.Size = new System.Drawing.Size(110, 20);
            this.rdMaximizacao.TabIndex = 2;
            this.rdMaximizacao.TabStop = true;
            this.rdMaximizacao.Text = "Maximização";
            this.rdMaximizacao.UseVisualStyleBackColor = true;
            // 
            // lstResultado
            // 
            this.lstResultado.FormatString = "N1";
            this.lstResultado.FormattingEnabled = true;
            this.lstResultado.ItemHeight = 16;
            this.lstResultado.Location = new System.Drawing.Point(26, 32);
            this.lstResultado.Name = "lstResultado";
            this.lstResultado.Size = new System.Drawing.Size(151, 372);
            this.lstResultado.TabIndex = 14;
            // 
            // gpResultado
            // 
            this.gpResultado.Controls.Add(this.lstResultado);
            this.gpResultado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpResultado.Location = new System.Drawing.Point(609, 25);
            this.gpResultado.Name = "gpResultado";
            this.gpResultado.Size = new System.Drawing.Size(200, 434);
            this.gpResultado.TabIndex = 15;
            this.gpResultado.TabStop = false;
            this.gpResultado.Text = "Resultado";
            // 
            // Simplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 479);
            this.Controls.Add(this.gpResultado);
            this.Controls.Add(this.gpTipo);
            this.Controls.Add(this.gpSimplex);
            this.Controls.Add(this.gpButton);
            this.Controls.Add(this.gpVariaveis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Simplex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simplex";
            this.gpVariaveis.ResumeLayout(false);
            this.gpVariaveis.PerformLayout();
            this.gpButton.ResumeLayout(false);
            this.gpSimplex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaMatriz)).EndInit();
            this.gpTipo.ResumeLayout(false);
            this.gpTipo.PerformLayout();
            this.gpResultado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVFolga;
        private System.Windows.Forms.Label lblVBasica;
        private System.Windows.Forms.TextBox txtVBasica;
        private System.Windows.Forms.GroupBox gpVariaveis;
        private System.Windows.Forms.GroupBox gpButton;
        private System.Windows.Forms.GroupBox gpSimplex;
        private System.Windows.Forms.GroupBox gpTipo;
        private System.Windows.Forms.Button btLimparMatriz;
        private System.Windows.Forms.Button btGerarMatriz;
        private System.Windows.Forms.Button btInteracao;
        private System.Windows.Forms.DataGridView tabelaMatriz;
        private System.Windows.Forms.RadioButton rdMinimizacao;
        private System.Windows.Forms.RadioButton rdMaximizacao;
        private System.Windows.Forms.TextBox txtVFolga;
        private System.Windows.Forms.Button btResultado;
        private System.Windows.Forms.ListBox lstResultado;
        private System.Windows.Forms.GroupBox gpResultado;
    }
}
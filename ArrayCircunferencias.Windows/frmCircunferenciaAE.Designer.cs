namespace ArrayCircunferencias.Windows
{
    partial class frmCircunferenciaAE
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtRadio = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            label2 = new Label();
            cboColores = new ComboBox();
            gbxBordes = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 47);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 0;
            label1.Text = "Medida del Radio";
            // 
            // txtRadio
            // 
            txtRadio.Location = new Point(165, 49);
            txtRadio.Name = "txtRadio";
            txtRadio.Size = new Size(151, 27);
            txtRadio.TabIndex = 1;
            txtRadio.TextChanged += txtRadio_TextChanged;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(148, 286);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(105, 88);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(311, 286);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 88);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 90);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 4;
            label2.Text = "Color Relleno";
            // 
            // cboColores
            // 
            cboColores.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColores.FormattingEnabled = true;
            cboColores.Location = new Point(165, 87);
            cboColores.Name = "cboColores";
            cboColores.Size = new Size(151, 28);
            cboColores.TabIndex = 5;
            // 
            // gbxBordes
            // 
            gbxBordes.Location = new Point(347, 49);
            gbxBordes.Name = "gbxBordes";
            gbxBordes.Size = new Size(189, 214);
            gbxBordes.TabIndex = 6;
            gbxBordes.TabStop = false;
            gbxBordes.Text = "Tipos de Bordes";
            // 
            // frmCircunferenciaAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 403);
            ControlBox = false;
            Controls.Add(gbxBordes);
            Controls.Add(cboColores);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtRadio);
            Controls.Add(label1);
            MaximumSize = new Size(600, 450);
            MinimumSize = new Size(600, 450);
            Name = "frmCircunferenciaAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCircunferenciaAE";
            Load += frmCircunferenciaAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRadio;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
        private ComboBox cboColores;
        private Label label2;
        private GroupBox gbxBordes;
    }
}
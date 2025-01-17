namespace finanzasApp
{
    partial class FormIndex
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
            dataGridResumen = new DataGridView();
            textMes = new TextBox();
            txtCantidadChaquetas = new TextBox();
            txtValorUnitario = new TextBox();
            btnAgregarIngreso = new Button();
            btnMostrarResumen = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnEliminarIngreso = new Button();
            btnActualizarIngreso = new Button();
            txtIdIngreso = new TextBox();
            Gastos = new Button();
            btnMostrarIngresos = new Button();
            dataGridIngresos = new DataGridView();
            btnAhorros = new Button();
            dataGridAhorros = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridResumen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridIngresos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAhorros).BeginInit();
            SuspendLayout();
            // 
            // dataGridResumen
            // 
            dataGridResumen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridResumen.Location = new Point(10, 137);
            dataGridResumen.Name = "dataGridResumen";
            dataGridResumen.Size = new Size(564, 143);
            dataGridResumen.TabIndex = 1;
            dataGridResumen.Visible = false;
            // 
            // textMes
            // 
            textMes.Location = new Point(36, 47);
            textMes.Name = "textMes";
            textMes.Size = new Size(100, 23);
            textMes.TabIndex = 1;
            // 
            // txtCantidadChaquetas
            // 
            txtCantidadChaquetas.Location = new Point(224, 47);
            txtCantidadChaquetas.Name = "txtCantidadChaquetas";
            txtCantidadChaquetas.Size = new Size(100, 23);
            txtCantidadChaquetas.TabIndex = 2;
            // 
            // txtValorUnitario
            // 
            txtValorUnitario.Location = new Point(408, 47);
            txtValorUnitario.Name = "txtValorUnitario";
            txtValorUnitario.Size = new Size(100, 23);
            txtValorUnitario.TabIndex = 3;
            // 
            // btnAgregarIngreso
            // 
            btnAgregarIngreso.Location = new Point(224, 96);
            btnAgregarIngreso.Name = "btnAgregarIngreso";
            btnAgregarIngreso.Size = new Size(101, 23);
            btnAgregarIngreso.TabIndex = 4;
            btnAgregarIngreso.Text = "Nuevo Ingreso";
            btnAgregarIngreso.UseVisualStyleBackColor = true;
            btnAgregarIngreso.Click += btnAgregarIngreso_Click;
            // 
            // btnMostrarResumen
            // 
            btnMostrarResumen.Location = new Point(422, 323);
            btnMostrarResumen.Name = "btnMostrarResumen";
            btnMostrarResumen.Size = new Size(75, 23);
            btnMostrarResumen.TabIndex = 5;
            btnMostrarResumen.Text = "Resumen";
            btnMostrarResumen.UseVisualStyleBackColor = true;
            btnMostrarResumen.Click += btnMostrarResumen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 22);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 6;
            label1.Text = "mes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 22);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 7;
            label2.Text = "cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(417, 22);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 8;
            label3.Text = "valor unitario ";
            // 
            // btnEliminarIngreso
            // 
            btnEliminarIngreso.Location = new Point(93, 395);
            btnEliminarIngreso.Name = "btnEliminarIngreso";
            btnEliminarIngreso.Size = new Size(75, 23);
            btnEliminarIngreso.TabIndex = 9;
            btnEliminarIngreso.Text = "Eliminar";
            btnEliminarIngreso.UseVisualStyleBackColor = true;
            btnEliminarIngreso.Click += btnEliminarIngreso_Click;
            // 
            // btnActualizarIngreso
            // 
            btnActualizarIngreso.Location = new Point(378, 395);
            btnActualizarIngreso.Name = "btnActualizarIngreso";
            btnActualizarIngreso.Size = new Size(75, 23);
            btnActualizarIngreso.TabIndex = 10;
            btnActualizarIngreso.Text = "Actualizar";
            btnActualizarIngreso.UseVisualStyleBackColor = true;
            btnActualizarIngreso.Click += btnActualizarIngreso_Click;
            // 
            // txtIdIngreso
            // 
            txtIdIngreso.Location = new Point(224, 395);
            txtIdIngreso.Name = "txtIdIngreso";
            txtIdIngreso.Size = new Size(100, 23);
            txtIdIngreso.TabIndex = 11;
            // 
            // Gastos
            // 
            Gastos.Location = new Point(36, 323);
            Gastos.Name = "Gastos";
            Gastos.Size = new Size(75, 23);
            Gastos.TabIndex = 12;
            Gastos.Text = "Gastos";
            Gastos.UseVisualStyleBackColor = true;
            Gastos.Click += BtnGastos_Click;
            // 
            // btnMostrarIngresos
            // 
            btnMostrarIngresos.Location = new Point(236, 323);
            btnMostrarIngresos.Name = "btnMostrarIngresos";
            btnMostrarIngresos.Size = new Size(75, 23);
            btnMostrarIngresos.TabIndex = 13;
            btnMostrarIngresos.Text = "Ingresos";
            btnMostrarIngresos.UseVisualStyleBackColor = true;
            btnMostrarIngresos.Click += BtnMostrarIngresos_Click;
            // 
            // dataGridIngresos
            // 
            dataGridIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridIngresos.Location = new Point(10, 137);
            dataGridIngresos.Name = "dataGridIngresos";
            dataGridIngresos.Size = new Size(564, 143);
            dataGridIngresos.TabIndex = 0;
            // 
            // btnAhorros
            // 
            btnAhorros.Location = new Point(515, 425);
            btnAhorros.Name = "btnAhorros";
            btnAhorros.Size = new Size(75, 23);
            btnAhorros.TabIndex = 14;
            btnAhorros.Text = "HRRS";
            btnAhorros.UseVisualStyleBackColor = true;
            btnAhorros.Click += btnAhorros_Click;
            // 
            // dataGridAhorros
            // 
            dataGridAhorros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAhorros.Location = new Point(82, 137);
            dataGridAhorros.Name = "dataGridAhorros";
            dataGridAhorros.RowTemplate.Height = 25;
            dataGridAhorros.Size = new Size(415, 143);
            dataGridAhorros.TabIndex = 15;
            // 
            // FormIndex
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 450);
            Controls.Add(dataGridAhorros);
            Controls.Add(btnAhorros);
            Controls.Add(dataGridIngresos);
            Controls.Add(btnMostrarIngresos);
            Controls.Add(Gastos);
            Controls.Add(txtIdIngreso);
            Controls.Add(btnActualizarIngreso);
            Controls.Add(btnEliminarIngreso);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnMostrarResumen);
            Controls.Add(btnAgregarIngreso);
            Controls.Add(txtValorUnitario);
            Controls.Add(txtCantidadChaquetas);
            Controls.Add(textMes);
            Controls.Add(dataGridResumen);
            Name = "FormIndex";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridResumen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridIngresos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAhorros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridResumen;
        private TextBox textMes;
        private TextBox txtCantidadChaquetas;
        private TextBox txtValorUnitario;
        private Button btnAgregarIngreso;
        private Button btnMostrarResumen;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnEliminarIngreso;
        private Button btnActualizarIngreso;
        private TextBox txtIdIngreso;
        private Button Gastos;
        private Button btnMostrarIngresos;
        private DataGridView dataGridIngresos;
        private Button btnAhorros;
        private DataGridView dataGridAhorros;
    }
}
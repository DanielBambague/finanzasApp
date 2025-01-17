namespace finanzasApp
{
    partial class FormGastos
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
            txtMes = new TextBox();
            txtDescripcion = new TextBox();
            txtValor = new TextBox();
            btnGuardar = new Button();
            dataGridViewGastos = new DataGridView();
            labelMes = new Label();
            labelDescripcion = new Label();
            labelValor = new Label();
            btnEliminar = new Button();
            btnActualizar = new Button();
            textEA = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGastos).BeginInit();
            SuspendLayout();
            // 
            // txtMes
            // 
            txtMes.Location = new Point(30, 50);
            txtMes.Name = "txtMes";
            txtMes.Size = new Size(100, 23);
            txtMes.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(150, 50);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(370, 50);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(100, 23);
            txtValor.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(500, 50);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Registrar Gasto";
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // dataGridViewGastos
            // 
            dataGridViewGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGastos.Location = new Point(30, 100);
            dataGridViewGastos.Name = "dataGridViewGastos";
            dataGridViewGastos.Size = new Size(570, 250);
            dataGridViewGastos.TabIndex = 7;
            // 
            // labelMes
            // 
            labelMes.Location = new Point(30, 30);
            labelMes.Name = "labelMes";
            labelMes.Size = new Size(100, 23);
            labelMes.TabIndex = 1;
            labelMes.Text = "Mes:";
            // 
            // labelDescripcion
            // 
            labelDescripcion.Location = new Point(150, 30);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(100, 23);
            labelDescripcion.TabIndex = 3;
            labelDescripcion.Text = "Descripción:";
            // 
            // labelValor
            // 
            labelValor.Location = new Point(370, 30);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(100, 23);
            labelValor.TabIndex = 5;
            labelValor.Text = "Valor:";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(83, 407);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminarGasto_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(500, 406);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizarGasto_Click;
            // 
            // textEA
            // 
            textEA.Location = new Point(288, 407);
            textEA.Name = "textEA";
            textEA.Size = new Size(100, 23);
            textEA.TabIndex = 10;
            // 
            // FormGastos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 472);
            Controls.Add(textEA);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(txtMes);
            Controls.Add(labelMes);
            Controls.Add(txtDescripcion);
            Controls.Add(labelDescripcion);
            Controls.Add(txtValor);
            Controls.Add(labelValor);
            Controls.Add(btnGuardar);
            Controls.Add(dataGridViewGastos);
            Name = "FormGastos";
            Text = "Gastos";
            Load += FormGastos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewGastos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        

        private TextBox txtMes;
        private TextBox txtDescripcion;
        private TextBox txtValor;
        private Button btnGuardar;
        private DataGridView dataGridViewGastos;
        private Label labelMes;
        private Label labelDescripcion;
        private Label labelValor;
        private Button btnEliminar;
        private Button btnActualizar;
        private TextBox textEA;
    }

    #endregion
}

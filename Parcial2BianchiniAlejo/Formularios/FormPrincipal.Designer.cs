namespace Formularios
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddPedido = new System.Windows.Forms.Button();
            this.txbTitulo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lvPedidosPendientes = new System.Windows.Forms.ListView();
            this.lvPedidosEntregados = new System.Windows.Forms.ListView();
            this.btnAleatorios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddPedido
            // 
            this.btnAddPedido.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPedido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnAddPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPedido.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnAddPedido.Location = new System.Drawing.Point(253, 410);
            this.btnAddPedido.Name = "btnAddPedido";
            this.btnAddPedido.Size = new System.Drawing.Size(344, 98);
            this.btnAddPedido.TabIndex = 30;
            this.btnAddPedido.Text = "Agregar nuevo Pedido";
            this.btnAddPedido.UseVisualStyleBackColor = false;
            this.btnAddPedido.Click += new System.EventHandler(this.btnAddPedido_Click);
            // 
            // txbTitulo
            // 
            this.txbTitulo.BackColor = System.Drawing.Color.PaleGreen;
            this.txbTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTitulo.CausesValidation = false;
            this.txbTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbTitulo.Enabled = false;
            this.txbTitulo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTitulo.Location = new System.Drawing.Point(31, 12);
            this.txbTitulo.Name = "txbTitulo";
            this.txbTitulo.ReadOnly = true;
            this.txbTitulo.Size = new System.Drawing.Size(363, 24);
            this.txbTitulo.TabIndex = 32;
            this.txbTitulo.TabStop = false;
            this.txbTitulo.Text = "Pedidos en Preparacion";
            this.txbTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CausesValidation = false;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(455, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(363, 24);
            this.textBox1.TabIndex = 33;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Pedidos Entregados";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lvPedidosPendientes
            // 
            this.lvPedidosPendientes.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lvPedidosPendientes.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPedidosPendientes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lvPedidosPendientes.HideSelection = false;
            this.lvPedidosPendientes.Location = new System.Drawing.Point(31, 42);
            this.lvPedidosPendientes.Name = "lvPedidosPendientes";
            this.lvPedidosPendientes.Size = new System.Drawing.Size(363, 343);
            this.lvPedidosPendientes.TabIndex = 37;
            this.lvPedidosPendientes.UseCompatibleStateImageBehavior = false;
            this.lvPedidosPendientes.View = System.Windows.Forms.View.List;
            // 
            // lvPedidosEntregados
            // 
            this.lvPedidosEntregados.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lvPedidosEntregados.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPedidosEntregados.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lvPedidosEntregados.HideSelection = false;
            this.lvPedidosEntregados.Location = new System.Drawing.Point(455, 42);
            this.lvPedidosEntregados.Name = "lvPedidosEntregados";
            this.lvPedidosEntregados.Size = new System.Drawing.Size(363, 343);
            this.lvPedidosEntregados.TabIndex = 38;
            this.lvPedidosEntregados.UseCompatibleStateImageBehavior = false;
            this.lvPedidosEntregados.View = System.Windows.Forms.View.List;
            // 
            // btnAleatorios
            // 
            this.btnAleatorios.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAleatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAleatorios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnAleatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAleatorios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAleatorios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnAleatorios.Location = new System.Drawing.Point(714, 413);
            this.btnAleatorios.Name = "btnAleatorios";
            this.btnAleatorios.Size = new System.Drawing.Size(104, 98);
            this.btnAleatorios.TabIndex = 39;
            this.btnAleatorios.Text = "Generar Pedidos Aleatorios";
            this.btnAleatorios.UseVisualStyleBackColor = false;
            this.btnAleatorios.Click += new System.EventHandler(this.btnAleatorios_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(852, 536);
            this.Controls.Add(this.btnAleatorios);
            this.Controls.Add(this.lvPedidosEntregados);
            this.Controls.Add(this.lvPedidosPendientes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txbTitulo);
            this.Controls.Add(this.btnAddPedido);
            this.Name = "FormPrincipal";
            this.Text = "Tablero de Pedidos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddPedido;
        private System.Windows.Forms.TextBox txbTitulo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView lvPedidosPendientes;
        private System.Windows.Forms.ListView lvPedidosEntregados;
        private System.Windows.Forms.Button btnAleatorios;
    }
}


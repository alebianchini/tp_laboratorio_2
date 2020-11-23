namespace Formularios
{
    partial class FormAltaIndumentaria
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbForCategory = new System.Windows.Forms.Label();
            this.lbForStock = new System.Windows.Forms.Label();
            this.lbForPrecio = new System.Windows.Forms.Label();
            this.lbForDesc = new System.Windows.Forms.Label();
            this.cbTalle = new System.Windows.Forms.ComboBox();
            this.txbStock = new System.Windows.Forms.TextBox();
            this.txbColor = new System.Windows.Forms.TextBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(335, 199);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(128, 43);
            this.btnAgregar.TabIndex = 23;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(118, 115);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(121, 20);
            this.txbPrecio.TabIndex = 21;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(118, 64);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(121, 20);
            this.txbDescripcion.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(152, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 24);
            this.label5.TabIndex = 28;
            this.label5.Text = "Nueva Indumentaria";
            // 
            // lbForCategory
            // 
            this.lbForCategory.AutoSize = true;
            this.lbForCategory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForCategory.Location = new System.Drawing.Point(291, 112);
            this.lbForCategory.Name = "lbForCategory";
            this.lbForCategory.Size = new System.Drawing.Size(45, 21);
            this.lbForCategory.TabIndex = 27;
            this.lbForCategory.Text = "Talle";
            // 
            // lbForStock
            // 
            this.lbForStock.AutoSize = true;
            this.lbForStock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForStock.Location = new System.Drawing.Point(283, 61);
            this.lbForStock.Name = "lbForStock";
            this.lbForStock.Size = new System.Drawing.Size(53, 21);
            this.lbForStock.TabIndex = 26;
            this.lbForStock.Text = "Stock";
            // 
            // lbForPrecio
            // 
            this.lbForPrecio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForPrecio.Location = new System.Drawing.Point(27, 102);
            this.lbForPrecio.Name = "lbForPrecio";
            this.lbForPrecio.Size = new System.Drawing.Size(85, 55);
            this.lbForPrecio.TabIndex = 25;
            this.lbForPrecio.Text = "Precio p/Unidad";
            // 
            // lbForDesc
            // 
            this.lbForDesc.AutoSize = true;
            this.lbForDesc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForDesc.Location = new System.Drawing.Point(12, 63);
            this.lbForDesc.Name = "lbForDesc";
            this.lbForDesc.Size = new System.Drawing.Size(100, 21);
            this.lbForDesc.TabIndex = 24;
            this.lbForDesc.Text = "Descripcion";
            // 
            // cbTalle
            // 
            this.cbTalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTalle.FormattingEnabled = true;
            this.cbTalle.Location = new System.Drawing.Point(342, 115);
            this.cbTalle.Name = "cbTalle";
            this.cbTalle.Size = new System.Drawing.Size(121, 21);
            this.cbTalle.TabIndex = 22;
            // 
            // txbStock
            // 
            this.txbStock.Location = new System.Drawing.Point(342, 64);
            this.txbStock.Name = "txbStock";
            this.txbStock.Size = new System.Drawing.Size(121, 20);
            this.txbStock.TabIndex = 20;
            // 
            // txbColor
            // 
            this.txbColor.Location = new System.Drawing.Point(118, 167);
            this.txbColor.Name = "txbColor";
            this.txbColor.Size = new System.Drawing.Size(121, 20);
            this.txbColor.TabIndex = 29;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.Location = new System.Drawing.Point(61, 166);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(51, 21);
            this.lbColor.TabIndex = 30;
            this.lbColor.Text = "Color";
            // 
            // FormAltaIndumentaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(180)))), ((int)(((byte)(127)))));
            this.ClientSize = new System.Drawing.Size(524, 254);
            this.Controls.Add(this.txbColor);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbForCategory);
            this.Controls.Add(this.lbForStock);
            this.Controls.Add(this.lbForPrecio);
            this.Controls.Add(this.lbForDesc);
            this.Controls.Add(this.cbTalle);
            this.Controls.Add(this.txbStock);
            this.Name = "FormAltaIndumentaria";
            this.Text = "FormAltaIndumentaria";
            this.Load += new System.EventHandler(this.FormAltaIndumentaria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbForCategory;
        private System.Windows.Forms.Label lbForStock;
        private System.Windows.Forms.Label lbForPrecio;
        private System.Windows.Forms.Label lbForDesc;
        private System.Windows.Forms.ComboBox cbTalle;
        private System.Windows.Forms.TextBox txbStock;
        private System.Windows.Forms.TextBox txbColor;
        private System.Windows.Forms.Label lbColor;
    }
}
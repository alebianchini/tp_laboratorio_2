namespace Formularios
{
    partial class FormAltaAlimento
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
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.txbStock = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(181, 166);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(128, 43);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(109, 124);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(121, 20);
            this.txbPrecio.TabIndex = 11;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(109, 73);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(121, 20);
            this.txbDescripcion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(159, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nuevo Alimento";
            // 
            // lbForCategory
            // 
            this.lbForCategory.AutoSize = true;
            this.lbForCategory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForCategory.Location = new System.Drawing.Point(236, 121);
            this.lbForCategory.Name = "lbForCategory";
            this.lbForCategory.Size = new System.Drawing.Size(91, 21);
            this.lbForCategory.TabIndex = 17;
            this.lbForCategory.Text = "Categoría";
            // 
            // lbForStock
            // 
            this.lbForStock.AutoSize = true;
            this.lbForStock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForStock.Location = new System.Drawing.Point(274, 70);
            this.lbForStock.Name = "lbForStock";
            this.lbForStock.Size = new System.Drawing.Size(53, 21);
            this.lbForStock.TabIndex = 16;
            this.lbForStock.Text = "Stock";
            // 
            // lbForPrecio
            // 
            this.lbForPrecio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForPrecio.Location = new System.Drawing.Point(18, 111);
            this.lbForPrecio.Name = "lbForPrecio";
            this.lbForPrecio.Size = new System.Drawing.Size(85, 55);
            this.lbForPrecio.TabIndex = 15;
            this.lbForPrecio.Text = "Precio p/Unidad";
            // 
            // lbForDesc
            // 
            this.lbForDesc.AutoSize = true;
            this.lbForDesc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForDesc.Location = new System.Drawing.Point(3, 72);
            this.lbForDesc.Name = "lbForDesc";
            this.lbForDesc.Size = new System.Drawing.Size(100, 21);
            this.lbForDesc.TabIndex = 14;
            this.lbForDesc.Text = "Descripcion";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(333, 124);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbCategoria.TabIndex = 12;
            // 
            // txbStock
            // 
            this.txbStock.Location = new System.Drawing.Point(333, 73);
            this.txbStock.Name = "txbStock";
            this.txbStock.Size = new System.Drawing.Size(121, 20);
            this.txbStock.TabIndex = 10;
            // 
            // FormAltaAlimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(488, 232);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbForCategory);
            this.Controls.Add(this.lbForStock);
            this.Controls.Add(this.lbForPrecio);
            this.Controls.Add(this.lbForDesc);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.txbStock);
            this.Name = "FormAltaAlimento";
            this.Text = "Alta Alimento";
            this.Load += new System.EventHandler(this.FormAltaAlimento_Load);
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
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.TextBox txbStock;
    }
}
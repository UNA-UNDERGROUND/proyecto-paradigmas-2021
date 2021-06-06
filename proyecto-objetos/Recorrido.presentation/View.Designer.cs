
namespace proyectoParadigmas.Recorrido.presentation
{
    partial class View
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
            this.Tablero = new System.Windows.Forms.DataGridView();
            this.botonSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).BeginInit();
            this.SuspendLayout();
            // 
            // Tablero
            // 
            this.Tablero.AllowUserToAddRows = false;
            this.Tablero.AllowUserToDeleteRows = false;
            this.Tablero.AllowUserToResizeColumns = false;
            this.Tablero.AllowUserToResizeRows = false;
            this.Tablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tablero.ColumnHeadersVisible = false;
            this.Tablero.Location = new System.Drawing.Point(12, 12);
            this.Tablero.Name = "Tablero";
            this.Tablero.ReadOnly = true;
            this.Tablero.RowHeadersVisible = false;
            this.Tablero.RowHeadersWidth = 5;
            this.Tablero.Size = new System.Drawing.Size(936, 924);
            this.Tablero.TabIndex = 0;
            // 
            // botonSiguiente
            // 
            this.botonSiguiente.Location = new System.Drawing.Point(1065, 222);
            this.botonSiguiente.Name = "botonSiguiente";
            this.botonSiguiente.Size = new System.Drawing.Size(75, 23);
            this.botonSiguiente.TabIndex = 1;
            this.botonSiguiente.Text = "Siguiente";
            this.botonSiguiente.UseVisualStyleBackColor = true;
            this.botonSiguiente.Click += new System.EventHandler(this.botonSiguiente_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 849);
            this.Controls.Add(this.botonSiguiente);
            this.Controls.Add(this.Tablero);
            this.Name = "View";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Tablero;
        private System.Windows.Forms.Button botonSiguiente;
    }
}
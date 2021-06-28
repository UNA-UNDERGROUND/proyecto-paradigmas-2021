
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tablero = new System.Windows.Forms.DataGridView();
            this.botonSiguiente = new System.Windows.Forms.Button();
            this.terminar = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Tablero.DefaultCellStyle = dataGridViewCellStyle1;
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
            // terminar
            // 
            this.terminar.Location = new System.Drawing.Point(1065, 268);
            this.terminar.Name = "terminar";
            this.terminar.Size = new System.Drawing.Size(75, 23);
            this.terminar.TabIndex = 2;
            this.terminar.Text = "Terminar";
            this.terminar.UseVisualStyleBackColor = true;
            this.terminar.Click += new System.EventHandler(this.terminar_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 849);
            this.Controls.Add(this.terminar);
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
        private System.Windows.Forms.Button terminar;
    }
}
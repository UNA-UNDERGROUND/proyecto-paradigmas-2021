
namespace proyectoParadigmas.Menu.Presentation
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inicialX = new System.Windows.Forms.TextBox();
            this.inicialY = new System.Windows.Forms.TextBox();
            this.dimension = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Solucion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dimension";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Menu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Casilla primaria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "X: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Y:";
            // 
            // inicialX
            // 
            this.inicialX.Location = new System.Drawing.Point(128, 183);
            this.inicialX.Name = "inicialX";
            this.inicialX.Size = new System.Drawing.Size(100, 20);
            this.inicialX.TabIndex = 6;
            this.inicialX.Text = "0";
            // 
            // inicialY
            // 
            this.inicialY.Location = new System.Drawing.Point(128, 215);
            this.inicialY.Name = "inicialY";
            this.inicialY.Size = new System.Drawing.Size(100, 20);
            this.inicialY.TabIndex = 7;
            this.inicialY.Text = "0";
            // 
            // dimension
            // 
            this.dimension.Location = new System.Drawing.Point(128, 105);
            this.dimension.Name = "dimension";
            this.dimension.Size = new System.Drawing.Size(100, 20);
            this.dimension.TabIndex = 8;
            this.dimension.Text = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tipo de solucion:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Solucion
            // 
            this.Solucion.FormattingEnabled = true;
            this.Solucion.Items.AddRange(new object[] {
            "Backtracking",
            "WarnsDorff"});
            this.Solucion.Location = new System.Drawing.Point(128, 252);
            this.Solucion.Name = "Solucion";
            this.Solucion.Size = new System.Drawing.Size(121, 21);
            this.Solucion.TabIndex = 10;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 438);
            this.Controls.Add(this.Solucion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dimension);
            this.Controls.Add(this.inicialY);
            this.Controls.Add(this.inicialX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "View";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inicialX;
        private System.Windows.Forms.TextBox inicialY;
        private System.Windows.Forms.TextBox dimension;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Solucion;
    }
}
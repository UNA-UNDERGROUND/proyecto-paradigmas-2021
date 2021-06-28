using proyectoParadigmas.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoParadigmas.Recorrido.presentation
{
    public partial class View : Form
    {

        private Controller controller;
        private Model model;
        private int cont;
        private int xActual;
        private int yActual;
        public View(Controller c, Model m)
        {
            model = m;
            cont = model.ListaDeSaltos.Count - 1; 
            xActual = ((SaltoDeCaballo)model.ListaDeSaltos[cont]).X;
            yActual = ((SaltoDeCaballo)model.ListaDeSaltos[cont]).Y;
           
            controller = c;
            
            InitializeComponent();
        }

        public void llenarDataGrid()
        {


            int dim = controller.Tablero.Dimencion;
            

            if (Tablero.Columns.Count < dim)
            {
                for (int x = 0; x < dim; x++)
                {
                    Tablero.Columns.Add(Convert.ToString(x), "Habitacion " + Convert.ToString(x));
                    Tablero.Columns[x].Width = 100;
                }
            }
            for (int x = 0; x < dim; x++)
            {
                if (Tablero.Rows.Count < dim)
                {
                    Tablero.Rows.Add();
                    Tablero.Rows[x].Height = 100;
                }
                for (int y = 0; y < dim; y++)
                {
                    if( (x + y) % 2 == 0)
                    {
                        Tablero.Rows[x].Cells[y].Style.BackColor = Color.White;
                    }
                    else
                    {
                        Tablero.Rows[x].Cells[y].Style.BackColor = Color.Brown;
                    }
                    
                }
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            llenarDataGrid();
            Tablero.Rows[xActual].Cells[yActual].Value = "🐎";

        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            cambiarPosFicha();
        }

        public void cambiarPosFicha()
        {
            if (cont > 0)
            {
                Tablero.Rows[xActual].Cells[yActual].Value = (model.ListaDeSaltos.Count - cont);
                cont--;

                xActual = ((SaltoDeCaballo)model.ListaDeSaltos[cont]).X;
                yActual = ((SaltoDeCaballo)model.ListaDeSaltos[cont]).Y;


                Tablero.Rows[xActual].Cells[yActual].Value = "🐎";
            }


        }

        private void terminar_Click(object sender, EventArgs e)
        {

            while (cont > 0)
            {
                Tablero.Rows[xActual].Cells[yActual].Value = (model.ListaDeSaltos.Count - cont);
                cont--;

                xActual = ((SaltoDeCaballo)model.ListaDeSaltos[cont]).X;
                yActual = ((SaltoDeCaballo)model.ListaDeSaltos[cont]).Y;


                Tablero.Rows[xActual].Cells[yActual].Value = "🐎";
            }

        }
    }
}

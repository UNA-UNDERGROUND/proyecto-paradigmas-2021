using proyectoParadigmas.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoParadigmas.Recorrido.presentation
{
    public class Controller
    {

        private Tablero tablero;
        private Model model;
        private View view;
        private Metodo metodo;

        private int x;
        private int y;
        int dimencion;



        public Tablero Tablero { get => tablero; set => tablero = value; }

        public Controller(int xAux, int yAux, int dAux, int t)
        {
            model = new Model();

            x = xAux;
            y = yAux;
            dimencion = dAux;
           
            if(t == 0)
            {
                metodo = new Recursivo(x,y,dimencion);
            }
            else
            {
                metodo = new WarnsDorff(x, y, dimencion);
            }

            metodo.obtenerRespuesta();
            tablero = new Tablero(dimencion);
            view = new View(this, model);

        }

        public void show()
        {
            
            view.ShowDialog();
        }


        



    }
}
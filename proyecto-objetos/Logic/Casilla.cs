using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoParadigmas.Logic
{
    public class Casilla
    {

        private bool visitada;//es "true" si ya la casilla es visitada por el caballo
        private bool actual;// es "true" en el caso que el caballo este en ella, nos ayudara a mostrar el caballo o el numero de la posicion
        private int posicion; // guarda la posicion de la lista en el cual fue visitada

        public Casilla()
        {
            visitada = false;
            actual = false;
            posicion = 0;
        }

        public bool Visitada { get => visitada; set => visitada = value; }
        public bool Actual { get => actual; set => actual = value; }
        public int Posicion { get => posicion; set => posicion = value; }


        public void esOcupada(int aux)
        {
            posicion = aux;
            actual = true;
            visitada = true;
        }


    }
}

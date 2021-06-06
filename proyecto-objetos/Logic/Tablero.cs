using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoParadigmas.Logic
{
    public class Tablero
    {

        private Casilla[,] matriz;
        private int dimencion;
        private int cantTotal;

        public Tablero(int dim)
        {
            dimencion = dim;
            cantTotal = dim * dim;
            matriz = new Casilla[dim, dim];
            inicializarCasillas();


        }

        public Casilla[,] Matriz { get => matriz; set => matriz = value; }
        public int Dimencion { get => dimencion; set => dimencion = value; }
        public int CantTotal { get => cantTotal; set => cantTotal = value; }

        public Casilla getCasillaEsp(int x, int y)
        {
            return matriz[x, y];
        }

        public void inicializarCasillas()
        {
            for (int i = 0; i < dimencion; i++)
            {
                for (int j = 0; j < dimencion; j++)
                {
                    matriz[i, j] = new Casilla();
                }
            }
        }
    }
}

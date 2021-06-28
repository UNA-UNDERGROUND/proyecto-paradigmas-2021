using proyectoParadigmas.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proyectoParadigmas.Logic
{
    public class WarnsDorff : Metodo
    {
        private SaltoDeCaballo[] listaDeSaltos;
        private ArrayList lista; // se va a guardar la lista de saltos correctos, para luego ser mostrada en el view
        static readonly int[] cx = { 1, 1, 2, 2, -1, -1, -2, -2 }; //Lista de movimientos posibles en el eje X
        static readonly int[] cy = { 2, -2, 1, -1, 2, -2, 1, -1 }; //Lista de movimientos posibles en el eje Y
        private int N;
        private int dim;
        private int xp;
        private int yp;
        Random r;


        public WarnsDorff(int x, int y, int d)
        {
            xp = x;
            yp = y;
            dim = d;
            listaDeSaltos = new SaltoDeCaballo[d * d];
            lista = ListaDeSoluciones.getInstance().Lista;
            r = new Random();
            N = 8;

        }



        bool limits(int x, int y)// calcula que el siguiente salto este dentro de la matriz
        {
            return ((x >= 0 && y >= 0) && (x < dim && y < dim));
        }


        bool esVacio(int[] a, int x, int y)// comprueba si es un salto es valido o si esta Vacio
        {
            return (limits(x, y)) && (a[y * dim + x] < 0);
        }

        int saltosValidos(int[] a, int x, int y)// devuelve la cantidad de saltos validos
        {
            int count = 0;
            for (int i = 0; i < N; ++i)
                if (esVacio(a, (x + cx[i]), (y + cy[i])))
                    count++;

            return count;
        }

        unsafe bool nextMove(int[] a, int* x, int* y)//elige el siguiente salto posible, si no lo hay retorna false
        {
            int min_deg_idx = -1, c, min_deg = (dim + 1), nx, ny;


            int start = r.Next(N);
            for (int count = 0; count < dim; ++count)
            {
                int i = (start + count) % N;
                nx = *x + cx[i];
                ny = *y + cy[i];
                if ((esVacio(a, nx, ny)) &&
                    (c = saltosValidos(a, nx, ny)) < min_deg)
                {
                    min_deg_idx = i;
                    min_deg = c;
                }
            }


            if (min_deg_idx == -1)
                return false;


            nx = *x + cx[min_deg_idx];
            ny = *y + cy[min_deg_idx];


            a[ny * dim + nx] = a[(*y) * dim + (*x)] + 1;


            *x = nx;
            *y = ny;

            return true;
        }

        void print(int[] a) // es el metodo encargado de pasar la solucion, al formato en el cual lo pueda leer la vista
        {
            for (int i = 0; i < dim; ++i)
            {
                for (int j = 0; j < dim; ++j)
                {
                    listaDeSaltos[a[j * dim + i] - 1] = new SaltoDeCaballo(i, j, 0);
                }

            }

            for (int i = ((dim * dim) - 1); i >= 0; --i)
            {
                lista.Add(listaDeSaltos[i]);

            }

        }

        bool esCicloCerrado(int x, int y, int xx, int yy)
        {
            for (int i = 0; i < dim; ++i)
                if (((x + cx[i]) == xx) && ((y + cy[i]) == yy))
                    return true;

            return false;
        }


        unsafe bool findClosedTour()
        {
            int[] a = new int[(dim * dim)];
            for (int i = 0; i < dim * dim; ++i)
                a[i] = -1;

            int sx = xp;
            int sy = yp;


            int x = sx, y = sy;
            a[y * dim + x] = 1; // Mark first move.


            for (int i = 0; i < (dim * dim) - 1; ++i)
                if (nextMove(a, &x, &y) == false)
                    return false;


            if (!esCicloCerrado(x, y, sx, sy))
                return false;

            print(a);
            return true;
        }


        public override void obtenerRespuesta()
        {

            while (!findClosedTour())
            {

                ;
            }


        }
    }
}

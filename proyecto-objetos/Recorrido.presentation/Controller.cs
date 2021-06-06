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

        private int x;
        private int y;
        int dimencion;
        int cantTotal;

        int numeroAfuera = 0;
        int numeroAdentro = 0;

        public Tablero Tablero { get => tablero; set => tablero = value; }

        public Controller(int xAux, int yAux, int dAux)
        {
            model = new Model();

           

            x = xAux;
            y = yAux;
            dimencion = dAux;
            cantTotal = dAux * dAux;
            tablero = new Tablero(dimencion);

            
            tablero.Matriz[x, y].Visitada = true;

            obtenerRecorrido(new SaltoDeCaballo(xAux, yAux, 0)); 
   
            model.ListaDeSaltos.Add(new SaltoDeCaballo(xAux, yAux, 0));

            view = new View(this, model);


        }

        public void show()
        {
            
            view.ShowDialog();
        }


        public bool validarSalto(SaltoDeCaballo s)
        {
            if (s.X >= dimencion || s.Y >= dimencion || s.X < 0 || s.Y < 0)
            {
                return false;
            }
            else
            {
                if (tablero.Matriz[s.X, s.Y].Visitada == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public bool obtenerRecorrido(SaltoDeCaballo s) 
        {

            int xAux = s.X;
            int yAux = s.Y;
            int cAux = s.CantSaltos;
            ArrayList validos = new ArrayList();
            SaltoDeCaballo sa1 = new SaltoDeCaballo(xAux, yAux, cAux);

            if (s.CantSaltos == (cantTotal - 2))
            {
                Console.WriteLine(s.X + " " + s.Y+ "menos 2");

            }

            if (s.CantSaltos == (cantTotal - 1))
            {
                Console.WriteLine(s.X + " " + s.Y + "menos 1");
                tablero.Matriz[x, y].Visitada = false;
            }
            else
            {
                
                tablero.Matriz[x, y].Visitada = true;
            }
            if (validarSalto(sa1.saltoTipo1(sa1)))
            {
                validos.Add(sa1);
            }
            SaltoDeCaballo sa2 = new SaltoDeCaballo(xAux, yAux, cAux);
            if (validarSalto(sa2.saltoTipo2(sa2)))
            {
                validos.Add(sa2);
            }
            SaltoDeCaballo sa3 = new SaltoDeCaballo(xAux, yAux, cAux);
            if (validarSalto(sa3.saltoTipo3(sa3)))
            {
                validos.Add(sa3);
            }
            SaltoDeCaballo sa4 = new SaltoDeCaballo(xAux, yAux, cAux);
            if (validarSalto(sa4.saltoTipo4(sa4)))
            {
                validos.Add(sa4);
            }
            SaltoDeCaballo sa5 = new SaltoDeCaballo(xAux, yAux, cAux);
            if (validarSalto(sa5.saltoTipo5(sa5)))
            {
                validos.Add(sa5);
            }
            SaltoDeCaballo sa6 = new SaltoDeCaballo(xAux, yAux, cAux);
            if (validarSalto(sa6.saltoTipo6(sa6)))
            {
                validos.Add(sa6);
            }
            SaltoDeCaballo sa7 = new SaltoDeCaballo(xAux, yAux, cAux);
            if (validarSalto(sa7.saltoTipo7(sa7)))
            {
                validos.Add(sa7);
            }
            SaltoDeCaballo sa8 = new SaltoDeCaballo(xAux, yAux, cAux);
            if (validarSalto(sa8.saltoTipo8(sa8)))
            {
                validos.Add(sa8);
            }



            while (s.CantSaltos < (cantTotal  ) && validos.Count > 0)//while (s.CantSaltos < (cantTotal - 1) && validos.Count > 0)
            {

                for (int i = 0; i < validos.Count; i++)
                {

                   
                    SaltoDeCaballo posibleSalto = (SaltoDeCaballo)validos[i];
                    //Si la casilla del nuevo estado no esta visitada
                    if (!tablero.Matriz[posibleSalto.X, posibleSalto.Y].Visitada)
                    {
                        tablero.Matriz[posibleSalto.X, posibleSalto.Y].Visitada = true;
                        if (s.CantSaltos < (cantTotal ))
                        {
                            //Recursividad Backtracking
                            if (!obtenerRecorrido(posibleSalto))
                            {
                                tablero.Matriz[posibleSalto.X, posibleSalto.Y].Visitada = false;
                                validos.RemoveAt(i);
                                
                            }
                            else
                            {
                                
                                model.ListaDeSaltos.Add(validos[i]);
                                s.CantSaltos = cantTotal;
                                validos.Clear();
                                break;
                            }
                        }
                    }
                }
            }

            if (s.CantSaltos == cantTotal)//if (s.CantSaltos == cantTotal - 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }



    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoParadigmas.Data
{
    public class ListaDeSoluciones
    {
        private ArrayList lista;
        private static ListaDeSoluciones instance = null;


        public ListaDeSoluciones()
        {
            lista = new ArrayList();
        }

        public static ListaDeSoluciones getInstance()
        {
            if (instance == null)
            {
                instance = new ListaDeSoluciones();
            }
            return instance;
        }

        public ArrayList Lista { get => lista; set => lista = value; }

    }
}

using proyectoParadigmas.Menu.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoParadigmas
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            int aux = 0;

            Controller controller = new Controller();
            controller.show();

        }
    }
}

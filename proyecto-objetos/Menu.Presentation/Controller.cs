using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoParadigmas.Menu.Presentation
{
    public class Controller
    {
        private Model model;
        private View view;
        private Recorrido.presentation.Controller recoController;

        public Controller()
        {
            model = new Model();
            view = new View(this, model);

        }

        public void recorridoShow(int x, int y, int d, int t)
        {

            recoController = new Recorrido.presentation.Controller(y, x, d, t);
            recoController.show();


        }

        public void show()
        {
            Application.Run(view);
        }

    }
}

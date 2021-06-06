using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoParadigmas.Menu.Presentation
{
    public partial class View : Form
    {

        Model model;
        Controller controller;
        public View(Controller c, Model m)
        {
            model = m;
            controller = c;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(inicialX.Text);
            int y = int.Parse(inicialY.Text);
            int d = int.Parse(dimension.Text);

            controller.recorridoShow(x, y, d);

        }
    }
}

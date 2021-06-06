using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoParadigmas.Logic
{
    public class SaltoDeCaballo
    {

        private int x;
        private int y;
        private int cantSaltos = 0;

        public SaltoDeCaballo()
        {
            x = 0;
            y = 0;
            cantSaltos = 0;
        }

        public SaltoDeCaballo(int x, int y, int cantSaltos)
        {
            this.x = x;
            this.y = y;
            this.cantSaltos = cantSaltos;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int CantSaltos { get => cantSaltos; set => cantSaltos = value; }

        public SaltoDeCaballo saltoTipo1(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X - 1;
            s.Y = s.Y + 2;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }

        public SaltoDeCaballo saltoTipo2(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X - 2;
            s.Y = s.Y + 1;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }

        public SaltoDeCaballo saltoTipo3(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X - 2;
            s.Y = s.Y - 1;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }

        public SaltoDeCaballo saltoTipo4(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X - 1;
            s.Y = s.Y - 2;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }

        public SaltoDeCaballo saltoTipo5(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X + 1;
            s.Y = s.Y - 2;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }

        public SaltoDeCaballo saltoTipo6(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X + 2;
            s.Y = s.Y - 1;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }

        public SaltoDeCaballo saltoTipo7(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X + 2;
            s.Y = s.Y + 1;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }

        public SaltoDeCaballo saltoTipo8(SaltoDeCaballo s)
        {
            s.cantSaltos++;
            s.X = s.X + 1;
            s.Y = s.Y + 2;
            return new SaltoDeCaballo(X, Y, cantSaltos);
        }


    }

}


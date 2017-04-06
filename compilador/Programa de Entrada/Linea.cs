using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compilador.Programa_de_Entrada
{
    class Linea
    {
        public int Numero;
        public string Contenido;

        public Linea()
        {

        }
        public Linea(int numeroLinea, string contenido)
        {
            this.Numero = numeroLinea;
            this.Contenido = contenido;
        }

        public int getNumeroLinea()
        {
            return this.Numero;
        }

        public string getContenido()
        {
            return this.Contenido;
        }
    }
}

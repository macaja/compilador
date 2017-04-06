using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compilador.Analisis_Lexico
{
    class ComponenteLexico
    {
        public int numerolinea;
        public int posicionInicialLinea;
        public int posicionFinalLinea;
        public string lexema;
        public string categoria;

        public ComponenteLexico()
        {

        }

        private ComponenteLexico(int numeroLinea, int posicionInicialLinea, int posicionFinalLinea, string Lexema, string categoria)
        {
            this.numerolinea = numeroLinea;
            this.posicionInicialLinea = posicionInicialLinea;
            this.posicionFinalLinea = posicionFinalLinea;
            this.lexema = Lexema;
            this.categoria = categoria;

        }
        public static ComponenteLexico CREATE(int numeroLinea, int posicionInicialLinea, string Lexema, string categoria)
        {
            return new ComponenteLexico(numeroLinea, posicionInicialLinea, (posicionInicialLinea + Lexema.Length), Lexema, categoria);

        }

        public int getNumerolinea()
        {
            return numerolinea;
        }

        public int getPosicionInicialLinea()
        {
            return posicionInicialLinea;
        }


        public int getPosicionFinalLinea()
        {
            return posicionFinalLinea;
        }

        public String getLexema()
        {
            return lexema;
        }

        public String getCategoria()
        {
            return categoria;
        }
    }
}

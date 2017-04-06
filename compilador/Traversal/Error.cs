using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compilador.Traversal
{
    class Error
    {
        public int numerolinea;
        public int posicionInicialLinea;
        public int posicionFinalLinea;
        public string lexema;
        public string MensajeError;
        public string TipoError;


        private Error(int numeroLinea, int posicionInicialLinea, int posicionFinalLinea, string Lexema, string MensajeError, string TipoError)
        {
            this.numerolinea = numeroLinea;
            this.posicionInicialLinea = posicionInicialLinea;
            this.posicionFinalLinea = posicionFinalLinea;
            this.lexema = Lexema;
            this.MensajeError = MensajeError;
            this.TipoError = TipoError;


        }
        public static Error CREATE(int numeroLinea, int posicionInicialLinea, string Lexema, string MensajeError, string TipoError)
        {
            return new Error(numeroLinea, posicionInicialLinea, (posicionInicialLinea + Lexema.Length), Lexema, MensajeError, TipoError);

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

        public String getMensajeError()
        {
            return MensajeError;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compilador.Analisis_Lexico;
using compilador.Traversal;

namespace compilador.Traversal
{
    class TablaPalabrasReservadas
    {
        private static TablaPalabrasReservadas INSTANCIA = new TablaPalabrasReservadas();
        private Dictionary<string, ComponenteLexico> mapaPalabrasReservadas = new Dictionary<string, ComponenteLexico>();

        private TablaPalabrasReservadas() { }
        public static TablaPalabrasReservadas obtenerTablaPalabrasReservadas()
        {
            return INSTANCIA;
        }

        private void Inicializar()
        {
            mapaPalabrasReservadas.Add("PARA", ComponenteLexico.CREATE(0, 0, "PARA", "PALABRA RESERVADA PARA"));
            mapaPalabrasReservadas.Add("SI", ComponenteLexico.CREATE(0, 0, "SI", "PALABRA RESERVADA SI"));
            mapaPalabrasReservadas.Add("ENTONCES", ComponenteLexico.CREATE(0, 0, "ENTONCES", "PALABRA RESERVADA ENTONCES"));
        }
        public Boolean EsPalabraReservada(string lexema)
        {
            return mapaPalabrasReservadas.ContainsKey(lexema);
        }
        public ComponenteLexico ObtenerPalabraReservada(String Lexema)
        {

            return mapaPalabrasReservadas[Lexema];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compilador.Analisis_Lexico;

namespace compilador.Tabla_Simbolos
{
    class TablaSimbolos
    {
        private static TablaSimbolos INSTANCIA = new TablaSimbolos();
        private Dictionary<string, List<ComponenteLexico>> mapaSimbolos = new Dictionary<string, List<ComponenteLexico>>();
        private TablaSimbolos() { }

        public static TablaSimbolos obtenerTablaSimbolos()
        {
            return INSTANCIA;
        }

        public void AgregarSimbolo(ComponenteLexico componente)
        {
            if (mapaSimbolos.ContainsKey(componente.lexema)) mapaSimbolos[componente.lexema].Add(componente);
            else
            {
                List<ComponenteLexico> lista = new List<ComponenteLexico>();
                lista.Add(componente);
                mapaSimbolos.Add(componente.lexema, lista);
            }
        }
    }
}

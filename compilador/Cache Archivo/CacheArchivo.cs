using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compilador.Programa_de_Entrada;

namespace compilador.Cache_Archivo
{
    class CacheArchivo
    {
        private static CacheArchivo INSTANCIA = new CacheArchivo();

        private CacheArchivo() { }
        private List<Linea> listaLineas = new List<Linea>();

        public static CacheArchivo obtenerCacheArchivo()
        {
            return INSTANCIA;
        }

        public void adicionarLinea(Linea linea)
        {
            listaLineas.Add(linea);
        }

        public Linea obtenerLinea(int numeroLinea)
        {
            Linea retorno = null;
            if (listaLineas.Count >= 1 && numeroLinea <= listaLineas.Count)
            {
                retorno = listaLineas.ElementAt(numeroLinea - 1);
            }
            else
            {
                retorno = new Linea(numeroLinea, "@EOF@");
            }
            return retorno;
        }

        public void limpiarLineas()
        {
            listaLineas.Clear();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace compilador.Traversal
{
    class ManejadorDeErrores
    {

        private Dictionary<string, List<Error>> mapaErrores = new Dictionary<string, List<Error>>();
        private static ManejadorDeErrores INSTANCIA = new ManejadorDeErrores();
        private ManejadorDeErrores()
        {
            mapaErrores.Add("LEXICO", new List<Error>());
            mapaErrores.Add("SINTACTICO", new List<Error>());
            mapaErrores.Add("SEMANTICO", new List<Error>());
        }

        public static ManejadorDeErrores ObtenerManejadorErrores()
        {
            return INSTANCIA;
        }
        public void AgregarError(Error error)
        {
            if (error != null && mapaErrores.ContainsKey(error.TipoError)) mapaErrores[error.TipoError].Add(error);

        }

        public Boolean HayErrores(string TipoError)
        {
            return (mapaErrores.ContainsKey(TipoError) && mapaErrores[TipoError].Count > 0);
        }
    }
}

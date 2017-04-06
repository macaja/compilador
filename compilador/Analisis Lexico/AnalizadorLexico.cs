using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compilador.Programa_de_Entrada;
using compilador.Cache_Archivo;
using compilador.Tabla_Simbolos;

namespace compilador.Analisis_Lexico
{
     class AnalizadorLexico
    {
        private int Numero;
        public int Puntero = 0;
        private string lexema = null;
        private string caracterActual = null;
        private Linea lineaActual = null;
        private ComponenteLexico componente;
        public int estadoActual;
        public AnalizadorLexico()
        {
            CargarLinea();
        }
        private void CargarLinea()
        {
            int numeroLinea = 0;
            if (lineaActual != null)
            {
                numeroLinea = lineaActual.Numero + 1;
            }
            //si la linea no existe retornara una line @EOF@
            lineaActual = CacheArchivo.obtenerCacheArchivo().obtenerLinea(numeroLinea);
            //reset al puntero 
            Puntero = 1;
        }

        private void LeerSiguienteCaracter()
        {
            if (lineaActual == null || lineaActual.Contenido.Equals("@EOF@"))
            {

                caracterActual = "@EOF@";
            }
            else if (lineaActual.Contenido.Length >= Puntero)
            {
                caracterActual = lineaActual.Contenido.Substring((Puntero - 1), 1);
                Puntero = Puntero + 1;
            }
            else
            {
                caracterActual = "@FL@";
                Puntero = Puntero + 1;
            }
        }
        private void DevolverPuntero()
        {
            Puntero -= 1;
        }

        public ComponenteLexico Analizar()
        {
            //ComponenteLexico componente = null;
            lexema = "";
            estadoActual = 0;
            bool continuarEvaluacion = true;
            while (continuarEvaluacion)
            {
                switch (estadoActual)
                {            
                    case 0:
                        
                        //int posicionInicial = 0;
                        LeerSiguienteCaracter();

                        while (" ".Equals(caracterActual))
                        {
                            LeerSiguienteCaracter();
                        }

                        if (char.IsLetter(caracterActual.ToCharArray()[0]) || "$".Equals(caracterActual) || "_".Equals(caracterActual))
                        {
                            estadoActual = 4;
                            lexema += caracterActual;

                        }
                        else if ("+".Equals(caracterActual))
                        {
                            estadoActual = 5;
                            lexema += caracterActual;
                        }

                        else if (char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            estadoActual = 1;
                            lexema += caracterActual;
                        }

                        else if ("-".Equals(caracterActual))
                        {
                            estadoActual = 6;
                            lexema += caracterActual;
                        }
                        else if ("*".Equals(caracterActual))
                        {
                            estadoActual = 7;
                            lexema += caracterActual;
                        }

                        else if ("/".Equals(caracterActual))
                        {
                            estadoActual = 8;
                            lexema += caracterActual;
                        }

                        else if ("%".Equals(caracterActual))
                        {
                            estadoActual = 9;
                            lexema += caracterActual;
                        }

                        else if ("(".Equals(caracterActual))
                        {
                            estadoActual = 10;
                            lexema += caracterActual;
                        }

                        else if (")".Equals(caracterActual))
                        {
                            estadoActual = 11;
                            lexema += caracterActual;
                        }

                        else if ("@EOF@".Equals(caracterActual))
                        {
                            estadoActual = 12;
                            lexema += caracterActual;
                        }

                        else if ("=".Equals(caracterActual))
                        {
                            estadoActual = 19;
                            lexema += caracterActual;
                        }


                        else if ("<".Equals(caracterActual))
                        {
                            estadoActual = 20;
                            lexema += caracterActual;
                        }


                        else if (">".Equals(caracterActual))
                        {
                            estadoActual = 21;
                            lexema += caracterActual;
                        }


                        else if (":".Equals(caracterActual))
                        {
                            estadoActual = 22;
                            lexema += caracterActual;
                        }


                        else if ("!".Equals(caracterActual))
                        {
                            estadoActual = 30;
                            lexema += caracterActual;
                        }

                        else if ("@FL@".Equals(caracterActual))
                        {
                            estadoActual = 13;
                            lexema += "";
                        }

                        else
                        {
                            estadoActual = 18;

                        }
                        break;
                    case 1:
                        LeerSiguienteCaracter();
                        if (char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            estadoActual = 1;
                            lexema += caracterActual;
                        }
                        else if (",".Equals(caracterActual))
                        {
                            estadoActual = 2;
                            lexema = lexema + caracterActual;
                        }
                        else estadoActual = 14;

                        break;
                    case 2:
                        LeerSiguienteCaracter();
                        if (char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            estadoActual = 3;
                            lexema += caracterActual;
                        }
                        else estadoActual = 17;
                        break;
                    case 3:
                        LeerSiguienteCaracter();
                        if (char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            estadoActual = 3;
                            lexema += caracterActual;
                        }
                        else estadoActual = 15;
                        break;
                    case 4:
                        LeerSiguienteCaracter();
                        if (char.IsLetter(caracterActual.ToCharArray()[0]) || "$".Equals(caracterActual) || "_".Equals(caracterActual) || char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            estadoActual = 4;
                            lexema += caracterActual;
                        }
                        else estadoActual = 16;
                        break;
                        
                    case 5:
                        int posicionInicial = (Puntero - 1) - lexema.Length;
                        int numeroLinea = lineaActual.Numero;
                        string categoria = "SUMA";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 6:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "RESTA";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 7:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "MULTIPLICACION";

                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 8:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "DIVISION";

                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 9:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "MODULO";

                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 10:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "PARENTESIS ABRE";

                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;
                    case 11:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "PARENTESIS CIERRA";

                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 12:
                        DevolverPuntero();

                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "@EOF@";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);

                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);

                        continuarEvaluacion = false;
                        break;

                    case 13:
                        CargarLinea();
                        estadoActual = 0;
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);
                        break;
                        
                    case 14:
                        DevolverPuntero();

                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "NUMERO ENTERO";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);

                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);

                        continuarEvaluacion = false;
                        break;

                    case 15:
                        DevolverPuntero();
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "NUMERO DECIMAL";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);
                        continuarEvaluacion = false;
                        break;

                    case 16:
                        DevolverPuntero();
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "IDENTIFICADOR";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);
                        continuarEvaluacion = false;
                        break;

                    case 17:
                        DevolverPuntero();
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "ERROR NUMERO DECIMAL NO VALIDO";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);

                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);

                        continuarEvaluacion = false;
                        break;

                    case 18:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "SIMBOLO NO VALIDO";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);

                        continuarEvaluacion = false;
                        break;

                    case 19:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "IGUAL QUE";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);

                        continuarEvaluacion = false;
                        break;

                    case 20:
                        LeerSiguienteCaracter();
                        if (">".Equals(caracterActual))
                        {
                            estadoActual = 23;
                            lexema += caracterActual;
                        }
                        else if ("=".Equals(caracterActual))
                        {
                            estadoActual = 24;
                            lexema += caracterActual;
                        }
                        else
                        {
                            estadoActual = 25;
                            lexema += caracterActual;
                        }
                        break;
                    case 21:
                        LeerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            estadoActual = 26;
                            lexema += caracterActual;
                        }
                        else
                        {
                            estadoActual = 27;
                            lexema += caracterActual;
                        }
                        break;
                    case 22:
                        LeerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            estadoActual = 28;
                            lexema += caracterActual;
                        }
                        else
                        {
                            estadoActual = 29;
                            lexema += caracterActual;
                        }
                        break;
                    case 23:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "DIFERENTE QUE";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 24:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "MENOR O IGUAL QUE";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;

                    case 25:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "MENOR QUE";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        DevolverPuntero();
                        break;
                    case 26:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "MAYOR O IGUAL QUE";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;
                    case 27:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "MAYOR QUE";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        DevolverPuntero();
                        continuarEvaluacion = false;
                        break;
                    case 28:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "ASIGNACION";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;
                    case 29:
                        DevolverPuntero();

                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "ASIGNACION NO VALIDA";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);

                        //colocar el componente en la tabla de simbolos
                        TablaSimbolos.obtenerTablaSimbolos().AgregarSimbolo(componente);

                        continuarEvaluacion = false;
                        break;
                    case 30:
                        LeerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            estadoActual = 31;
                            lexema += caracterActual;
                        }
                        break;
                    case 31:
                        posicionInicial = (Puntero - 1) - lexema.Length;
                        numeroLinea = lineaActual.Numero;
                        categoria = "DIFERENTE QUE";
                        componente = ComponenteLexico.CREATE(numeroLinea, posicionInicial, lexema, categoria);
                        continuarEvaluacion = false;
                        break;
                }


            }
            return componente;

        }
    }
}

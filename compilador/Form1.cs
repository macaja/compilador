using compilador.Analisis_Lexico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using compilador.Programa_de_Entrada;
using System.IO;

namespace compilador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnalizadorLexico anaLex = new AnalizadorLexico();
            ComponenteLexico componente = anaLex.Analizar();
            while (!componente.lexema.Equals("@EOF@"))
            {
                MessageBox.Show(componente.lexema + "-->" + componente.categoria);
                anaLex.Puntero = componente.posicionFinalLinea + 1;
                anaLex.estadoActual = 0;
                componente = anaLex.Analizar();
            }
            /*if (textBox1.Text == "")
            {
                MessageBox.Show("Escriba texto");
            }
            else if (!textBox1.Text.Equals(""))
            {
                MessageBox.Show("Debe borrar el archivo que ya se encuentra cargado");
            }
            else
            {
                textBox1.Text = "";
                string[] texto = textBox2.Lines;
                for (int i = 0; i < texto.Length; i++)
                {
                    int j = i + 1;
                    Linea Linea = new Linea();
                    Linea.NumeroLinea = j;
                    Linea.ContenidoLinea = texto[i];
                    textBox1.Text += "Linea " + j + " : " + texto[i];
                    textBox1.Text += "\n";
                }
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        string ruta = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = buscar.FileName;
            }
            /* = openFileDialog1.FileName;
            nombreArchivo.Text = ruta;
            StreamReader sr = new StreamReader(ruta);
            int c = 1;
            while (!sr.EndOfStream)
            {
                String linea = sr.ReadLine();
                Linea Linea = new Linea();
                Linea.Numero = c;
                Linea.Contenido = linea;
                richTextBox1.Text += "Linea " + c + " : " + linea;
                richTextBox1.Text += "\n";
                c++;
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;
            listBox1.Items.Clear();
            StreamReader file = new StreamReader(textBox3.Text);
            //listBox1.Items.Add(" ");
            while ((line = file.ReadLine()) != null)
            {
                listBox1.Items.Add(" " + line + "\n");
                counter++;
            }
            guardar("normal.txt");
            file.Close();
        }
        private void guardar(string nombre)
        {
            StreamWriter codigonuevo = File.CreateText(nombre);
            foreach (object lista in listBox1.Items)
            {
                codigonuevo.WriteLine(lista.ToString());
            }
            codigonuevo.Flush();
            codigonuevo.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

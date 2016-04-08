using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//añadimos los import de mysql
using System.Data.Odbc;
using MySql.Data.Types;
using MySql.Data.MySqlClient;


namespace EjemploMysql
{
    public partial class Form1 : Form
    {
        //este ejemplo conectará con una base de datos 
        //MYSQL

        //necesito 5 parámetros:
            //Server: la ip o npmbre dns del servidor
            //Database: nonmbre de la base de datos
            //Uid: usuario(OJO!!! no se puede dejar en blanco)
            //Pwd: clave de acceso si la tuviera
            //Port: default=3306

        //paramatetro de la conexion
        private string connStr;

        //variable que maneja la conexion
        private MySqlConnection conn;

        //cosulta que quiero hacer a la base de datos
        private String Sentencia_SQL;

        //variable que sirve para crear la conexion
        private static MySqlCommand comando;

        //guarda el resultado de la consulta
        private MySqlDataReader resultado;

        //abre la base de datos y la guarda en DataTable() 
        private DataTable datos = new DataTable();

        private int contadorFila=0;
        private int numeroTotalFilas = 0;
        
        public Form1()
        {
            InitializeComponent();

            connStr = "Server=localhost; Database=test; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            //abrir la conexion
            conn.Open();
            Sentencia_SQL = "Select * from pokemon";
            comando = new MySqlCommand(Sentencia_SQL, conn);
            resultado = comando.ExecuteReader();
            datos.Load(resultado);
            conn.Close();
            numeroTotalFilas = datos.Rows.Count;
           
        }
        private String consulta(String columna) { 

            
            DataRow fila =datos.Rows[contadorFila];
             

             if (fila != null)
             {
                 return fila[columna].ToString();
             }
               
             else return "no existe";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //si consigue leerun dato de la base de datos es que todo 
            //esta OK


            label1.Text = consulta("name");
            label2.Text = consulta("habitat");
            label3.Text = consulta("id");
            contadorFila++;
            if (numeroTotalFilas == contadorFila)
            {
                contadorFila = 0;

            }
          
        }
        
    }
}

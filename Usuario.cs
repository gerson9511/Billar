using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Billar
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=billar; Uid=root; pwd=");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = ("SELECT id_cargo FROM cargo WHERE cargo='" + txt_cargo.Text + "'");
            MySqlDataReader ejecutarid1 = consulta.ExecuteReader();
            string cargo = "";
            if (ejecutarid1.Read())
            {
                cargo = ejecutarid1.GetValue(0).ToString();
           
            }
            conectar.Close();
            conectar.Open();
            consulta.CommandText = ("INSERT INTO usuario (id, keycode, dni, nombre, apellidos, fechanacimiento, estado, anexo, correo, sexo, idcargo, idarea) VALUES(NULL, '" + txt_code.Text + "', '" + txt_dni.Text + "', '" + txt_nombre.Text + "', '" + txt_apellidos.Text + "', '" + txt_fecha.Text + "', '" + 1 + "', '" + txt_anexo.Text + "', '" + txt_correo.Text + "', '" + cbm_sexo.Text + "', '" + txt_cargo.Text + "', '" + txt_area.Text + "')");
                                                                                                                                         
            MySqlDataReader ejecutarus = consulta.ExecuteReader();
            ejecutarus.Read();

            MessageBox.Show("Usuario insertado");
            conectar.Close();

        }
    }
}

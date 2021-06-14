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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1;database=billar;Uid=root;pwd=;");
            conectar.Open();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conectar;
            consulta.CommandText = ("SELECT * FROM usuario WHERE usuario= '" + txt_usuario.Text + "'AND password ='" + txt_password.Text + "'");
            MySqlDataReader ejecutar = consulta.ExecuteReader();
            if (ejecutar.Read())
            {
                MessageBox.Show("Bienvenido al sistema");
                Menu llamar = new Menu();
                txt_usuario.Text = "";
                txt_password.Clear();
                llamar.Show();
               
                
            }
            else
            {
                MessageBox.Show("usuario contraseñas no validos");
                txt_usuario.Text = "";
                txt_password.Clear();
                this.Show();
        }
      }
   }
}

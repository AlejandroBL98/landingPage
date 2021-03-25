using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace landingP.Models
{
    public class RegistroUsuario
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Insertar(Usuario usr)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO registro (nombre, correo, telefono, mensage)values(@nombre,@correo,@telefono,@mensage)", con);

            
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.Int);
            comando.Parameters.Add("@mensage", SqlDbType.VarChar);

            comando.Parameters["@nombre"].Value = usr.Nombre;
            comando.Parameters["@correo"].Value = usr.Correo;
            comando.Parameters["@telefono"].Value = usr.Telefono;
            comando.Parameters["@mensage"].Value = usr.Mensage;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<Usuario> RecupearTodos()
        {
            Conectar();
            List<Usuario> usuario = new List<Usuario>();

            SqlCommand com = new SqlCommand("SELECT nombre,correo,telefono,mensage FROM registro ORDER BY nombre ASC", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                Usuario usr = new Usuario
                {
                    
                    Nombre = registros["nombre"].ToString(),
                    Telefono = int.Parse(registros["telefono"].ToString()),
                    Correo = registros["correo"].ToString(),
                    Mensage = registros["mensage"].ToString()


                };
                usuario.Add(usr);

            }
            con.Close();
            return usuario;
        }
        public Usuario Recuperar(int nombre)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("SELECT nombre,correo,telefono,mensage FROM registro WHERE nombre=@nombre", con);

            comando.Parameters.Add("@nombre", SqlDbType.Int);
            comando.Parameters["@nombre"].Value = nombre;

            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuario = new Usuario();

            if (registros.Read())
            {
                
                usuario.Nombre = registros["nombre"].ToString();
                usuario.Correo = registros["correo"].ToString();
                usuario.Telefono = int.Parse(registros["telefono"].ToString());
                usuario.Mensage = registros["mensage"].ToString();
            }
            con.Close();
            return usuario;
        }
        

    }
}
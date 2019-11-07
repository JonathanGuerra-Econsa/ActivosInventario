using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace Activos
{
    class ConsultasMysql
    {
        private MySqlConnection connection = new MySqlConnection("datasource=192.168.0.5;port=3306;username=admin;password=;database=activos;");
        MySqlDataReader reader;

        public DataTable consulta(string datos, string consulta = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("Estado");
            dt.Columns.Add("idEstado");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("idCategoria");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Fecha de Ingreso");
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT a.idActivo,a.descripcion,u.nombre as 'Usuario', u.idUsuario, " +
                "e.nombre as 'Estado', e.idEstado, c.nombre as 'Categoria', c.idCategoria, em.nombre as 'Empresa', a.fecha_ingreso FROM `"+datos+"` as a " +
                "JOIN `usuario` as u ON a.idUsuario = u.idUsuario " +
                "JOIN `estado` as e ON a.idEstado = e.idEstado " +
                "JOIN `categoria` as c ON a.idCategoria = c.idCategoria " +
                "JOIN `empresa` as em ON a.idEmpresa = em.idEmpresa " + consulta;
            connection.Open();
            Console.WriteLine(cmd.CommandText);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow activo = dt.NewRow();
                    activo["ID"] = reader.GetString(0);
                    activo["Descripcion"] = reader.GetString(1);
                    activo["Usuario"] = reader.GetString(2);
                    activo["idUsuario"] = reader.GetString(3);
                    activo["Estado"] = reader.GetString(4);
                    activo["idEstado"] = reader.GetString(5);
                    activo["Categoria"] = reader.GetString(6);
                    activo["idCategoria"] = reader.GetString(7);
                    activo["Empresa"] = reader.GetString(8);
                    activo["Fecha de Ingreso"] = reader.GetString(9);
                    dt.Rows.Add(activo);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable usuarios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idU", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow usuario = dt.NewRow();
                    usuario["idU"] = reader.GetInt32(0);
                    usuario["nombre"] = reader.GetString(1);
                    dt.Rows.Add(usuario);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable categorias()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idC", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM categoria";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow categoria = dt.NewRow();
                    categoria["idC"] = reader.GetInt32(0);
                    categoria["nombre"] = reader.GetString(1);
                    dt.Rows.Add(categoria);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable estados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idE", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM estado";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow estado = dt.NewRow();
                    estado["idE"] = reader.GetInt32(0);
                    estado["nombre"] = reader.GetString(1);
                    dt.Rows.Add(estado);
                }
            }
            connection.Close();
            return dt;
        }

        // Revisar Articulos

        public DataTable buscar(string tabla, string id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("Estado");
            dt.Columns.Add("idEstado");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("idCategoria");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Fecha de Ingreso");
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT a.idActivo,a.descripcion,u.nombre as 'Usuario', u.idUsuario, " +
                "e.nombre as 'Estado', e.idEstado, c.nombre as 'Categoria', c.idCategoria, em.nombre as 'Empresa', a.fecha_ingreso FROM `" + tabla + "` as a " +
                "JOIN `usuario` as u ON a.idUsuario = u.idUsuario " +
                "JOIN `estado` as e ON a.idEstado = e.idEstado " +
                "JOIN `categoria` as c ON a.idCategoria = c.idCategoria " +
                "JOIN `empresa` as em ON a.idEmpresa = em.idEmpresa WHERE a.idActivo = " + id;
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow encontrado = dt.NewRow();
                    encontrado[0] = reader.GetString(0);
                    encontrado[1] = reader.GetString(1);
                    encontrado[2] = reader.GetString(2);
                    encontrado[3] = reader.GetString(3);
                    encontrado[4] = reader.GetString(4);
                    encontrado[5] = reader.GetString(5);
                    encontrado[6] = reader.GetString(6);
                    encontrado[7] = reader.GetString(7);
                    encontrado[8] = reader.GetString(8);
                    encontrado[9] = reader.GetString(9);
                    dt.Rows.Add(encontrado);
                }
            }
            connection.Close();
            return dt;
        }
    }
}

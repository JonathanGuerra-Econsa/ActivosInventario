using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Activos
{
    class ConsultasMySQL_JG
    {
        //----------------------------------------------*Variables Gloables*--------------------------------------------//
        string connectionString = @"Server=192.168.0.5;Database=activos;Uid=hola;Pwd=;port=3306;";
        string Tabla_Departamento = "departamento";
        string Tabla_Usuario = "usuario";
        string Tabla_Categoria = "categoria";
        string Tabla_Activo = "activo";
        string Tabla_Activo_Historial = "activo_historial";
        string Tabla_Articulo = "articulo";
        string Tabla_Articulo_Historial = "articulo_historial";
        string Tabla_Estado = "estado";
        string Tabla_Status = "status";
        string Tabla_Empresa = "empresa";
        string Tabla_DetalleInvActivo = "detalleinvactivo";
        string Tabla_InvActivo = "inventario_activo";
        //---------------------------------------------------------------------------------------------------------------//

        //-----------------------------------------Plantilla para Metodo View----------------------------------------//
        public DataTable View()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format(""), mysqlCon);
                DataTable Table = new DataTable();
                mysqlCmd.Fill(Table);
                return Table;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//

        public DataTable verDepartamentos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idDepartamento as 'ID', nombre as 'Departamento' FROM {0}", Tabla_Departamento), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }

        public DataTable verEstados()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idEstado as 'ID', nombre as 'Estado' FROM {0}", Tabla_Estado), mysqlCon);
                DataTable TableEstado = new DataTable();
                mySqlCmd.Fill(TableEstado);
                return TableEstado;
            }
        }

        public DataTable verEmpresa()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idEmpresa as 'ID', nombre as 'Empresa' FROM {0}", Tabla_Empresa), mysqlCon);
                DataTable TableEmpresa = new DataTable();
                mySqlCmd.Fill(TableEmpresa);
                return TableEmpresa;
            }
        }

        public DataTable verUsuarios()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idUsuario as 'ID', {0}.nombre as 'Nombre', {0}.user as 'Usuario', {1}.nombre as 'Departamento' FROM {0} INNER JOIN {1} ON {0}.idDepartamento = {1}.idDepartamento", Tabla_Usuario, Tabla_Departamento), mysqlCon);
                DataTable TableUser = new DataTable();
                mySqlCmd.Fill(TableUser);
                return TableUser;
            }
        }

        public DataTable verCategorias()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT idCategoria as 'ID', nombre as 'Categoria' FROM {0}", Tabla_Categoria), mysqlCon);
                DataTable TableCategoria = new DataTable();
                mysqlCmd.Fill(TableCategoria);
                return TableCategoria;
            }
        }

        public DataTable verActivos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idActivo as 'ID', {0}.descripcion as 'Descripcion', {1}.user as 'Usuario', {2}.nombre as 'Estado', {3}.nombre as 'Categoria', {4}.nombre as 'Empresa', {0}.fecha_ingreso as 'Fecha Ingreso' FROM {0} INNER JOIN {1} ON {1}.idUsuario = {0}.idusuario INNER JOIN {2} ON {2}.idEstado = {0}.idEstado INNER JOIN {3} ON {3}.idCategoria = {0}.idcategoria INNER JOIN {4} ON {4}.idEmpresa = {0}.idEmpresa", Tabla_Activo, Tabla_Usuario, Tabla_Estado, Tabla_Categoria, Tabla_Empresa), mysqlCon);
                DataTable TableActivo = new DataTable();
                mysqlCmd.Fill(TableActivo);
                return TableActivo;
            }
        }

        public DataTable verArticulos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idActivo as 'ID', {0}.descripcion as 'Descripcion', {1}.user as 'Usuario', {2}.nombre as 'Estado', {3}.nombre as 'Categoria', {4}.nombre as 'Empresa', {0}.fecha_ingreso as 'Fecha Ingreso' FROM {0} INNER JOIN {1} ON {1}.idUsuario = {0}.idusuario INNER JOIN {2} ON {2}.idEstado = {0}.idEstado INNER JOIN {3} ON {3}.idCategoria = {0}.idcategoria INNER JOIN {4} ON {4}.idEmpresa = {0}.idEmpresa", Tabla_Articulo, Tabla_Usuario, Tabla_Estado, Tabla_Categoria, Tabla_Empresa), mysqlCon);
                DataTable TableArticulo = new DataTable();
                mysqlCmd.Fill(TableArticulo);
                return TableArticulo;
            }
        }

        public DataTable verDetalleActivo()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT dt.idDetalle as 'ID', a.descripcion as 'Descripcion', u.user as 'Usuario', e.nombre as 'Estado', c.nombre as 'Categoria', em.nombre as 'Empresa', a.fecha_ingreso as 'Fecha Ingreso', st.nombre as 'Estatus', dt.fecha_apertura as 'Fecha Apertura', inv.nombre as 'Inventario' FROM {0} dt INNER JOIN {1} a ON dt.idActivo = a.idActivo INNER JOIN {2} u ON a.idUsuario = u.idUsuario INNER JOIN {3} e ON e.idEstado = dt.idEstado INNER JOIN {4} c ON c.idCategoria = a.idCategoria INNER JOIN {5} em ON em.idEmpresa = a.idEmpresa INNER JOIN {6} st ON st.idStatus = dt.idStatus INNER JOIN {7} inv ON inv.idInventarioActivo = dt.idInventario WHERE  u.nombre LIKE '%%' ", Tabla_DetalleInvActivo, Tabla_Activo, Tabla_Usuario, Tabla_Estado, Tabla_Categoria, Tabla_Empresa, Tabla_Status, Tabla_InvActivo), mysqlCon);
                DataTable TableDetalle = new DataTable();
                mysqlCmd.Fill(TableDetalle);
                return TableDetalle;
            }
        }

        public string verIdActivos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                string idActivo = "NULL";
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT MAX(idActivo) as 'ID' FROM {0}", Tabla_Activo), mysqlCon);
                DataTable TableActivo = new DataTable();
                mysqlCmd.Fill(TableActivo);
                if (TableActivo.Rows.Count > 0)
                {
                    DataRow row = TableActivo.Rows[0];
                    DataRow name = TableActivo.Rows[0];
                    idActivo = Convert.ToString(row[0]);
                }
                return idActivo;
            }
        }

        public string verIdArticulos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                string idArticulo = "NULL";
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT MAX(idActivo) as 'ID' FROM {0}", Tabla_Articulo), mysqlCon);
                DataTable TableActivo = new DataTable();
                mysqlCmd.Fill(TableActivo);
                if (TableActivo.Rows.Count > 0)
                {
                    DataRow row = TableActivo.Rows[0];
                    DataRow name = TableActivo.Rows[0];
                    idArticulo = Convert.ToString(row[0]);
                }
                return idArticulo;
            }
        }

        public void agregarDepartamento(string departamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre) VALUES('{1}')", Tabla_Departamento, departamento), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        public void agregarUsuario(string nombre, string usuario, string password, string idDepartamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre, user, password, idDepartamento) VALUES('{1}','{2}','{3}','{4}')", Tabla_Usuario, nombre, usuario, password, idDepartamento), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        public void agregarCategoria(string nombre)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre) VALUES('{1}')", Tabla_Categoria, nombre), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        public void agregarActivo(string descripcion, string idUsuario, string idEstado, string idcategoria, string idEmpresa, string fecha)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(descripcion, idUsuario, idEstado, idCategoria, idEmpresa, fecha_ingreso) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Tabla_Activo, descripcion, idUsuario, idEstado, idcategoria, idEmpresa, fecha), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        public void agregarActivo_Historial(string descripcion, string idUsuario, string idEstado, string idcategoria, string idEmpresa, string fecha, string idActivo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(descripcion, idUsuario, idEstado, idCategoria, idEmpresa, fecha_ingreso, idActivo) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", Tabla_Activo_Historial, descripcion, idUsuario, idEstado, idcategoria, idEmpresa, fecha, idActivo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        public void agregarArticulo(string descripcion, string idUsuario, string idEstado, string idcategoria, string idEmpresa, string fecha)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(descripcion, idUsuario, idEstado, idCategoria, idEmpresa, fecha_ingreso) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Tabla_Articulo, descripcion, idUsuario, idEstado, idcategoria, idEmpresa, fecha), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        public void agregarArticulo_Historial(string descripcion, string idUsuario, string idEstado, string idcategoria, string idEmpresa, string fecha, string idActivo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(descripcion, idUsuario, idEstado, idCategoria, idEmpresa, fecha_ingreso, idArticulo) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", Tabla_Articulo_Historial, descripcion, idUsuario, idEstado, idcategoria, idEmpresa, fecha, idActivo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        public string Login(string usuario, string password)
        {
            string user = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT  nombre FROM {0} WHERE user LIKE '{1}' AND password LIKE '{2}'", Tabla_Usuario, usuario, password), mysqlCon);
                DataTable TableUsuario = new DataTable();
                mysqlCmd.Fill(TableUsuario);
                if(TableUsuario.Rows.Count > 0)
                {
                    DataRow row = TableUsuario.Rows[0];
                    user = row[0].ToString();
                }
                return user;
            }
        }
    }
}

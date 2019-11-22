﻿using System;
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
        #region Variables
        //----------------------------------------------*Variables Gloables*--------------------------------------------//
        string connectionString = @"Server=192.168.0.5;Database=activos;Uid=hola;Pwd=;port=3306;";
        string Tabla_Departamento = "departamento";
        string Tabla_Usuario = "usuario";
        string Tabla_Tipo = "tipo";
        string Tabla_Activo = "activo";
        string Tabla_Articulo = "articulo";
        string Tabla_Estado = "estado";
        string Tabla_Status = "status";
        string Tabla_Empresa = "empresa";
        string Tabla_DetalleInvActivo = "detalleinvactivo";
        string Tabla_InvActivo = "inventario_activo";
        string Tabla_SubGrupo = "subgrupo";
        string Tabla_Grupo = "grupo";
        //---------------------------------------------------------------------------------------------------------------//
        //---------------------------------------------- * Variables de Reader * -----------------------------------------//

        public string descripcion;
        public string estado;
        public string tipo;
        public string empresa;
        public string fecha_compra;
        public string usuario;
        public string nombreUsuario;
        public string nombreDepartamentoUsuario;
        public string puestoUsuario;
        public string grupo;
        public string subgrupo;
        public string valor;
        public string fpc;
        public string fechaDep;
        public string porcentajeDep;
        public string depAcumulada;
        public string valorResidual;
        public string valorLibros;
        //------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Plantilla ;)
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
        #endregion
        #region verDepartamentos()
        //---------------------------------------Ver los departamentos------------------------------------------------------------//
        public DataTable verDepartamentos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idDepartamento as 'ID', nombre as 'Departamento' FROM {0} ORDER BY idDepartamento", Tabla_Departamento), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verEstados()
        //------------------------------------------------Ver los Estados--------------------------------------------------------//
        public DataTable verEstados()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idEstado as 'ID', nombre as 'Estado' FROM {0} ORDER BY idEstado", Tabla_Estado), mysqlCon);
                DataTable TableEstado = new DataTable();
                mySqlCmd.Fill(TableEstado);
                return TableEstado;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verEmpresa()
        //--------------------------------------Ver las empresas-----------------------------------------------------------//
        public DataTable verEmpresa()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idEmpresa as 'ID', nombre as 'Empresa' FROM {0} ORDER BY idEmpresa", Tabla_Empresa), mysqlCon);
                DataTable TableEmpresa = new DataTable();
                mySqlCmd.Fill(TableEmpresa);
                return TableEmpresa;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verUsuario()
        //-----------------------------------------------Ver los Usuarios---------------------------------------------------------//
        public DataTable verUsuarios()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idUsuario as 'ID', {0}.nombre as 'Nombre', {0}.user as 'Usuario', {1}.nombre as 'Departamento' FROM {0} INNER JOIN {1} ON {0}.idDepartamento = {1}.idDepartamento ORDER BY idUsuario", Tabla_Usuario, Tabla_Departamento), mysqlCon);
                DataTable TableUser = new DataTable();
                mySqlCmd.Fill(TableUser);
                return TableUser;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verTipo()
        //---------------------------------------------------Ver las Categorias------------------------------------------------------//
        public DataTable verTipos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT idTipo as 'ID', tipo as 'Tipo' FROM {0} ORDER BY idTipo", Tabla_Tipo), mysqlCon);
                DataTable TableCategoria = new DataTable();
                mysqlCmd.Fill(TableCategoria);
                return TableCategoria;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verActivos()
        //---------------------------------------------Ver los Activos------------------------------------------------------------//
        public DataTable verActivos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idActivo as 'ID', {0}.descripcion as 'Descripcion', {1}.user as 'Usuario', {2}.nombre as 'Estado', {3}.nombre as 'Categoria', {4}.nombre as 'Empresa', {0}.fecha_ingreso as 'Fecha Ingreso' FROM {0} INNER JOIN {1} ON {1}.idUsuario = {0}.idusuario INNER JOIN {2} ON {2}.idEstado = {0}.idEstado INNER JOIN {3} ON {3}.idCategoria = {0}.idcategoria INNER JOIN {4} ON {4}.idEmpresa = {0}.idEmpresa ORDER BY idActivo", Tabla_Activo, Tabla_Usuario, Tabla_Estado, Tabla_Tipo, Tabla_Empresa), mysqlCon);
                DataTable TableActivo = new DataTable();
                mysqlCmd.Fill(TableActivo);
                return TableActivo;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verArtículos()
        //----------------------------------------------------Ver los Artículos------------------------------------------------------------//
        public DataTable verArticulos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idArticulo as 'ID', {0}.descripcion as 'Descripcion', {1}.user as 'Usuario', {2}.nombre as 'Estado', {3}.nombre as 'Categoria', {4}.nombre as 'Empresa', {0}.fecha_ingreso as 'Fecha Ingreso' FROM {0} INNER JOIN {1} ON {1}.idUsuario = {0}.idusuario INNER JOIN {2} ON {2}.idEstado = {0}.idEstado INNER JOIN {3} ON {3}.idCategoria = {0}.idcategoria INNER JOIN {4} ON {4}.idEmpresa = {0}.idEmpresa ORDER BY idArticulo", Tabla_Articulo, Tabla_Usuario, Tabla_Estado, Tabla_Tipo, Tabla_Empresa), mysqlCon);
                DataTable TableArticulo = new DataTable();
                mysqlCmd.Fill(TableArticulo);
                return TableArticulo;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verDetalleActivo()
        //------------------------------------------------------Ver los Detalles de Activos--------------------------------------------------//
        public DataTable verDetalleActivo()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT dt.idDetalle as 'ID', a.descripcion as 'Descripcion', u.user as 'Usuario', e.nombre as 'Estado', c.nombre as 'Categoria', em.nombre as 'Empresa', a.fecha_ingreso as 'Fecha Ingreso', st.nombre as 'Estatus', dt.fecha_apertura as 'Fecha Apertura', inv.nombre as 'Inventario' FROM {0} dt INNER JOIN {1} a ON dt.idActivo = a.idActivo INNER JOIN {2} u ON a.idUsuario = u.idUsuario INNER JOIN {3} e ON e.idEstado = dt.idEstado INNER JOIN {4} c ON c.idCategoria = a.idCategoria INNER JOIN {5} em ON em.idEmpresa = a.idEmpresa INNER JOIN {6} st ON st.idStatus = dt.idStatus INNER JOIN {7} inv ON inv.idInventarioActivo = dt.idInventario WHERE  u.nombre LIKE '%%' ORDER BY idDetalle", Tabla_DetalleInvActivo, Tabla_Activo, Tabla_Usuario, Tabla_Estado, Tabla_Tipo, Tabla_Empresa, Tabla_Status, Tabla_InvActivo), mysqlCon);
                DataTable TableDetalle = new DataTable();
                mysqlCmd.Fill(TableDetalle);
                return TableDetalle;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verIdActivos()
        //------------------------------------------------------Buscar ------------------------------------------------------//
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
        #endregion
        #region verArticulos()
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
        #endregion
        #region agregarDepartamento()
        public void agregarDepartamento(string departamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre) VALUES('{1}')", Tabla_Departamento, departamento), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region agregarUsuario()
        public void agregarUsuario(string nombre, string usuario, string password, string idDepartamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre, user, password, idDepartamento) VALUES('{1}','{2}','{3}','{4}')", Tabla_Usuario, nombre, usuario, password, idDepartamento), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region agregarCategoria()
        public void agregarCategoria(string nombre)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre) VALUES('{1}')", Tabla_Tipo, nombre), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region agregarActivo()
        public void agregarActivo(string descripcion, string idUsuario, string idEstado, string idTipo, string idEmpresa, string fecha_compra, string valor, string fpc, string fecha_dep, string porcentajeDep, string depAcumulada, string valorResidual, string valorLibros, string idSubGrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}( descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, Valor, FPC, fecha_dep, PorcentajeDep, DepAcumulada, ValorResidual, ValorLibros, idSubgrupo ) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')", Tabla_Activo, descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, valor, fpc, fecha_dep, porcentajeDep, depAcumulada, valorResidual, valorLibros, idSubGrupo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region agregarArticulo()
        public void agregarArticulo(string descripcion, string idUsuario, string idEstado, string idcategoria, string idEmpresa, string fecha)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(descripcion, idUsuario, idEstado, idCategoria, idEmpresa, fecha_ingreso) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Tabla_Articulo, descripcion, idUsuario, idEstado, idcategoria, idEmpresa, fecha), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Login()
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
        #endregion
        #region updateUsuario
        public void updateUsuario(string nombre, string user, string idDepartamento, string idUsuario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET nombre = '{1}', user = '{2}', idDepartamento = '{3}' WHERE idUsuario = '{4}'", Tabla_Usuario, nombre, user, idDepartamento, idUsuario), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region updateDepartamento()
        public void updateDepartamento(string id, string departamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET nombre = '{1}' WHERE idDepartamento = '{2}'", Tabla_Departamento, departamento, id), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region updateCategoria()
        public void updateCategoria(string id, string categoria)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET nombre = '{1}' WHERE idCategoria = '{2}'", Tabla_Tipo, categoria, id), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region updateActivo()
        public void updateActivo(string descripcion, string idUsuario, string idEstado, string idTipo, string idEmpresa, string fecha_compra, string valor, string fpc, string fecha_dep, string porcentajeDep, string  depAcumulada, string valorResidual, string valorLibros, string idSubGrupo, string idActivo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET descripcion = '{1}', idUsuario = '{2}', idEstado = '{3}', idTipo = '{4}', idEmpresa = '{5}', fecha_compra = '{6}', Valor = '{7}', FPC = '{8}', fecha_dep = '{9}', PorcentajeDep = '{10}', DepAcumulada = '{11}', ValorResidual = '{12}', ValorLibros = '{13}', idSubgrupo = '{14}' WHERE idActivo = '{15}'", Tabla_Activo, descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, valor, fpc, fecha_dep, porcentajeDep, depAcumulada, valorResidual, valorLibros, idSubGrupo, idActivo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Buscar Usuario
        //----------------------------------------Busca a un Usuario por su ID-------------------------------------------//
        public void buscarUsuario(string idUsuario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("SELECT u.nombre as 'Nombre', d.nombre as 'Departamento', u.puesto as 'Puesto' FROM {0} u INNER JOIN {1} d ON u.idDepartamento = d.idDepartamento WHERE idUsuario = '{2}'", Tabla_Usuario, Tabla_Departamento, idUsuario), mysqlCon);
                MySqlDataReader read = mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    nombreUsuario = read["Nombre"].ToString();
                    nombreDepartamentoUsuario = read["Departamento"].ToString();
                    puestoUsuario = read["Puesto"].ToString();
                }
                read.Close();
                mysqlCon.Close();
            }
        }
        //----------------------------------------------------- ----------------------------------------------------------------//
        #endregion
        #region verGrupos()
        public DataTable verGrupos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT idGrupo as 'ID', nombre as 'Nombre' FROM {0}", Tabla_Grupo),mysqlCon);
                DataTable grupo = new DataTable();
                mysqlDa.Fill(grupo);
                return grupo;
            }
        }
        #endregion
        #region verSubGrupo()
        public DataTable verSubGrupo(string idGrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT s.idSubgrupo as 'ID', s.nombre as 'Nombre' FROM {0} s INNER JOIN {1} g ON s.idGrupo = g.idGrupo WHERE s.idGrupo = '{2}'", Tabla_SubGrupo, Tabla_Grupo, idGrupo), mysqlCon);
                DataTable subgrupo = new DataTable();
                mysqlDa.Fill(subgrupo);
                return subgrupo;
            }
        }
        #endregion
        #region Detalle Activo
        //----------------------------------------------- * Data reader que trae la data para el detalle de activo * -----------------------------------------------------//
        public void detalleActivo(string idActivo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("SELECT a.descripcion as 'Descripcion', e.nombre as 'Estado', t.Tipo as 'Tipo', em.nombre as 'Empresa', a.fecha_compra as 'Fecha Compra', u.user as 'Usuario', u.nombre as 'Nombre Usuario', d.nombre as 'Departamento Usuario', u.puesto as 'Puesto', g.nombre as 'Grupo', s.nombre as 'Sub Grupo', a.Valor as 'Valor', a.FPC as 'FPC', a.fecha_dep as 'Fecha Depreciacion', a.PorcentajeDep as 'Porcentaje Depreciacion', a.DepAcumulada as 'Depreciacion Acumulada', a.ValorResidual as 'valor Residual', a.ValorLibros as 'Valor Libros' FROM {0} a INNER JOIN {1} e ON a.idEstado = e.idEstado INNER JOIN {2} t ON a.idTipo = t.idTipo INNER JOIN {3} em ON a.idEmpresa = em.idEmpresa INNER JOIN {4} u ON a.idUsuario = u.idUsuario INNER JOIN {5} d ON u.idDepartamento = d.idDepartamento INNER JOIN {6} s ON a.idSubgrupo = s.idSubgrupo INNER JOIN {7} g ON s.idGrupo = g.idGrupo WHERE idActivo = '{8}'", Tabla_Activo, Tabla_Estado, Tabla_Tipo, Tabla_Empresa, Tabla_Usuario, Tabla_Departamento, Tabla_SubGrupo, Tabla_Grupo, idActivo), mysqlCon);
                MySqlDataReader read = mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    descripcion = read["Descripcion"].ToString();
                    estado = read["Estado"].ToString();
                    tipo = read["Tipo"].ToString();
                    empresa = read["Empresa"].ToString();
                    fecha_compra = read["Fecha Compra"].ToString();
                    usuario = read["Usuario"].ToString();
                    nombreUsuario = read["Nombre Usuario"].ToString();
                    nombreDepartamentoUsuario = read["Departamento Usuario"].ToString();
                    puestoUsuario = read["Puesto"].ToString();
                    grupo = read["Grupo"].ToString();
                    subgrupo = read["Sub Grupo"].ToString();
                    valor = read["Valor"].ToString();
                    fpc = read["FPC"].ToString();
                    fechaDep = read["Fecha Depreciacion"].ToString();
                    porcentajeDep = read["Porcentaje Depreciacion"].ToString();
                    depAcumulada = read["Depreciacion Acumulada"].ToString();
                    valorResidual = read["Valor Residual"].ToString();
                    valorLibros = read["Valor Libros"].ToString();
                }
                read.Close();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verTiposActivo()
        //--------------------------------------------- Método para traer los tipos de la base de datos ----------------------------------------//
        public DataTable verTiposActivo()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT t.idTipo as 'ID', t.Tipo as 'Tipo', s.nombre as 'Sub Grupo' FROM Tipo t INNER JOIN subgrupo s ON t.idSubgrupo = s.idSubgrupo "), mysqlCon);
                DataTable table_Tipo = new DataTable();
                mysqlDa.Fill(table_Tipo);
                return table_Tipo;
            }
        }
        //------------------------------------------------------------------------- --------------------------------------------------------------------//
        #endregion
        #region verGrupo()
        //---------------------------------------------------------------- Método que trae la tabla de grupos --------------------------------------------------//
        public DataTable verGrupo()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT idGrupo as 'ID', nombre as 'Nombre' FROM grupo"), mysqlCon);
                DataTable table_grupo = new DataTable();
                mysqlDa.Fill(table_grupo);
                return table_grupo;
            }
        }
        //-------------------------------------------------------------------------------- -----------------------------------------------------------------------------//
        #endregion
    }
}

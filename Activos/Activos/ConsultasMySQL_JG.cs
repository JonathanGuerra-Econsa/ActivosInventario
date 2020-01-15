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
        #region Variables
        //----------------------------------------------*Variables Gloables*--------------------------------------------//
        string connectionString = @"Server=192.168.0.7;Database=activos;Uid=admin;Pwd=;port=3306;Convert Zero Datetime=True;";
        string Tabla_Departamento = "departamento";
        string Tabla_Usuario = "usuario";
        string Tabla_Tipo = "tipo";
        string Tabla_Tipo_ART = "tipo_articulo";
        string Tabla_Activo = "activo";
        string Tabla_Articulo = "articulo";
        string Tabla_Estado = "estado";
        string Tabla_Status = "status";
        string Tabla_Empresa = "empresa";
        string Tabla_DetalleInvActivo = "detalleinvactivo";
        string Tabla_DetalleInvArticulo = "detalleinvarticulo";
        string Tabla_InvActivo = "inventario_activo";
        string Tabla_InvArticulo = "inventario_articulo";
        string Tabla_SubGrupo = "subgrupo";
        string Tabla_Grupo = "grupo";
        string Tabla_Grupo_Articulo = "grupo_articulo";
        //---------------------------------------------------------------------------------------------------------------//
        //---------------------------------------------- * Variables de Reader Activo* -----------------------------------------//

        public string descripcion;
        public string estado;
        public string tipo;
        public string empresa;
        public string fecha_compra;
        public string fecha_activo;
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
        public string departamentoUsuario;
        public string idDetalleActivo;
        public string fisico;
        public string inv_activo;
        public string valor_depreciable;
        public string depreciacion_mes;
        //------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Variables Artículo
        //---------------------------------------------------* Variables Globales de Artículos *--------------------------------------//
        public string descripcion_articulo;
        public string usuario_articulo;
        public string departamento_articulo;
        public string estado_articulo;
        public string tipo_articulo;
        public string empresa_articulo;
        public string fecha_articulo;
        public string valor_articulo;
        public string fpc_articulo;
        public string fisico_articulo;
        public string inv_articulo;
        public string idDetalleArticulo;
        //---------------------------------------------------------------------------------------------------------------------------------//
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
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idEstado as 'ID', nombre as 'Estado' FROM {0} WHERE idEstado != 5 ORDER BY idEstado", Tabla_Estado), mysqlCon);
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
        public DataTable verUsuarios(string idDepartamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idUsuario as 'ID', {0}.nombre as 'Nombre', {0}.user as 'Usuario', {1}.nombre as 'Departamento', {0}.puesto as 'Puesto' FROM {0} INNER JOIN {1} ON {0}.idDepartamento = {1}.idDepartamento WHERE {0}.idDepartamento = '{2}' ORDER BY idUsuario", Tabla_Usuario, Tabla_Departamento, idDepartamento), mysqlCon);
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
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT a.idActivo as 'ID', a.descripcion as 'Descripcion', u.nombre as 'Usuario', es.nombre as 'Estado', t.Tipo as 'Tipo' FROM activo a INNER JOIN usuario u ON a.idUsuario = u.idUsuario INNER JOIN estado es ON a.idEstado = es.idEstado INNER JOIN tipo t ON a.idTipo = t.idTipo ORDER BY a.idActivo"), mysqlCon);
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
        public void agregarUsuario(string nombre, string usuario, string password, string idDepartamento, string puesto)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre, user, password, idDepartamento, puesto) VALUES('{1}','{2}','{3}','{4}', '{5}')", Tabla_Usuario, nombre, usuario, password, idDepartamento, puesto), mysqlCon);
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
        public void agregarActivo(string descripcion, string idUsuario, string idEstado, string idTipo, string idEmpresa, string fecha_compra, string valor, string fpc, string fecha_dep, string porcentajeDep, string depAcumulada, string valorResidual, string valorLibros, string idSubGrupo, string valorDepreciable, string depreciacionMes)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}( descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, Valor, FPC, fecha_dep, PorcentajeDep, DepAcumulada, ValorResidual, ValorLibros, idSubgrupo, valor_depreciable, depreciacion_mes) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}')", Tabla_Activo, descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, valor, fpc, fecha_dep, porcentajeDep, depAcumulada, valorResidual, valorLibros, idSubGrupo, valorDepreciable, depreciacionMes), mysqlCon);
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
                if (TableUsuario.Rows.Count > 0)
                {
                    DataRow row = TableUsuario.Rows[0];
                    user = row[0].ToString();
                }
                return user;
            }
        }
        #endregion
        #region updateUsuario
        public void updateUsuario(string nombre, string user, string idDepartamento, string idUsuario, string puesto)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET nombre = '{1}', user = '{2}', idDepartamento = '{3}', puesto = '{5}' WHERE idUsuario = '{4}'", Tabla_Usuario, nombre, user, idDepartamento, idUsuario, puesto), mysqlCon);
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
        public void updateActivo(string descripcion, string idUsuario, string idEstado, string idTipo, string idEmpresa, string fecha_compra, string valor, string fpc, string fecha_dep, string porcentajeDep, string depAcumulada, string valorResidual, string valorLibros, string idSubGrupo, string idActivo, string valorDepreciable, string depreciacionMes)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET descripcion = '{1}', idUsuario = '{2}', idEstado = '{3}', idTipo = '{4}', idEmpresa = '{5}', fecha_compra = '{6}', Valor = '{7}', FPC = '{8}', fecha_dep = '{9}', PorcentajeDep = '{10}', DepAcumulada = '{11}', ValorResidual = '{12}', ValorLibros = '{13}', idSubgrupo = '{14}', valor_depreciable = '{16}',  depreciacion_mes = '{17}' WHERE idActivo = '{15}'", Tabla_Activo, descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, valor, fpc, fecha_dep, porcentajeDep, depAcumulada, valorResidual, valorLibros, idSubGrupo, idActivo, valorDepreciable, depreciacionMes), mysqlCon);
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
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT idGrupo as 'ID', nombre as 'Nombre' FROM {0}", Tabla_Grupo), mysqlCon);
                DataTable grupo = new DataTable();
                mysqlDa.Fill(grupo);
                return grupo;
            }
        }
        #endregion
        #region verGrupoArticulo()
        public DataTable verGrupoArticulo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT idGrupoArticulo as 'ID', nombre as 'Nombre' FROM {0}", Tabla_Grupo_Articulo), mysqlCon);
                mysqlDa.Fill(dt);
                mysqlCon.Close();
            }
            return dt;
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
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("SELECT a.descripcion as 'Descripcion', e.nombre as 'Estado', t.Tipo as 'Tipo', em.nombre as 'Empresa', a.fecha_compra as 'Fecha Compra', u.nombre as 'Usuario', u.nombre as 'Nombre Usuario', d.nombre as 'Departamento Usuario', u.puesto as 'Puesto', g.nombre as 'Grupo', s.nombre as 'Sub Grupo', a.Valor as 'Valor', a.FPC as 'FPC', a.fecha_dep as 'Fecha Depreciacion', a.PorcentajeDep as 'Porcentaje Depreciacion', a.DepAcumulada as 'Depreciacion Acumulada', a.ValorResidual as 'valor Residual', a.ValorLibros as 'Valor Libros', u.idDepartamento as 'Departamento Usuario', a.valor_depreciable as 'Valor Depreciable', a.depreciacion_mes	as 'Depreciacion Mes'  FROM {0} a INNER JOIN {1} e ON a.idEstado = e.idEstado INNER JOIN {2} t ON a.idTipo = t.idTipo INNER JOIN {3} em ON a.idEmpresa = em.idEmpresa INNER JOIN {4} u ON a.idUsuario = u.idUsuario INNER JOIN {5} d ON u.idDepartamento = d.idDepartamento INNER JOIN {6} s ON a.idSubgrupo = s.idSubgrupo INNER JOIN {7} g ON s.idGrupo = g.idGrupo WHERE idActivo = '{8}'", Tabla_Activo, Tabla_Estado, Tabla_Tipo, Tabla_Empresa, Tabla_Usuario, Tabla_Departamento, Tabla_SubGrupo, Tabla_Grupo, idActivo), mysqlCon);
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
                    departamentoUsuario = read["Departamento Usuario"].ToString();
                    valor_depreciable = read["Valor Depreciable"].ToString();
                    depreciacion_mes = read["Depreciacion Mes"].ToString();
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
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT t.idTipo as 'ID', t.Tipo as 'Tipo' FROM {0} t", Tabla_Tipo), mysqlCon);
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
        #region verSubGrupos()
        public DataTable verSubGrupo()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT s.idSubGrupo as 'ID', s.nombre as 'Nombre', g.nombre as 'Grupo' FROM {0} s INNER JOIN grupo g ON g.idGrupo = s.idGrupo ORDER BY idSubgrupo", Tabla_SubGrupo), mysqlCon);
                DataTable table_grupo = new DataTable();
                mysqlDa.Fill(table_grupo);
                return table_grupo;
            }
        }
        #endregion
        #region ver grupo según su subgrupo
        public string verGrupo_SubGrupo(string idSubgrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                string grupo = "NULL";
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT g.nombre as 'Nombre' FROM {1} s INNER JOIN {2} g ON s.idGrupo = g.idGrupo WHERE s.idSubgrupo = '{0}'", idSubgrupo, Tabla_SubGrupo, Tabla_Grupo), mysqlCon);
                DataTable TableActivo = new DataTable();
                mysqlDa.Fill(TableActivo);
                if (TableActivo.Rows.Count > 0)
                {
                    DataRow row = TableActivo.Rows[0];
                    DataRow name = TableActivo.Rows[0];
                    grupo = Convert.ToString(row[0]);
                }
                return grupo;
            }
        }
        #endregion
        #region verSubGrupoFiltrado()
        public DataTable verSubGrupoFiltrado(string idGrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT s.idSubGrupo as 'ID', s.nombre as 'Nombre', g.nombre as 'Grupo' FROM {0} s INNER JOIN grupo g ON g.idGrupo = s.idGrupo WHERE s.idGrupo = '{1}' ORDER BY idSubgrupo", Tabla_SubGrupo, idGrupo), mysqlCon);
                DataTable table_grupo = new DataTable();
                mysqlDa.Fill(table_grupo);
                return table_grupo;
            }
        }
        #endregion
        #region addTipo
        public void addTipo(string tipo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(tipo) VALUES('{1}')", Tabla_Tipo, tipo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region editTipo()
        public void editTipo(string idTipo, string tipo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET tipo = '{1}' WHERE idTipo = '{2}'", Tabla_Tipo, tipo, idTipo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region addGrupo()
        public void addGrupo(string nombre)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre) VALUES('{1}')", Tabla_Grupo, nombre), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region editGrupo()
        public void editGrupo(string idGrupo, string nombreGrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET nombre = '{1}' WHERE idGrupo = '{2}'", Tabla_Grupo, nombreGrupo, idGrupo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
                mysqlCon.Close();
            }
        }
        #endregion
        #region addSubGrupo
        public void addSubGrupo(string nombre, string idGrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre, idGrupo) VALUES ('{1}', '{2}')", Tabla_SubGrupo, nombre, idGrupo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region editSubGrupo
        public void editSubGrupo(string idSubGrupo, string nombre, string idGrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET nombre = '{1}', idGrupo = '{2}' WHERE idSubGrupo = '{3}'", Tabla_SubGrupo, nombre, idGrupo, idSubGrupo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region filtrarUsuarioDep()
        public DataTable filtrarUsuarioDep(string idDepartamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT idUsuario as 'ID', nombre as 'Nombre' FROM {0} WHERE idDepartamento = '{1}'", Tabla_Usuario, idDepartamento), mysqlCon);
                DataTable dt = new DataTable();
                mysqlDa.Fill(dt);
                return dt;
            }
        }

        #endregion
        #region llenarVariablesArticulos
        public void detalleArticulo(string idArticulo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("SELECT ar.descripcion as 'Descripcion', u.nombre as 'Usuario', d.nombre as 'Departamento' , es.nombre as 'Estado', t.Tipo as 'Tipo', em.nombre as 'Empresa', ar.fecha_compra as 'Fecha', ar.Valor as 'Valor', ar.FPC as 'FPC' FROM {0} ar INNER JOIN {1} u ON ar.idUsuario = u.idUsuario INNER JOIN {6} d ON u.idDepartamento = d.idDepartamento INNER JOIN {2} es ON ar.idEstado = es.idEstado INNER JOIN {3} t ON ar.idTipo = t.idTipoArticulo INNER JOIN {4} em ON ar.idEmpresa = em.idEmpresa WHERE ar.idArticulo = '{5}'", Tabla_Articulo, Tabla_Usuario, Tabla_Estado, Tabla_Tipo_ART, Tabla_Empresa, idArticulo, Tabla_Departamento), mysqlCon);
                MySqlDataReader read =  mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    descripcion_articulo = read["Descripcion"].ToString();
                    usuario_articulo = read["Usuario"].ToString();
                    estado_articulo = read["Estado"].ToString();
                    tipo_articulo = read["Tipo"].ToString();
                    empresa_articulo = read["Empresa"].ToString();
                    fecha_articulo = read["Fecha"].ToString();
                    valor_articulo = read["Valor"].ToString();
                    fpc_articulo = read["FPC"].ToString();
                    departamento_articulo = read["Departamento"].ToString();
                }
                read.Close();
            }
        }
        #endregion
        #region addArtículo
        public void addArticulo(string descripcion, string idUsuario, string idEstado, string idTipo, string idEmpresa, string fecha, string valor, string FPC)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, Valor, FPC) VALUES('{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", Tabla_Articulo, descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha, valor, FPC),mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Ver usuarios por ID Departamento
        public DataTable verUsuariosDep(string idDepartamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idUsuario as 'ID', {0}.nombre as 'Nombre', {0}.user as 'Usuario', {1}.nombre as 'Departamento', {0}.puesto as 'Puesto' FROM {0} INNER JOIN {1} ON {0}.idDepartamento = {1}.idDepartamento WHERE {0}.idDepartamento = '{2}' ORDER BY idUsuario", Tabla_Usuario, Tabla_Departamento, idDepartamento), mysqlCon);
                DataTable TableUser = new DataTable();
                mySqlCmd.Fill(TableUser);
                return TableUser;
            }
        }
        #endregion
        #region editArticulo
        public void editArticulo(string descripcion, string idUsuario, string idEstado, string idTipo, string idEmpresa, string fecha_compra, string Valor, string FPC, string idArticulo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET descripcion = '{1}', idUsuario = '{2}', idEstado = '{3}', idTipo = '{4}', idEmpresa = '{5}', fecha_compra = '{6}', Valor = '{7}', FPC = '{8}' WHERE idArticulo = '{9}'", Tabla_Articulo, descripcion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, Valor, FPC, idArticulo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region verTipoArt()
        //---------------------------------------------------Ver las Categorias------------------------------------------------------//
        public DataTable verTipoArt(string idGrupo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlCmd = new MySqlDataAdapter(string.Format("SELECT idTipoArticulo as 'ID', tipo as 'Tipo' FROM {0} WHERE idGrupoArticulo = '{1}' ORDER BY idTipoArticulo", Tabla_Tipo_ART, idGrupo), mysqlCon);
                DataTable TableCategoria = new DataTable();
                mysqlCmd.Fill(TableCategoria);
                return TableCategoria;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        #endregion
        #region verificarInventario()
        //---------------------------------------------------------------------- Verificar que no hayan inventarios repetidos ------------------------------------------------------------------//
        public DataTable verificarInventarioActivo(string inventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlActivo = new MySqlDataAdapter(string.Format("SELECT idInventarioActivo FROM {0} WHERE nombre = '{1}'", Tabla_InvActivo, inventario), mysqlCon);
                //MySqlDataAdapter mysqlArticulo = new MySqlDataAdapter(string.Format("SELECT idInventarioArticulo FROM {0} WHERE nombre = '{1}'", Tabla_InvArticulo, inventario), mysqlCon);
                DataTable dt = new DataTable();
                mysqlActivo.Fill(dt);
                return dt;
            }
        }
        //---------------------------------------------------------------------- --------------------------------------------------------------------------------------------------------------------//
        public DataTable verificarInventarioArticulo(string inventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //MySqlDataAdapter mysqlActivo = new MySqlDataAdapter(string.Format("SELECT idInventarioActivo FROM {0} WHERE nombre = '{1}'", Tabla_InvActivo, inventario), mysqlCon);
                MySqlDataAdapter mysqlArticulo = new MySqlDataAdapter(string.Format("SELECT idInventarioArticulo FROM {0} WHERE nombre = '{1}'", Tabla_InvArticulo, inventario), mysqlCon);
                DataTable dt = new DataTable();
                mysqlArticulo.Fill(dt);
                return dt;
            }
        }
        //--------------------------------------------------------------------------------------------------------- ------------------------------------------------------------------------------------//
        #endregion
        #region insertInvActivo() 
        //------------------------------------------------------------------------ Insertar Inventario Activo -------------------------------------------------------------//
        public void insertInvActivo(string nombre, string fecha_apertura)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre, idEstadoInv ,fecha_apertura, fecha_final) VALUES('{1}',  1,'{2}', '0')", Tabla_InvActivo, nombre, fecha_apertura), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //--------------------------------------------------------------------------------------- ------------------------------------------------------------------------------//
        #endregion
        #region insertArticulo()
        //---------------------------------------------------------- Inserta en la Tabla Inventario Articulo --------------------------------------//
        public void insertInvArticulo(string nombre, string fechaApertura)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre, idEstadoInv, fecha_apertura, fecha_final) VALUES('{1}', 1, '{2}', '0')", Tabla_InvArticulo, nombre, fechaApertura), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region buscarInventario()
        //----------------------------------------------------* Busca el id de un inventario por su fecha *-----------------------------------//
        public string buscarInventario(string fechaApertura)
        {
            string idInventario = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("SELECT idInventarioActivo FROM {0} WHERE fecha_apertura = '{1}'", Tabla_InvActivo, fechaApertura), mysqlCon);
                MySqlDataReader read = mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    idInventario = read["idInventarioActivo"].ToString();
                }
                return idInventario;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region buscarInventarioArtículo()
        //----------------------------------------------------* Busca el id de un inventario por su fecha *-----------------------------------//
        public string buscarInventarioArticulo(string fechaApertura)
        {
            string idInventario = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("SELECT idInventarioArticulo FROM {0} WHERE fecha_apertura = '{1}'", Tabla_InvArticulo, fechaApertura), mysqlCon);
                MySqlDataReader read = mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    idInventario = read["idInventarioArticulo"].ToString();
                }
                return idInventario;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region insertarDetalleActivo()
        //-------------------------------------------- * Crea los detalles de los inventarios * ---------------------------------------------//
        public void insertarDetalleActivo(string idInventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(idActivo, idEstado, idStatus, idInventario, fecha_actualizacion) SELECT idActivo as 'ID activo', 5 as 'Estado', 2 as 'Status', '{1}' as 'ID Inventario', '0' as 'Fecha Actualización' FROM activo WHERE idEstado != 4 ORDER BY idActivo ASC", Tabla_DetalleInvActivo, idInventario), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region insertarDetalleActivoUnDepto
        //-------------------------------------------- * Crea los detalles de los inventarios * ---------------------------------------------//
        public void insertarDetalleActivoUnDepto(string idInventario, string idDepartamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(idActivo, idEstado, idStatus, idInventario, fecha_actualizacion) SELECT idActivo as 'ID activo', 5 as 'Estado', 2 as 'Status', '{1}' as 'ID Inventario', '0' as 'Fecha Actualización' FROM activo WHERE idEstado != 4 AND idUsuario in (SELECT idUsuario FROM usuario WHERE idDepartamento = '{2}') ORDER BY idActivo ASC", Tabla_DetalleInvActivo, idInventario, idDepartamento), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region insertarDetalleActivoUnUsuario
        //-------------------------------------------- * Crea los detalles de los inventarios * ---------------------------------------------//
        public void insertarDetalleActivoUnUsuario(string idInventario, string idUsuario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(idActivo, idEstado, idStatus, idInventario, fecha_actualizacion) SELECT idActivo as 'ID activo', 5 as 'Estado', 2 as 'Status', '{1}' as 'ID Inventario', '0' as 'Fecha Actualización' FROM activo WHERE idEstado != 4 AND idUsuario = '{2}' ORDER BY idActivo ASC", Tabla_DetalleInvActivo, idInventario, idUsuario), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region insertarDetalleArticulo()
        //-------------------------------------------- * Crea los detalles de los inventarios * ---------------------------------------------//
        public void insertarDetalleArticulo(string idInventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(idArticulo, idEstado, idStatus, idInventario, fecha_actualizacion) SELECT idArticulo as 'ID articulo', 5 as 'Estado', 2 as 'Status', '{1}' as 'ID Inventario', '0' as 'Fecha Actualización' FROM articulo WHERE idEstado != 4 ORDER BY idArticulo ASC", Tabla_DetalleInvArticulo, idInventario), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region insertarDetalleArticuloUnDepartamento()
        //-------------------------------------------- * Crea los detalles de los inventarios * ---------------------------------------------//
        public void insertarDetalleArticuloUnDepartamento(string idInventario, string idDepartamento)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(idArticulo, idEstado, idStatus, idInventario, fecha_actualizacion) SELECT idArticulo as 'ID articulo', 5 as 'Estado', 2 as 'Status', '{1}' as 'ID Inventario', '0' as 'Fecha Actualización' FROM articulo WHERE idEstado != 4 AND idUsuario in (SELECT idUsuario FROM usuario WHERE idDepartamento = '{2}') ORDER BY idArticulo ASC", Tabla_DetalleInvArticulo, idInventario, idDepartamento), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region insertarDetalleArticuloUnUsuario()
        //-------------------------------------------- * Crea los detalles de los inventarios * ---------------------------------------------//
        public void insertarDetalleArticuloUnUsuario(string idInventario, string idUsuario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(idArticulo, idEstado, idStatus, idInventario, fecha_actualizacion) SELECT idArticulo as 'ID articulo', 5 as 'Estado', 2 as 'Status', '{1}' as 'ID Inventario', '0' as 'Fecha Actualización' FROM articulo WHERE idEstado != 4 AND idUsuario = '{2}' ORDER BY idArticulo ASC", Tabla_DetalleInvArticulo, idInventario, idUsuario), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region inventarioActivo()
        //------------------------------------- * busca todos los inventarios de activo * --------------------------------------//
        public DataTable inventarioActivo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //MySqlDataAdapter mySqlData = new MySqlDataAdapter(string.Format("SELECT idInventarioActivo as 'ID', nombre as 'Nombre' FROM {0} ORDER BY idInventarioActivo DESC", Tabla_InvActivo), mysqlCon);
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(string.Format("SELECT a.idInventarioActivo as 'ID', a.nombre as 'Nombre' FROM inventario_activo a WHERE a.fecha_apertura not in (SELECT inventario_articulo.fecha_apertura FROM inventario_articulo INNER JOIN inventario_activo ON inventario_activo.nombre = inventario_articulo.nombre) ORDER BY a.idInventarioActivo DESC", Tabla_InvActivo), mysqlCon);
                mySqlData.Fill(dt);
            }
            return dt;
        }
        //-------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region inventarioArticulo()
        //--------------------------------- * Busca los inventarios de articulo * ---------------------------//
        public DataTable inventarioArticulo()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //MySqlDataAdapter mySqlData = new MySqlDataAdapter(string.Format("SELECT idInventarioArticulo as 'ID', nombre as 'Nombre' FROM {0} ORDER BY idInventarioArticulo DESC", Tabla_InvArticulo), mysqlCon);
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(string.Format("SELECT idInventarioArticulo as 'ID', nombre as 'Nombre' FROM inventario_articulo WHERE fecha_apertura not in (SELECT inventario_activo.fecha_apertura FROM inventario_articulo INNER JOIN inventario_activo ON inventario_activo.nombre = inventario_articulo.nombre) ORDER BY idInventarioArticulo DESC", Tabla_InvArticulo), mysqlCon);
                mySqlData.Fill(dataTable);
            }
            return dataTable;
        }
        //--------------------------------------------------- --------------------------------------------------//
        #endregion
        #region inventarioActivoArticulo()
        //------------------------------------------- * Busca y trae todos los inventario que tengan el mismo nombre en activo y articulo * ---------------------------------------------//
        public DataTable inventarioActivoArticulo()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(string.Format("SELECT a.nombre as 'Nombre' FROM inventario_activo a INNER JOIN inventario_articulo ar ON a.nombre = ar.nombre WHERE a.fecha_apertura = ar.fecha_apertura ORDER BY a.fecha_apertura DESC", Tabla_InvActivo, Tabla_InvArticulo), mysqlCon);
                mySqlData.Fill(dataTable);
            }
            return dataTable;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region idActivo()
        //---------------- * trae el id de activo segun su nombre * ------------------//
        public string idActivo(string nombre)
        {
            string idActivo = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("SELECT idInventarioActivo as 'ID' FROM {0} WHERE nombre = '{1}'", Tabla_InvActivo, nombre),mysqlCon);
                MySqlDataReader read = mySqlCmd.ExecuteReader();
                while (read.Read())
                {
                    idActivo = read["ID"].ToString();
                }
            }
            return idActivo;
        }
        //------------------------------------- ------------------------------------------//
        #endregion
        #region idArticulo()
        //----------------------- * trae el id de artículo segun su nombre * --------------------------//
        public string idArticulo(string nombre)
        {
            string idArticulo = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("SELECT idInventarioArticulo as 'ID' FROM {0} WHERE nombre = '{1}'", Tabla_InvArticulo, nombre), mysqlCon);
                MySqlDataReader read = mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    idArticulo = read["ID"].ToString();
                }
            }
            return idArticulo;
        }
        //----------------------------------------------- -------------------------------------------------//
        #endregion
        #region DataArtículo
        //----------------------------- * Trae la información que necesito de artículo * ------------------------------//
        public void traerArticulo(string idArticulo, string idInvArticulo)
        {
            idDetalleArticulo = "";
            descripcion_articulo = "";
            usuario_articulo = "";
            estado_articulo = "";
            fisico_articulo = "";
            inv_articulo = "";
            fecha_articulo = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("" +
                    "SELECT " +
                    "dART.idDetalle as 'Detalle', " +
                    "ar.descripcion as 'Articulo', " +
                    "u.nombre as 'Usuario', " +
                    "e.nombre as 'Estado', " +
                    "s.nombre as 'Status', " +
                    "inv.nombre as 'Inventario', " +
                    "dArt.fecha_actualizacion as 'Fecha' " +
                    "FROM detalleinvarticulo dArt " +
                    "INNER JOIN articulo ar ON dArt.idArticulo = ar.idArticulo " +
                    "INNER JOIN usuario u ON ar.idUsuario = u.idUsuario " +
                    "INNER JOIN estado e ON ar.idEstado = e.idEstado " +
                    "INNER JOIN status s ON s.idStatus = dArt.idStatus " +
                    "INNER JOIN inventario_articulo inv ON inv.idInventarioArticulo = dArt.idInventario " +
                    "WHERE dArt.idArticulo = '{0}' AND dArt.idInventario = '{1}' " +
                    "ORDER BY `dArt`.`idDetalle` ASC", idArticulo, idInvArticulo), mysqlCon); 
                MySqlDataReader read = mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    idDetalleArticulo = read["Detalle"].ToString();
                    descripcion_articulo = read["Articulo"].ToString();
                    usuario_articulo = read["Usuario"].ToString();
                    estado_articulo = read["Estado"].ToString();
                    fisico_articulo = read["Status"].ToString();
                    inv_articulo = read["Inventario"].ToString();
                    if (read["Fecha"].ToString() == "1/01/0001 00:00:00")
                    {
                        fecha_articulo = "Sin actualizaciones";
                    }
                    else
                    {
                        fecha_articulo = read["Fecha"].ToString();
                    }
                }
            }
        }
        //------------------------------------------------------- ----------------------------------------------------------//
        #endregion
        #region DataActivo
        public void traerActivo(string idActivo, string idInvActivo)
        {
            idDetalleActivo = "";
            descripcion = "";
            usuario = "";
            estado = "";
            fisico = "";
            inv_activo = "";
            fecha_activo = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("" +
                    "SELECT " +
                    "dAct.idDetalle as 'Detalle', " +
                    "a.descripcion as 'Activo', " +
                    "u.nombre as 'Usuario', " +
                    "e.nombre as 'Estado', " +
                    "s.nombre as 'Status', " +
                    "inv.nombre as 'Inventario', " +
                    "dAct.fecha_actualizacion as 'Fecha' " +
                    "FROM detalleinvactivo dAct " +
                    "INNER JOIN activo a ON dAct.idActivo = a.idActivo " +
                    "INNER JOIN usuario u ON a.idUsuario = u.idUsuario " +
                    "INNER JOIN estado e ON a.idEstado = e.idEstado " +
                    "INNER JOIN status s ON s.idStatus = dAct.idStatus" +
                    " INNER JOIN inventario_activo inv ON inv.idInventarioActivo = dAct.idInventario " +
                    "WHERE dAct.idActivo = '{0}' AND dAct.idInventario = '{1}' " +
                    "ORDER BY dAct.idDetalle ASC", idActivo, idInvActivo), mysqlCon);
                MySqlDataReader read = mysqlCmd.ExecuteReader();
                while (read.Read())
                {
                    idDetalleActivo = read["Detalle"].ToString();
                    descripcion = read["Activo"].ToString();
                    usuario = read["Usuario"].ToString();
                    estado = read["Estado"].ToString();
                    fisico = read["Status"].ToString();
                    inv_activo = read["Inventario"].ToString();
                    if (read["Fecha"].ToString() == "1/01/0001 00:00:00")
                    {
                        fecha_activo = "Sin actualizaciones";
                    }
                    else
                    {
                        fecha_activo = read["Fecha"].ToString();
                    }
                }
            }
        }
        #endregion
        #region updateDetalleActivo
        public void updateDetalleActivo(string idEstado, string idStatus, string fecha, string idDetalle)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("" +
                    "UPDATE {0} SET " +
                    "idEstado = '{1}', " +
                    "idStatus = '{2}', " +
                    "fecha_actualizacion = '{3}' " +
                    "WHERE idDetalle = '{4}'", Tabla_DetalleInvActivo, idEstado, idStatus, fecha, idDetalle), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region updateDetalleArticulo
        public void updateDetalleArticulo(string idEstado, string idStatus, string fechaDep, string idDetalle)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("" +
                    "UPDATE {0} SET " +
                    "idEstado = '{1}', " +
                    "idStatus = '{2}', " +
                    "fecha_actualizacion = '{3}' " +
                    "WHERE idDetalle = '{4}'", Tabla_DetalleInvArticulo, idEstado, idStatus, fechaDep, idDetalle), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Cambiar Estado de Activo
        public void cambioEstadoActivo(string idEstado, string idActivo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("" +
                    "UPDATE {0} " +
                    "SET idEstado = '{1}' " +
                    "WHERE idActivo = '{2}'", Tabla_Activo, idEstado, idActivo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Cambiar Estado de Articulo
        public void cambioEstadoArticulo(string idEstado, string idArticulo)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("" +
                    "UPDATE {0} " +
                    "SET idEstado = '{1}' " +
                    "WHERE idArticulo = '{2}'", Tabla_Articulo, idEstado, idArticulo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region idEstados
        public string idEstados(string idActivo)
        {
            string idEstado = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlData = new MySqlCommand(string.Format("SELECT idEstado FROM {0} WHERE idActivo = '{1}'", Tabla_Activo, idActivo), mysqlCon);
                MySqlDataReader read = mySqlData.ExecuteReader();
                while (read.Read())
                {
                    idEstado = read["idEstado"].ToString();
                }
            }
            return idEstado;
        }
        #endregion
        #region depreciacionAcumulada()
        public void depreciacionAcumulada()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand(string.Format("UPDATE {0} set DepAcumulada = (DepAcumulada + depreciacion_mes), ValorLibros = (Valor - DepAcumulada) WHERE (DepAcumulada + depreciacion_mes) <= valor_depreciable", Tabla_Activo), mysqlCon);
                mysqlCmd.ExecuteNonQuery();
                mysqlCon.Close();
            }
        }
        #endregion
        #region reporteActivoUsuario()
        public DataTable reporteActivoUsuario(string idUser)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) 
            {
                mysqlCon.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(string.Format("SELECT * FROM activo WHERE idUser = '{0}'", idUser), mysqlCon);
                adapter.Fill(dt);
                mysqlCon.Close();
                return dt;
            }
        }
        #endregion
    }
}

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

        public DataTable consulta(string consulta = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("Estado");
            dt.Columns.Add("idEstado");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("idTipo");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Fecha de Compra");
            dt.Columns.Add("Valor");
            dt.Columns.Add("FPC");
            dt.Columns.Add("Fecha de Depreciacion");
            dt.Columns.Add("% Depreciacion");
            dt.Columns.Add("Depreciacion Acumulada");
            dt.Columns.Add("Valor Residual");
            dt.Columns.Add("Valor Libros");
            dt.Columns.Add("Subgrupo");
            dt.Columns.Add("idSubgrupo");
            dt.Columns.Add("Grupo");
            dt.Columns.Add("idGrupo");
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT a.idActivo, " +
                "a.descripcion, " +
                "u.nombre AS 'Usuario', " +
                "u.idUsuario, " +
                "e.nombre AS 'Estado', " +
                "e.idEstado, " +
                "c.tipo AS 'Tipo', " +
                "c.idTipo, " +
                "em.nombre AS 'Empresa', " +
                "a.fecha_compra, " +
                "a.Valor, " +
                "a.FPC, " +
                "a.fecha_dep, " +
                "a.PorcentajeDep, " +
                "a.DepAcumulada, " +
                "a.ValorResidual, " +
                "a.ValorLibros, " +
                "s.nombre AS 'Subgrupo', " +
                "a.idSubgrupo, " +
                "g.nombre AS 'grupo', " +
                "g.idGrupo " +
                "FROM `activo` AS a " +
                "JOIN `usuario` AS u ON a.idUsuario = u.idUsuario " +
                "JOIN `estado` AS e ON a.idEstado = e.idEstado " +
                "JOIN `tipo` AS c ON a.idTipo = c.idTipo " +
                "JOIN `empresa` AS em ON a.idEmpresa = em.idEmpresa " +
                "JOIN `subgrupo` AS s ON a.idSubgrupo = s.idSubgrupo " +
                "JOIN `grupo` AS g ON g.idGrupo = s.idGrupo " +
                "JOIN `departamento` AS d ON d.idDepartamento = u.idDepartamento " + 
                consulta + 
                " ORDER BY a.idActivo";
            connection.Open();
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
                    activo["Tipo"] = reader.GetString(6);
                    activo["idTipo"] = reader.GetString(7);
                    activo["Empresa"] = reader.GetString(8);
                    activo["Fecha de Compra"] = reader.GetString(9);
                    activo["Valor"] = reader.GetString(10);
                    activo["FPC"] = reader.GetString(11);
                    activo["Fecha de Depreciacion"] = reader.GetString(12);
                    activo["% Depreciacion"] = reader.GetString(13);
                    activo["Depreciacion Acumulada"] = reader.GetString(14);
                    activo["Valor Residual"] = reader.GetString(15);
                    activo["Valor Libros"] = reader.GetString(16);
                    activo["Subgrupo"] = reader.GetString(17);
                    activo["idSubgrupo"] = reader.GetString(18);
                    activo["Grupo"] = reader.GetString(19);
                    activo["idGrupo"] = reader.GetString(20);
                    dt.Rows.Add(activo);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable consultaActivoDetalle(int id, string consulta = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("idActivo");
            dt.Columns.Add("Estado Fisico");
            dt.Columns.Add("idEstado");
            dt.Columns.Add("Estado");
            dt.Columns.Add("idStatus");
            dt.Columns.Add("idInventario");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("idTipo");
            dt.Columns.Add("Subgrupo");
            dt.Columns.Add("idSubgrupo");
            dt.Columns.Add("Grupo");
            dt.Columns.Add("idGrupo");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("idEmpresa");
            dt.Columns.Add("Fecha de Actualizacion");
            dt.Columns.Add("idDepartamento");
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT a.idDetalle, " +
                "ar.descripcion, " +
                "a.idActivo, " +
                "e.nombre, " +
                "e.idEstado, " +
                "s.nombre, " +
                "s.idStatus, " +
                "i.idInventarioActivo, " +
                "u.nombre, " +
                "u.idUsuario, " +
                "t.Tipo, " +
                "t.idTipo, " +
                "sub.nombre, " +
                "sub.idSubgrupo, " +
                "g.nombre, " +
                "g.idGrupo, " +
                "em.nombre, " +
                "em.idEmpresa, " +
                "a.fecha_actualizacion, " +
                "u.idDepartamento " +
                "FROM detalleinvactivo a " +
                "JOIN activo ar ON a.idActivo = ar.idActivo " +
                "JOIN estado e ON a.idEstado = e.idEstado " +
                "JOIN status s ON a.idStatus = s.idStatus " +
                "JOIN inventario_activo i On a.idInventario = i.idInventarioActivo " +
                "JOIN usuario u ON ar.idUsuario = u.idUsuario " +
                "JOIN tipo t ON ar.idTipo = t.idTipo " +
                "JOIN empresa em ON ar.idEmpresa = em.idEmpresa " +
                "JOIN subgrupo sub ON ar.idSubgrupo = sub.idSubgrupo " +
                "JOIN grupo g ON sub.idGrupo = g.idGrupo " +
                "WHERE i.idInventarioActivo = " + id + consulta + " ORDER BY a.idDetalle ASC, a.idEstado DESC";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow activo = dt.NewRow();
                    activo["ID"] = reader.GetString(0);
                    activo["Descripcion"] = reader.GetString(1);
                    activo["idActivo"] = reader.GetString(2);
                    activo["Estado Fisico"] = reader.GetString(3);
                    activo["idEstado"] = reader.GetString(4);
                    activo["Estado"] = reader.GetString(5);
                    activo["idStatus"] = reader.GetString(6);
                    activo["idInventario"] = reader.GetString(7);
                    activo["Usuario"] = reader.GetString(8);
                    activo["idUsuario"] = reader.GetString(9);
                    activo["Tipo"] = reader.GetString(10);
                    activo["idTipo"] = reader.GetString(11);
                    activo["Subgrupo"] = reader.GetString(12);
                    activo["idSubgrupo"] = reader.GetString(13);
                    activo["Grupo"] = reader.GetString(14);
                    activo["idGrupo"] = reader.GetString(15);
                    activo["Empresa"] = reader.GetString(16);
                    activo["idEmpresa"] = reader.GetString(17);
                    activo["Fecha de Actualizacion"] = reader.GetMySqlDateTime(18);
                    activo["idDepartamento"] = reader.GetString(19);
                    dt.Rows.Add(activo);
                }
            }
            connection.Close();
            return dt;
        }

        public int ActivosRevisados(int id)
        {
            int revisados = new int();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM detalleinvactivo WHERE idStatus = 1 AND idInventario = " + id;
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    revisados = reader.GetInt32(0);
                }
            }
            connection.Close();
            return revisados;
        }

        public int ActivosNoRevisados(int id)
        {
            int revisados = new int();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM detalleinvactivo WHERE idStatus = 2 AND idInventario = " + id;
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    revisados = reader.GetInt32(0);
                }
            }
            connection.Close();
            return revisados;
        }

        public DataTable consultaArticulo(string consulta = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("Estado");
            dt.Columns.Add("idEstado");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("idTipo");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Fecha de Compra");
            dt.Columns.Add("Valor");
            dt.Columns.Add("FPC");
            dt.Columns.Add("Subgrupo");
            dt.Columns.Add("idSubgrupo");
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT a.idArticulo, " +
                "a.descripcion, " +
                "u.nombre AS 'Usuario', " +
                "u.idUsuario, " +
                "e.nombre AS 'Estado', " +
                "e.idEstado, " +
                "c.Tipo AS 'Tipo', " +
                "c.idTipoArticulo, " +
                "em.nombre AS 'Empresa', " +
                "a.fecha_compra, " +
                "a.Valor, " +
                "a.FPC, " +
                "s.nombre AS 'Grupo', " +
                "s.idGrupoArticulo " +
                "FROM `articulo` AS a " +
                "JOIN `usuario` AS u ON a.idUsuario = u.idUsuario " +
                "JOIN `estado` AS e ON a.idEstado = e.idEstado " +
                "JOIN `tipo_articulo` AS c ON a.idTipo = c.idTipoArticulo " +
                "JOIN `empresa` AS em ON a.idEmpresa = em.idEmpresa " +
                "JOIN `grupo_articulo` AS s ON c.idGrupoArticulo = s.idGrupoArticulo " +
                "JOIN `departamento` AS d ON d.idDepartamento = u.idDepartamento " + 
                consulta + 
                " ORDER BY a.idArticulo";
            connection.Open();
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
                    activo["Tipo"] = reader.GetString(6);
                    activo["idTipo"] = reader.GetString(7);
                    activo["Empresa"] = reader.GetString(8);
                    activo["Fecha de Compra"] = reader.GetString(9);
                    activo["Valor"] = reader.GetString(10);
                    activo["FPC"] = reader.GetString(11);
                    activo["Subgrupo"] = reader.GetString(12);
                    activo["idSubgrupo"] = reader.GetString(13);
                    dt.Rows.Add(activo);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable consultaArticuloDetalle(int id, string consulta = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("idArticulo");
            dt.Columns.Add("Estado Fisico");
            dt.Columns.Add("idEstado");
            dt.Columns.Add("Estado");
            dt.Columns.Add("idStatus");
            dt.Columns.Add("idInventario");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("idTipo");
            dt.Columns.Add("Grupo");
            dt.Columns.Add("idGrupo");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("idEmpresa");
            dt.Columns.Add("Fecha de Actualizacion");
            dt.Columns.Add("idDepartamento");
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT a.idDetalle, " +
                "ar.descripcion, " +
                "a.idArticulo, " +
                "e.nombre, " +
                "e.idEstado, " +
                "s.nombre, " +
                "s.idStatus, " +
                "i.idInventarioArticulo, " +
                "u.nombre, " +
                "u.idUsuario, " +
                "t.Tipo, " +
                "t.idTipoArticulo, " +
                "em.nombre, " +
                "em.idEmpresa, " +
                "g.nombre, " +
                "g.idGrupoArticulo, " +
                "a.fecha_actualizacion ," +
                "u.idDepartamento " +
                "FROM detalleinvarticulo a " +
                "JOIN articulo ar ON a.idArticulo = ar.idArticulo " +
                "JOIN estado e ON a.idEstado = e.idEstado " +
                "JOIN status s ON a.idStatus = s.idStatus " +
                "JOIN inventario_articulo i On a.idInventario = i.idInventarioArticulo " +
                "JOIN usuario u ON ar.idUsuario = u.idUsuario " +
                "JOIN tipo_articulo t ON ar.idTipo = t.idTipoArticulo " +
                "JOIN empresa em ON ar.idEmpresa = em.idEmpresa " +
                "JOIN grupo_articulo g ON t.idGrupoArticulo = g.idGrupoArticulo " +
                "WHERE i.idInventarioArticulo = " + id + consulta + " ORDER BY a.idDetalle ASC, a.idEstado DESC";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow activo = dt.NewRow();
                    activo["ID"] = reader.GetString(0);
                    activo["Descripcion"] = reader.GetString(1);
                    activo["idArticulo"] = reader.GetString(2);
                    activo["Estado Fisico"] = reader.GetString(3);
                    activo["idEstado"] = reader.GetString(4); 
                    activo["Estado"] = reader.GetString(5);
                    activo["idStatus"] = reader.GetString(6);
                    activo["idInventario"] = reader.GetString(7);
                    activo["Usuario"] = reader.GetString(8);
                    activo["idUsuario"] = reader.GetString(9);
                    activo["Tipo"] = reader.GetString(10);
                    activo["idTipo"] = reader.GetString(11);
                    activo["Empresa"] = reader.GetString(12);
                    activo["idEmpresa"] = reader.GetString(13);
                    activo["Grupo"] = reader.GetString(14);
                    activo["idGrupo"] = reader.GetString(15);
                    activo["Fecha de Actualizacion"] = reader.GetMySqlDateTime(16);
                    activo["idDepartamento"] = reader.GetString(17);
                    dt.Rows.Add(activo);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable historial(int id, int tabla)
        {
            DataTable dt = new DataTable();
            if (tabla == 1)
            {
                //activos
                dt.Columns.Add("ID", typeof(Int32));
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Usuario");
                dt.Columns.Add("idUsuario");
                dt.Columns.Add("Estado");
                dt.Columns.Add("idEstado");
                dt.Columns.Add("Tipo");
                dt.Columns.Add("idTipo");
                dt.Columns.Add("Empresa");
                dt.Columns.Add("Fecha de Compra");
                dt.Columns.Add("Valor");
                dt.Columns.Add("FPC");
                dt.Columns.Add("Fecha de Depreciacion");
                dt.Columns.Add("% Depreciacion");
                dt.Columns.Add("Depreciacion Acumulada");
                dt.Columns.Add("Valor Residual");
                dt.Columns.Add("Valor Libros");
                dt.Columns.Add("Subgrupo");
                dt.Columns.Add("idSubgrupo");
                dt.Columns.Add("Grupo");
                dt.Columns.Add("idGrupo");
                dt.Columns.Add("Código");
                dt.Columns.Add("Fecha de Modificación");
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT a.idHistorial, " +
                    "a.descripcion, " +
                    "u.nombre AS 'Usuario', " +
                    "u.idUsuario, " +
                    "e.nombre AS 'Estado', " +
                    "e.idEstado, " +
                    "c.tipo AS 'Tipo', " +
                    "c.idTipo, " +
                    "em.nombre AS 'Empresa', " +
                    "a.fecha_compra, " +
                    "a.Valor, " +
                    "a.FPC, " +
                    "a.fecha_dep, " +
                    "a.PorcentajeDep, " +
                    "a.DepAcumulada, " +
                    "a.ValorResidual, " +
                    "a.ValorLibros, " +
                    "s.nombre AS 'Subgrupo', " +
                    "a.idSubgrupo, " +
                    "g.nombre, " +
                    "s.idGrupo, " +
                    "ar.codigo, " +
                    "a.fecha_modificacion " +
                    "FROM `historial_activo` AS a " +
                    "JOIN `activo` AS ar ON a.idActivo = ar.idActivo " +
                    "JOIN `usuario` AS u ON a.idUsuario = u.idUsuario " +
                    "JOIN `estado` AS e ON a.idEstado = e.idEstado " +
                    "JOIN `tipo` AS c ON a.idTipo = c.idTipo " +
                    "JOIN `empresa` AS em ON a.idEmpresa = em.idEmpresa " +
                    "JOIN `subgrupo` AS s ON a.idSubgrupo = s.idSubgrupo " +
                    "JOIN `grupo` AS g ON g.idGrupo = s.idGrupo " +
                    "JOIN `departamento` AS d ON d.idDepartamento = u.idDepartamento " +
                    "WHERE a.idActivo = " + id + " ORDER BY a.idHistorial DESC";
                connection.Open();
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
                        activo["Tipo"] = reader.GetString(6);
                        activo["idTipo"] = reader.GetString(7);
                        activo["Empresa"] = reader.GetString(8);
                        activo["Fecha de Compra"] = reader.GetString(9);
                        activo["Valor"] = reader.GetString(10);
                        activo["FPC"] = reader.GetString(11);
                        activo["Fecha de Depreciacion"] = reader.GetString(12);
                        activo["% Depreciacion"] = reader.GetString(13);
                        activo["Depreciacion Acumulada"] = reader.GetString(14);
                        activo["Valor Residual"] = reader.GetString(15);
                        activo["Valor Libros"] = reader.GetString(16);
                        activo["Subgrupo"] = reader.GetString(17);
                        activo["idSubgrupo"] = reader.GetString(18);
                        activo["Grupo"] = reader.GetString(19);
                        activo["idGrupo"] = reader.GetString(20);
                        activo["Código"] = reader.GetString(21);
                        activo["Fecha de Modificación"] = reader.GetString(22);
                        dt.Rows.Add(activo);
                    }
                }
                connection.Close();
            }
            else
            {
                //articulos
                dt.Columns.Add("ID", typeof(Int32));
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Usuario");
                dt.Columns.Add("idUsuario");
                dt.Columns.Add("Estado");
                dt.Columns.Add("idEstado");
                dt.Columns.Add("Tipo");
                dt.Columns.Add("idTipo");
                dt.Columns.Add("Grupo");
                dt.Columns.Add("idGrupo");
                dt.Columns.Add("Empresa");
                dt.Columns.Add("Fecha de Compra");
                dt.Columns.Add("Valor");
                dt.Columns.Add("FPC");
                dt.Columns.Add("Código");
                dt.Columns.Add("Fecha de Modificación");
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT a.idHistorial, " +
                    "a.descripcion, " +
                    "u.nombre AS 'Usuario', " +
                    "u.idUsuario, " +
                    "e.nombre AS 'Estado', " +
                    "e.idEstado, " +
                    "c.tipo AS 'Tipo', " +
                    "c.idTipo, " +
                    "em.nombre AS 'Empresa', " +
                    "a.fecha_compra, " +
                    "a.Valor, " +
                    "a.FPC, " +
                    "a.fecha_dep, " +
                    "a.PorcentajeDep, " +
                    "a.DepAcumulada, " +
                    "a.ValorResidual, " +
                    "a.ValorLibros, " +
                    "s.nombre AS 'Subgrupo', " +
                    "a.idSubgrupo, " +
                    "g.nombre, " +
                    "s.idGrupo, " +
                    "ar.codigo, " +
                    "a.fecha_modificacion " +
                    "FROM `historial_activo` AS a " +
                    "JOIN `activo` AS ar ON a.idActivo = ar.idActivo " +
                    "JOIN `usuario` AS u ON a.idUsuario = u.idUsuario " +
                    "JOIN `estado` AS e ON a.idEstado = e.idEstado " +
                    "JOIN `tipo` AS c ON a.idTipo = c.idTipo " +
                    "JOIN `empresa` AS em ON a.idEmpresa = em.idEmpresa " +
                    "JOIN `subgrupo` AS s ON a.idSubgrupo = s.idSubgrupo " +
                    "JOIN `grupo` AS g ON g.idGrupo = s.idGrupo " +
                    "JOIN `departamento` AS d ON d.idDepartamento = u.idDepartamento " +
                    "WHERE a.idActivo = " + id + " ORDER BY a.idHistorial DESC";
                connection.Open();
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
                        activo["Tipo"] = reader.GetString(6);
                        activo["idTipo"] = reader.GetString(7);
                        activo["Empresa"] = reader.GetString(8);
                        activo["Fecha de Compra"] = reader.GetString(9);
                        activo["Valor"] = reader.GetString(10);
                        activo["FPC"] = reader.GetString(11);
                        activo["Grupo"] = reader.GetString(12);
                        activo["idGrupo"] = reader.GetString(13);
                        activo["Código"] = reader.GetString(14);
                        activo["Fecha de Modificación"] = reader.GetString(15);
                        dt.Rows.Add(activo);
                    }
                }
                connection.Close();
            }
            return dt;
        }

        public int ArticulosRevisados(int id)
        {
            int revisados = new int();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM detalleinvarticulo WHERE idStatus = 1 AND idInventario = " + id;
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    revisados= reader.GetInt32(0);
                }
            }
            connection.Close();
            return revisados;
        }

        public int ArticulosNoRevisados(int id)
        {
            int revisados = new int();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM detalleinvarticulo WHERE idStatus = 2 AND idInventario =" + id;
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    revisados = reader.GetInt32(0);
                }
            }
            connection.Close();
            return revisados;
        }

        public DataTable usuarios(int idDepto)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idU", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario WHERE idDepartamento = " + idDepto;
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

        public DataTable grupos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idG", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM grupo";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow grupo = dt.NewRow();
                    grupo["idG"] = reader.GetInt32(0);
                    grupo["nombre"] = reader.GetString(1);
                    dt.Rows.Add(grupo);
                }
            }
            connection.Close();
            return dt;
        }

        public int EstadoInvAr(int id)
        {
            int estado = new int();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT idEstadoInv FROM inventario_articulo WHERE idInventarioArticulo = " + id;
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    estado = reader.GetInt32(0);
                }
            }
            connection.Close();
            return estado;
        }

        public bool cerrarInvAr(int id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE inventario_articulo SET idEstadoInv = 2, fecha_final = current_timestamp() WHERE idInventarioArticulo = " + id;
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public int EstadoInvAc(int id)
        {
            int estado = new int();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT idEstadoInv FROM inventario_activo WHERE idInventarioActivo = " + id;
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    estado = reader.GetInt32(0);
                }
            }
            connection.Close();
            return estado;
        }

        public bool cerrarInvAc(int id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE inventario_activo SET idEstadoInv = 2, fecha_final = current_timestamp() WHERE idInventarioActivo = " + id;
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public DataTable gruposAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Grupo", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM grupo_articulo ORDER BY idGrupoArticulo";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow grupo = dt.NewRow();
                    grupo["ID"] = reader.GetInt32(0);
                    grupo["Grupo"] = reader.GetString(1);
                    dt.Rows.Add(grupo);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable grupo(string id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Grupo", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM grupo_articulo WHERE idGrupoArticulo = " + id + " ORDER BY idGrupoArticulo";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow categoria = dt.NewRow();
                    categoria["ID"] = reader.GetInt32(0);
                    categoria["Tipo"] = reader.GetString(1);
                    dt.Rows.Add(categoria);
                }
            }
            connection.Close();
            return dt;
        }

        public bool addGrupo(string desc)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO grupo_articulo VALUES (0, '" + desc + "')";
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public bool editGrupo(string desc, string id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE grupo_articulo SET nombre = '" + desc + "' WHERE idGrupoArticulo = " + id;
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public bool deleteGrupoTipoArticulo(string tabla, string id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Delete From" + tabla.Replace("s","").ToLower() + "_articulo Where id" + tabla.Replace("s", "") + "Articulo = " + id;
            connection.Open();
            object resultado;
            try
            { 
                resultado = cmd.ExecuteNonQuery();
            }
            catch
            {
                resultado = null;
            }
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public DataTable subgrupo(int idGrupo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idS", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM subgrupo WHERE idGrupo = " + idGrupo;
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow sub = dt.NewRow();
                    sub["idS"] = reader.GetInt32(0);
                    sub["nombre"] = reader.GetString(1);
                    dt.Rows.Add(sub);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable tipos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idT", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow categoria = dt.NewRow();
                    categoria["idT"] = reader.GetInt32(0);
                    categoria["nombre"] = reader.GetString(1);
                    dt.Rows.Add(categoria);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable status()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idS", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM status";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow categoria = dt.NewRow();
                    categoria["idS"] = reader.GetInt32(0);
                    categoria["nombre"] = reader.GetString(1);
                    dt.Rows.Add(categoria);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable tiposArticulo(int idSub)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idT", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_articulo WHERE idGrupoArticulo =" + idSub;
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow categoria = dt.NewRow();
                    categoria["idT"] = reader.GetInt32(0);
                    categoria["nombre"] = reader.GetString(1);
                    dt.Rows.Add(categoria);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable tiposAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Grupo", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT t.idTipoArticulo, t.Tipo, g.nombre FROM tipo_articulo as t " +
                "JOIN grupo_articulo AS g ON t.idGrupoArticulo = g.idGrupoArticulo ORDER BY t.idTipoArticulo";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow categoria = dt.NewRow();
                    categoria["ID"] = reader.GetInt32(0);
                    categoria["Tipo"] = reader.GetString(1);
                    categoria["Grupo"] = reader.GetString(2);
                    dt.Rows.Add(categoria);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable tipo(string id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Grupo", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM tipo_articulo as t " +
                "JOIN grupo_articulo AS g ON t.idGrupoArticulo = g.idGrupoArticulo WHERE t.idTipoArticulo = " + id + " ORDER BY t.idTipoArticulo";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow categoria = dt.NewRow();
                    categoria["ID"] = reader.GetInt32(0);
                    categoria["Tipo"] = reader.GetString(1);
                    categoria["Grupo"] = reader.GetString(2);
                    dt.Rows.Add(categoria);
                }
            }
            connection.Close();
            return dt;
        }

        public bool addTipo(string desc, string grupo)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO tipo_articulo VALUES (0, '" + desc + "', " + grupo + ")";
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public bool editTipo(string desc, string grupo, string id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE tipo_articulo SET tipo = '" + desc + "', idGrupoArticulo = " + grupo + " WHERE idTipoArticulo = " + id;
            Console.WriteLine(cmd.CommandText);
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
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

        public DataTable empresas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idEm", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM empresa";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow empresa = dt.NewRow();
                    empresa["idEm"] = reader.GetInt32(0);
                    empresa["nombre"] = reader.GetString(1);
                    dt.Rows.Add(empresa);
                }
            }
            connection.Close();
            return dt;
        }

        public DataTable departamentos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idD", typeof(Int32));
            dt.Columns.Add("nombre", typeof(string));
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM departamento";
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow depto = dt.NewRow();
                    depto["idD"] = reader.GetInt32(0);
                    depto["nombre"] = reader.GetString(1);
                    dt.Rows.Add(depto);
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
            cmd.CommandText = "SELECT a.idActivo,a.descripcion,u.nombre AS 'Usuario', u.idUsuario, " +
                "e.nombre AS 'Estado', e.idEstado, c.nombre AS 'Categoria', c.idCategoria, em.nombre AS 'Empresa', a.fecha_ingreso FROM `" + tabla + "` AS a " +
                "JOIN `usuario` AS u ON a.idUsuario = u.idUsuario " +
                "JOIN `estado` AS e ON a.idEstado = e.idEstado " +
                "JOIN `categoria` AS c ON a.idCategoria = c.idCategoria " +
                "JOIN `empresa` AS em ON a.idEmpresa = em.idEmpresa WHERE a.idActivo = " + id;
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

        public bool traspaso(int idUsuario, string tabla, int id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE " + tabla + " SET idUsuario = " + idUsuario + " WHERE idActivo = " + id;
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public bool editar(string desc, int estado, int cat, int empresa, string tabla, int id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE " + tabla + " SET descripcion = '" +desc  + "'," +
                "idEstado = "+estado+"," +
                "idCategoria = "+cat+"," +
                "idEmpresa = "+empresa+" WHERE idActivo = " + id;
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }

        public bool fecha(string tabla, string fecha, int id)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE " + tabla + " SET fecha_ingreso = '" + fecha + "' WHERE idActivo = " + id;
            connection.Open();
            object resultado = cmd.ExecuteNonQuery();
            connection.Close();
            if (resultado != null) return true;
            else return false;
        }
    }
}

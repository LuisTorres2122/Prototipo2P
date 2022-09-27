using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Modelo
{
    public class sentencias
    {
        Conexion con = new Conexion();
        public OdbcDataAdapter llenartabla(string tabla)
        {


            string sql = "select * from " + tabla + ";";
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());



            return datatable;
        }

        public void insertar(string dato, string tipo, string tabla)
        {
            try
            {
                string sql = "insert into " + tabla + "(" + tipo + ") values (" + dato + ")";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }


        }

        public void eliminar(int clave, string campo, string tabla)
        {
            try
            {
                string sql = "delete from " + tabla + " where " + campo + "=" + clave + ";";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }

        }

        public void actualizar(string dato, string condicion, string tabla)
        {
            try
            {
                string sql = "Update " + tabla + " " + dato + " where " + condicion;
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }


        }

        public string buscarid(string tabla, string tipo)
        {
            string dato = " ";
            try
            {

                string sql = "select " + tipo + " from " + tabla + " Order by " + tipo + " Desc Limit 1";
                OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
                OdbcDataReader lr = cmd.ExecuteReader();
                while (lr.Read())
                {
                    dato = lr.GetString(0);
                }
            }
            catch (Exception e)
            {

            }


            return dato;
        }


        public OdbcDataAdapter buscarnombretabla2(string tabla, int numero, string BD)
        {
            string[] dato = new string[numero];
            string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_SCHEMA= '" + BD + "' AND TABLE_NAME= '" + tabla + "' order by COLUMN_NAME asc";
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());

            return datatable;
        }
        public OdbcDataAdapter buscarnombretabla()
        {

            string sql = "show tables";
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());

            return datatable;
        }

        public string[] comprobaciondellenado(string tabla, string tipo, string dato, int tamaño)
        {

            string[] datos = new string[tamaño];
            string sql = "select * from " + tabla + " where " + tipo + " = '" + dato + "'";
            OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
            OdbcDataReader lr = cmd.ExecuteReader();
            while (lr.Read())
            {
                for (int x = 0; x < tamaño; x++)
                {
                    datos[x] = lr.GetString(x);
                }

            }



            return datos;
        }

        public int estadotabla(string tabla)
        {
            int dato = 0;
            string sql = "select count(*) as total from " + tabla;
            OdbcCommand cmd = new OdbcCommand(sql, con.conexion());
            OdbcDataReader lr = cmd.ExecuteReader();
            while (lr.Read())
            {

                dato = lr.GetInt32(0);


            }
            return dato;
        }


    }
}

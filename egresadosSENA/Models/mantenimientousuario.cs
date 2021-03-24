using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;




namespace egresadosSENA.Models
{
    public class mantenimientousuario
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Alta(usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into es_usuarios(documento, tipo_doc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado,direccion, barrio, ciudad, departamento, fecharegistro) values(@documento, @tipo_doc, @nombre, @celular, @email, @genero, @aprendiz, @egresado, @areaformacion, @fechaegresado, @direccion, @barrio, @ciudad, @departamento, @fecharegistro)", con);


            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters.Add("@tipo_doc", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.VarChar);

            comando.Parameters["@documento"].Value = usu.documento;
            comando.Parameters["@tipo_doc"].Value = usu.tipo_doc;
            comando.Parameters["@nombre"].Value = usu.nombre;
            comando.Parameters["@celular"].Value = usu.celular;
            comando.Parameters["@email"].Value = usu.email;
            comando.Parameters["@genero"].Value = usu.genero;
            comando.Parameters["@aprendiz"].Value = usu.aprendiz;
            comando.Parameters["@egresado"].Value = usu.egresado;
            comando.Parameters["@areaformacion"].Value = usu.areaformacion;
            comando.Parameters["@fechaegresado"].Value = usu.fechaegresado;
            comando.Parameters["@direccion"].Value = usu.direccion;
            comando.Parameters["@barrio"].Value = usu.barrio;
            comando.Parameters["@ciudad"].Value = usu.ciudad;
            comando.Parameters["@departamento"].Value = usu.departamento;
            comando.Parameters["@fecharegistro"].Value = usu.fecharegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public List<usuario> RecuperarTodos()
        {
            Conectar();
            List<usuario> usuario = new List<usuario>();

            SqlCommand com = new SqlCommand("select id, documento, tipo_doc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {


                usuario usu = new usuario
                {
                    id = Convert.ToInt32(registros["id"]),
                    documento = registros["documento"].ToString(),
                    tipo_doc = registros["tipo_doc"].ToString(),
                    nombre = registros["nombre"].ToString(),
                    celular = registros["celular"].ToString(),
                    email = registros["email"].ToString(),
                    genero = registros["genero"].ToString(),
                    aprendiz = registros["aprendiz"].ToString(),
                    egresado = registros["egresado"].ToString(),
                    areaformacion = registros["areaformacion"].ToString(),
                    fechaegresado = registros["fechaegresado"].ToString(),
                    direccion = registros["direccion"].ToString(),
                    barrio = registros["barrio"].ToString(),
                    ciudad = registros["ciudad"].ToString(),
                    departamento = registros["departamento"].ToString(),
                    fecharegistro = registros["fecharegistro"].ToString(),
                };

                usuario.Add(usu);

            }
            con.Close();
            return usuario;
        }

        public usuario RecuperarAreaFormacion(string areaformacion)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select documento, tipo_doc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where areaformacion = @areaformacion", con);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = areaformacion;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            usuario usuario = new usuario();

            if (registros.Read())
            {
                usuario.documento = registros["documento"].ToString();
                usuario.tipo_doc = registros["tipo_doc"].ToString();
                usuario.nombre = registros["nombre"].ToString();
                usuario.celular = registros["celular"].ToString();
                usuario.email = registros["email"].ToString();
                usuario.genero = registros["genero"].ToString();
                usuario.aprendiz = registros["aprendiz"].ToString();
                usuario.egresado = registros["egresado"].ToString();
                usuario.areaformacion = registros["areaformacion"].ToString();
                usuario.fechaegresado = registros["fechaegresado"].ToString();
                usuario.direccion = registros["direccion"].ToString();
                usuario.barrio = registros["barrio"].ToString();
                usuario.ciudad = registros["ciudad"].ToString();
                usuario.departamento = registros["departamento"].ToString();
                usuario.fecharegistro = registros["fecharegistro"].ToString();
            }
            else
                usuario = null;

            con.Close();
            return usuario;
        }
        public usuario RecuperarPorGenero(string genero)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, documento, tipo_doc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where genero = @genero", con);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = genero;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            usuario usuario = new usuario();

            if (registros.Read())
            {
                usuario.id = int.Parse(registros["id"].ToString());
                usuario.documento = registros["documento"].ToString();
                usuario.tipo_doc = registros["tipo_doc"].ToString();
                usuario.nombre = registros["nombre"].ToString();
                usuario.celular = registros["celular"].ToString();
                usuario.email = registros["email"].ToString();
                usuario.genero = registros["genero"].ToString();
                usuario.aprendiz = registros["aprendiz"].ToString();
                usuario.egresado = registros["egresado"].ToString();
                usuario.areaformacion = registros["areaformacion"].ToString();
                usuario.fechaegresado = registros["fechaegresado"].ToString();
                usuario.direccion = registros["direccion"].ToString();
                usuario.barrio = registros["barrio"].ToString();
                usuario.ciudad = registros["ciudad"].ToString();
                usuario.departamento = registros["departamento"].ToString();
                usuario.fecharegistro = registros["fecharegistro"].ToString();
            }
            con.Close();
            return usuario;
        }
        public usuario RecuperarPorDocumento(long documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, documento, tipo_doc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where documento = @documento", con);
            comando.Parameters.Add("@documento", SqlDbType.BigInt);
            comando.Parameters["@documento"].Value = documento;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            usuario usuario = new usuario();

            if (registros.Read())
            {
                usuario.id = int.Parse(registros["id"].ToString());
                usuario.documento = registros["documento"].ToString();
                usuario.tipo_doc = registros["tipo_doc"].ToString();
                usuario.nombre = registros["nombre"].ToString();
                usuario.celular = registros["celular"].ToString();
                usuario.email = registros["email"].ToString();
                usuario.genero = registros["genero"].ToString();
                usuario.aprendiz = registros["aprendiz"].ToString();
                usuario.egresado = registros["egresado"].ToString();
                usuario.areaformacion = registros["areaformacion"].ToString();
                usuario.fechaegresado = registros["fechaegresado"].ToString();
                usuario.direccion = registros["direccion"].ToString();
                usuario.barrio = registros["barrio"].ToString();
                usuario.ciudad = registros["ciudad"].ToString();
                usuario.departamento = registros["departamento"].ToString();
                usuario.fecharegistro = registros["fecharegistro"].ToString();
            }
            con.Close();
            return usuario;
        }

        public usuario Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, documento, tipo_doc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where id = @id", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            usuario usuario = new usuario();

            if (registros.Read())
            {
                usuario.id = int.Parse(registros["id"].ToString());
                usuario.documento = registros["documento"].ToString();
                usuario.tipo_doc = registros["tipo_doc"].ToString();
                usuario.nombre = registros["nombre"].ToString();
                usuario.celular = registros["celular"].ToString();
                usuario.email = registros["email"].ToString();
                usuario.genero = registros["genero"].ToString();
                usuario.aprendiz = registros["aprendiz"].ToString();
                usuario.egresado = registros["egresado"].ToString();
                usuario.areaformacion = registros["areaformacion"].ToString();
                usuario.fechaegresado = registros["fechaegresado"].ToString();
                usuario.direccion = registros["direccion"].ToString();
                usuario.barrio = registros["barrio"].ToString();
                usuario.ciudad = registros["ciudad"].ToString();
                usuario.departamento = registros["departamento"].ToString();
                usuario.fecharegistro = registros["fecharegistro"].ToString();
            }
            con.Close();
            return usuario;
        }

        public int Modificar(usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update usuarios set tipo_doc=@tipo_doc, nombre=@nombre, celular=@celular, email=@email, genero=@genero, aprendiz=@aprendiz, egresado=@egresado, areaformacion=@areaformacion, fechaegresado=@fechaegresado, direccion=@direccion, barrio=@barrio, ciudad=@ciudad, departamento=@departamento, fecharegistro=@fecharegistro where documento=@documento", con);

            comando.Parameters.Add("@tipo_doc", SqlDbType.VarChar);
            comando.Parameters["@tipodoc"].Value = usu.tipo_doc;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.nombre;

            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters["@celular"].Value = usu.celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.email;

            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = usu.genero;

            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters["@aprendiz"].Value = usu.aprendiz;

            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters["@egresado"].Value = usu.egresado;

            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = usu.areaformacion;

            comando.Parameters.Add("@fechaegresado", SqlDbType.VarChar);
            comando.Parameters["@fechaegresado"].Value = usu.fechaegresado;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = usu.direccion;

            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters["@barrio"].Value = usu.barrio;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.ciudad;

            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters["@departamento"].Value = usu.departamento;

            comando.Parameters.Add("@fecharegistro", SqlDbType.VarChar);
            comando.Parameters["@fecharegistro"].Value = usu.fecharegistro;

            comando.Parameters.Add("@documento", SqlDbType.BigInt);
            comando.Parameters["@documento"].Value = usu.documento;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from usuarios where documento=@documento", con);
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters["@documento"].Value = documento;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}


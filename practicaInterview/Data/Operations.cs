using practicaInterview.Models;
using System.Data.SqlClient;
using System.Data;
using practicaInterview.Services;

namespace practicaInterview.Data
{
    public class Operations
    {
        public List<ClientModel> Listar()
        {
            var oLista = new List<ClientModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("list_clients", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClientModel()
                        {
                            id_user = Convert.ToInt32(dr["id_user"]),
                            userName = dr["userName"].ToString(),
                            email = dr["email"].ToString(),
                            userPassword = dr["userPassword"].ToString(),
                        });
                    }
                }
                
                
            }

            return oLista;

        }

        public List<bookModel> ListarBooks()
        {
            var oLista = new List<bookModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("list_books", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr);
                        oLista.Add(new bookModel()
                        {
                            id_book = Convert.ToInt32(dr["id_cuadro"]),
                            nombre = dr["nombre"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            autor = dr["autor"].ToString()
                        });
                    }
                }


            }

            return oLista;

        }

        public ClientModel getClient(int id_client)
        {
            var oClient = new ClientModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("get_client", conexion);
                cmd.Parameters.AddWithValue("Id_client", id_client);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oClient.id_user = Convert.ToInt32(dr["id_user"]);
                        oClient.userName = dr["userName"].ToString();
                        oClient.email = dr["email"].ToString();
                        oClient.userPassword = dr["userPassword"].ToString();
  
                    }
                }


            }

            return oClient;

        }

        public bool Register(ClientModel oclient)
        {
            bool rpta = true;
            try
            {
                var con = new Conexion();
                using (var conexion = new SqlConnection(con.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("create_client", conexion);
                    cmd.Parameters.AddWithValue("Name", oclient.userName);
                    cmd.Parameters.AddWithValue("Email", oclient.email);
                    cmd.Parameters.AddWithValue("Password",EncryptionService.ComputeSHA256(oclient.userPassword));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;

            }
            return rpta;

        }

        public bool RegisterBook(bookModel bookModel)
        {
            bool rpta = true;
            try
            {
                var con = new Conexion();
                using (var conexion = new SqlConnection(con.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("create_book", conexion);
                    cmd.Parameters.AddWithValue("Nombre", bookModel.nombre);
                    cmd.Parameters.AddWithValue("Descripcion", bookModel.descripcion);
                    cmd.Parameters.AddWithValue("Id_user", bookModel.id_user);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;

            }
            return rpta;

        }



        public bool Edit(ClientModel oclient)
        {
            bool rpta = true;
            try
            {
                var con = new Conexion();
                using (var conexion = new SqlConnection(con.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("update_password", conexion);
                    cmd.Parameters.AddWithValue("Id_client", oclient.id_user);
                    cmd.Parameters.AddWithValue("Password", EncryptionService.ComputeSHA256(oclient.newPassword));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;

            }
            return rpta;

        }


        public bool Delete(int id_client)
        {
            bool rpta = true;
            try
            {
                var con = new Conexion();
                using (var conexion = new SqlConnection(con.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("delete_client", conexion);
                    cmd.Parameters.AddWithValue("Id_client", id_client);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;

            }
            return rpta;

        }

        public bool Login(LoginModel loginModel)
        {
            bool rpta = true;
            try
            {
                var con = new Conexion();
                using (var conexion = new SqlConnection(con.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("loginUser", conexion);
                    cmd.Parameters.AddWithValue("Email", loginModel.email);
                    cmd.Parameters.AddWithValue("Password", EncryptionService.ComputeSHA256(loginModel.userPassword));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader data = cmd.ExecuteReader();

                    if (data.HasRows == false)
                    {
                        rpta = false;
                    }
                }
            }
            catch (Exception ex)
            {

                string error = ex.Message;
                rpta = false;

            }
            return rpta;

        }
    }
}

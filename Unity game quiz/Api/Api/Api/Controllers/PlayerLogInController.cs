using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
namespace Api.Controllers
{
    public class PlayerLogInController : ApiController
    {
        private SqlConnection cn;
        // GET: api/PlayerLogIn
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        

        public string POST([FromBody] checkPlayer value)
        {
            int retValue = 0;

            cn = new SqlConnection("server=DESKTOP-1A67GIT;integrated security=true;database=Kviz");
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "dbo.Login";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            cm.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, value.username));
            cm.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, value.password));


            cn.Open();
            cm.ExecuteNonQuery();
            retValue = (int)cm.Parameters["@RETURN_VALUE"].Value;

            if (retValue > 0)
            {
                return value.username;

            }
            else
            {
                return "Pogresan username ili sifra";
            }


        }

        




        //public IEnumerable<PlayerLogIn> Get(int id)
        //{
        //    cn = new SqlConnection("server=DESKTOP-1A67GIT;integrated security=true;database=Kviz");
        //    DataTable dt = new DataTable();
        //    SqlCommand cm = new SqlCommand();
        //    cm.Connection = cn;
        //    cm.CommandType = CommandType.StoredProcedure;
        //    cm.CommandText = "dbo.Korisnik";

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cm;
        //    cm.Parameters.Add(new SqlParameter("@playerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
        //    da.Fill(dt);

        //    List<PlayerLogIn> login = new List<Models.PlayerLogIn>(dt.Rows.Count); //Velicina liste onoliko redova koliko ima u bazi

        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow a in dt.Rows)
        //        {
        //            login.Add(new ReadLogIn(a));
        //        }
        //    }

        //    return login;
        //}






    }
}

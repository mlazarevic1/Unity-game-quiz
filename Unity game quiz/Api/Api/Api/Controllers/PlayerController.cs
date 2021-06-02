using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Api.Models;

namespace Api.Controllers
{

    public class PlayerController : ApiController
    {
        // GET: api/RegisterUser
        private SqlConnection cn;

        public IEnumerable<LeaderBoard> Get()
        {
            cn = new SqlConnection("server=DESKTOP-1A67GIT;integrated security=true;database=Kviz");
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "dbo.LeaderBoard";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            da.Fill(dt);

            List<LeaderBoard> leaders = new List<Models.LeaderBoard>(dt.Rows.Count); //Velicina liste onoliko redova koliko ima u bazi

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow a in dt.Rows)
                {
                    leaders.Add(new ReadLeaderBoard(a));
                }
            }
            return leaders;
        }

        public string POST([FromBody] CreatePlayer value)
        {
            int retValue = 0;
            cn = new SqlConnection("server=DESKTOP-1A67GIT;integrated security=true;database=Kviz");
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "dbo.Register";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            cm.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, value.username));
            cm.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, value.password));
            cm.Parameters.Add(new SqlParameter("@brojBodova", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, value.brojBodova));

            cn.Open();
            int result = cm.ExecuteNonQuery();
            retValue = (int)cm.Parameters["@RETURN_VALUE"].Value;

            if (retValue > 0)
            {
                return "Uspesno ste se registrovali";

            }
            else
            {
                return "Neuspesno";
            }
        }
        public void Put(string username, [FromBody] CreatePlayer value)
        {
            cn = new SqlConnection("server=DESKTOP-1A67GIT;integrated security=true;database=Kviz");
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "dbo.DodajBodove";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            cm.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, value.username));
            cm.Parameters.Add(new SqlParameter("@brojBodova", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, value.brojBodova));

            cn.Open();
            int result = cm.ExecuteNonQuery();
        }
    }
}

using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Security.Principal;

namespace Api.Controllers
{
    public class OdgovoriController : ApiController
    {
        private SqlConnection cn;
        
        public IEnumerable<Odgovori> Get()
        {
            cn = new SqlConnection("server=DESKTOP-1A67GIT;integrated security=true;database=Kviz");
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "dbo.OdgovorZaPitanje";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            da.Fill(dt);

            List<Odgovori> odgovori = new List<Models.Odgovori>(dt.Rows.Count); //Velicina liste onoliko redova koliko ima u bazi

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow a in dt.Rows)
                {
                    odgovori.Add(new ReadOdgovori(a));
                }
            }

            return odgovori;
        }

        // GET: api/Pitanja/5
        public string Get(int id)
        {
            return "value";
        }
    }
}

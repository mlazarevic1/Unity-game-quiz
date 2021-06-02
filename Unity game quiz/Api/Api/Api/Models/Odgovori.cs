using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Odgovori
    {
        public int pitanjeID { get; set; }
        public string odgovor { get; set; }
        public int tacnost { get; set; }


    }

    public class ReadOdgovori : Odgovori
    {

        public ReadOdgovori(DataRow row)
        {

            pitanjeID = Convert.ToInt32(row["pitanjeID"]);
            odgovor = row["odgovor"].ToString();
            tacnost = Convert.ToInt32(row["tacnost"]);
        }
    }


}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Pitanja
    {

       
        public int pitanjeID { get; set; }
        public string pitanje { get; set; }
        public string level { get; set; }
        public int iskorisceno { get; set; }
        
        
 
    }

    public class ReadPitanja : Pitanja
    {

        public ReadPitanja(DataRow row)
        {
            
            pitanjeID = Convert.ToInt32(row["pitanjeID"]);
            pitanje = row["pitanje"].ToString();
            level = row["level"].ToString();
            iskorisceno = Convert.ToInt32(row["iskorisceno"]);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class PlayerLogIn
    {
        public int playerID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        


    }


    public class checkPlayer : PlayerLogIn
    {



    }


    public class ReadLogIn : PlayerLogIn
    {

        public ReadLogIn(DataRow row)
        {
            playerID = Convert.ToInt32(row["playerID"]);
            username = row["username"].ToString();
            password = row["password"].ToString();
            

        }


    }


}

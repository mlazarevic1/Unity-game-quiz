using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Api.Models
{
    public class Player
    {

        public int playerID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int brojBodova { get; set; }


    }

    

    public class CreatePlayer : Player
    {
        


    }

    public class ReadPlayer : Player
    {

        public ReadPlayer(DataRow row)
        {
            playerID =Convert.ToInt32(row["playerID"]);
            username = row["username"].ToString();
            password = row["password"].ToString();
            brojBodova = Convert.ToInt32(row["brojBodova"]);

        }


    }
}
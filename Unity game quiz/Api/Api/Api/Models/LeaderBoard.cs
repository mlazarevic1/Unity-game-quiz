using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Api.Models
{
    public class LeaderBoard
    {



        public string username { get; set; }

        public int brojBodova { get; set; }


    }





        public class ReadLeaderBoard : LeaderBoard
        {



            public ReadLeaderBoard(DataRow row)
            {
                username = row["username"].ToString();
                brojBodova = Convert.ToInt32(row["brojBodova"]);

            }

        }
        

    
}
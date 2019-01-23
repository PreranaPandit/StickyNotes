using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerana_Pandit_StickyNotes
{
   public class LoginBLL
    {
        Dbconnection db = new Dbconnection();

        //properties
        private string username;
        private string password;

        //getter and setter begins
        public string _username
        {
            get { return username; }
            set { username = value; }
        }

        public string _password
        {
            get { return password; }
            set { password = value; }
        }

        //check user 
        public bool checkUser()
        {

            string query;
            query = "select Username from Users where Username='" + username + "' and Passcode='" + password + "'";
            DataTable dt = db.Retrieve(query);


            if (dt.Rows.Count > 0)
            {


                return true;

            }
            else
            {
                return false;
            }
        }

    }
}

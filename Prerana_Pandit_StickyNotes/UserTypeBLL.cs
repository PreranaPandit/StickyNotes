using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerana_Pandit_StickyNotes
{
    //INHERITANCE performed through connection of DBCONNECTION Class
    class UserTypeBLL:Dbconnection
    {
        //properties
        private string userTypeName;

        public UserTypeBLL()
        {

        }
 
        //getter and setter for userTypeName label
        public string _userTypeName
        {
            get { return userTypeName; }
            set { this.userTypeName = value; }
        }

        //insertion query
        public void insertuserType()
        {
            String query;
            query = "Insert into Usertype(Usertype_Name)values('" + userTypeName + "')";
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }

        }


        //selection query
        public DataTable retrieveUserType()
        {
            string query;
            query = "select Usertype_ID, Usertype_Name from Usertype";
            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }
            return dt;

        }


        //select query for datagrid view
        public DataTable selectUserType(int userTypeId)
        {
            string query;
            query = "select Usertype_Name from Usertype where Usertype_ID = " + userTypeId;
            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }
            return dt;
        }

        //delete query from datagrid view
        public void deleteUserType(int userTypeId)
        {
            string query;
            query = "delete from Usertype where Usertype_ID =" + userTypeId;
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }

        }

        //update query by clicking on edit when save turns to update
        public void updateUserType(int userTypeId)
        {
            string query;
            query = "Update Usertype set Usertype_Name='" + userTypeName + "' where Usertype_ID = " + userTypeId;
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }

        }



    }
}

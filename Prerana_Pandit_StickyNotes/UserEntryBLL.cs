using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerana_Pandit_StickyNotes
{
    //INHERITANCE performed through connection of DBCONNECTION Class
   public class UserEntryBLL:Dbconnection
    {
        //properties
        private int userTypeId;
        private string firstName;
        private string lastName;
        private string address;
        private string gender;
        private string phoneNumber;
        private string email;
        private string Username;
        private string Password;


        public UserEntryBLL()
        {

        }
     
        //getter and setter for all labels
        public int _userTypeId
        {
            get { return userTypeId; }
            set { this.userTypeId = value; }
        }
        public string _firstName
        {
            get { return firstName; }
            set { this.firstName = value; }
        }
        public string _lastName
        {
            get { return lastName; }
            set { this.lastName = value; }
        }
        public string _address
        {
            get { return address; }
            set { this.address = value; }
        }
        public string _gender
        {
            get { return gender; }
            set { this.gender = value; }
        }

        public string _phoneNumber
        {
            get { return phoneNumber; }
            set { this.phoneNumber = value; }
        }
        public string _email
        {
            get { return email; }
            set { this.email = value; }
        }
        public string _Username
        {
            get { return Username; }
            set { this.Username = value; }
        }
        public string _Password
        {
            get { return Password; }
            set { this.Password = value; }
        }



        //insertion query of users form
        public void insertUsers()
        {
            String query;
            query = "Insert into Users(Usertype_ID,FirstName,LastName,Address_Name,Gender,Phone_No,Email,Username,Passcode)values(" + userTypeId + ",'" + firstName + "','" + lastName + "','" + address + "','" + gender + "','" + phoneNumber + "','" + email + "','" + Username + "','" + Password + "')";
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }
        }

        //for unit testing
        public int insertUsers_Count()
        {
            DataTable dt = null;
            string query = "select COUNT(Usertype_ID) from Users";
            dt = Retrieve(query);
            return int.Parse(dt.Rows[0][0].ToString());

        }

        //selection query of users
        public DataTable retrieveUsers()
        {
            string query;
            query = "select U.Users_ID, UT.Usertype_Name, U.FirstName, U.LastName, U.Address_Name, U.Gender, U.Phone_No, U.Email, U.Passcode, U.Username from  Users U, Usertype UT where U.Usertype_ID = UT.Usertype_ID";

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


        //update query of users
        public void updateUsers(int userId)
        {
            string updateUsers;
            updateUsers = "Update Users set Usertype_ID='" + userTypeId + "',FirstName='" + firstName + "', LastName='" + lastName + "',Address_Name='" + address + "',Gender='" + gender + "',Phone_No='" + phoneNumber + "',Email='" + email + "',Username='" + Username + "',Passcode='" + Password + "' where Users_ID = " + userId;
            try
            {
                Manipulate(updateUsers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }

        }


        public int updateUserCount()
        {
            DataTable dt = null;
            string query = "select COUNT(Usertype_ID) from Users";
            dt = Retrieve(query);
            return int.Parse(dt.Rows[0][0].ToString());
        }

        //selection query from data grid view table 
        public DataTable SelectUsers(int userId)
        {
            string query;
            query = "select UT.Usertype_Name, U.FirstName, U.LastName, U.Address_Name, U.Gender, U.Phone_No, U.Email, U.Username, U.Passcode from Usertype UT, Users U where U.Usertype_ID = UT.Usertype_ID and U.Users_ID = " + userId;
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

        //delete query form data grid view.
        public void deleteUsers(int userId)
        {
            string query;
            query = "delete from Users where Users_ID =" + userId;
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }

        }
        public int deleteUserCount()
        {
            DataTable dt = null;
            string query = "select COUNT(Users_ID) from Users";
            dt = Retrieve(query);
            return int.Parse(dt.Rows[0][0].ToString());
        }


    }
}

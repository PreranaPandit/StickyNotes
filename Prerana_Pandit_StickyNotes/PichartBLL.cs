using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerana_Pandit_StickyNotes
{
    //Inheritance applied for class
    class PichartBLL:Dbconnection
    {
        //properties
        private string Username;

        //getter and setter
        public string _username
        {
            get { return Username; }
            set { Username = value; }
        }

        //query for selecting userId
        public int usersss()
        {
            string query = "select Users_ID from Users where Username='" + Username + "';";
            DataTable dt = Retrieve(query);
            return int.Parse(dt.Rows[0][0].ToString());
        }

        //today's work  
        public DataTable NoteCounttodaydate(string todaydate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created='" + todaydate + "'and IsCompleted='1' and Users_ID=" + usersss();

            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }


        //todays work
        public DataTable NoteCounttodaydate2(string todaydate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created='" + todaydate + "' and IsCompleted='0'and Users_ID=" + usersss();
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        //weekly work done
        public DataTable NoteCountweekdate(string todaydate, string Nowdate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created between '" + Nowdate + "' and '" + todaydate + "' and IsCompleted='1' and Users_ID=" + usersss();
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        //weekly work done
        public DataTable NoteCountweekdate2(string todaydate, string Nowdate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created between '" + Nowdate + "' and '" + todaydate + "' and IsCompleted='0'and Users_ID=" + usersss();
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        //monthly work done
        public DataTable NoteCountmonthdate(string todaydate, string Nowdate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created between '" + Nowdate + "' and '" + todaydate + "'and IsCompleted='1' and Users_ID=" + usersss();
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        //monthly work done
        public DataTable NoteCountmonthdate2(string todaydate, string Nowdate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created between '" + Nowdate + "' and '" + todaydate + "' and IsCompleted='0'and Users_ID=" + usersss();
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        //Yearly work done
        public DataTable NoteCountyeardate(string todaydate, string Nowdate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created between '" + Nowdate + "' and '" + todaydate + "'and IsCompleted='1' and Users_ID=" + usersss();
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        //yearly work done
        public DataTable NoteCountyeardate2(string todaydate, string Nowdate)
        {
            DataTable dt = null;
            string query;
            query = "select Count(IsCompleted) from StickyNotes where Date_Created between '" + Nowdate + "' and '" + todaydate + "' and IsCompleted='0'and Users_ID=" + usersss();
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dt;

        }
    }
}

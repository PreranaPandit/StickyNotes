using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prerana_Pandit_StickyNotes
{
    public partial class MAINDASHBOARD : Form
    {
        public MAINDASHBOARD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //opens usertype form to add
            this.Hide();
            usertype usertype = new usertype();
            usertype.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //opens categories form to add
            this.Hide();
            Categories categories = new Categories();
            categories.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //opens the userentry form to add
            this.Hide();
            Userentry userentry = new Userentry();
            userentry.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //opens loginform for dashboard going process
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}

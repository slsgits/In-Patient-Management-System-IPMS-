using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace InPatientManagement
{
    public partial class frmLogin : Form
    {
        HomeScreen hs = new HomeScreen();
        public frmLogin()
        {
            InitializeComponent();
        }
        private void clearText()
        {
            txtUserID.Clear();
            txtPassword.Clear();
            txtUserID.Focus();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtUserID.Text =="" || txtPassword.Text =="")
            {
                MessageBox.Show("Enter UserID and Password..!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                clearText();
                return;
            }
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da_login = new SqlDataAdapter("select * from login_info where userid=@userid and password=@pass",con);
            da_login.SelectCommand.Parameters.AddWithValue("@userid",txtUserID.Text);
            da_login.SelectCommand.Parameters.AddWithValue("@pass",txtPassword.Text);
            DataTable dt_login = new DataTable();
            da_login.Fill(dt_login);
            if (dt_login.Rows.Count == 0)
            {
                MessageBox.Show("Invalid UserID and Password!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                clearText();
                return;
            }
            else
            {
                this.Hide();
                //global.category = dt_login.Rows[0]["USER_TYPE"].ToString();
                hs.WindowState = FormWindowState.Maximized;
                hs.ShowDialog();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserID.Focus();
        }

        private void cboIAm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUserID.Focus();
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSubmit.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}

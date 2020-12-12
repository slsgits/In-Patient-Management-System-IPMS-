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
using InPatientManagement;


namespace ESTIMAZER
{
    public partial class frmHelp : Form
    {
        SqlDataAdapter da;
        SqlConnection con;
        DataTable dt;
        
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
           
        }

        public void hmenu(string table, params string[] cns)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);
            string str = "", cols = "";
            foreach (string col in cns)
            {
                if (col == cns.Last())
                {
                    cols = cols + col + "";
                }
                else
                {
                    cols = cols + col + ",";
                }
                str = "select " + cols + " from " + table;
            }
            da = new SqlDataAdapter(str, con);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Date not found!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                global.flag = false;
            }
            else
            {
                dgHelp.DataSource = dt.DefaultView;
                global.flag = true;
                this.ShowDialog();
            }
        }


        public void hmenu(string query)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);
            da = new SqlDataAdapter(query, con);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("Data not found!", global.msgBoxHead ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
                global.flag = false;
            }
            else
            {
                dgHelp.DataSource = dt.DefaultView;
                global.flag = true;
                this.ShowDialog();
            }
           
        }

        private void frmHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgHelp_DoubleClick(object sender, EventArgs e)
        {
            global.retStr = dgHelp.SelectedRows[0].Cells[0].Value.ToString();
            //global.retStatus = dgHelp.SelectedRows[0].Cells[1].Value.ToString();
            this.Close();
        }
    }
}

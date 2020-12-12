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
using ESTIMAZER;

namespace InPatientManagement
{
    public partial class HomeScreen : Form
    {
        string MODE;
        SqlConnection con;
        SqlCommand com,treat_com;
        SqlDataAdapter da,da_login;
        SqlDataReader dr;
        DataTable dt, dt_login;
        DataTable dt_treatment = new DataTable();
        DataSet ds;
        DataRow drow;
        int i;
        char c = '0';
        string s;
        decimal total_charge=0;
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            fieldWithNumAndDot();
            chkChanged(chkTest1,false);
            chkChanged(chkTest2, false);
            chkChanged(chkTest3, false);
            chkChanged(chkTest4, false);
            chkChanged(chkTest5, false);
            chkChanged(chkTest6, false);
            chkChanged(chkTest7, false);
            chkChanged(chkTest8, false);
            chkChanged(chkTest9, false);
            chkChanged(chkTest10, false);
            
            cboTitle.Text = cboTitle.Items[0].ToString();
            cboPatientGender.Text = cboPatientGender.Items[0].ToString();
            cboPatientMaritalStatus.Text = cboPatientMaritalStatus.Items[0].ToString();
            cboStatus.Text = cboStatus.Items[0].ToString();

            
            if (global.category == "DOCTOR")
            {
                //ipmstabControl.TabPages.RemoveAt(0);
            }
            btnSAVE.Enabled = false;
        }
        private void ConnectionString()
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);
        }
        private void clearText()
        {
            switch (ipmstabControl.SelectedTab.Text)
            {
                case "PATIENT DETAIL":
                    txtPatientId.Clear();
                    dtpDate.Value = DateTime.Today;
                    cboStatus.Text = cboStatus.Items[0].ToString();
                    cboTitle.Text = cboTitle.Items[0].ToString();
                    txtFirstName.Clear();
                    txtSurname.Clear();
                    txtMidFatHusName.Clear();
                    dtpPatientDOB.Value = DateTime.Today;
                    txtPatientAge.Clear();
                    cboPatientGender.Text = cboPatientGender.Items[0].ToString();
                    cboPatientMaritalStatus.Text = cboPatientMaritalStatus.Items[0].ToString();
                    txtPatientOccupation.Clear();
                    txtDrInCharge.Clear();
                    txtPatientAddress1.Clear();
                    txtPatientAddress2.Clear();
                    txtPatientAddress3.Clear();
                    txtPatientCity.Clear();
                    txtPatientState.Clear();
                    txtPatientPincode.Clear();
                    txtPatientMobile.Clear();
                    txtPatientTelNo.Clear();
                    txtPatientEmail.Clear();
                    txtPatientCountry.Text = "INDIA";
                    txtRelativeName.Clear();
                    txtRelativeAddress.Clear();
                    txtRelation.Clear();
                    txtRelativeCity.Clear();
                    txtRelativeState.Clear();
                    txtRelativePincode.Clear();
                    txtRelativeNo.Clear();
                    txtRelativeCountry.Clear();
                    break;

                case "TREATMENT DETAIL":
                    txtPIDTreatInfo.Clear();
                    lblPNameTreatInfo.Text = "Patient Name Here............";
                    txtDrInChrge.Clear();
                    txtConsDr1.Clear();
                    txtConsDr2.Clear();
                    txtConsDr3.Clear();
                    txtConsDr4.Clear();
                    txtConsNurse1.Clear();
                    txtConsNurse2.Clear();
                    txtConsNurse3.Clear();
                    txtConsNurse4.Clear();

                    txtTreatSrNo.Clear();
                    txtMedicineName.Clear();
                    txtMedicineQty.Clear();
                    txtMedicineCharge.Clear();
                    txtPrescribedBy.Clear();
                    dtpTreatDate.Value = DateTime.Today;
                    txtTotalCharge.Clear();
                    break;
                case "TEST DETAIL":
                    txtPIDTestInfo.Clear();
                    txtPIDTestInfo.Enabled = true;
                    lblPNameTestInfo.Text = "Patient Name Here....";
                    lblTestDrInCharge.Text = "Dr InCharge Name Here...";


                    chkTest1.Checked = false;
                    chkTest2.Checked = false;
                    chkTest3.Checked = false;
                    chkTest4.Checked = false;
                    chkTest5.Checked = false;
                    chkTest6.Checked = false;
                    chkTest7.Checked = false;
                    chkTest8.Checked = false;
                    chkTest9.Checked = false;
                    chkTest10.Checked = false;

                    dtpTest1.Value = DateTime.Today;
                    dtpTest2.Value = DateTime.Today;
                    dtpTest3.Value = DateTime.Today;
                    dtpTest4.Value = DateTime.Today;
                    dtpTest5.Value = DateTime.Today;
                    dtpTest6.Value = DateTime.Today;
                    dtpTest7.Value = DateTime.Today;
                    dtpTest8.Value = DateTime.Today;
                    dtpTest9.Value = DateTime.Today;
                    dtpTest10.Value = DateTime.Today;

                    txtTestBy1.Clear();
                    txtTestBy2.Clear();
                    txtTestBy3.Clear();
                    txtTestBy4.Clear();
                    txtTestBy5.Clear();
                    txtTestBy6.Clear();
                    txtTestBy7.Clear();
                    txtTestBy8.Clear();
                    txtTestBy9.Clear();
                    txtTestBy10.Clear();

                    cboTestStatus1.Text  = cboTestStatus1.Items[0].ToString();
                    cboTestStatus2.Text = cboTestStatus2.Items[0].ToString();
                    cboTestStatus3.Text = cboTestStatus3.Items[0].ToString();
                    cboTestStatus4.Text = cboTestStatus4.Items[0].ToString();
                    cboTestStatus5.Text = cboTestStatus5.Items[0].ToString();
                    cboTestStatus6.Text = cboTestStatus6.Items[0].ToString();
                    cboTestStatus7.Text = cboTestStatus7.Items[0].ToString();
                    cboTestStatus8.Text = cboTestStatus8.Items[0].ToString();
                    cboTestStatus9.Text = cboTestStatus9.Items[0].ToString();
                    cboTestStatus10.Text = cboTestStatus10.Items[0].ToString();

                    cboTestReport1.Text = cboTestReport1.Items[0].ToString();
                    cboTestReport2.Text = cboTestReport2.Items[0].ToString();
                    cboTestReport3.Text = cboTestReport3.Items[0].ToString();
                    cboTestReport4.Text = cboTestReport4.Items[0].ToString();
                    cboTestReport5.Text = cboTestReport5.Items[0].ToString();
                    cboTestReport6.Text = cboTestReport6.Items[0].ToString();
                    cboTestReport7.Text = cboTestReport7.Items[0].ToString();
                    cboTestReport8.Text = cboTestReport8.Items[0].ToString();
                    cboTestReport9.Text = cboTestReport9.Items[0].ToString();
                    cboTestReport10.Text = cboTestReport10.Items[0].ToString();

                    txtTestCharge1.Clear();
                    txtTestCharge2.Clear();
                    txtTestCharge3.Clear();
                    txtTestCharge4.Clear();
                    txtTestCharge5.Clear();
                    txtTestCharge6.Clear();
                    txtTestCharge7.Clear();
                    txtTestCharge8.Clear();
                    txtTestCharge9.Clear();
                    txtTestCharge10.Clear();

                break;
                case "WARD DETAIL":
                    cboWardType.Text = cboWardType.Items[0].ToString();
                    txtWardRoomNo.Clear();
                    txtWardBedNo.Clear();
                    txtWardOccupiedBy.Clear();
                    dtpFromDate.Value = DateTime.Today;
                    dtpToDate.Value = DateTime.Today;
                    dtpEntryDate.Value = DateTime.Today;
                    txtWardDays.Clear();
                    txtWardCharge.Clear();
                    txtWardTotalCharge.Clear();
                    cboWardStatus.Text =cboWardStatus.Items[0].ToString();
                break;
                case "DISCHARGE SUMMARY":
                    txtDischargeCardNo.Clear();
                    dtpDischargeCardDate.Value = DateTime.Today;
                    txtDischargePID.Clear();
                    lblDischargePFName.Text = "";
                    txtDischargePAge.Clear();
                    txtDischargePGender.Clear();
                    dtpDischargePDOA.Value = DateTime.Today;
                    dtpDischargePDOD.Value = DateTime.Today;
                    txtDischargePDInCharge.Clear();
                    txtDischargePDiagnosis.Clear();
                    txtDischargePReferredBy.Clear();
                    txtDischargePConsultantCharge.Clear();
                    txtDischargePBedCharge.Clear();
                    txtDischargePNurseCharge.Clear();
                    txtDischargePTestCharge.Clear();
                    txtDischargePEquipCharge.Clear();
                    txtDischargePMedicineCharge.Clear();
                    rdoDischargePVisitYes.Checked=true;
                    dtpDischargePNextVisit.Value = DateTime.Today;
                break;
                case "STAFF DETAIL":
                    txtStaffID.Clear();
                    dtpJoinDate.Value = DateTime.Today;
                    cboStaffCategory.Text = cboStaffCategory.Items[0].ToString(); 
                    cboStaffTitle.Text =cboStaffTitle.Items[0].ToString();
                    txtStaffFName.Clear();
                    txtStaffLName.Clear();
                    txtStaffMidFathHusName.Clear();
                    dtpStaffDOB.Value = DateTime.Today;
                    txtStaffAge.Clear();
                    cboStaffGender.Text = cboStaffGender.Items[0].ToString();
                    cboStaffMaritalStatus.Text =cboStaffMaritalStatus.Items[0].ToString();
                    cboStaffDepartment.Text = cboStaffDepartment.Items[0].ToString();
                    cboStaffDesignation.Text = cboStaffDesignation.Items[0].ToString();
                    txtStaffAddress1.Clear();
                    txtStaffAddress2.Clear();
                    txtStaffAddress3.Clear();
                    txtStaffCity.Clear();
                    txtStaffState.Clear();
                    txtStaffPincode.Clear();
                    txtStaffCountry.Text = "INDIA";
                    txtStaffTelNo.Clear();
                    txtStaffMobileNo.Clear();
                    txtStaffEmail.Clear();

                    txtStaffQualification1.Clear();
                    txtStaffQualification2.Clear();
                    txtStaffQualification3.Clear();
                    txtStaffQualification4.Clear();
                    break;
                case "REPORTS":
                     txtReportCardNo.Clear();
                     txtPatientIDReport.Clear();
                     cboReportType.Text = cboReportType.Items[0].ToString();
                    break;
                case "PASSWORD CHANGE":
                    txtChangePassUserID.Clear();
                    txtChangePassOld.Clear();
                    txtChangePassNew.Clear();
                    txtChangePassReType.Clear();
                break;
                
            }
        }
        private void btnNEW_Click(object sender, EventArgs e)
        {
            MODE = global.NMode;
            ConnectionString();
            //string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            //con = new SqlConnection(cs);
            com = new SqlCommand("select MAX(SUBSTRING(P_id,5,5)) from patient_info ORDER BY MAX(SUBSTRING(P_id,5,5)) DESC", con);
            con.Open();
            s = com.ExecuteScalar().ToString();
            if (s == "")
            {
                i = 0 + 1;
            }
            else
            {
                i = Convert.ToInt32(s) + 1;
            }
            txtPatientId.Text = 'P' + i.ToString().PadLeft(4, c);
            con.Close();
            txtPatientId.Enabled = false;
            txtPatientId.CausesValidation = true;
            dtpDate.Focus();


        }

        private void btnMODIFY_Click(object sender, EventArgs e)
        {
            MODE = global.MMode;
            clearText();
            txtPatientId.Clear();
            txtPatientId.Enabled = true;
            txtPatientId.Focus();
            txtPatientId.CausesValidation = true;
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            MODE = global.DMode;
            txtPatientId.Clear();
            clearText();
            txtPatientId.Enabled = true;
            txtPatientId.Focus();
            txtPatientId.CausesValidation = true;
        }

        private void btnVIEW_Click(object sender, EventArgs e)
        {
            MODE = global.VMode;
            txtPatientId.Clear();
            txtPatientId.Enabled = true;
            txtPatientId.Focus();
            txtPatientId.CausesValidation = true;
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            MODE = global.RMode;
            btnSAVE.Enabled = false;
            //if (MessageBox.Show("Want to cancel entry/update/delete", "IPMS", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    txtPatientId.CausesValidation = false;
            //    txtPatientId.Enabled = false;
            clearText();
            //}
            //else
            //{
            //    txtPatientId.CausesValidation = true;
            //}


            //HomeScreen_Load(sender,e);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);
            if (MODE == global.NMode)
            {
                try
                {
                    com = new SqlCommand("insert into patient_info values(@p_id,@p_title,@p_fname,@p_surname,@p_midname,@p_dob,@p_age,@p_gender,@p_marital_status,@p_occupation,@p_add1,@p_add2,@p_add3,@p_city,@p_state,@p_pincode,@p_country,@p_tel_no,@p_mobile_no,@p_emailid,@a_name,@a_relation,@a_address,@a_city,@a_state,@a_pincode,@a_country,@a_contact_no,@p_admit_date,@p_dr_incharge,@p_status)", con);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (MODE == global.MMode)
            {
                try
                {
                    com = new SqlCommand("update patient_info set p_title=@p_title,p_fname=@p_fname,p_surname=@p_surname,p_midfahus_name=@p_midname,p_dob=@p_dob,p_age=@p_age,p_gender=@p_gender,p_marital_status=@p_marital_status,p_occupation=@p_occupation,p_add1=@p_add1,p_add2=@p_add2,p_add3=@p_add3,p_city=@p_city,p_state=@p_state,p_pincode=@p_pincode,p_country=@p_country,p_tel_no=@p_tel_no,p_mobile_no=@p_mobile_no,p_emailid=@p_emailid,a_name=@a_name,a_relation=@a_relation,a_address=@a_address,a_city=@a_city,a_state=@a_state,a_pincode=@a_pincode,a_country=@a_country,a_contact_no=@a_contact_no,p_admit_date=@p_admit_date,p_dr_incharge=@p_dr_incharge,p_status=@p_status where p_id=@p_id", con);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (MODE == global.MMode || MODE == global.NMode)
            {
                com.Parameters.AddWithValue("@p_id", txtPatientId.Text.Trim());
                com.Parameters.AddWithValue("@p_title", cboTitle.Text);
                com.Parameters.AddWithValue("@p_fname", txtFirstName.Text.Trim());
                com.Parameters.AddWithValue("@p_surname", txtSurname.Text.Trim());
                com.Parameters.AddWithValue("@p_midname", txtMidFatHusName.Text.Trim());
                com.Parameters.AddWithValue("@p_dob", dtpPatientDOB.Value);
                com.Parameters.AddWithValue("@p_age", Convert.ToInt16(txtPatientAge.Text.Trim()));
                com.Parameters.AddWithValue("@p_gender", cboPatientGender.Text);
                com.Parameters.AddWithValue("@p_marital_status", cboPatientMaritalStatus.Text);
                com.Parameters.AddWithValue("@p_occupation", txtPatientOccupation.Text.Trim());
                com.Parameters.AddWithValue("@p_add1", txtPatientAddress1.Text.Trim());
                com.Parameters.AddWithValue("@p_add2", txtPatientAddress2.Text.Trim());
                com.Parameters.AddWithValue("@p_add3", txtPatientAddress3.Text.Trim());
                com.Parameters.AddWithValue("@p_city", txtPatientCity.Text.Trim());
                com.Parameters.AddWithValue("@p_state", txtPatientState.Text.Trim());
                com.Parameters.AddWithValue("@p_pincode", txtPatientPincode.Text.Trim());
                com.Parameters.AddWithValue("@p_country", txtPatientCountry.Text.Trim());
                com.Parameters.AddWithValue("@p_tel_no", txtPatientTelNo.Text.Trim());
                com.Parameters.AddWithValue("@p_mobile_no", txtPatientMobile.Text.Trim());
                com.Parameters.AddWithValue("@p_emailid", txtPatientEmail.Text.Trim());
                com.Parameters.AddWithValue("@a_name", txtRelativeName.Text.Trim());
                com.Parameters.AddWithValue("@a_relation", txtRelation.Text.Trim());
                com.Parameters.AddWithValue("@a_address", txtRelativeAddress.Text.Trim());
                com.Parameters.AddWithValue("@a_city", txtRelativeCity.Text.Trim());
                com.Parameters.AddWithValue("@a_state", txtRelativeState.Text.Trim());
                com.Parameters.AddWithValue("@a_pincode", txtRelativePincode.Text.Trim());
                com.Parameters.AddWithValue("@a_country", txtRelativeCountry.Text.Trim());
                com.Parameters.AddWithValue("@a_contact_no", txtRelativeNo.Text.Trim());
                com.Parameters.AddWithValue("@p_admit_date", dtpDate.Value);
                com.Parameters.AddWithValue("@p_dr_incharge", txtDrInCharge.Text.Trim());
                com.Parameters.AddWithValue("@p_status", cboStatus.Text);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            if (MODE == global.NMode)
            {
                MessageBox.Show("Data Saved Successfully.");
                clearText();
            }
            else if (MODE == global.MMode)
            {
                MessageBox.Show("Data Updated Successfully.");
                clearText();
            }
        }

        private void txtPatientId_Validated(object sender, EventArgs e)
        {
           
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);

            if (MODE == global.MMode || MODE == global.DMode || MODE == global.VMode)
            {
                da = new SqlDataAdapter("select * from patient_info where p_id=@p_id", con);
                da.SelectCommand.Parameters.AddWithValue("@p_id", txtPatientId.Text.Trim());
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    if (txtPatientId.Text == "")
                    {
                        txtPatientId.CausesValidation = false;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Patient detail not found!");
                        txtPatientId.Focus();
                        return;
                    }

                }
                else
                {
                    btnSAVE.Enabled = true;
                    txtPatientId.Text = dt.Rows[0]["p_id"].ToString();
                    cboTitle.Text = dt.Rows[0]["p_title"].ToString();
                    txtFirstName.Text = dt.Rows[0]["p_fname"].ToString();
                    txtSurname.Text = dt.Rows[0]["p_surname"].ToString();
                    txtMidFatHusName.Text = dt.Rows[0]["p_midfahus_name"].ToString();
                    dtpPatientDOB.Text = dt.Rows[0]["p_dob"].ToString();
                    txtPatientAge.Text = dt.Rows[0]["p_age"].ToString();
                    cboPatientGender.Text = dt.Rows[0]["p_gender"].ToString();
                    cboPatientMaritalStatus.Text = dt.Rows[0]["p_marital_status"].ToString();
                    txtPatientOccupation.Text = dt.Rows[0]["p_occupation"].ToString();
                    txtPatientAddress1.Text = dt.Rows[0]["p_add1"].ToString();
                    txtPatientAddress2.Text = dt.Rows[0]["p_add2"].ToString();
                    txtPatientAddress3.Text = dt.Rows[0]["p_add3"].ToString();
                    txtPatientCity.Text = dt.Rows[0]["p_city"].ToString();
                    txtPatientState.Text = dt.Rows[0]["p_state"].ToString();
                    txtPatientPincode.Text = dt.Rows[0]["p_pincode"].ToString();
                    txtPatientCountry.Text = dt.Rows[0]["p_country"].ToString();
                    txtPatientTelNo.Text = dt.Rows[0]["p_tel_no"].ToString();
                    txtPatientMobile.Text = dt.Rows[0]["p_mobile_no"].ToString();
                    txtPatientEmail.Text = dt.Rows[0]["p_emailid"].ToString();
                    txtRelativeName.Text = dt.Rows[0]["a_name"].ToString();
                    txtRelation.Text = dt.Rows[0]["a_relation"].ToString();
                    txtRelativeAddress.Text = dt.Rows[0]["a_address"].ToString();
                    txtRelativeCity.Text = dt.Rows[0]["a_city"].ToString();
                    txtRelativeState.Text = dt.Rows[0]["a_state"].ToString();
                    txtRelativePincode.Text = dt.Rows[0]["a_pincode"].ToString();
                    txtRelativeCountry.Text = dt.Rows[0]["a_country"].ToString();
                    txtRelativeNo.Text = dt.Rows[0]["a_contact_no"].ToString();
                    dtpDate.Text = dt.Rows[0]["p_admit_date"].ToString();
                    txtDischargePDInCharge.Text = dt.Rows[0]["p_dr_incharge"].ToString();
                    cboStatus.Text = dt.Rows[0]["p_status"].ToString();

                }

            }
            if (MODE == global.DMode)
            {
                btnSAVE.Enabled = false;
                if (MessageBox.Show("Do you want to delete patient detail?", "IPMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    com = new SqlCommand("delete from patient_info where p_id=@p_id", con);
                    com.Parameters.AddWithValue("@p_id", txtPatientId.Text.Trim());
                    con.Open();
                    com.ExecuteNonQuery();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MessageBox.Show("Patient detail deleted!");
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                else
                {
                    clearText();
                }
            }

        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HomeScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && MODE !=null && MODE !="")
            {
                frmHelp h = new frmHelp();
                h.hmenu("patient_info", "p_ID AS CODE", "p_fname + ' ' + p_midfahus_name + ' ' + p_surname  as NAME", "p_CITY as CITY", "p_STATE AS STATE");
                h.ShowDialog();
                txtPatientId.Text = global.retStr;
                global.retStr = "";
                txtPatientId.CausesValidation = true;
            }
        }

        private void dtpDate_Validated(object sender, EventArgs e)
        {
            if (MODE == global.NMode)
            {
                btnSAVE.Enabled = true;
            }
        }

        //private void txtPatientId_KeyPress(object sender, KeyPressEventArgs e)
        //{
            //if (e.KeyChar == 'P' || e.KeyChar =='p' || e.KeyChar == 'Back')
            //{
            //    e.Handled = false;
            //}
            //else 
            //{
            //    e.Handled = true;
            //}
        //}

        private void dtpPatientDOB_Validated(object sender, EventArgs e)
        {
            txtPatientAge.Text = (System.Math.Ceiling((DateTime.Today.Date.Subtract(dtpPatientDOB.Value.Date)).TotalDays / 365)).ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
          switch(ipmstabControl.SelectedTab.Text)
          {
              case "WARD DETAIL":
                  cboWardType.Text = cboWardType.Items[0].ToString();
                  cboWardStatus.Text = cboWardStatus.Items[0].ToString();
                  break;
              case "STAFF DETAIL":
                  btnStaffNEW.Focus();
                  cboStaffCategory.Text = cboStaffCategory.Items[0].ToString();
                  cboStaffDepartment.Text = cboStaffDepartment.Items[0].ToString();
                  cboStaffDesignation.Text = cboStaffDesignation.Items[0].ToString();
                  cboStaffGender.Text = cboStaffGender.Items[0].ToString();
                  cboStaffTitle.Text = cboStaffTitle.Items[0].ToString();
                  cboStaffMaritalStatus.Text = cboStaffMaritalStatus.Items[0].ToString();
                  break;
              case "DISCHARGE SUMMARY":
                  rdoDischargePVisitYes.Checked = true;
                  btnDischargeSAVE.Enabled = false;
              break;
              case "REPORTS":
                  cboReportType.Text = cboReportType.Items[0].ToString();
              break;
              case "PASSWORD CHANGE":
                  
              break;
          }
        }

        private void btnStaffNEW_Click(object sender, EventArgs e)
        {
            MODE = global.NMode;
            clearText();
            rdoCreateAccYes.Enabled  = true;
            rdoCreateAccNo.Enabled = true;
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);
            com = new SqlCommand("select MAX(SUBSTRING(st_id,5,5)) from staff_info ORDER BY MAX(SUBSTRING(st_id,5,5)) DESC", con);
            con.Open();
            s = com.ExecuteScalar().ToString();
            if (s == "")
            {
                i = 0 + 1;
            }
            else
            {
                i = Convert.ToInt32(s) + 1;
            }
            txtStaffID.Text = 'S' + i.ToString().PadLeft(4, c);
            con.Close();
            txtStaffID.Enabled = false;
            dtpJoinDate.Focus();
        }

        private void btnStaffMODIFY_Click(object sender, EventArgs e)
        {
            MODE = global.MMode;
            if (txtStaffID.Enabled == false)
            {
                txtStaffID.Enabled = true;
            }
            txtStaffID.CausesValidation = true;
            txtStaffID.Focus();
            clearText();
        }

        private void btnStaffDELETE_Click(object sender, EventArgs e)
        {
            MODE = global.DMode;
            if (txtStaffID.Enabled == false)
            {
                txtStaffID.Enabled = true;
            }
            txtStaffID.CausesValidation = true;
            txtStaffID.Focus();
            clearText();
        }

        private void btnStaffVIEW_Click(object sender, EventArgs e)
        {
            MODE = global.VMode;
            if (txtStaffID.Enabled == false)
            {
                txtStaffID.Enabled = true;
            }
            txtStaffID.CausesValidation = true;
            txtStaffID.Focus();
            clearText();
        }

        private void btnStaffRESET_Click(object sender, EventArgs e)
        {
            MODE = global.RMode;
            clearText();
            txtStaffID.CausesValidation = false;
            rdoCreateAccYes.Enabled = true;
            rdoCreateAccNo.Enabled = true;
        }

        private void btnStaffSAVE_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);

            if (MODE == global.NMode)
            {
                try
                {
                    com = new SqlCommand("insert into staff_info values(@st_id,@st_title,@st_fname,@st_surname,@st_midname,@st_dob,@st_age,@st_gender,@st_marital_status,@st_department,@st_add1,@st_add2,@st_add3,@st_city,@st_state,@st_pincode,@st_country,@st_tel_no,@st_mobile_no,@st_emailid,@st_qualification1,@st_qualification2,@st_qualification3,@st_qualification4,@st_designation,@st_join_date,@st_category)", con);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (MODE == global.MMode)
            {
                try
                {
                    com = new SqlCommand("update staff_info set st_title=@st_title,st_fname=@st_fname,st_surname=@st_surname,st_midfahus_name=@st_midname,st_dob=@st_dob,st_age=@st_age,st_gender=@st_gender,st_marital_status=@st_marital_status,st_department=@st_department,st_add1=@st_add1,st_add2=@st_add2,st_add3=@st_add3,st_city=@st_city,st_state=@st_state,st_pincode=@st_pincode,st_country=@st_country,st_tel_no=@st_tel_no,st_mobile_no=@st_mobile_no,st_emailid=@st_emailid,st_qualification1=@st_qualification1,st_qualification2=@st_qualification2,st_qualification3=@st_qualification3,st_qualification4=@st_qualification4,st_designation=@st_designation,st_join_date=@st_join_date,st_category=@st_category where st_id=@st_id", con);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (MODE == global.NMode || MODE == global.MMode)
            {
                com.Parameters.AddWithValue("@st_id", txtStaffID.Text.Trim());
                com.Parameters.AddWithValue("@st_title", cboStaffTitle.Text);
                com.Parameters.AddWithValue("@st_fname", txtStaffFName.Text.Trim());
                com.Parameters.AddWithValue("@st_surname", txtStaffLName.Text.Trim());
                com.Parameters.AddWithValue("@st_midname", txtStaffMidFathHusName.Text.Trim());
                com.Parameters.AddWithValue("@st_dob", dtpStaffDOB.Value);
                com.Parameters.AddWithValue("@st_age", Convert.ToInt16(txtStaffAge.Text.Trim()));
                com.Parameters.AddWithValue("@st_gender", cboStaffGender.Text);
                com.Parameters.AddWithValue("@st_marital_status", cboStaffMaritalStatus.Text);
                com.Parameters.AddWithValue("@st_department", cboStaffDepartment.Text);
                com.Parameters.AddWithValue("@st_add1", txtStaffAddress1.Text.Trim());
                com.Parameters.AddWithValue("@st_add2", txtStaffAddress2.Text.Trim());
                com.Parameters.AddWithValue("@st_add3", txtStaffAddress3.Text.Trim());
                com.Parameters.AddWithValue("@st_city", txtStaffCity.Text.Trim());
                com.Parameters.AddWithValue("@st_state", txtStaffState.Text.Trim());
                com.Parameters.AddWithValue("@st_pincode", txtStaffPincode.Text.Trim());
                com.Parameters.AddWithValue("@st_country", txtStaffCountry.Text.Trim());
                com.Parameters.AddWithValue("@st_tel_no", txtStaffTelNo.Text.Trim());
                com.Parameters.AddWithValue("@st_mobile_no", txtStaffMobileNo.Text.Trim());
                com.Parameters.AddWithValue("@st_emailid", txtStaffEmail.Text.Trim());
                com.Parameters.AddWithValue("@st_qualification1", txtStaffQualification1.Text.Trim());
                com.Parameters.AddWithValue("@st_qualification2", txtStaffQualification2.Text.Trim());
                com.Parameters.AddWithValue("@st_qualification3", txtStaffQualification3.Text.Trim());
                com.Parameters.AddWithValue("@st_qualification4", txtStaffQualification4.Text.Trim());
                com.Parameters.AddWithValue("@st_designation", cboStaffDesignation.Text);
                com.Parameters.AddWithValue("@st_join_date", dtpJoinDate.Value);
                com.Parameters.AddWithValue("@st_category", cboStaffCategory.Text);
            }

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            com.ExecuteNonQuery();

            if ((MODE == global.NMode || MODE ==global.MMode ) && rdoCreateAccYes.Checked)
            {
                MessageBox.Show("Data Saved Successfully.");
                da = new SqlDataAdapter("select * from login_info where userid=@userid",con);
                da.SelectCommand.Parameters.AddWithValue("@userid",txtStaffID.Text.Trim());
                dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count ==0)
                {
                    com = new SqlCommand("insert into login_info values(@st_id,@password,@user_type)", con);
                    com.Parameters.AddWithValue("@st_id", txtStaffID.Text.Trim());
                    string default_pass = "USER" + dtpStaffDOB.Value.Day.ToString() + "." + dtpStaffDOB.Value.Month.ToString() + "." + dtpStaffDOB.Value.Year.ToString().Substring(2, 2);
                    com.Parameters.AddWithValue("@password", default_pass);
                    com.Parameters.AddWithValue("@user_type", cboStaffCategory.Text);
                    com.ExecuteNonQuery();
                }
                clearText();
            }
            else if (MODE == global.MMode && rdoCreateAccNo.Checked)
            {
                com = new SqlCommand("delete from login_info where userid=@userid", con);
                com.Parameters.AddWithValue("@userid", txtStaffID.Text.Trim());
                com.ExecuteNonQuery();
                clearText();
            }
            else if (MODE == global.MMode)
            {
                MessageBox.Show("Data Updated Successfully.");
                clearText();
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void dtpStaffDOB_Validated(object sender, EventArgs e)
        {
            txtStaffAge.Text = (System.Math.Ceiling((DateTime.Today.Date.Subtract(dtpStaffDOB.Value.Date)).TotalDays / 365)).ToString();
        }

        private void dtpJoinDate_Validated(object sender, EventArgs e)
        {
            if (MODE == global.NMode)
            {
                btnStaffSAVE.Enabled = true;
            }
        }

        private void txtStaffID_Validated(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);

            if (MODE == global.MMode || MODE == global.DMode || MODE == global.VMode)
            {
                da = new SqlDataAdapter("select * from staff_info where st_id=@st_id", con);
                da_login = new SqlDataAdapter("select * from login_info where userid=@userid",con);
                da.SelectCommand.Parameters.AddWithValue("@st_id", txtStaffID.Text.Trim());
                da_login.SelectCommand.Parameters.AddWithValue("@userid",txtStaffID.Text.Trim());
                ds = new DataSet();
                dt_login = new DataTable();
                da.Fill(ds);
                da_login.Fill(dt_login);
                if (ds.Tables[0].Rows.Count == 0 && dt_login.Rows.Count == 0)
                {
                    if (txtStaffID.Text == "")
                    {
                        txtStaffID.CausesValidation = false;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Staff detail not found!");
                        txtStaffID.Focus();
                        return;
                    }

                }
                else
                {
                    btnStaffSAVE.Enabled = true;
                    txtStaffID.Text = ds.Tables[0].Rows[0]["st_id"].ToString();
                    cboStaffTitle.Text = ds.Tables[0].Rows[0]["st_title"].ToString();
                    txtStaffFName.Text = ds.Tables[0].Rows[0]["st_fname"].ToString();
                    txtStaffLName.Text = ds.Tables[0].Rows[0]["st_surname"].ToString();
                    txtStaffMidFathHusName.Text = ds.Tables[0].Rows[0]["st_midfahus_name"].ToString();
                    dtpStaffDOB.Text = ds.Tables[0].Rows[0]["st_dob"].ToString();
                    txtStaffAge.Text = ds.Tables[0].Rows[0]["st_age"].ToString();
                    cboStaffGender.Text = ds.Tables[0].Rows[0]["st_gender"].ToString();
                    cboStaffMaritalStatus.Text = ds.Tables[0].Rows[0]["st_marital_status"].ToString();
                    cboStaffDepartment.Text = ds.Tables[0].Rows[0]["st_department"].ToString();
                    txtStaffAddress1.Text = ds.Tables[0].Rows[0]["st_add1"].ToString();
                    txtStaffAddress2.Text = ds.Tables[0].Rows[0]["st_add2"].ToString();
                    txtStaffAddress3.Text = ds.Tables[0].Rows[0]["st_add3"].ToString();
                    txtStaffCity.Text = ds.Tables[0].Rows[0]["st_city"].ToString();
                    txtStaffState.Text = ds.Tables[0].Rows[0]["st_state"].ToString();
                    txtStaffPincode.Text = ds.Tables[0].Rows[0]["st_pincode"].ToString();
                    txtStaffCountry.Text = ds.Tables[0].Rows[0]["st_country"].ToString();
                    txtStaffTelNo.Text = ds.Tables[0].Rows[0]["st_tel_no"].ToString();
                    txtStaffMobileNo.Text = ds.Tables[0].Rows[0]["st_mobile_no"].ToString();
                    txtStaffEmail.Text = ds.Tables[0].Rows[0]["st_emailid"].ToString();
                    txtStaffQualification1.Text = ds.Tables[0].Rows[0]["st_qualification1"].ToString();
                    txtStaffQualification2.Text = ds.Tables[0].Rows[0]["st_qualification2"].ToString();
                    txtStaffQualification3.Text = ds.Tables[0].Rows[0]["st_qualification3"].ToString();
                    txtStaffQualification4.Text = ds.Tables[0].Rows[0]["st_qualification4"].ToString();
                    cboStaffDesignation.Text = ds.Tables[0].Rows[0]["st_designation"].ToString();
                    dtpJoinDate.Text = ds.Tables[0].Rows[0]["st_join_date"].ToString();
                    cboStaffCategory.Text = ds.Tables[0].Rows[0]["st_category"].ToString();

                    if (dt_login.Rows.Count == 0)
                    {
                        rdoCreateAccNo.Checked = true;
                        rdoCreateAccNo.Enabled = true;
                        rdoCreateAccYes.Enabled = true;
                    }
                    else
                    {
                        rdoCreateAccYes.Checked = true;
                        rdoCreateAccYes.Enabled = true;
                        rdoCreateAccNo.Enabled = true;
                    }
                }
            }


            if (MODE == global.DMode)
            {
                btnSAVE.Enabled = false;
                if (MessageBox.Show("Do you want to delete staff detail?", "IPMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    com = new SqlCommand("delete from login_info where userid=@user_id;delete from staff_info where st_id=@st_id", con);
                    com.Parameters.AddWithValue("@user_id", txtStaffID.Text.Trim());
                    com.Parameters.AddWithValue("@st_id", txtStaffID.Text.Trim());
                    con.Open();
                    com.ExecuteNonQuery();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MessageBox.Show("Staff detail deleted!");
                    clearText();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                else
                {
                    clearText();
                }
            }
        }

        private void cboStaffDepartment_Validated(object sender, EventArgs e)
        {
            //if (cboStaffDepartment.Text =="SELECT")
            //{
            //    MessageBox.Show("Select Department!","IPMS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //    cboStaffDepartment.Focus();
            //}
        }

        private void cboStaffGender_Validated(object sender, EventArgs e)
        {
            //if (cboStaffGender.Text == "SELECT")
            //{
            //    MessageBox.Show("Select Gender!", "IPMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cboStaffGender.Focus();
            //}
        }

        private void cboStaffMaritalStatus_Validated(object sender, EventArgs e)
        {
            //if (cboStaffMaritalStatus.Text == "SELECT")
            //{
            //    MessageBox.Show("Select Marital Status!", "IPMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cboStaffMaritalStatus.Focus();
            //}
        }

        private void cboStaffDesignation_Validated(object sender, EventArgs e)
        {
            //if (cboStaffDesignation.Text == "SELECT")
            //{
            //    MessageBox.Show("Select Designation!", "IPMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cboStaffDesignation.Focus();
            //}
        }

        private void btnNEWTreatInfo_Click(object sender, EventArgs e)
        {
            MODE = global.NMode;
            btnEnDis(false);
            clearFields(ipmstabControl.SelectedTab.Text);
            clearText();
            dgTreatmentData.DataSource = "";
            txtTotalCharge.Clear();
        }

        private void txtPIDTreatInfo_Validated(object sender, EventArgs e)
        {
            if (txtPIDTreatInfo.Text == "")
            {
                //MessageBox.Show("Enter ID!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
                //string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
                //con = new SqlConnection(cs);
            ConnectionString();
                if (MODE == global.NMode)
                {
                    da = new SqlDataAdapter("select * from consultant_info where p_id = @id", con);
                    da.SelectCommand.Parameters.AddWithValue("@id", txtPIDTreatInfo.Text.Trim());
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        MessageBox.Show("Patient treatment data already available!", global.msgBoxHead, MessageBoxButtons.OK);
                        txtPIDTreatInfo.Clear();
                        txtPIDTreatInfo.Focus();
                        return;

                    }
                    else
                    {
                        da = new SqlDataAdapter("select p_id,p_fname + ' '+ p_midfahus_name + ' ' + p_surname  as 'P_NAME',p_dr_incharge from patient_info where p_id=@pid", con);
                        da.SelectCommand.Parameters.AddWithValue("@pid", txtPIDTreatInfo.Text.Trim());
                        dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Patient detail not found!", "IPMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPIDTreatInfo.Focus();
                            return;

                        }
                        else
                        {
                            txtPIDTreatInfo.Text = dt.Rows[0]["p_id"].ToString();
                            lblPNameTreatInfo.Text = dt.Rows[0]["P_NAME"].ToString();
                            txtDrInChrge.Text = dt.Rows[0]["p_dr_incharge"].ToString();
                            txtConsDr1.Focus();
                        }
                    }

                }
                if (MODE == global.MMode || MODE == global.VMode || MODE == global.DMode)
                {
                    da = new SqlDataAdapter("select * from consultant_info where p_id=@p_id;select sr_no as 'SR.NO.',pres_date as 'DATE',medicine_name as 'MEDICINE',medicine_qty 'QTY',prescribed_by AS 'PRESCRIBED BY',medicine_charge as 'CHARGE' from treatment_info where p_id=@p_id;select p_fname + ' '+ p_midfahus_name + ' ' + p_surname  as 'P_NAME' from patient_info where p_id=@p_id", con);
                    da.SelectCommand.Parameters.AddWithValue("@p_id", txtPIDTreatInfo.Text);
                    ds = new DataSet();
                    ds.Clear();
                    da.Fill(ds);

                    ds.Tables[0].TableName = "consultant_info";
                    ds.Tables[1].TableName = "treatment_info";
                    ds.Tables[2].TableName = "p_fullname";

                    //data from ds.tables["consultant_info"]
                    txtPIDTreatInfo.Text = ds.Tables["consultant_info"].Rows[0]["p_id"].ToString();
                    txtDrInChrge.Text = ds.Tables["consultant_info"].Rows[0]["dr_in_charge"].ToString();
                    txtConsDr1.Text = ds.Tables["consultant_info"].Rows[0]["cons_dr_name1"].ToString();
                    txtConsDr2.Text = ds.Tables["consultant_info"].Rows[0]["cons_dr_name2"].ToString();
                    txtConsDr3.Text = ds.Tables["consultant_info"].Rows[0]["cons_dr_name3"].ToString();
                    txtConsDr4.Text = ds.Tables["consultant_info"].Rows[0]["cons_dr_name4"].ToString();
                    txtConsNurse1.Text = ds.Tables["consultant_info"].Rows[0]["cons_nusre_name1"].ToString();
                    txtConsNurse2.Text = ds.Tables["consultant_info"].Rows[0]["cons_nusre_name2"].ToString();
                    txtConsNurse3.Text = ds.Tables["consultant_info"].Rows[0]["cons_nusre_name3"].ToString();
                    txtConsNurse4.Text = ds.Tables["consultant_info"].Rows[0]["cons_nusre_name4"].ToString();

                    //data from ds.tables["treatment_info"]

                    dgTreatmentData.DataSource = ds.Tables["treatment_info"].DefaultView;

                    for (int i = 0; i <= ds.Tables["treatment_info"].Rows.Count - 1; i++)
                    {
                        total_charge = total_charge + Convert.ToDecimal(ds.Tables["treatment_info"].Rows[i]["CHARGE"]);
                    }
                    txtTotalCharge.Text = total_charge.ToString();

                    // data from ds.tables["p_fullname"]

                    lblPNameTreatInfo.Text = ds.Tables["p_fullname"].Rows[0]["P_NAME"].ToString();

                    //ds.Clear();
                }
                if (MODE == global.DMode)
                {
                    if (MessageBox.Show("Do you want to delete treatment detail!", global.msgBoxHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        com = new SqlCommand("delete from consultant_info where p_id = @p_id;delete from treatment_info where p_id=@p_id", con);
                        com.Parameters.AddWithValue("@p_id", txtPIDTreatInfo.Text);
                        con.Open();
                        com.ExecuteNonQuery();
                        MessageBox.Show("Patient Treatment detail deleted!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearText();
                        con.Close();
                        dgTreatmentData.DataSource = "";
                    }
                    else
                    {
                        clearText();
                        dgTreatmentData.DataSource = "";
                    }

                }
                total_charge = 0;
                //btnDeleteTreat.Enabled = false;
                //btnSaveTreat.Enabled = false;
                btnEnDis(true);
                txtPIDTreatInfo.Enabled = false;
            //}
            
            
        }

        private void btnSAVETreatInfo_Click(object sender, EventArgs e)
        {
            if(txtPIDTreatInfo.Text =="")
            {
                return;
            }
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);

            if(MODE ==global.NMode)
            {
                com = new SqlCommand("insert into consultant_info values(@p_id,@dr_in_charge,@cons_dr_name1,@cons_dr_name2,@cons_dr_name3,@cons_dr_name4,@cons_nusre_name1,@cons_nusre_name2,@cons_nusre_name3,@cons_nusre_name4)", con);
                com.Parameters.AddWithValue("@p_id", txtPIDTreatInfo.Text.Trim());
                com.Parameters.AddWithValue("@dr_in_charge", txtDrInChrge.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name1", txtConsDr1.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name2", txtConsDr2.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name3", txtConsDr3.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name4", txtConsDr4.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name1", txtConsNurse1.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name2", txtConsNurse2.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name3", txtConsNurse3.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name4", txtConsNurse4.Text.Trim());


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                for (int i = 0; i <= dt_treatment.Rows.Count - 1; i++)
                {
                    treat_com = new SqlCommand("insert into treatment_info(p_id,sr_no,pres_date,medicine_name,medicine_qty,prescribed_by,medicine_charge) values(@p_id,@sr_no,@pres_date,@medicine_name,@medicine_qty,@pres_by,@medicine_charge)", con);

                    treat_com.Parameters.AddWithValue("@p_id", txtPIDTreatInfo.Text);
                    treat_com.Parameters.AddWithValue("@sr_no", dt_treatment.Rows[i][0]);
                    treat_com.Parameters.AddWithValue("@pres_date", dt_treatment.Rows[i][1]);
                    treat_com.Parameters.AddWithValue("@medicine_name", dt_treatment.Rows[i][2]);
                    treat_com.Parameters.AddWithValue("@medicine_qty", dt_treatment.Rows[i][3]);
                    treat_com.Parameters.AddWithValue("@pres_by", dt_treatment.Rows[i][4]);
                    treat_com.Parameters.AddWithValue("@medicine_charge", dt_treatment.Rows[i][5]);
                    treat_com.ExecuteNonQuery();
                    //treat_com.Parameters.AddWithValue("@cons_charge", dt_treatment.Rows[i][6]);
                }
                com.ExecuteNonQuery();
                MessageBox.Show("Treatment Detail Saved!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearText();
                dt_treatment.Clear();
                con.Close();
            }
            else if(MODE ==global.MMode)
            {
                com = new SqlCommand("update consultant_info set dr_in_charge = @dr_in_charge,cons_dr_name1 =@cons_dr_name1,cons_dr_name2=@cons_dr_name2,cons_dr_name3=@cons_dr_name3,cons_dr_name4=@cons_dr_name4,cons_nusre_name1=@cons_nusre_name1,cons_nusre_name2=@cons_nusre_name2,cons_nusre_name3=@cons_nusre_name3,cons_nusre_name4=@cons_nusre_name4 where p_id =@p_id;delete from treatment_info where p_id =@p_id",con);
                com.Parameters.AddWithValue("@p_id",txtPIDTreatInfo.Text.Trim());
                com.Parameters.AddWithValue("@dr_in_charge",txtDrInChrge.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name1",txtConsDr1.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name2",txtConsDr2.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name3",txtConsDr3.Text.Trim());
                com.Parameters.AddWithValue("@cons_dr_name4",txtConsDr4.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name1", txtConsNurse1.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name2", txtConsNurse2.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name3", txtConsNurse3.Text.Trim());
                com.Parameters.AddWithValue("@cons_nusre_name4", txtConsNurse4.Text.Trim());

                if(con.State ==ConnectionState.Closed)
                {
                    con.Open();
                }
                com.ExecuteNonQuery();
                for (int i = 0; i <= ds.Tables["treatment_info"].Rows.Count - 1; i++)
                {
                    treat_com = new SqlCommand("insert into treatment_info(p_id,sr_no,pres_date,medicine_name,medicine_qty,prescribed_by,medicine_charge) values(@p_id,@sr_no,@pres_date,@medicine_name,@medicine_qty,@pres_by,@medicine_charge)", con);

                    treat_com.Parameters.AddWithValue("@p_id", txtPIDTreatInfo.Text);
                    treat_com.Parameters.AddWithValue("@sr_no", ds.Tables["treatment_info"].Rows[i][0]);
                    treat_com.Parameters.AddWithValue("@pres_date", ds.Tables["treatment_info"].Rows[i][1]);
                    treat_com.Parameters.AddWithValue("@medicine_name", ds.Tables["treatment_info"].Rows[i][2]);
                    treat_com.Parameters.AddWithValue("@medicine_qty", ds.Tables["treatment_info"].Rows[i][3]);
                    treat_com.Parameters.AddWithValue("@pres_by", ds.Tables["treatment_info"].Rows[i][4]);
                    treat_com.Parameters.AddWithValue("@medicine_charge", ds.Tables["treatment_info"].Rows[i][5]);
                    treat_com.ExecuteNonQuery();
                    //treat_com.Parameters.AddWithValue("@cons_charge", dt_treatment.Rows[i][6]);
                }
                MessageBox.Show("Treatment Detail updated!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                ds.Clear();
            }
            total_charge = 0;
            txtTotalCharge.Clear();
        }

        private void txtMedicineQty_KeyPress(object sender, KeyPressEventArgs e)
        {
          if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
          {
              e.Handled = true;
          }
        }

        private void btnNewTreat_Click(object sender, EventArgs e)
        {
            if(txtPIDTreatInfo.Text =="")
            {
                return;
            }
            string cs = ConfigurationManager.ConnectionStrings["MyDataOnly"].ConnectionString;
            con = new SqlConnection(cs);
           
            com = new SqlCommand("select isnull(MAX(sr_no),0) from treatment_info where p_id =@P_ID", con);
            com.Parameters.AddWithValue("@P_ID",txtPIDTreatInfo.Text.Trim());
            con.Open();
            //if (com.ExecuteScalar() == DBNull.Value)
            //{
            //    nxt_sr += 1;
            //}
            //else
            //{
            //    nxt_sr = Convert.ToInt16(com.ExecuteScalar()) + 1;
            //}
            int nxt_sr=Convert.ToInt16(com.ExecuteScalar()) + 1;
            txtTreatSrNo.Text = nxt_sr.ToString();
            if (MODE == global.MMode)
            {
               //txtTreatSrNo.Text = (Convert.ToInt16(ds.Tables["treatment_info"].Rows.Count) + 1).ToString();
                
               btnSaveTreat.Text = "Save";
               //btnNewTreat.Enabled = false;
            }
            else if (MODE == global.NMode)
            {
                 //txtTreatSrNo.Text = (Convert.ToInt16(dt_treatment.Rows.Count) + 1).ToString();
                 btnNewTreat.Enabled = false;
            }
            dtpTreatDate.Focus();
            btnSaveTreat.Enabled = true;
            btnNewTreat.Enabled = false;
            btnDeleteTreat.Enabled = false;
            //dt = new DataTable();
           
        }

        private void btnSaveTreat_Click(object sender, EventArgs e)
        {

            //try
            //if (btnSaveTreat.Text == "OK" || btnSaveTreat.Text == "Save")
            //{
            //    if (btnSaveTreat.Text == "OK")
            //    {
            //        dt_treatment.Rows.RemoveAt(global.indx);
            //    }
            //    else if (btnSaveTreat.Text == "Save")
            //    {
                   
            //    }
            //    drow = dt_treatment.NewRow();
            //    drow[0] = txtTreatSrNo.Text;
            //    drow[1] = dtpTreatDate.Value;
            //    drow[2] = txtMedicineName.Text;
            //    drow[3] = txtMedicineQty.Text;
            //    drow[4] = txtPrescribedBy.Text;
            //    drow[5] = txtMedicineCharge.Text;
            //}

            //if(MODE ==global.NMode)
            //{
            //    if (dt_treatment.Rows.Count == 0)
            //    {
            //        //dt.Columns.Add("PID", typeof(System.String));
            //        dt_treatment.Columns.Add("Sr No", typeof(System.Int32));
            //        dt_treatment.Columns.Add("Date", typeof(System.DateTime));
            //        dt_treatment.Columns.Add("Medicine Name", typeof(System.String));
            //        dt_treatment.Columns.Add("Quantity", typeof(System.Int32));
            //        dt_treatment.Columns.Add("Prescriped By", typeof(System.String));
            //        dt_treatment.Columns.Add("Charge", typeof(System.Decimal));
            //    }
            //}

            //if (btnSaveTreat.Text == "OK" && MODE ==global.NMode)
            //{
            //    dt_treatment.Rows.InsertAt(drow,global.indx);
            //}
            //else if (btnSaveTreat.Text == "Save" && MODE ==global.NMode)
            //{
            //    dt_treatment.Rows.Add(drow);
            //}
            //---------

            if(txtTreatSrNo.Text=="")
            {
                return;
            }

            if (MODE == global.NMode)
            {
                if (dt_treatment.Rows.Count == 0)
                {
                    //dt.Columns.Add("PID", typeof(System.String));
                    dt_treatment.Columns.Add("Sr No", typeof(System.Int32));
                    dt_treatment.Columns.Add("Date", typeof(System.DateTime));
                    dt_treatment.Columns.Add("Medicine Name", typeof(System.String));
                    dt_treatment.Columns.Add("Quantity", typeof(System.Int32));
                    dt_treatment.Columns.Add("Prescriped By", typeof(System.String));
                    dt_treatment.Columns.Add("Charge", typeof(System.Decimal));
                }
                if(btnSaveTreat.Text =="OK")
                {
                    dt_treatment.Rows.RemoveAt(global.indx);
                    DataRow dr = dt_treatment.NewRow();
                    dr[0] = txtTreatSrNo.Text;
                    dr[1] = dtpTreatDate.Value;
                    dr[2] = txtMedicineName.Text;
                    dr[3] = txtMedicineQty.Text;
                    dr[4] = txtPrescribedBy.Text;
                    dr[5] = txtMedicineCharge.Text;
                    //dt_treatment.Rows.Add(dr);
                    dt_treatment.Rows.InsertAt(dr, global.indx);
                }

                if (btnSaveTreat.Text == "Save")
                {
                    DataRow dr = dt_treatment.NewRow();
                    dr[0] = txtTreatSrNo.Text;
                    dr[1] = dtpTreatDate.Value;
                    dr[2] = txtMedicineName.Text;
                    dr[3] = txtMedicineQty.Text;
                    dr[4] = txtPrescribedBy.Text;
                    dr[5] = txtMedicineCharge.Text;
                    dt_treatment.Rows.Add(dr);
                    btnNewTreat.Focus();
                }
                dgTreatmentData.DataSource = dt_treatment;
                for (int i = 0; i <= dt_treatment.Rows.Count - 1;i++ )
                {
                    total_charge += Convert.ToDecimal(dt_treatment.Rows[i]["CHARGE"]);
                }
                //total_charge = total_charge + Convert.ToDecimal(txtMedicineCharge.Text.Trim());
                txtTotalCharge.Clear();
                txtTotalCharge.Text = total_charge.ToString();
                
            }
            else if(MODE ==global.MMode)
            {
               if(btnSaveTreat.Text =="OK")
               {
                   ds.Tables["treatment_info"].Rows.RemoveAt(global.indx);
                   DataRow dr = ds.Tables["treatment_info"].NewRow();
                   dr[0] = txtTreatSrNo.Text;
                   dr[1] = dtpTreatDate.Value;
                   dr[2] = txtMedicineName.Text;
                   dr[3] = txtMedicineQty.Text;
                   dr[4] = txtPrescribedBy.Text;
                   dr[5] = txtMedicineCharge.Text;
                   ds.Tables["treatment_info"].Rows.InsertAt(dr, global.indx);
                   btnNewTreat.Focus();
                  // clearTreatmentFields();
               }
               
                if(btnSaveTreat.Text =="Save")
                {
                    DataRow dr = ds.Tables["treatment_info"].NewRow();
                    dr[0] = txtTreatSrNo.Text;
                    dr[1] = dtpTreatDate.Value;
                    dr[2] = txtMedicineName.Text;
                    dr[3] = txtMedicineQty.Text!=""?txtMedicineQty.Text:"0";
                    dr[4] = txtPrescribedBy.Text;
                    dr[5] = txtMedicineCharge.Text != "" ? txtMedicineCharge.Text : "0";
                    ds.Tables["treatment_info"].Rows.Add(dr);
                    btnNewTreat.Focus();
                    //clearTreatmentFields();
                }
                
                dgTreatmentData.DataSource = ds.Tables["treatment_info"];
                for (int i = 0; i <= ds.Tables["treatment_info"].Rows.Count - 1; i++)
                {
                    total_charge += Convert.ToDecimal(ds.Tables["treatment_info"].Rows[i]["CHARGE"]);
                }
                //total_charge = total_charge + Convert.ToDecimal(txtMedicineCharge.Text);
                txtTotalCharge.Clear();
                txtTotalCharge.Text = total_charge.ToString();
                btnSaveTreat.Enabled = false;
            }
            btnNewTreat.Enabled = true;
            btnNewTreat.Focus();
            clearTreatmentFields();
            total_charge = 0;
        }

        private void clearTreatmentFields()
        {
            txtMedicineName.Clear();
            txtMedicineQty.Clear();
            txtMedicineCharge.Clear();
            txtPrescribedBy.Clear();
            dtpTreatDate.Value = DateTime.Today;
            txtTreatSrNo.Clear();
        }
        private void btnMODIFYTreatInfo_Click(object sender, EventArgs e)
        {
            MODE = global.MMode;
            btnEnDis(false);
            clearFields(ipmstabControl.SelectedTab.Text);
            total_charge = 0;
            txtTotalCharge.Clear();
            clearText();
            dgTreatmentData.DataSource = "";
            txtTotalCharge.Clear();
        }

        private void btnDELETETreatInfo_Click(object sender, EventArgs e)
        {

            MODE = global.DMode;
            //clearFields();
            clearFields(ipmstabControl.SelectedTab.Text);
            clearText();
            dgTreatmentData.DataSource = "";
            txtTotalCharge.Clear();
        }

        private void txtStaffID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                h.hmenu("staff_info", "st_ID AS CODE", "st_fname + ' ' + st_midfahus_name + ' ' + st_surname  as NAME", "st_CITY as CITY", "st_STATE AS STATE");
                h.ShowDialog();
                txtStaffID.Text = global.retStr;
                global.retStr = "";
            }
        }

        private void txtPIDTreatInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                if(MODE == global.NMode)
                {
                    h.hmenu("select p_id as 'ID',p_fname AS 'NAME' from patient_info where p_id not in (select p_id from consultant_info)  and p_status='ADMITTED'");
                }
                else if (MODE == global.MMode || MODE == global.DMode || MODE == global.VMode)
                {
                    h.hmenu("consultant_info", "p_ID AS CODE", "dr_in_charge as [DR INCHARGE]");
                }
                //h.ShowDialog();
                txtPIDTreatInfo.Text  = global.retStr;
                global.retStr = "";
            }
        }
        private void btnEnDis(bool value)
        {
            switch(ipmstabControl.SelectedTab.Text)
            {
            case "TREATMENT DETAIL":
                 btnDeleteTreat.Enabled = value;
                 btnSaveTreat.Enabled = value;
                 btnNewTreat.Enabled = value;

                 btnDELETETreatInfo.Enabled = value;
                 btnMODIFYTreatInfo.Enabled = value;
                 btnSAVETreatInfo.Enabled = value;
                 btnVIEWTreatInfo.Enabled = value;
                 btnNEWTreatInfo.Enabled = value;
            break;
            case "TEST DETAIL":
                 btnNEWTestInfo.Enabled = value;
                 btnMODIFYTestInfo.Enabled = value;
                 btnDELETETestInfo.Enabled = value;
                 btnSAVETestInfo.Enabled = value;
                 btnVIEWTestInfo.Enabled = value;
            break;
            case "WARD DETAIL":
                 btnNEWWard.Enabled = value;
                 btnMODIFYWard.Enabled = value;
                 btnDELETEWard.Enabled = value;
                 btnVIEWWard.Enabled = value;
                 btnSAVEWard.Enabled = value;
            break;
            case "DISCHARGE SUMMARY":
                 btnDischargeNEW.Enabled = value; 
                 btnDischargeSAVE.Enabled = value;
                 btnDischargeMODIFY.Enabled = value;
                 btnDischargeDELETE.Enabled = value;
                 btnDischargeVIEW.Enabled = value;
                 if (MODE == global.NMode)
                 {
                     txtDischargeCardNo.Enabled = value;
                 }
                 else if(MODE ==global.MMode)
                 {
                     btnDischargeSAVE.Enabled = true;
                 }
            break;
            }
            
        }

        private void clearFields(string tabtext)
        {
            switch(tabtext)
            {
                case "TREATMENT DETAIL":
                    txtPIDTreatInfo.CausesValidation = true;
                    lblDischargePFName.Text = "";
                    txtPIDTreatInfo.Clear();
                    txtPIDTreatInfo.Enabled = true;
                    txtPIDTreatInfo.Focus();
                break;
                case "TEST DETAIL":
                    txtPIDTestInfo.Clear();
                    txtPIDTestInfo.Enabled = true;
                    txtPIDTestInfo.Focus();
                    txtPIDTestInfo.CausesValidation = true;
                break;
                case "WARD DETAIL":
                    txtWardOccupiedBy.Clear();
                    txtWardOccupiedBy.Enabled = true;
                    cboWardType.Focus();
                break;
                case "DISCHARGE SUMMARY":
                if (MODE != global.NMode)
                {
                    txtDischargeCardNo.Clear();
                    txtDischargeCardNo.Focus();
                    txtDischargeCardNo.Enabled = true;
                }
                else
                {
                    txtDischargePID.Clear();
                    txtDischargePID.Enabled = true;
                    txtDischargePID.Focus();
                }
                break;
            }
            
           
        }
        private void btnaVIEWTreatInfo_Click(object sender, EventArgs e)
        {
            MODE = global.VMode;
            btnEnDis(false);
            clearFields(ipmstabControl.SelectedTab.Text);
            clearText();
            dgTreatmentData.DataSource = "";
            txtTotalCharge.Clear();
           
        }

        private void btnRESETTreatInfo_Click(object sender, EventArgs e)
        {
            clearText();
            dgTreatmentData.DataSource = "";
            txtTotalCharge.Clear();
            total_charge = 0;
            btnEnDis(true);

        }

        private void dgTreatmentData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for(int i =0;i<=dgTreatmentData.Rows.Count-1;i++)
            {
               global.indx = dgTreatmentData.SelectedRows[i].Index;
               //int id = Convert.ToInt32(indx);
               //MessageBox.Show(indx.ToString());
               //if (e.RowIndex == indx)
               //{
               txtTreatSrNo.Text = dgTreatmentData.Rows[global.indx].Cells[0].Value.ToString();
               dtpDate.Value = Convert.ToDateTime(dgTreatmentData.Rows[global.indx].Cells[1].Value);
               txtMedicineName.Text = dgTreatmentData.Rows[global.indx].Cells[2].Value.ToString();
               txtMedicineQty.Text = dgTreatmentData.Rows[global.indx].Cells[3].Value.ToString();
               txtPrescribedBy.Text = dgTreatmentData.Rows[global.indx].Cells[4].Value.ToString();
               txtMedicineCharge.Text = dgTreatmentData.Rows[global.indx].Cells[5].Value.ToString();
               btnSaveTreat.Text = "OK";
               btnNewTreat.Enabled = false;
               btnSaveTreat.Enabled = true;
               btnDeleteTreat.Enabled = true;
               return;
               //}
              
            }
            
        }

        private void txtMedicineCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar !='.'))
            //{
            //    e.Handled = true;
            //}

            //if((e.KeyChar =='.') && ((sender as TextBox).Text.IndexOf('.')>-1) )
            //{
            //    e.Handled = true;
            //}
        }

        private void btnDeleteTreat_Click(object sender, EventArgs e)
        {
            if(txtTreatSrNo.Text !="")
            {
                btnDeleteTreat.Enabled = false;
                if (MODE == global.NMode)
                {
                    dt_treatment.Rows.RemoveAt(global.indx);
                    dt_treatment.AcceptChanges();
                    dgTreatmentData.DataSource = dt_treatment;
                }

                if (MODE == global.MMode)
                {
                    ds.Tables["treatment_info"].Rows.RemoveAt(global.indx);
                    ds.Tables["treatment_info"].AcceptChanges();
                    dgTreatmentData.DataSource = ds.Tables["treatment_info"];
                }

                clearTreatmentFields();
                btnDeleteTreat.Enabled = true;
                txtTreatSrNo.Clear();
            }
            btnNewTreat.Enabled = true;
        }

        private void txtMedicineCharge_Validated(object sender, EventArgs e)
        {
            btnSaveTreat.Focus();
        }

        private void txtPrescribedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                h.hmenu("select st_fname + ' ' + st_midfahus_name + ' ' + st_surname  as NAME from staff_info where st_designation='DOCTOR' order by NAME");
                //h.ShowDialog();
                txtPrescribedBy.Text = global.retStr;
                global.retStr = "";
            }
        }

        private void txtTestCharge1_KeyPress(object sender, KeyPressEventArgs e)
        {
           //ValidateKeyPress(sender,e);
            //txtTestCharge1.KeyPress += ValidateKeyPress;
            //txtTestCharge2.KeyPress += ValidateKeyPress;
        }
        private void ValidateKeyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void fieldWithNumAndDot()
        {
            //test_detail fields
            txtTestCharge1.KeyPress += ValidateKeyPress;
            txtTestCharge2.KeyPress += ValidateKeyPress;
            txtTestCharge3.KeyPress += ValidateKeyPress;
            txtTestCharge4.KeyPress += ValidateKeyPress;
            txtTestCharge5.KeyPress += ValidateKeyPress;
            txtTestCharge6.KeyPress += ValidateKeyPress;
            txtTestCharge7.KeyPress += ValidateKeyPress;
            txtTestCharge8.KeyPress += ValidateKeyPress;
            txtTestCharge9.KeyPress += ValidateKeyPress;
            txtTestCharge10.KeyPress += ValidateKeyPress;
            txtMedicineCharge.KeyPress += ValidateKeyPress;
            //ward_info tab fields
            txtWardCharge.KeyPress += ValidateKeyPress;
            //DISCHARGE SUMMARY FIELDS
            txtDischargePConsultantCharge.KeyPress += ValidateKeyPress;
            txtDischargePBedCharge.KeyPress += ValidateKeyPress;
            txtDischargePNurseCharge.KeyPress += ValidateKeyPress;
            txtDischargePMedicineCharge.KeyPress += ValidateKeyPress;
            txtDischargePTestCharge.KeyPress += ValidateKeyPress;
            txtDischargePEquipCharge.KeyPress += ValidateKeyPress;
        }
        private void chkChanged(CheckBox cb,bool value)
        { 
           switch(cb.Name)
           {
               case "chkTest1":
                   dtpTest1.Enabled = value;
                   txtTestBy1.Enabled = value;
                   cboTestStatus1.Enabled = value;
                   cboTestReport1.Enabled = value;
                   txtTestCharge1.Enabled = value;
               break;

               case "chkTest2":
               dtpTest2.Enabled = value;
               txtTestBy2.Enabled = value;
               cboTestStatus2.Enabled = value;
               cboTestReport2.Enabled = value;
               txtTestCharge2.Enabled = value;
               break;

               case "chkTest3":
               dtpTest3.Enabled = value;
               txtTestBy3.Enabled = value;
               cboTestStatus3.Enabled = value;
               cboTestReport3.Enabled = value;
               txtTestCharge3.Enabled = value;
               break;

               case "chkTest4":
               dtpTest4.Enabled = value;
               txtTestBy4.Enabled = value;
               cboTestStatus4.Enabled = value;
               cboTestReport4.Enabled = value;
               txtTestCharge4.Enabled = value;
               break;

               case "chkTest5":
               dtpTest5.Enabled = value;
               txtTestBy5.Enabled = value;
               cboTestStatus5.Enabled = value;
               cboTestReport5.Enabled = value;
               txtTestCharge5.Enabled = value;
               break;

               case "chkTest6":
               dtpTest6.Enabled = value;
               txtTestBy6.Enabled = value;
               cboTestStatus6.Enabled = value;
               cboTestReport6.Enabled = value;
               txtTestCharge6.Enabled = value;
               break;

               case "chkTest7":
               dtpTest7.Enabled = value;
               txtTestBy7.Enabled = value;
               cboTestStatus7.Enabled = value;
               cboTestReport7.Enabled = value;
               txtTestCharge7.Enabled = value;
               break;

               case "chkTest8":
               dtpTest8.Enabled = value;
               txtTestBy8.Enabled = value;
               cboTestStatus8.Enabled = value;
               cboTestReport8.Enabled = value;
               txtTestCharge8.Enabled = value;
               break;

               case "chkTest9":
               dtpTest9.Enabled = value;
               txtTestBy9.Enabled = value;
               cboTestStatus9.Enabled = value;
               cboTestReport9.Enabled = value;
               txtTestCharge9.Enabled = value;
               break;

               case "chkTest10":
               dtpTest10.Enabled = value;
               txtTestBy10.Enabled = value;
               cboTestStatus10.Enabled = value;
               cboTestReport10.Enabled = value;
               txtTestCharge10.Enabled = value;
               break;
           
           }
        }
        private void btnSAVETestInfo_Click(object sender, EventArgs e)
        {
            if(txtPIDTestInfo.Text=="" || MODE ==global.VMode)
            {
                return;
            }
            ConnectionString();

            if(MODE ==global.NMode)
            {
             com = new SqlCommand("insert into PATIENT_TEST_DATA values(@p_id,@test1,@test1_date,@test1_by,@test1_status,@test1_report,@test1_charge,@test2,@test2_date,@test2_by,@test2_status,@test2_report,@test2_charge,  @test3,@test3_date,@test3_by,@test3_status,@test3_report,@test3_charge,  @test4,@test4_date,@test4_by,@test4_status,@test4_report,@test4_charge,@test5,@test5_date,@test5_by,@test5_status,@test5_report,@test5_charge, @test6,@test6_date,@test6_by,@test6_status,@test6_report,@test6_charge,  @test7,@test7_date,@test7_by,@test7_status,@test7_report,@test7_charge,  @test8,@test8_date,@test8_by,@test8_status,@test8_report,@test8_charge,  @test9,@test9_date,@test9_by,@test9_status,@test9_report,@test9_charge,  @test10,@test10_date,@test10_by,@test10_status,@test10_report,@test10_charge)", con);
            }
            else if (MODE == global.MMode)
            {
                com = new SqlCommand("update PATIENT_TEST_DATA set test1=@test1,test1_date=@test1_date,test1_by=@test1_by,test1_status=@test1_status,test1_report=@test1_report,test1_charge=@test1_charge,test2=@test2,test2_date=@test2_date,test2_by=@test2_by,test2_status=@test2_status,test2_report=@test2_report,test2_charge=@test2_charge, test3=@test3,test3_date=@test3_date,test3_by=@test3_by,test3_status=@test3_status,test3_report=@test3_report,test3_charge=@test3_charge,test4=@test4,test4_date=@test4_date,test4_by=@test4_by,test4_status=@test4_status,test4_report=@test4_report,test4_charge=@test4_charge,test5=@test5,test5_date=@test5_date,test5_by=@test5_by,test5_status=@test5_status,test5_report=@test5_report,test5_charge=@test5_charge,test6=@test6,test6_date=@test6_date,test6_by=@test6_by,test6_status=@test6_status,test6_report=@test6_report,test6_charge=@test6_charge,test7=@test7,test7_date=@test7_date,test7_by=@test7_by,test7_status=@test7_status,test7_report=@test7_report,test7_charge=@test7_charge,test8=@test8,test8_date=@test8_date,test8_by=@test8_by,test8_status=@test8_status,test8_report=@test8_report,test8_charge=@test8_charge,test9=@test9,test9_date=@test9_date,test9_by=@test9_by,test9_status=@test9_status,test9_report=@test9_report,test9_charge=@test9_charge,test10=@test10,test10_date=@test10_date,test10_by=@test10_by,test10_status=@test10_status,test10_report=@test10_report,test10_charge=@test10_charge where p_id=@p_id", con);
            }

            com.Parameters.AddWithValue("@p_id",txtPIDTestInfo.Text.Trim());
            //if(chkTest1.Checked)
            //{
                com.Parameters.AddWithValue("@test1",chkTest1.Checked? chkTest1.Text:"");
                com.Parameters.AddWithValue("@test1_date", dtpTest1.Value);
                com.Parameters.AddWithValue("@test1_by", txtTestBy1.Text.Trim());
                com.Parameters.AddWithValue("@test1_status", cboTestStatus1.Text);
                com.Parameters.AddWithValue("@test1_report", cboTestReport1.Text);
                com.Parameters.AddWithValue("@test1_charge", txtTestCharge1.Text !=""?txtTestCharge1.Text:"0");
            //}

            //if (chkTest2.Checked)
            //{
                com.Parameters.AddWithValue("@test2",chkTest2.Checked?chkTest2.Text:"");
                com.Parameters.AddWithValue("@test2_date", dtpTest2.Value);
                com.Parameters.AddWithValue("@test2_by", txtTestBy2.Text.Trim());
                com.Parameters.AddWithValue("@test2_status", cboTestStatus2.Text);
                com.Parameters.AddWithValue("@test2_report", cboTestReport2.Text);
                com.Parameters.AddWithValue("@test2_charge", txtTestCharge2.Text != "" ? txtTestCharge2.Text : "0");
            //}

            //if (chkTest3.Checked)
            //{
                com.Parameters.AddWithValue("@test3", chkTest3.Checked?chkTest3.Text:"");
                com.Parameters.AddWithValue("@test3_date", dtpTest3.Value);
                com.Parameters.AddWithValue("@test3_by", txtTestBy3.Text.Trim());
                com.Parameters.AddWithValue("@test3_status", cboTestStatus3.Text);
                com.Parameters.AddWithValue("@test3_report", cboTestReport3.Text);
                com.Parameters.AddWithValue("@test3_charge", txtTestCharge3.Text != "" ? txtTestCharge3.Text : "0");
            //}

            //if (chkTest4.Checked)
            //{
                com.Parameters.AddWithValue("@test4", chkTest4.Checked?chkTest4.Text:"");
                com.Parameters.AddWithValue("@test4_date", dtpTest4.Value);
                com.Parameters.AddWithValue("@test4_by", txtTestBy4.Text.Trim());
                com.Parameters.AddWithValue("@test4_status", cboTestStatus4.Text);
                com.Parameters.AddWithValue("@test4_report", cboTestReport4.Text);
                com.Parameters.AddWithValue("@test4_charge", txtTestCharge4.Text != "" ? txtTestCharge4.Text : "0");
            //}

            //if (chkTest5.Checked)
            //{
                com.Parameters.AddWithValue("@test5",chkTest5.Checked ? chkTest5.Text:"");
                com.Parameters.AddWithValue("@test5_date", dtpTest5.Value);
                com.Parameters.AddWithValue("@test5_by", txtTestBy5.Text.Trim());
                com.Parameters.AddWithValue("@test5_status", cboTestStatus5.Text);
                com.Parameters.AddWithValue("@test5_report", cboTestReport5.Text);
                com.Parameters.AddWithValue("@test5_charge", txtTestCharge5.Text != "" ? txtTestCharge5.Text : "0");
            //}

            //if (chkTest6.Checked)
            //{
                com.Parameters.AddWithValue("@test6", chkTest6.Checked ? chkTest6.Text:"");
                com.Parameters.AddWithValue("@test6_date", dtpTest6.Value);
                com.Parameters.AddWithValue("@test6_by", txtTestBy6.Text.Trim());
                com.Parameters.AddWithValue("@test6_status", cboTestStatus6.Text);
                com.Parameters.AddWithValue("@test6_report", cboTestReport6.Text);
                com.Parameters.AddWithValue("@test6_charge", txtTestCharge6.Text != "" ? txtTestCharge6.Text : "0");
            //}

            //if (chkTest7.Checked)
            //{
                com.Parameters.AddWithValue("@test7",chkTest7.Checked ? chkTest7.Text:"");
                com.Parameters.AddWithValue("@test7_date", dtpTest7.Value);
                com.Parameters.AddWithValue("@test7_by", txtTestBy7.Text.Trim());
                com.Parameters.AddWithValue("@test7_status", cboTestStatus7.Text);
                com.Parameters.AddWithValue("@test7_report", cboTestReport7.Text);
                com.Parameters.AddWithValue("@test7_charge", txtTestCharge7.Text != "" ? txtTestCharge7.Text : "0");
            //}

            //if (chkTest8.Checked)
            //{
                com.Parameters.AddWithValue("@test8", chkTest8.Checked ? chkTest8.Text:"");
                com.Parameters.AddWithValue("@test8_date", dtpTest8.Value);
                com.Parameters.AddWithValue("@test8_by", txtTestBy8.Text.Trim());
                com.Parameters.AddWithValue("@test8_status", cboTestStatus8.Text);
                com.Parameters.AddWithValue("@test8_report", cboTestReport8.Text);
                com.Parameters.AddWithValue("@test8_charge", txtTestCharge8.Text != "" ? txtTestCharge8.Text : "0");
            //}

            //if (chkTest9.Checked)
            //{
                com.Parameters.AddWithValue("@test9", chkTest9.Checked ? chkTest9.Text:"");
                com.Parameters.AddWithValue("@test9_date", dtpTest9.Value);
                com.Parameters.AddWithValue("@test9_by", txtTestBy9.Text.Trim());
                com.Parameters.AddWithValue("@test9_status", cboTestStatus9.Text);
                com.Parameters.AddWithValue("@test9_report", cboTestReport9.Text);
                com.Parameters.AddWithValue("@test9_charge", txtTestCharge9.Text != "" ? txtTestCharge9.Text : "0");
            //}

            //if (chkTest10.Checked)
            //{
                com.Parameters.AddWithValue("@test10", chkTest10.Checked ? chkTest10.Text:"");
                com.Parameters.AddWithValue("@test10_date", dtpTest10.Value);
                com.Parameters.AddWithValue("@test10_by", txtTestBy10.Text.Trim());
                com.Parameters.AddWithValue("@test10_status", cboTestStatus10.Text);
                com.Parameters.AddWithValue("@test10_report", cboTestReport10.Text);
                com.Parameters.AddWithValue("@test10_charge", txtTestCharge10.Text != "" ? txtTestCharge10.Text : "0");
            //}

            con.Open();
            com.ExecuteNonQuery();
            if (MODE == global.NMode)
            {
                MessageBox.Show("Test Data Saved!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if(MODE==global.MMode)
            {
                MessageBox.Show("Test Data Updated!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
            con.Close();
            clearText();
            //dr[5] = txtMedicineCharge.Text != "" ? txtMedicineCharge.Text : "0";
        }

        private void chkTest1_CheckedChanged(object sender, EventArgs e)
        {
           if(chkTest1.Checked)
           {
               chkChanged(chkTest1, true);
           }
           else
            {
                chkChanged(chkTest1, false);
           }
        }

        private void chkTest2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest2.Checked)
            {
                chkChanged(chkTest2, true);
            }
            else
            {
                chkChanged(chkTest2, false);
            }
        }
        private void chkTest3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkTest3.Checked)
            {
                chkChanged(chkTest3, true);
            }
            else
            {
                chkChanged(chkTest3, false);
            }
        }

        private void chkTest4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkTest4.Checked)
            {
                chkChanged(chkTest4, true);
            }
            else
            {
                chkChanged(chkTest4, false);
            }
        }

        private void btnNEWTestInfo_Click(object sender, EventArgs e)
        {
            MODE = global.NMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
            clearText();
           
        }

        private void btnMODIFYTestInfo_Click(object sender, EventArgs e)
        {
            MODE = global.MMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
            clearText();
        }

        private void btnDELETETestInfo_Click(object sender, EventArgs e)
        {
            MODE = global.DMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
            clearText();
        }

        private void btnVIEWTestInfo_Click(object sender, EventArgs e)
        {
            MODE = global.VMode;
            clearText();
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
            
        }

        private void txtPIDTestInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                if (MODE == global.NMode)
                {
                    h.hmenu("select p_id as P_ID,p_fname + ' ' + p_midfahus_name + ' ' + p_surname  as NAME from patient_info where p_id not in (select p_id from patient_test_data) order by p_id");
                }
                else if (MODE == global.MMode || MODE ==global.VMode || MODE==global.DMode)
                {
                    h.hmenu("select p.p_id as P_ID,p.p_fname + ' ' + p.p_midfahus_name + ' ' + p.p_surname  as NAME from patient_info p,patient_test_data pt where p.p_id=pt.p_id order by p_id");
                }
                if(global.flag ==true)
                {
                 // h.ShowDialog();
                  txtPIDTestInfo.Text = global.retStr;
                  global.retStr = "";
                }
                
            }
        }

        private void txtPIDTestInfo_Validated(object sender, EventArgs e)
        {
            ConnectionString();

            if (MODE == global.NMode)
            {
                da = new SqlDataAdapter("select p_id from patient_test_data where p_id = @id", con);
                da.SelectCommand.Parameters.AddWithValue("@id",txtPIDTestInfo.Text.Trim());
                dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Patient test data already available!", global.msgBoxHead, MessageBoxButtons.OK);
                    txtPIDTestInfo.Clear();
                    txtPIDTestInfo.Focus();
                    return;

                }
                else
                {
                    da = new SqlDataAdapter("select p_id,p_fname + ' '+ p_midfahus_name + ' ' + p_surname  as 'P_NAME',p_dr_incharge from patient_info where p_id=@pid", con);
                    da.SelectCommand.Parameters.AddWithValue("@pid", txtPIDTestInfo.Text.Trim());
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Patient detail not found!", "IPMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPIDTreatInfo.Focus();
                        return;

                    }
                    else
                    {
                        txtPIDTestInfo.Text = dt.Rows[0]["p_id"].ToString();
                        lblPNameTestInfo.Text = dt.Rows[0]["P_NAME"].ToString();
                        lblTestDrInCharge.Text = dt.Rows[0]["p_dr_incharge"].ToString();
                        chkTest1.Focus();
                    }
                }

            }
            if (MODE == global.MMode || MODE == global.VMode || MODE == global.DMode)
            {
                da = new SqlDataAdapter("select *,p.p_fname + ' '+ p.p_midfahus_name + ' ' + p.p_surname  as 'P_NAME',p.p_dr_incharge as 'DrInCharge' from patient_info p,patient_test_data pt where pt.p_id=@p_id and p.p_id=pt.p_id", con);
                da.SelectCommand.Parameters.AddWithValue("@p_id", txtPIDTestInfo.Text);
                dt = new DataTable();
                string[] test_name = new string[10];
                dt.Clear();
                da.Fill(dt);

                if(dt.Rows.Count ==0)
                {
                    return;
                }
                //data from ds.tables["consultant_info"]
                txtPIDTestInfo.Text = dt.Rows[0]["p_id"].ToString();
                lblPNameTestInfo.Text = dt.Rows[0]["P_NAME"].ToString();
                lblTestDrInCharge.Text = dt.Rows[0]["DrInCharge"].ToString();

                test_name[0] = dt.Rows[0]["Test1"].ToString();
                if(test_name[0] =="")
                {
                    chkTest1.Checked=false;
                }
                else
                {
                    chkTest1.Checked = true;
                }
                dtpTest1.Value = Convert.ToDateTime(dt.Rows[0]["test1_date"]);
                txtTestBy1.Text = dt.Rows[0]["Test1_By"].ToString();
                cboTestStatus1.Text = dt.Rows[0]["Test1_Status"].ToString();
                cboTestReport1.Text = dt.Rows[0]["Test1_Report"].ToString();
                txtTestCharge1.Text = dt.Rows[0]["Test1_Charge"].ToString();

                test_name[1] = dt.Rows[0]["Test2"].ToString();
                if (test_name[1] == "")
                {
                    chkTest2.Checked = false;
                }
                else
                {
                    chkTest2.Checked = true;
                }

                dtpTest2.Value = Convert.ToDateTime(dt.Rows[0]["test2_date"]);
                txtTestBy2.Text = dt.Rows[0]["Test2_By"].ToString();
                cboTestStatus2.Text = dt.Rows[0]["Test2_Status"].ToString();
                cboTestReport2.Text = dt.Rows[0]["Test2_Report"].ToString();
                txtTestCharge2.Text = dt.Rows[0]["Test2_Charge"].ToString();

                test_name[2] = dt.Rows[0]["Test3"].ToString();
                if (test_name[2] == "")
                {
                    chkTest3.Checked = false;
                }
                else
                {
                    chkTest3.Checked = true;
                }
                dtpTest3.Value = Convert.ToDateTime(dt.Rows[0]["test3_date"]);
                txtTestBy3.Text = dt.Rows[0]["Test3_By"].ToString();
                cboTestStatus3.Text = dt.Rows[0]["Test3_Status"].ToString();
                cboTestReport3.Text = dt.Rows[0]["Test3_Report"].ToString();
                txtTestCharge3.Text = dt.Rows[0]["Test3_Charge"].ToString();

                test_name[3] = dt.Rows[0]["Test4"].ToString();
                if (test_name[3] == "")
                {
                    chkTest4.Checked = false;
                }
                else
                {
                    chkTest4.Checked = true;
                }
                dtpTest4.Value = Convert.ToDateTime(dt.Rows[0]["test4_date"]);
                txtTestBy4.Text = dt.Rows[0]["Test4_By"].ToString();
                cboTestStatus4.Text = dt.Rows[0]["Test4_Status"].ToString();
                cboTestReport4.Text = dt.Rows[0]["Test4_Report"].ToString();
                txtTestCharge4.Text = dt.Rows[0]["Test4_Charge"].ToString();

                test_name[4] = dt.Rows[0]["Test5"].ToString();
                if (test_name[4] == "")
                {
                    chkTest5.Checked = false;
                }
                else
                {
                    chkTest5.Checked = true;
                }
                dtpTest5.Value = Convert.ToDateTime(dt.Rows[0]["test5_date"]);
                txtTestBy5.Text = dt.Rows[0]["Test5_By"].ToString();
                cboTestStatus5.Text = dt.Rows[0]["Test5_Status"].ToString();
                cboTestReport5.Text = dt.Rows[0]["Test5_Report"].ToString();
                txtTestCharge5.Text = dt.Rows[0]["Test5_Charge"].ToString();

                test_name[5] = dt.Rows[0]["Test6"].ToString();
                if (test_name[5] == "")
                {
                    chkTest6.Checked = false;
                }
                else
                {
                    chkTest6.Checked = true;
                }
                dtpTest6.Value = Convert.ToDateTime(dt.Rows[0]["test6_date"]);
                txtTestBy6.Text = dt.Rows[0]["Test6_By"].ToString();
                cboTestStatus6.Text = dt.Rows[0]["Test6_Status"].ToString();
                cboTestReport6.Text = dt.Rows[0]["Test6_Report"].ToString();
                txtTestCharge6.Text = dt.Rows[0]["Test6_Charge"].ToString();

                test_name[6] = dt.Rows[0]["Test7"].ToString();
                if (test_name[6] == "")
                {
                    chkTest7.Checked = false;
                }
                else
                {
                    chkTest7.Checked = true;
                }
                dtpTest7.Value = Convert.ToDateTime(dt.Rows[0]["test7_date"]);
                txtTestBy7.Text = dt.Rows[0]["Test7_By"].ToString();
                cboTestStatus7.Text = dt.Rows[0]["Test7_Status"].ToString();
                cboTestReport7.Text = dt.Rows[0]["Test7_Report"].ToString();
                txtTestCharge7.Text = dt.Rows[0]["Test7_Charge"].ToString();

                test_name[7] = dt.Rows[0]["Test8"].ToString();
                if (test_name[7] == "")
                {
                    chkTest8.Checked = false;
                }
                else
                {
                    chkTest8.Checked = true;
                }
                dtpTest8.Value = Convert.ToDateTime(dt.Rows[0]["test8_date"]);
                txtTestBy8.Text = dt.Rows[0]["Test8_By"].ToString();
                cboTestStatus8.Text = dt.Rows[0]["Test8_Status"].ToString();
                cboTestReport8.Text = dt.Rows[0]["Test8_Report"].ToString();
                txtTestCharge8.Text = dt.Rows[0]["Test8_Charge"].ToString();

                test_name[8] = dt.Rows[0]["Test9"].ToString();
                if (test_name[8] == "")
                {
                    chkTest9.Checked = false;
                }
                else
                {
                    chkTest9.Checked = true;
                }
                dtpTest9.Value = Convert.ToDateTime(dt.Rows[0]["test9_date"]);
                txtTestBy9.Text = dt.Rows[0]["Test9_By"].ToString();
                cboTestStatus9.Text = dt.Rows[0]["Test9_Status"].ToString();
                cboTestReport9.Text = dt.Rows[0]["Test9_Report"].ToString();
                txtTestCharge9.Text = dt.Rows[0]["Test9_Charge"].ToString();

                test_name[9] = dt.Rows[0]["Test10"].ToString();
                if (test_name[9] == "")
                {
                    chkTest10.Checked = false;
                }
                else
                {
                    chkTest10.Checked = true;
                }
                dtpTest10.Value = Convert.ToDateTime(dt.Rows[0]["test10_date"]);
                txtTestBy10.Text = dt.Rows[0]["Test10_By"].ToString();
                cboTestStatus10.Text = dt.Rows[0]["Test10_Status"].ToString();
                cboTestReport10.Text = dt.Rows[0]["Test10_Report"].ToString();
                txtTestCharge10.Text = dt.Rows[0]["Test10_Charge"].ToString();


            }
            if (MODE == global.DMode)
            {
                if (MessageBox.Show("Do you want to delete test detail!", global.msgBoxHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    com = new SqlCommand("delete from patient_test_data where p_id = @p_id",con);
                    com.Parameters.AddWithValue("@p_id",txtPIDTestInfo.Text.Trim());
                    con.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("Patient Test detail deleted!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearText();
                    con.Close();
                }
                else
                {
                    clearText();
                }

            }
            total_charge = 0;
            btnEnDis(true);
            txtPIDTestInfo.Enabled = false;
            //}
            
            
        }

        private void btnRESETTestInfo_Click(object sender, EventArgs e)
        {
            clearText();
            btnEnDis(true);
        }

        private void btnEXITTestInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTest5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest5.Checked)
            {
                chkChanged(chkTest5, true);
            }
            else
            {
                chkChanged(chkTest5, false);
            }
        }

        private void chkTest6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest6.Checked)
            {
                chkChanged(chkTest6, true);
            }
            else
            {
                chkChanged(chkTest6, false);
            }
        }

        private void chkTest7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest7.Checked)
            {
                chkChanged(chkTest7, true);
            }
            else
            {
                chkChanged(chkTest7, false);
            }
        }

        private void chkTest8_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest8.Checked)
            {
                chkChanged(chkTest8, true);
            }
            else
            {
                chkChanged(chkTest8, false);
            }
        }

        private void chkTest9_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest9.Checked)
            {
                chkChanged(chkTest9, true);
            }
            else
            {
                chkChanged(chkTest9, false);
            }
        }

        private void chkTest10_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest10.Checked)
            {
                chkChanged(chkTest10, true);
            }
            else
            {
                chkChanged(chkTest10, false);
            }
        }

        private void txtTestCharge1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTestCharge2_TextChanged(object sender, EventArgs e)
        {
            //total_charge += Convert.ToDecimal(txtTestCharge2.Text);
            //lblTotalTestCharge.Text = total_charge.ToString();
        }

        private void txtTestCharge1_Validated(object sender, EventArgs e)
        {
           
        }

        private void btnNEWWard_Click(object sender, EventArgs e)
        {
            MODE = global.NMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
        }

        private void btnMODIFYWard_Click(object sender, EventArgs e)
        {
            MODE = global.MMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            //txtWardOccupiedBy.Clear();
            //txtWardOccupiedBy.Enabled = true;
            //txtWardOccupiedBy.Focus();
            btnEnDis(false);
        }

        private void btnDELETEWard_Click(object sender, EventArgs e)
        {
            MODE = global.DMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            //txtWardOccupiedBy.Clear();
            //txtWardOccupiedBy.Enabled = true;
            //txtWardOccupiedBy.Focus();
            btnEnDis(false);
        }

        private void btnVIEWWard_Click(object sender, EventArgs e)
        {
            MODE = global.VMode;
            //txtWardOccupiedBy.Clear();
            //txtWardOccupiedBy.Enabled = true;
            //txtWardOccupiedBy.Focus();
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
           
        }

        private void btnSAVEWard_Click(object sender, EventArgs e)
        {
            if(txtWardOccupiedBy.Text =="")
            {
                return;
            }
            ConnectionString();
            if(MODE ==global.NMode)
            {
                com = new SqlCommand("insert into ward_info values(@ward_type,@room_no,@bed_no,@occcupied_by,@from_date,@to_date,@total_days,@cost,@total_cost,@status,@entry_date);update ward set status =@status where ward_type=@Ward_type and room_number=@room_no and bed_no=@bed_no", con);
            }
            else if (MODE ==global.MMode)
            {
                com = new SqlCommand("update ward_info set room_no=@room_no,bed_no=@bed_no,from_date=@from_date,to_date=@to_date,total_days=@total_days,cost=@cost,total_cost=@total_cost,status=@status,entry_date=@entry_date;update ward set status =@status where ward_type=@Ward_type and room_number=@room_no and bed_no=@bed_no", con);            
            }

            com.Parameters.AddWithValue("@ward_type", cboWardType.SelectedItem);
            com.Parameters.AddWithValue("@room_no", txtWardRoomNo.Text.Trim());
            com.Parameters.AddWithValue("@bed_no", txtWardBedNo.Text.Trim());
            com.Parameters.AddWithValue("@occcupied_by", txtWardOccupiedBy.Text.Trim());
            com.Parameters.AddWithValue("@from_date", dtpFromDate.Value);
            com.Parameters.AddWithValue("@to_date", dtpToDate.Value);
            com.Parameters.AddWithValue("@total_days", txtWardDays.Text);
            com.Parameters.AddWithValue("@cost", txtWardCharge.Text.Trim());
            com.Parameters.AddWithValue("@total_cost", txtWardTotalCharge.Text.Trim());
            com.Parameters.AddWithValue("@status", cboWardStatus.Text);
            com.Parameters.AddWithValue("@entry_date", dtpEntryDate.Value);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            com.ExecuteNonQuery();
            MessageBox.Show("Ward Detail Saved!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearText();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void btnEXITWard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWardCheck_Click(object sender, EventArgs e)
        {

        }

        private void cboWardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtWardRoomNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && cboWardType.SelectedText != "SELECT")
            {
                frmHelp h = new frmHelp();
                h.hmenu("SELECT room_number as 'ROOM NO',bed_no AS 'BED NO',STATUS FROM WARD WHERE WARD_TYPE='" + cboWardType.SelectedItem + "' and status='AVAILABLE'");
                //if(global.flag==true)
                //{
                    //h.ShowDialog();
                    txtWardRoomNo.Text = global.retStr;
                    global.retStr = "";
                //}
                
            }
        }

        private void txtWardBedNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                h.hmenu("SELECT bed_no AS 'BED NO',status FROM WARD WHERE WARD_TYPE='" + cboWardType.SelectedItem + "' and room_number='" + txtWardRoomNo.Text + "' and status='AVAILABLE'");
                //h.ShowDialog();
                txtWardBedNo.Text = global.retStr;
               // cboWardStatus.Text = global.retStatus;
            }
        }

        private void txtWardOccupiedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                if (MODE == global.NMode)
                {
                    h.hmenu("select p_id as P_ID,p_fname + ' ' + p_midfahus_name + ' ' + p_surname  as NAME from patient_info where p_status='ADMITTED' order by p_id");
                }
                else if (MODE == global.MMode || MODE == global.VMode || MODE == global.DMode)
                {
                    h.hmenu("select distinct p.p_id as P_ID,p.p_fname + ' ' + p.p_midfahus_name + ' ' + p.p_surname  as NAME,w.ward_type as 'WARD' from patient_info p,ward_info w where p.p_id=w.occupied_by and p.p_status ='ADMITTED' and w.ward_type ='"+cboWardType.SelectedItem+"' order by p.p_id");
                }
                if (global.flag == true)
                {
                    //h.ShowDialog();
                    txtWardOccupiedBy.Text  = global.retStr;
                    global.retStr = "";
                }

            }
        }

        private void dtpToDate_Validated(object sender, EventArgs e)
        {
            txtWardDays.Text =(dtpToDate.Value.Date.Subtract(dtpFromDate.Value.Date).TotalDays+1).ToString();
        }

        private void txtWardCharge_Validated(object sender, EventArgs e)
        {
            txtWardTotalCharge.Text = (Convert.ToInt16(txtWardDays.Text) * Convert.ToDecimal(txtWardCharge.Text)).ToString();
        }

        private void txtWardOccupiedBy_Validated(object sender, EventArgs e)
        {
            ConnectionString();
            if(txtWardOccupiedBy.Text !="")
            {
               txtWardOccupiedBy.Enabled = false;
            }

            if (MODE == global.NMode)
            {
                
                da = new SqlDataAdapter("select CONVERT(VARCHAR(20),ENTRY_DATE,103) AS 'DATE',WARD_TYPE,ROOM_NO,BED_NO,CONVERT(VARCHAR(20),FROM_DATE,103) AS FROM_DATE,CONVERT(VARCHAR(20),TO_DATE,103) AS TO_DATE,TOTAL_DAYS,COST,TOTAL_COST,STATUS FROM ward_info where occupied_by=@p_id and ward_type=@ward_type", con);
                da.SelectCommand.Parameters.AddWithValue("@p_id", txtWardOccupiedBy.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@ward_type", cboWardType.SelectedItem);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Ward detail already exists for " + txtWardOccupiedBy.Text, global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWardOccupiedBy.Clear();
                    txtWardOccupiedBy.Enabled = true;
                    cboWardType.Focus();
                    return;
                    //dgWardDetail.DataSource = dt;
                }
                else 
                {
                    dtpFromDate.Focus();
                }
            }

            if(MODE == global.DMode || MODE == global.MMode || MODE ==global.VMode)
            {
                da = new SqlDataAdapter("select * from ward_info where occupied_by=@occupied_by and ward_type = @ward_type",con);
                da.SelectCommand.Parameters.AddWithValue("@occupied_by",txtWardOccupiedBy.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@ward_type",cboWardType.SelectedItem);
                dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("Ward detail not found!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    txtWardRoomNo.Text = dt.Rows[0]["room_no"].ToString();
                    txtWardBedNo.Text  = dt.Rows[0]["bed_no"].ToString();
                    dtpEntryDate.Value = Convert.ToDateTime(dt.Rows[0]["entry_date"]);
                    dtpFromDate.Value = Convert.ToDateTime(dt.Rows[0]["from_date"]);
                    dtpToDate.Value = Convert.ToDateTime(dt.Rows[0]["to_date"]);
                    txtWardDays.Text = dt.Rows[0]["total_days"].ToString();
                    txtWardCharge.Text = dt.Rows[0]["cost"].ToString();
                    txtWardTotalCharge.Text = dt.Rows[0]["total_cost"].ToString();
                    cboWardStatus.Text = dt.Rows[0]["status"].ToString();
                }
                if (MODE == global.DMode)
                {
                    if (MessageBox.Show("Want to delete patient ward detail?", global.msgBoxHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        com = new SqlCommand("delete from ward_info where occupied_by=@p_id and ward_type=@ward_type;update ward set status='AVAILABLE' where ward_type=@ward_type and room_number=@rn and bed_no=@bn", con);
                        com.Parameters.AddWithValue("@p_id", txtWardOccupiedBy.Text.Trim());
                        com.Parameters.AddWithValue("@ward_type", cboWardType.SelectedItem);
                        com.Parameters.AddWithValue("@rn", txtWardRoomNo.Text.Trim());
                        com.Parameters.AddWithValue("@bn", txtWardBedNo.Text.Trim());
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        com.ExecuteNonQuery();
                        MessageBox.Show("Ward detail deleted!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearText();
                        //dgWardDetail.DataSource = "";
                        con.Close();
                    }
                    else
                    {
                        clearText();
                        //dgWardDetail.DataSource = "";
                    }
                }
                
            }
            if (MODE == global.MMode || MODE == global.NMode) { btnSAVEWard.Enabled = true; } else { btnSAVEWard.Enabled = false; }
            
        }

        private void cboWardType_Validated(object sender, EventArgs e)
        {
            if(MODE ==global.MMode || MODE == global.DMode || MODE==global.VMode)
            {
                txtWardOccupiedBy.Enabled = true;
                txtWardOccupiedBy.Focus();
            }
        }

        private void btnRESETWard_Click(object sender, EventArgs e)
        {
            MODE = "";
            //clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(true);
            clearText();
        }

        private void txtWardBedNo_Validated(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConnectionString();
            com = new SqlCommand("select MAX(SUBSTRING(card_no,4,4)) from discharge_summary ORDER BY MAX(SUBSTRING(P_id,4,4)) DESC", con);
            con.Open();
            s = com.ExecuteScalar().ToString();
            if (s == "")
            {
                i = 0 + 1;
            }
            else
            {
                i = Convert.ToInt32(s) + 1;
            }
            txtDischargeCardNo.Text = i.ToString().PadLeft(4, c);
            con.Close();

            MODE = global.NMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
        }

        private void btnDischargeMODIFY_Click(object sender, EventArgs e)
        {
            MODE = global.MMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
        }

        private void btnDischargeDELETE_Click(object sender, EventArgs e)
        {
            MODE = global.DMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
        }

        private void btnDischargeVIEW_Click(object sender, EventArgs e)
        {
            MODE = global.VMode;
            clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(false);
        }

        private void btnDischargeSAVE_Click(object sender, EventArgs e)
        {
            if(txtDischargeCardNo.Text =="")
            {
                return;
            }
            ConnectionString();
            if(MODE==global.NMode)
            {
                com = new SqlCommand("insert into discharge_summary values(@card_no,@card_date,@p_id,@p_name,@p_age,@p_gender,@p_doa,@p_dod,@p_dr_in_charge,@p_diagnosis,@referred_by,@dr_consultant_charge,@bed_charge,@nurse_charge,@test_charge,@equipment_charge,@medicine_charge,@next_visit)",con);
            }
            else if(MODE ==global.MMode)
            {
                com = new SqlCommand("update discharge_summary set card_date=@card_date,p_doa=@p_doa,p_dod=@p_dod,p_dr_in_charge=@p_dr_in_charge,p_diagnosis=@p_diagnosis,refered_by=@referred_by,dr_consultant_charge=@dr_consultant_charge,bed_charge=@bed_charge,nurse_charge=@nurse_charge,test_charge=@test_charge,equipment_charge=@equipment_charge,medicine_charge=@medicine_charge,next_visit=@next_visit where card_no=@card_no", con);
            }
            com.Parameters.AddWithValue("@card_no",txtDischargeCardNo.Text.Trim());
            com.Parameters.AddWithValue("@card_date", dtpDischargeCardDate.Value);
            com.Parameters.AddWithValue("@p_id",txtDischargePID.Text.Trim());
            com.Parameters.AddWithValue("@p_name",lblDischargePFName.Text);
            com.Parameters.AddWithValue("@p_age", txtDischargePAge.Text);
            com.Parameters.AddWithValue("@p_gender", txtDischargePGender.Text);
            com.Parameters.AddWithValue("@p_doa", dtpDischargePDOA.Value);
            com.Parameters.AddWithValue("@p_dod", dtpDischargePDOD.Value);
            com.Parameters.AddWithValue("@p_dr_in_charge", txtDischargePDInCharge.Text.Trim());
            com.Parameters.AddWithValue("@p_diagnosis", txtDischargePDiagnosis.Text.Trim());
            com.Parameters.AddWithValue("@referred_by", txtDischargePReferredBy.Text.Trim());
            com.Parameters.AddWithValue("@dr_consultant_charge", txtDischargePConsultantCharge.Text.Trim());
            com.Parameters.AddWithValue("@bed_charge",txtDischargePBedCharge.Text.Trim());
            com.Parameters.AddWithValue("@nurse_charge",txtDischargePNurseCharge.Text.Trim());
            com.Parameters.AddWithValue("@test_charge", txtDischargePTestCharge.Text.Trim());
            com.Parameters.AddWithValue("@equipment_charge",txtDischargePEquipCharge.Text.Trim());
            com.Parameters.AddWithValue("@medicine_charge", txtDischargePMedicineCharge.Text.Trim());
            com.Parameters.AddWithValue("@next_visit", rdoDischargePVisitYes.Checked? dtpDischargePNextVisit.Value.ToString():"");

            if(con.State ==ConnectionState.Closed)
            {
                con.Open();
            }
            com.ExecuteNonQuery();
            MessageBox.Show("Discharge Summary Detail Saved!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Information);
            clearText();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            
        }

        private void btnDischargeRESET_Click(object sender, EventArgs e)
        {
            //MODE = global.RMode;
            //clearFields(ipmstabControl.SelectedTab.Text);
            btnEnDis(true);
            clearText();
        }

        private void txtDischargePID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                if (MODE == global.NMode)
                {
                    h.hmenu("select p_id as P_ID,p_fname + ' ' + p_midfahus_name + ' ' + p_surname  as NAME from patient_info where p_status='ADMITTED' order by p_id");
                }
                else if (MODE == global.MMode || MODE == global.VMode || MODE == global.DMode)
                {
                    //h.hmenu("select distinct p.p_id as P_ID,p.p_fname + ' ' + p.p_midfahus_name + ' ' + p.p_surname  as NAME from patient_info p,w where p.p_id=w.occupied_by and p.p_status ='ADMITTED' order by p.p_id");
                }
                if (global.flag == true)
                {
                    //h.ShowDialog();
                    txtDischargePID.Text  = global.retStr;
                    global.retStr = "";
                }

            }
        }

        private void txtDischargePID_Validated(object sender, EventArgs e)
        {
            ConnectionString();
            if(MODE ==global.NMode && txtDischargePID.Text !="")
            {
            da = new SqlDataAdapter("SELECT P.p_id as 'P_ID',P.p_fname + ' '+P.p_midfahus_name+' '+ P.p_surname AS 'NAME',P.p_age AS 'AGE',P.p_gender AS 'GENDER',P.p_dr_incharge AS 'DR_INCHARGE',(SELECT SUM(total_cost) FROM ward_info WHERE occupied_by =@p_id) AS 'BED_CHARGE',(SELECT (PT.test1_charge+PT.test2_charge+PT.test3_charge+PT.test4_charge+PT.test5_charge+PT.test6_charge+PT.test7_charge+PT.test8_charge+PT.test9_charge+PT.test10_charge) FROM PATIENT_TEST_DATA PT WHERE p_id =@p_id) AS 'TEST_CHARGE',(SELECT SUM(MEDICINE_CHARGE) FROM treatment_info WHERE p_id =@p_id)  AS 'MEDICINE_CHARGE' FROM patient_info P WHERE P.p_id =@p_id",con);
            da.SelectCommand.Parameters.AddWithValue("@P_ID",txtDischargePID.Text.Trim());
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Details not found for patient " + txtDischargePID.Text, global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDischargePID.Focus();
                return;
            }
            else
            {
                txtDischargePID.Text = dt.Rows[0]["P_ID"].ToString();
                lblDischargePFName.Text = dt.Rows[0]["NAME"].ToString();
                txtDischargePAge.Text = dt.Rows[0]["AGE"].ToString();
                txtDischargePGender.Text = dt.Rows[0]["GENDER"].ToString();
                txtDischargePDInCharge.Text = dt.Rows[0]["DR_INCHARGE"].ToString();
                txtDischargePBedCharge.Text = dt.Rows[0]["BED_CHARGE"].ToString();
                txtDischargePTestCharge.Text = dt.Rows[0]["TEST_CHARGE"].ToString();
                txtDischargePMedicineCharge.Text = dt.Rows[0]["MEDICINE_CHARGE"].ToString();
                dtpDischargePDOA.Focus();

            }
            
            }
            btnDischargeSAVE.Enabled = true;
            
        }

        private void rdoDischargePVisitYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDischargePVisitYes.Checked)
            {
                dtpDischargePNextVisit.Visible = true;
            }
            else
            {
                dtpDischargePNextVisit.Visible = false;
            }
        }

        private void rdoDischargePVisitNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoDischargePVisitNo.Checked)
            {
                dtpDischargePNextVisit.Visible =false;
            }
            else 
            {
                dtpDischargePNextVisit.Visible = true;
            }
        }

        private void txtDischargeCardNo_Validated(object sender, EventArgs e)
        {
            ConnectionString();
            if(txtDischargeCardNo.Text =="")
            {
                return;
            }
            if(MODE==global.MMode || MODE==global.DMode || MODE==global.VMode)
            {
                da = new SqlDataAdapter("select * from discharge_summary where card_no=@card_no",con);
                da.SelectCommand.Parameters.AddWithValue("@card_no",txtDischargeCardNo.Text.Trim());
                dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("Discharge summary not found of "+txtDischargeCardNo.Text,global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtDischargeCardNo.Focus();
                    return;
                    
                }
                else
                {
                    dtpDischargeCardDate.Value = Convert.ToDateTime(dt.Rows[0]["Card_date"]);
                    txtDischargePID.Text =dt.Rows[0]["p_id"].ToString();
                    lblDischargePFName.Text = dt.Rows[0]["p_name"].ToString();
                    txtDischargePAge.Text = dt.Rows[0]["p_age"].ToString();
                    txtDischargePGender.Text = dt.Rows[0]["p_gender"].ToString();
                    dtpDischargePDOA.Value = Convert.ToDateTime(dt.Rows[0]["p_doa"]);
                    dtpDischargePDOD.Value = Convert.ToDateTime(dt.Rows[0]["p_dod"]);
                    txtDischargePDInCharge.Text = dt.Rows[0]["p_dr_in_charge"].ToString();
                    txtDischargePDiagnosis.Text = dt.Rows[0]["p_diagnosis"].ToString();
                    txtDischargePReferredBy.Text = dt.Rows[0]["refered_by"].ToString();
                    txtDischargePConsultantCharge.Text = dt.Rows[0]["dr_consultant_charge"].ToString();
                    txtDischargePBedCharge.Text = dt.Rows[0]["bed_charge"].ToString();
                    txtDischargePNurseCharge.Text = dt.Rows[0]["nurse_charge"].ToString();
                    txtDischargePTestCharge.Text = dt.Rows[0]["test_charge"].ToString();
                    txtDischargePEquipCharge.Text  = dt.Rows[0]["equipment_charge"].ToString();
                    txtDischargePMedicineCharge.Text = dt.Rows[0]["medicine_charge"].ToString();
                    if(dt.Rows[0]["next_visit"].ToString()=="")
                    {
                        rdoDischargePVisitNo.Checked = true;

                    }
                    else
                    {
                        rdoDischargePVisitYes.Checked = true;
                        dtpDischargePNextVisit.Value = Convert.ToDateTime(dt.Rows[0]["next_visit"]);
                    }
                }
               
            }
            if (MODE == global.DMode)
            {
                if (MessageBox.Show("Do you want to delete discharge summary?", global.msgBoxHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    com = new SqlCommand("delete from discharge_summary where card_no=@card_no", con);
                    com.Parameters.AddWithValue("@card_no", txtDischargeCardNo.Text.Trim());
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    com.ExecuteNonQuery();
                    MessageBox.Show("Discharge summary deleted!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearText();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                else
                {
                    clearText();
                }

            }
            else 
            {
                txtDischargePDInCharge.Enabled = false;
                txtDischargePID.Enabled = false;
            }
            txtDischargeCardNo.Enabled = false;
        }

        private void btnDischargeEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDischargeCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                h.hmenu("select CARD_NO,P_ID,P_NAME AS 'NAME' from discharge_summary");
                txtDischargeCardNo.Text = global.retStr;
                global.retStr = "";
                //}

            }
        }

        private void btnChangePassModify_Click(object sender, EventArgs e)
        {
            //MODE = global.MMode;
            //txtChangePassUserID.Clear();
            //txtChangePassUserID.Focus();
            if(txtChangePassUserID.Text =="")
            {
                MessageBox.Show("Enter UserID!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtChangePassUserID.Focus();
                return;
            }
            else if (txtChangePassOld.Text  == "")
            {
                MessageBox.Show("Enter Password!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChangePassOld.Focus();
                return;
            }
             else if (txtChangePassNew.Text =="")
            {
                MessageBox.Show("Enter New Password!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChangePassNew.Focus();
                return;
            }
            else if (txtChangePassReType.Text == "")
            {
                MessageBox.Show("Enter New Password Again!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChangePassReType.Focus();
                return;
            }
            else if(txtChangePassNew.Text.Trim()!=txtChangePassReType.Text.Trim())
            {
                MessageBox.Show("New passord and confirm passwords are not same!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConnectionString();
            da = new SqlDataAdapter("select userid,password from login_info where userid=@userid and password = @password", con);
            da.SelectCommand.Parameters.AddWithValue("@userid", txtChangePassUserID.Text);
            da.SelectCommand.Parameters.AddWithValue("@password", txtChangePassOld.Text);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid UserID and Password!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChangePassUserID.Focus();
                return;
            }
            else
            {
                com = new SqlCommand("update login_info set password = @newpass where userid=@userid", con);
                com.Parameters.AddWithValue("@userid", txtChangePassUserID.Text.Trim());
                com.Parameters.AddWithValue("@newpass", txtChangePassReType.Text.Trim());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MessageBox.Show("Password changed....!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                com.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                clearText();
            }
            
        }

        private void btnChangePassDelete_Click(object sender, EventArgs e)
        {
            //MODE = global.DMode;
            //txtChangePassUserID.Clear();
            //txtChangePassUserID.Focus();
        }

        private void txtChangePassUserID_Validated(object sender, EventArgs e)
        {
            //ConnectionString();
            //if ((txtChangePassUserID.Text != "" && MODE ==global.MMode) || MODE ==global.DMode)
            //{
            //    da = new SqlDataAdapter("select userid,password from login_info where userid=@userid", con);
            //    da.SelectCommand.Parameters.AddWithValue("@userid", txtChangePassUserID.Text.Trim());
            //    dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count == 0)
            //    {
            //        MessageBox.Show("User ID not found!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtChangePassUserID.Clear();
            //        return;
            //    }
            //    else
            //    {
                    
            //        global.OldPass = dt.Rows[0]["Password"].ToString();
                    
            //        if(MODE ==global.DMode)
            //        {
            //            txtChangePassUserID.Text = dt.Rows[0]["userid"].ToString();
            //            txtChangePassOld.Text = global.OldPass;
            //            if (MessageBox.Show("Do you want to delete user account!", global.msgBoxHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                com = new SqlCommand("delete from login_info where userid=@userid", con);
            //                com.Parameters.AddWithValue("@userid", txtChangePassUserID.Text.Trim());
            //                if (con.State == ConnectionState.Closed)
            //                {
            //                    con.Open();
            //                }
            //                com.ExecuteNonQuery();
            //                MessageBox.Show("User account deleted!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                clearText();
            //                con.Close();
            //            }
            //            else
            //            {
            //                clearText();
            //            }
                        
            //        }
            //        txtChangePassOld.Focus();
            //    }
            //}
            //else if (txtChangePassUserID.Text == "")
            //{
            //    //MessageBox.Show("Enter User ID!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtChangePassOld.Enabled = false;
            //    return;
            //}
            //else 
            //{
            //    txtChangePassOld.Enabled = true;
            //    txtChangePassOld.Focus();
            //}
            
        }

        private void btnChangePassExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePassSave_Click(object sender, EventArgs e)
        {
            //if(MODE ==global.MMode)
            //{
            //    string NewPass = txtChangePassNew.Text.Trim();
            //    string ReTypePass = txtChangePassReType.Text.Trim();
            //    if(NewPass =="" || ReTypePass =="")
            //    {
            //        MessageBox.Show("Enter new password!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        txtChangePassNew.Focus();
            //        return;
            //    }
            //    else if (NewPass != ReTypePass)
            //    {
            //        MessageBox.Show("New entered passwords are not same!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtChangePassNew.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        com = new SqlCommand("update login_info set password = @newpass where userid=@userid",con);
            //        com.Parameters.AddWithValue("@userid",txtChangePassUserID.Text.Trim());
            //        com.Parameters.AddWithValue("@newpass",txtChangePassReType.Text.Trim());
            //        if(con.State ==ConnectionState.Closed)
            //        {
            //            con.Open();
            //        }
            //        MessageBox.Show("Password changed succefully! Please login!",global.msgBoxHead,MessageBoxButtons.OK,MessageBoxIcon.Information);
            //        com.ExecuteNonQuery();
            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();
            //        }
            //        clearText();
            //    }
            //}
        }

        private void txtChangePassOld_Validated(object sender, EventArgs e)
        {
            //if (global.OldPass != txtChangePassOld.Text.Trim())
            //{
            //    MessageBox.Show("Invalid UserID or Password! Try Again!", global.msgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtChangePassUserID.Clear();
            //    txtChangePassOld.Clear();
            //    txtChangePassUserID.Focus();
            //    return;
            //}
            //else
            //{
            //    txtChangePassNew.Focus();
            //}

        }

        private void btnChangePassReset_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ConnectionString();
            dt = new DataTable();
            //string repoQuery = "";
            switch(cboReportType.SelectedItem.ToString())
            {
                case "WARD":
                    rptWardReport ward_rpt = new rptWardReport();
                    if(txtPatientIDReport.Text=="")
                    {
                        da = new SqlDataAdapter("select * from ward_info order by entry_date,occupied_by", con);
                    }
                    else
                    {
                        da = new SqlDataAdapter("select * from ward_info where occupied_by =@pid order by entry_date,occupied_by", con);
                        da.SelectCommand.Parameters.AddWithValue("@pid", txtPatientIDReport.Text.Trim());
                    }
                     dt.Columns.Clear();
                     dt.Clear();
                     da.Fill(dt);
                     ward_rpt.SetDataSource(dt);
                     CRVReports.ReportSource = ward_rpt;
                break;
                case "TREATMENT":
                    rptTreatment treat_rpt = new rptTreatment();
                    if(txtPatientIDReport.Text=="")
                    {
                        da = new SqlDataAdapter("SELECT P.p_id AS ID,P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME',P.p_dr_incharge AS 'DR. INCHARGE',T.sr_no AS 'SR.NO.',T.pres_date AS 'DATE',T.medicine_name AS 'MEDICINE NAME',T.medicine_qty AS 'QUANTITY',T.prescribed_by AS 'PRESCRIBED BY',medicine_charge as 'CHARGE' FROM patient_info P,treatment_info T WHERE P.p_id =T.p_id", con);
                    }
                    else
                    {
                        da = new SqlDataAdapter("SELECT P.p_id AS ID,P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME',P.p_dr_incharge AS 'DR. INCHARGE',T.sr_no AS 'SR.NO.',T.pres_date AS 'DATE',T.medicine_name AS 'MEDICINE NAME',T.medicine_qty AS 'QUANTITY',T.prescribed_by AS 'PRESCRIBED BY',medicine_charge as 'CHARGE' FROM patient_info P,treatment_info T WHERE P.p_id =T.p_id and p.p_id=@pid", con);
                        da.SelectCommand.Parameters.AddWithValue("@pid", txtPatientIDReport.Text.Trim());
                    }
                     dt.Columns.Clear();
                     dt.Clear();
                     da.Fill(dt);
                     treat_rpt.SetDataSource(dt);
                     CRVReports.ReportSource = treat_rpt;

                break;
                case "DISCHARGE":
                rptDischargeReport rptDischarge = new rptDischargeReport();
                    if(txtPatientIDReport.Text=="" && txtReportCardNo.Text =="")
                    {
                        da = new SqlDataAdapter("select * from discharge_summary order by card_no", con);
                    }
                    else if (txtReportCardNo.Text =="" && txtPatientIDReport.Text !="")
                    {
                        da = new SqlDataAdapter("select * from discharge_summary where p_id=@pid", con);
                        da.SelectCommand.Parameters.AddWithValue("@pid", txtPatientIDReport.Text.Trim());
                    }
                    else if (txtReportCardNo.Text != "" && txtPatientIDReport.Text != "")
                    {
                        da = new SqlDataAdapter("select * from discharge_summary where card_no=@cardno and p_id=@pid", con);
                        da.SelectCommand.Parameters.AddWithValue("@pid", txtPatientIDReport.Text.Trim());
                        da.SelectCommand.Parameters.AddWithValue("@cardno",txtReportCardNo.Text.Trim());
                    }
                     dt.Columns.Clear();
                     dt.Clear();
                     da.Fill(dt);
                     rptDischarge.SetDataSource(dt);
                     CRVReports.ReportSource = rptDischarge;
                break;

                case "TEST":
                rptTestReport rptTest = new rptTestReport();
                    if(txtPatientIDReport.Text=="")
                    {
                        da = new SqlDataAdapter("SELECT P.p_id AS ID,P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME',P.p_dr_incharge AS 'DR. INCHARGE',PT.* FROM patient_info P,PATIENT_TEST_DATA PT WHERE P.p_id =PT.p_id ", con);
                    }
                    else
                    {
                        da = new SqlDataAdapter("SELECT P.p_id AS ID,P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME',P.p_dr_incharge AS 'DR. INCHARGE',PT.* FROM patient_info P,PATIENT_TEST_DATA PT WHERE P.p_id =PT.p_id and P.P_ID=@P_ID", con);
                        da.SelectCommand.Parameters.AddWithValue("@p_id", txtPatientIDReport.Text.Trim());
                    }
                     dt.Columns.Clear();
                     dt.Clear();
                     da.Fill(dt);
                     rptTest.SetDataSource(dt);
                     CRVReports.ReportSource = rptTest;
                break;

            }
            CRVReports.Refresh();
            CRVReports.Show();


        }

        private void btnReportExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboReportType_Validated(object sender, EventArgs e)
        {
           
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReportType.Text == "DISCHARGE")
            {
                txtReportCardNo.Visible = true;
                label73.Visible = true;
            }
            else
            {
                txtReportCardNo.Visible = false;
                label73.Visible = false;
            }
        }

        private void txtPatientIDReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                string query = "";
                switch(cboReportType.Text)
                {
                    case "WARD":
                        query = "select p.p_id as 'ID',P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME' from patient_info p,ward_info w where p.p_id =w.occupied_by order by p.p_id";
                    break;
                    case "TREATMENT":
                    query = "select distinct p.p_id as 'ID',P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME' from patient_info p,treatment_info t where p.p_id =t.p_id  order by p.p_id";
                    break;
                    case "TEST":
                    query = "select distinct p.p_id as 'ID',P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME' from patient_info p,PATIENT_TEST_DATA pt where p.p_id =pt.p_id  order by p.p_id";
                    break;
                    case "DISCHARGE":
                    query = "select distinct p.p_id as 'ID',P.p_fname+' '+ P.p_midfahus_name + ' ' + P.p_surname AS 'NAME' from patient_info p,discharge_summary ds where p.p_id =ds.p_id  order by p.p_id ";
                    break;
                }
                
                 h.hmenu(query);
                if (global.flag == true)
                {
                    //h.ShowDialog();
                    txtPatientIDReport.Text = global.retStr;
                    global.retStr = "";
                }

            }
        }

        private void txtReportCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmHelp h = new frmHelp();
                h.hmenu("select card_no as 'CARD NO',p_name as 'P_NAME' from discharge_summary where p_id='"+txtPatientIDReport.Text.Trim()+"'");
                if (global.flag == true)
                {
                   txtReportCardNo.Text = global.retStr;
                    global.retStr = "";
                }
            }
        }

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void btnaEXITTreatInfo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

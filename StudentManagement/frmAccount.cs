using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using StudentLib.Models;
using StudentLib.Repository;
namespace StudentManagement
{
    public partial class frmAccount : Form
    {
        IAccountRepository accountRepository=new AccountRepository();
      IEnumerable<Account> accounts;
        public Account LoginInfo { get; set; }
        bool InsertOrUpdate=false;
        BindingSource source;
        public frmAccount()
        {
            InitializeComponent();
        }
        public void LoadAccount()
        {
            var acc=accountRepository.GetAll();
            try
            {
                source=new BindingSource();
                source.DataSource = acc;
                txtUsername.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtPhonenumber.DataBindings.Clear ();
                txtDOB.DataBindings.Clear();
                txtUserID.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtJoinDay.DataBindings.Clear();
                txtRoleID.DataBindings.Clear();
                txtUserID.DataBindings.Add("Text", source, "AccountId");
                txtUsername.DataBindings.Add("Text", source, "Username");
                txtPassword.DataBindings.Add("Text",source,"PassWord");
                txtPhonenumber.DataBindings.Add("Text",source,"PhoneNumber");
                txtDOB.DataBindings.Add("Text",source,"DOB");
                txtRoleID.DataBindings.Add("Text", source, "Roleid");
                txtStatus.DataBindings.Add("Text", source, "AccountStatus");
                txtJoinDay.DataBindings.Add("Text", source, "DateOfJoin");
                dgvData.DataSource = null;
                dgvData.DataSource = source;
                if (acc.Count() == 0)
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            } catch(Exception ex)
            {
                MessageBox.Show( ex.Message,"LoadAccount");
            }
        }
        private Account GetAccountObject()

        {

           Account account = null;

            try
            {
                account = new Account
                {
                   AccountId=int.Parse(txtUserID.Text),
                   Username = txtUsername.Text,
                   PassWord=txtPassword.Text,
                   PhoneNumber=txtPhonenumber.Text,
                   Dob=txtDOB.Text,
                   DateOfJoin=DateTime.Parse(txtJoinDay.Text),
                   Roleid=int.Parse(txtRoleID.Text),
                   AccountStatus=Boolean.Parse(txtStatus.Text),

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get account");
            }

            return account;

        }//end GetCarobject
        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAccountDetail frmAccountDetails = new frmAccountDetail
            {
                Text = "Add Account",
                InsertOrUpdate = false,
                accountRepository = accountRepository,
            };
            if (frmAccountDetails.ShowDialog() == DialogResult.OK)
            {
                LoadAccount();
                //Set focus car inserted
                source.Position = source.Count - 1;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAccountDetail frmAccountDetail = new frmAccountDetail
            {
                Text = "Update Account",
                InsertOrUpdate = true,
                accountRepository = accountRepository,
                accountInfo = GetAccountObject(),
           
        };
            if (frmAccountDetail.ShowDialog() == DialogResult.OK)
            {
                LoadAccount(); //Set focus car updated 
                source.Position = source.Count - 1;

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var account = GetAccountObject();
                if (account.AccountId == LoginInfo.AccountId)
                {
                    MessageBox.Show("Current login.Cannot delete");
                }
                else
                {
                  accountRepository.Remove(account.AccountId);
                LoadAccount();
                }
               
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Account");
            }
        }
    }
}

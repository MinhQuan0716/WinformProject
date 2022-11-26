using StudentLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLib.Models;
using System.Dynamic;

namespace StudentManagement
{
    public partial class frmAccountDetail : Form
    {
        public IAccountRepository accountRepository = new AccountRepository();
        IAccountRole roleRepository = new RoleRepository();
        public bool InsertOrUpdate { get; set; }
        public Account accountInfo { get; set; }
        public bool Check=false;
        public frmAccountDetail()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void Add()
        {
            var role = roleRepository.GetAccountRoles();
            cboRoleID.DataSource = role.ToList();
            cboRoleID.DisplayMember = "Rolename";

        }
        private void frmAccountDetail_Load(object sender, EventArgs e)
        {
            Add();
            txtAccountID.Enabled = false;
          cboRoleID.SelectedIndex = 0;
            if (InsertOrUpdate == true) //Update mode 
            {
                //Show car to perform updating 
                txtAccountID.Text = accountInfo.AccountId.ToString();
                txtUsername.Text = accountInfo.Username;
                txtPassword.Text = accountInfo.PassWord;
                txtPhoneNumber.Text = accountInfo.PhoneNumber;
                txtDOB.Text = accountInfo.Dob;

            }

        }
        public bool CheckInput(string input,string input2,string input3,string input4)
        {
            bool correct = true;
            if (input.Equals("")||input2.Equals("")||input3.Equals("")||input4.Equals(""))
            {
                correct = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z ]"))
            {
                correct = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(input3, "^[0-9]"))
            {
                correct = false;
            }

            return correct;
        }
        public bool CheckDuplicate(Account account)
        {
            bool correct = false;
            var s = accountRepository.GetAll();
            Account acc = accountRepository.GetAccount(account.AccountId);
            foreach(var item in s)
            {
                if (item.Username.Equals(acc.Username))
                {
                    correct = true;
                    break;
                }
                else
                {
                    correct = false;
                }
            }
            return correct;
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                var s = accountRepository.GetAll();
                AccountRole accountRole=cboRoleID.SelectedValue as AccountRole;
                var Account = new Account
                {
               
                    Username = txtUsername.Text,
                    PassWord = txtPassword.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Dob = txtDOB.Text,
                    DateOfJoin = dateTimePicker1.Value,
                     Roleid = accountRole.Roleid,
                    AccountStatus = checkBox1.Checked

                };
                if (InsertOrUpdate != true)
                {
                    if (CheckInput(txtUsername.Text, txtPassword.Text, txtPhoneNumber.Text, txtDOB.Text) == true)
                    {
                      foreach(var item in s)
                        {
                            if (Account.Username.Equals(item.Username))
                            {
                                Check = true;

                                break;
                            }
                            else
                            {
                                Check = false;
                            }
                        }
                        if (Check == false)
                        {
                            accountRepository.AddNew(Account);
                        }
                        else
                        {
                            MessageBox.Show("Duplicate");
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Error in validation");
                    }
                   
                }
                else
                {
                    
                    var Account02 = new Account
                    {
                        AccountId=int.Parse(txtAccountID.Text),
                        Username = txtUsername.Text,
                        PassWord = txtPassword.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Dob = txtDOB.Text,
                        DateOfJoin = dateTimePicker1.Value,
                        Roleid = accountRole.Roleid,
                        AccountStatus = checkBox1.Checked

                    };
                    if (CheckInput(txtUsername.Text, txtPassword.Text, txtPhoneNumber.Text, txtDOB.Text) == true)
                    {
                        if (CheckDuplicate(Account02)==false)
                        {
                            accountRepository.Update(Account02);
                        }
                        else
                        {
                            MessageBox.Show("Duplicate");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Error in validation");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }


       
    }
}


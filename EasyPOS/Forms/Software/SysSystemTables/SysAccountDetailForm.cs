using EasyPOS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysSystemTables
{
    public partial class SysAccountDetailForm : Form
    {
        SysSystemTablesForm SysSystemTablesForm;
        private Modules.SysUserRightsModule sysUserRights;

        MstAccountEntity mstAccountEntity;

        public SysAccountDetailForm(SysSystemTablesForm sysSystemTablesForm, MstAccountEntity accountEntity)
        {
            InitializeComponent();
            SysSystemTablesForm = sysSystemTablesForm;
            mstAccountEntity = accountEntity;

            sysUserRights = new Modules.SysUserRightsModule("SysTables");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (sysUserRights.GetUserRights().CanAdd == false)
                {
                    buttonSave.Enabled = false;
                }

                GetTypeList();
                textBoxAccount.Focus();
            }
        }

        public void LoadAccount()
        {
            if (mstAccountEntity != null)
            {
                textBoxCode.Text = mstAccountEntity.Code;
                textBoxAccount.Text = mstAccountEntity.Account;
                comboBoxType.Text = mstAccountEntity.AccountType;
            }
        }

        public void GetTypeList()
        {
            Controllers.MstAccountController mstAccountController = new Controllers.MstAccountController();
            var types = mstAccountController.ListType();
            if (types != null)
            {
                comboBoxType.DataSource = types;
                LoadAccount();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstAccountEntity == null)
            {
                Entities.MstAccountEntity newAccount = new Entities.MstAccountEntity()
                {
                    Code = textBoxCode.Text,
                    Account = textBoxAccount.Text,
                    AccountType = comboBoxType.Text
                };

                Controllers.MstAccountController mstAccountController = new Controllers.MstAccountController();
                String[] addAccount = mstAccountController.AddAccount(newAccount);
                if (addAccount[1].Equals("0") == true)
                {
                    MessageBox.Show(addAccount[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SysSystemTablesForm.UpdateAccountListDataSource();
                    Close();
                }
            }
            else
            {
                mstAccountEntity.Code = textBoxCode.Text;
                mstAccountEntity.Account = textBoxAccount.Text;
                mstAccountEntity.AccountType = comboBoxType.Text;
                Controllers.MstAccountController mstAccountController = new Controllers.MstAccountController();
                String[] updateAccount = mstAccountController.UpdateAccount(mstAccountEntity);
                if (updateAccount[1].Equals("0") == true)
                {
                    MessageBox.Show(updateAccount[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SysSystemTablesForm.UpdateAccountListDataSource();
                    Close();
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstUser
{
    public partial class MstUserDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public MstUserListForm mstUserListForm;
        public Entities.MstUserEntity mstUserEntity;

        public MstUserDetailForm(SysSoftwareForm softwareForm, MstUserListForm userListForm, Entities.MstUserEntity userEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            mstUserListForm = userListForm;
            mstUserEntity = userEntity;

            GetUserDetail();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        public void GetUserDetail()
        {
            UpdateComponents(mstUserEntity.IsLocked);

            textBoxFullName.Text = mstUserEntity.FullName;
            textBoxUserName.Text = mstUserEntity.UserName;
            textBoxPassword.Text = mstUserEntity.Password;
        }

        public void UpdateComponents(Boolean isLocked)
        {
            if (isLocked == true)
            {
                buttonLock.Enabled = false;
                buttonUnlock.Enabled = true;

                textBoxFullName.ReadOnly = true;
                textBoxUserName.ReadOnly = true;
                textBoxPassword.ReadOnly = true;
            }
            else
            {
                buttonLock.Enabled = true;
                buttonUnlock.Enabled = false;

                textBoxFullName.ReadOnly = false;
                textBoxUserName.ReadOnly = false;
                textBoxPassword.ReadOnly = false;
            }
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstUserController mstUserController = new Controllers.MstUserController();

            Entities.MstUserEntity newUserEntity = new Entities.MstUserEntity()
            {
                UserName = textBoxUserName.Text,
                Password = textBoxPassword.Text,
                FullName = textBoxFullName.Text,
                UserCardNumber = "NA"
            };

            String[] lockUser = mstUserController.LockUser(mstUserEntity.Id, newUserEntity);
            if (lockUser[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstUserListForm.UpdateUserListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockUser[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstUserController mstUserController = new Controllers.MstUserController();

            String[] unlockUser = mstUserController.UnlockUser(mstUserEntity.Id);
            if (unlockUser[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstUserListForm.UpdateUserListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockUser[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

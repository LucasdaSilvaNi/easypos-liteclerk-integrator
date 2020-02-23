using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstItemGroup
{
    public partial class MstItemGroupDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public MstItemGroupListForm mstItemGroupListForm;
        public Entities.MstItemGroupEntity mstItemGroupEntity;

        public MstItemGroupDetailForm(SysSoftwareForm softwareForm, MstItemGroupListForm itemListForm, Entities.MstItemGroupEntity itemEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            sysUserRights = new Modules.SysUserRightsModule("MstItemGroupDetail");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mstItemGroupListForm = itemListForm;
                mstItemGroupEntity = itemEntity;

                GetItemGroupDetail();
                textBoxItemGroup.Focus();
            }
        }

        public void GetItemGroupDetail()
        {
            textBoxItemGroup.Text = mstItemGroupEntity.ItemGroup;
            textBoxItemGroupImagePath.Text = mstItemGroupEntity.ImagePath;
            textBoxKitchenReport.Text = mstItemGroupEntity.KitchenReport;
            UpdateComponents(mstItemGroupEntity.IsLocked);
        }

        public void UpdateComponents(Boolean isLocked)
        {
            if (sysUserRights.GetUserRights().CanLock == false)
            {
                buttonLock.Enabled = false;
            }
            else
            {
                buttonLock.Enabled = !isLocked;
            }

            if (sysUserRights.GetUserRights().CanUnlock == false)
            {
                buttonUnlock.Enabled = false;
            }
            else
            {
                buttonUnlock.Enabled = isLocked;
            }

            textBoxItemGroup.Enabled = !isLocked;
            textBoxItemGroupImagePath.Enabled = !isLocked;
            textBoxKitchenReport.Enabled = !isLocked;
            textBoxItemGroup.Focus();
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstItemGroupController mstItemGroupController = new Controllers.MstItemGroupController();

            Entities.MstItemGroupEntity newItemGroupEntity = new Entities.MstItemGroupEntity()
            {
                ItemGroup = textBoxItemGroup.Text,
                ImagePath = textBoxItemGroupImagePath.Text,
                KitchenReport = textBoxKitchenReport.Text
            };

            String[] lockItemGroup = mstItemGroupController.LockItemGroup(mstItemGroupEntity.Id, newItemGroupEntity);
            if (lockItemGroup[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstItemGroupListForm.UpdateItemGroupListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockItemGroup[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstItemGroupController mstItemGroupController = new Controllers.MstItemGroupController();

            String[] unlockItemGroup = mstItemGroupController.UnlockItemGroup(mstItemGroupEntity.Id);
            if (unlockItemGroup[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstItemGroupListForm.UpdateItemGroupListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockItemGroup[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}

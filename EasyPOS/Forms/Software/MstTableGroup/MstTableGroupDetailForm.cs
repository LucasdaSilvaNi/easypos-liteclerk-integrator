using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstTableGroup
{
    public partial class MstTableGroupDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public MstTableGroupListForm mstTableGroupListForm;
        public Entities.MstTableGroupEntity mstTableGroupEntity;

        public MstTableGroupDetailForm(SysSoftwareForm softwareForm, MstTableGroupListForm tableListForm, Entities.MstTableGroupEntity tableEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            sysUserRights = new Modules.SysUserRightsModule("MstRestaurantTableDetail");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mstTableGroupListForm = tableListForm;
                mstTableGroupEntity = tableEntity;

                GetTableGroupDetail();
                textBoxTableGroup.Focus();
            }
        }

        public void GetTableGroupDetail()
        {
            textBoxTableGroup.Text = mstTableGroupEntity.TableGroup;
            UpdateComponents(mstTableGroupEntity.IsLocked);
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

            textBoxTableGroup.Enabled = !isLocked;
            textBoxTableGroup.Focus();
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstTableGroupController mstTableGroupController = new Controllers.MstTableGroupController();

            Entities.MstTableGroupEntity newTableGroupEntity = new Entities.MstTableGroupEntity()
            {
                TableGroup = textBoxTableGroup.Text
            };

            String[] lockTableGroup = mstTableGroupController.LockTableGroup(mstTableGroupEntity.Id, newTableGroupEntity);
            if (lockTableGroup[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstTableGroupListForm.UpdateTableGroupListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockTableGroup[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstTableGroupController mstTableGroupController = new Controllers.MstTableGroupController();

            String[] unlockTableGroup = mstTableGroupController.UnlockTableGroup(mstTableGroupEntity.Id);
            if (unlockTableGroup[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstTableGroupListForm.UpdateTableGroupListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockTableGroup[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}

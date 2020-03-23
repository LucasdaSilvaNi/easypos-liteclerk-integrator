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
    public partial class SysPeriodDetailForm : Form
    {
        SysSystemTablesForm sysSystemTablesForm;
        private Modules.SysUserRightsModule sysUserRights;

        Entities.MstPeriodEntity mstPeriodEntity;

        public SysPeriodDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstPeriodEntity periodEntity)
        {
            InitializeComponent();
            sysSystemTablesForm = systemTablesForm;
            mstPeriodEntity = periodEntity;

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

                LoadPeriod();
                textBoxPeriod.Focus();
            }
        }

        public void LoadPeriod()
        {
            if (mstPeriodEntity != null)
            {
                textBoxPeriod.Text = mstPeriodEntity.Period;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstPeriodEntity == null)
            {
                Entities.MstPeriodEntity newPeriod = new Entities.MstPeriodEntity()
                {
                    Period = textBoxPeriod.Text
                };

                Controllers.MstPeriodController mstPeriodController = new Controllers.MstPeriodController();
                String[] addPeriod = mstPeriodController.AddPeriod(newPeriod);
                if (addPeriod[1].Equals("0") == true)
                {
                    MessageBox.Show(addPeriod[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdatePeriodListDataSource();
                    Close();
                }
            }
            else
            {
                mstPeriodEntity.Period = textBoxPeriod.Text;
                Controllers.MstPeriodController mstPeriodController = new Controllers.MstPeriodController();
                String[] updatePeriod = mstPeriodController.UpdatePeriod(mstPeriodEntity);
                if (updatePeriod[1].Equals("0") == true)
                {
                    MessageBox.Show(updatePeriod[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdatePeriodListDataSource();
                    Close();
                }

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

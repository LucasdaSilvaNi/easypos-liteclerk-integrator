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
    public partial class SysSystemTablesPeriodDetailForm : Form
    {
        SysSystemTablesForm sysSystemTablesForm;
        Entities.MstPeriodEntity mstPeriodEntity;

        public SysSystemTablesPeriodDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstPeriodEntity periodEntity)
        {
            InitializeComponent();
            sysSystemTablesForm = systemTablesForm;
            mstPeriodEntity = periodEntity;
            LoadPeriod();
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

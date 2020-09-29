﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnPOSTouchActivityForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public TrnPOSTouchForm trnPOSTouchForm;
        public Entities.TrnSalesEntity trnSalesEntity;

        public TrnPOSTouchActivityForm(SysSoftwareForm softwareForm, TrnPOSTouchForm POSTouchForm, Entities.TrnSalesEntity salesEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnPOSTouchForm = POSTouchForm;
            trnSalesEntity = salesEntity;

            labelInvoiceNumber.Text = trnSalesEntity.SalesNumber;

            Boolean isLocked = trnSalesEntity.IsLocked;
            Boolean isTendered = trnSalesEntity.IsTendered;
            Boolean isCanclled = trnSalesEntity.IsCancelled;

            if (isLocked == true && isTendered == true && isCanclled == false)
            {
                buttonEditOrder.Enabled = false;
                buttonBillOut.Enabled = false;
                buttonPrintPartialBill.Enabled = false;
                buttonSplitMergeBill.Enabled = false;
                buttonTender.Enabled = false;
                buttonDeliver.Enabled = false;
            }
            else if (isLocked == true && isTendered == true && isCanclled == true)
            {
                buttonEditOrder.Enabled = false;
                buttonBillOut.Enabled = false;
                buttonPrintPartialBill.Enabled = false;
                buttonSplitMergeBill.Enabled = false;
                buttonTender.Enabled = false;
                buttonCancel.Enabled = false;
                buttonDeliver.Enabled = false;
            }
            else if (isLocked == true)
            {
                buttonDeliver.Enabled = false;
                buttonCancel.Enabled = false;
            }
            else
            {
                buttonCancel.Enabled = false;
            }
        }

        private void buttonEditOrder_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPagePOSTouchSalesDetail(trnPOSTouchForm, trnSalesEntity);
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonTender_Click(object sender, EventArgs e)
        {
            Boolean isLocked = trnSalesEntity.IsLocked;
            Boolean isTendered = trnSalesEntity.IsTendered;

            if (isTendered == true)
            {
                MessageBox.Show("Already tendered.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
                if (trnPOSSalesController.IsSalesTendered(trnSalesEntity.Id) == true)
                {
                    MessageBox.Show("Already tendered.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Modules.SysSerialPortModule.OpenSerialPort();

                    Entities.TrnSalesEntity newSalesEntity = new Entities.TrnSalesEntity
                    {
                        Id = trnSalesEntity.Id,
                        Amount = trnSalesEntity.Amount,
                        SalesNumber = trnSalesEntity.SalesNumber,
                        SalesDate = trnSalesEntity.SalesDate.ToString(),
                        Customer = trnSalesEntity.Customer,
                        Remarks = trnSalesEntity.Remarks
                    };

                    String line1 = Modules.SysCurrentModule.GetCurrentSettings().CustomerDisplayFirstLineMessage;
                    String line2 = "P " + newSalesEntity.Amount.ToString("#,##0.00");

                    if (newSalesEntity.Amount > 0)
                    {
                        line1 = "TOTAL:";
                    }

                    Modules.SysSerialPortModule.WriteSeralPortMessage(line1, line2);

                    TrnPOSTenderForm trnSalesDetailTenderForm = new TrnPOSTenderForm(sysSoftwareForm, null, null, trnPOSTouchForm, null, newSalesEntity);
                    trnSalesDetailTenderForm.ShowDialog();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Boolean isCanclled = trnSalesEntity.IsCancelled;
            Boolean isTendered = trnSalesEntity.IsTendered;

            if (isCanclled == true)
            {
                MessageBox.Show("Already Cancelled.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (isTendered == true)
                {
                    TrnPOSCancelRemarksForm trnSalesListCancelRemarksForm = new TrnPOSCancelRemarksForm(sysSoftwareForm, null, trnPOSTouchForm, trnSalesEntity.Id);
                    trnSalesListCancelRemarksForm.ShowDialog();
                }
            }
        }

        private void buttonDeliver_Click(object sender, EventArgs e)
        {
            if (Modules.SysCurrentModule.GetCurrentSettings().EnableEasyShopIntegration == true)
            {
                TrnPOSTouchActivityDeliver trnPOSTouchActivityDeliver = new TrnPOSTouchActivityDeliver(trnPOSTouchForm, this, trnSalesEntity.Id, trnSalesEntity.Remarks);
                trnPOSTouchActivityDeliver.ShowDialog();
            }
            else
            {
                MessageBox.Show("Easyshop Integration is not enabled.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    {
                        if (buttonEditOrder.Enabled == true)
                        {
                            buttonEditOrder.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.F3:
                    {
                        if (buttonBillOut.Enabled == true)
                        {
                            buttonBillOut.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.F4:
                    {
                        if (buttonTender.Enabled == true)
                        {
                            buttonTender.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.F5:
                    {
                        if (buttonCancel.Enabled == true)
                        {
                            buttonCancel.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.F6:
                    {
                        if (buttonDeliver.Enabled == true)
                        {
                            buttonDeliver.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.F7:
                    {
                        if (buttonPrintPartialBill.Enabled == true)
                        {
                            buttonPrintPartialBill.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.F8:
                    {
                        if (buttonSplitMergeBill.Enabled == true)
                        {
                            buttonSplitMergeBill.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.Escape:
                    {
                        Close();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

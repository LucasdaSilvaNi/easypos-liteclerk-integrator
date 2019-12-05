using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstItem
{
    public partial class MstItemDetailItemComponentDetailForm : Form
    {
        MstItemDetailForm mstItemDetailForm;
        Entities.MstItemComponentEntity mstItemComponentEntity;
        Int32 itemId;
        public MstItemDetailItemComponentDetailForm(MstItemDetailForm itemDetailForm, Int32 currentItemId, Entities.MstItemComponentEntity itemComponentEntity)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstItemComponentEntity = itemComponentEntity;
            itemId = currentItemId;

            GetItemList();
        }

        public void LoadItemComponent()
        {
            comboBoxItem.Enabled = false;
            comboBoxUnit.Enabled = false;
            textBoxCost.Enabled = false;
            textBoxAmount.Enabled = false;
            textBoxOnHantQty.Enabled = false;

            if (mstItemComponentEntity != null)
            {
                comboBoxItem.SelectedValue = mstItemComponentEntity.ItemId;
                comboBoxItemComponent.SelectedValue = mstItemComponentEntity.ComponentItemId;
                comboBoxUnit.SelectedValue = mstItemComponentEntity.UnitId;
                textBoxQuantity.Text = mstItemComponentEntity.Quantity.ToString("#,##0.00");
                textBoxCost.Text = mstItemComponentEntity.Cost.ToString("#,##0.00");
                textBoxAmount.Text = mstItemComponentEntity.Amount.ToString("#,##0.00");
                textBoxOnHantQty.Text = mstItemComponentEntity.OnHandQuantity.ToString("#,##0.00");
            }
            else
            {
                comboBoxItem.SelectedValue = itemId;
            }
        }

        public void GetItemList()
        {
            Controllers.MstItemComponentController mstItemComponentController = new Controllers.MstItemComponentController();
            var items = mstItemComponentController.ListItem();
            if (items.Any())
            {
                comboBoxItem.DataSource = items;
                comboBoxItem.ValueMember = "Id";
                comboBoxItem.DisplayMember = "ItemDescription";
            }

            if (mstItemComponentEntity != null)
            {
                GetItemComponentList();
            }
            else
            {
                LoadItemComponent();
            }
        }

        public void GetItemComponentList()
        {
            Controllers.MstItemComponentController mstItemComponentController = new Controllers.MstItemComponentController();
            var items = mstItemComponentController.ListItem();
            if (items.Any())
            {
                comboBoxItemComponent.DataSource = items;
                comboBoxItemComponent.ValueMember = "Id";
                comboBoxItemComponent.DisplayMember = "ItemDescription";
            }
            GetUnitList();
        }

        public void GetUnitList()
        {
            Controllers.MstItemComponentController mstItemComponentController = new Controllers.MstItemComponentController();
            var units = mstItemComponentController.ListUnit();
            if (units != null)
            {
                comboBoxUnit.DataSource = units;
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";
            }

            LoadItemComponent();
        }

        private void comboBoxItemComponent_Click(object sender, EventArgs e)
        {
            GetItemComponentList();
        }

        private void comboBoxItemComponent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Decimal defaulQuantity = 1, amount = 0;
            Controllers.MstItemComponentController mstItemComponentController = new Controllers.MstItemComponentController();
            String itemId = comboBoxItemComponent.SelectedValue.ToString();
            var item = mstItemComponentController.DetailItem(itemId);
            if (item != null)
            {
                comboBoxUnit.SelectedValue = item.UnitId;
                textBoxQuantity.Text = defaulQuantity.ToString("#,##0.00");
                textBoxCost.Text = item.Cost.ToString("#,##0.00");
                textBoxAmount.Text = amount.ToString("#,##0.00");
                textBoxOnHantQty.Text = item.OnhandQuantity.ToString("#,##0.00");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstItemComponentEntity == null)
            {
                Entities.MstItemComponentEntity newItemComponent = new Entities.MstItemComponentEntity()
                {
                    ItemId = itemId,
                    ComponentItemId = Convert.ToInt32(comboBoxItemComponent.SelectedValue),
                    UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue),
                    Quantity = Convert.ToDecimal(textBoxQuantity.Text),
                    Cost = Convert.ToDecimal(textBoxCost.Text),
                    Amount = Convert.ToDecimal(textBoxAmount.Text),
                };

                Controllers.MstItemComponentController mstItemComponentController = new Controllers.MstItemComponentController();
                String[] addItemComponent = mstItemComponentController.AddItemComponent(newItemComponent);
                if (addItemComponent.Equals("0") == true)
                {
                    MessageBox.Show(addItemComponent[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateItemComponentListDataSource();
                    Close();
                }
            }
            else
            {
                mstItemComponentEntity.ItemId = Convert.ToInt32(comboBoxItem.SelectedValue);
                mstItemComponentEntity.ComponentItemId = Convert.ToInt32(comboBoxItemComponent.SelectedValue);
                mstItemComponentEntity.UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
                mstItemComponentEntity.Quantity = Convert.ToDecimal(textBoxQuantity.Text);
                mstItemComponentEntity.Cost = Convert.ToDecimal(textBoxCost.Text);
                mstItemComponentEntity.Amount = Convert.ToDecimal(textBoxAmount.Text);

                Controllers.MstItemComponentController mstItemComponentController = new Controllers.MstItemComponentController();
                String[] updateItemComponent = mstItemComponentController.UpdateItemComponent(mstItemComponentEntity);
                if (updateItemComponent.Equals("0") == true)
                {
                    MessageBox.Show(updateItemComponent[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateItemComponentListDataSource();
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

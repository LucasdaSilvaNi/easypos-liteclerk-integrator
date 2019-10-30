using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepInventory
{
    public partial class RepInventoryReportInventoryReport : Form
    {
        public List<Entities.DgvInventoryReportEntity> inventoryReportList;
        public BindingSource dataInventoryReportListSource = new BindingSource();
        public PagedList<Entities.DgvInventoryReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateStart;
        public DateTime dateEnd;
        public Int32 idTerminal;

        public RepInventoryReportInventoryReport()
        {
            InitializeComponent();
        }

        public void GetDataGridViewCollectionDetailReportSource()
        {
            dataGridViewInventoryReport.DataSource = dataInventoryReportListSource;
        }

        private void buttonPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, 1, pageSize);
            dataInventoryReportListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = false;
            buttonPageListPrevious.Enabled = false;
            buttonPageListNext.Enabled = true;
            buttonPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, --pageNumber, pageSize);
                dataInventoryReportListSource.DataSource = pageList;
            }

            buttonPageListNext.Enabled = true;
            buttonPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonPageListFirst.Enabled = false;
                buttonPageListPrevious.Enabled = false;
            }

            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, ++pageNumber, pageSize);
                dataInventoryReportListSource.DataSource = pageList;
            }

            buttonPageListFirst.Enabled = true;
            buttonPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonPageListNext.Enabled = false;
                buttonPageListLast.Enabled = false;
            }

            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, pageList.PageCount, pageSize);
            dataInventoryReportListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = true;
            buttonPageListPrevious.Enabled = true;
            buttonPageListNext.Enabled = false;
            buttonPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}

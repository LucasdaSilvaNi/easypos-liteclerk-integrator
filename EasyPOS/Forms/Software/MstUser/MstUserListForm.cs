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

namespace EasyPOS.Forms.Software.MstUser
{
    public partial class MstUserListForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvUserListUserEntity> userListData = new List<Entities.DgvUserListUserEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvUserListUserEntity> userListPageList = new PagedList<Entities.DgvUserListUserEntity>(userListData, pageNumber, pageSize);
        public BindingSource userListDataSource = new BindingSource();

        public MstUserListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateUserListDataGridView();
        }

        public void UpdateUserListDataSource()
        {
            SetUserListDataSourceAsync();
        }

        public async void SetUserListDataSourceAsync()
        {
            List<Entities.DgvUserListUserEntity> getUserListData = await GetUserListDataTask();
            if (getUserListData.Any())
            {
                userListData = getUserListData;
                userListPageList = new PagedList<Entities.DgvUserListUserEntity>(userListData, pageNumber, pageSize);

                if (userListPageList.PageCount == 1)
                {
                    buttonUserListPageListFirst.Enabled = false;
                    buttonUserListPageListPrevious.Enabled = false;
                    buttonUserListPageListNext.Enabled = false;
                    buttonUserListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonUserListPageListFirst.Enabled = false;
                    buttonUserListPageListPrevious.Enabled = false;
                    buttonUserListPageListNext.Enabled = true;
                    buttonUserListPageListLast.Enabled = true;
                }
                else if (pageNumber == userListPageList.PageCount)
                {
                    buttonUserListPageListFirst.Enabled = true;
                    buttonUserListPageListPrevious.Enabled = true;
                    buttonUserListPageListNext.Enabled = false;
                    buttonUserListPageListLast.Enabled = false;
                }
                else
                {
                    buttonUserListPageListFirst.Enabled = true;
                    buttonUserListPageListPrevious.Enabled = true;
                    buttonUserListPageListNext.Enabled = true;
                    buttonUserListPageListLast.Enabled = true;
                }

                textBoxUserListPageNumber.Text = pageNumber + " / " + userListPageList.PageCount;
                userListDataSource.DataSource = userListPageList;
            }
            else
            {
                buttonUserListPageListFirst.Enabled = false;
                buttonUserListPageListPrevious.Enabled = false;
                buttonUserListPageListNext.Enabled = false;
                buttonUserListPageListLast.Enabled = false;

                pageNumber = 1;

                userListDataSource.Clear();
                textBoxUserListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvUserListUserEntity>> GetUserListDataTask()
        {
            String filter = textBoxUserListFilter.Text;
            Controllers.MstUserController mstUserController = new Controllers.MstUserController();

            List<Entities.MstUser> listUser = mstUserController.ListUser(filter);
            if (listUser.Any())
            {
                var users = from d in listUser
                            select new Entities.DgvUserListUserEntity
                            {
                                ColumnUserListButtonEdit = "Edit",
                                ColumnUserListButtonDelete = "Delete",
                                ColumnUserListId = d.Id,
                                ColumnUserListUserName = d.UserName,
                                ColumnUserListFullName = d.FullName
                            };

                return Task.FromResult(users.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvUserListUserEntity>());
            }
        }

        public void CreateUserListDataGridView()
        {
            UpdateUserListDataSource();

            dataGridViewUserList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUserList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUserList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUserList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUserList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUserList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUserList.DataSource = userListDataSource;
        }

        public void GetUserListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void textBoxUserListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateUserListDataSource();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageUserDetail();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetUserListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewUserList.CurrentCell.ColumnIndex == dataGridViewUserList.Columns["ColumnUserListButtonEdit"].Index)
            {
                sysSoftwareForm.AddTabPageUserDetail();
            }

            if (e.RowIndex > -1 && dataGridViewUserList.CurrentCell.ColumnIndex == dataGridViewUserList.Columns["ColumnUserListButtonDelete"].Index)
            {

            }
        }
    }
}

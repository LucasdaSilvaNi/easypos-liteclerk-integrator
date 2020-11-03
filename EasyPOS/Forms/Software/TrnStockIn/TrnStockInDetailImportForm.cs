using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailImportForm : Form
    {
        public TrnStockInDetailForm trnStockInDetailForm;
        public Entities.TrnStockInEntity trnStockInLineEntity;

        public TrnStockInDetailImportForm(TrnStockInDetailForm stockInDetailForm)
        {
            trnStockInDetailForm = stockInDetailForm;
            InitializeComponent();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
             openFileDialogImport.Filter = "CSV Files (*.csv) | *.csv | txt files (*.txt)|*.txt| All Files (*.*) | *.*";
            try
            {
                DialogResult dialogResult = openFileDialogImport.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    textBoxFileName.Text = openFileDialogImport.FileName;
                    var lines = File.ReadAllLines(textBoxFileName.Text).Skip(1);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonImport_Click(object sender, EventArgs e)
        {
            
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

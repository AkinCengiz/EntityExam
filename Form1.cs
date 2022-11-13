using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemoV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgvProduct.DataSource = _productDal.GetAll();
        }

        public void ClearControlAdd()
        {
            tbxId.Clear();
            tbxName.Clear();
            tbxUnitPrice.Clear();
            tbxStockAmount.Clear();
            tbxName.Focus();
        }

        public void ClearControlUpdate()
        {
            tbxIdUpdate.Clear();
            tbxNameUpdate.Clear();
            tbxUnipPriceUpdate.Clear();
            tbxStockAmountUpdate.Clear();
            tbxNameUpdate.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts();
            ClearControlAdd();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxIdUpdate.Text = dgvProduct.CurrentRow.Cells[0].Value.ToString();
            tbxNameUpdate.Text = dgvProduct.CurrentRow.Cells[1].Value.ToString();
            tbxUnipPriceUpdate.Text = dgvProduct.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgvProduct.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnipPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
                Id = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            ClearControlUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            ClearControlUpdate();
        }
    }
}

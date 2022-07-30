using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entegre_servis.DataDB;
namespace entegre_servis
{
    public partial class urunlisteleme : KryptonForm
    {
        public urunlisteleme()
        {
            InitializeComponent();
        }

        private void urunlisteleme_Load(object sender, EventArgs e)
        {
            KRYPTONContext db = new KRYPTONContext();
            var data = db.Urunlers.ToList();
            kryptonDataGridView1.DataSource = data;

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs data)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            urunler frm = new urunler();
            frm.Show();
            

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
           urunsatislar frm = new urunsatislar();
            frm.Show();

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            urunsiparis frm = new urunsiparis();
            frm.Show();
        }
    }
}

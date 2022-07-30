using entegre_servis.DataDB;
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

namespace entegre_servis
{
    public partial class urunsatislar : KryptonForm
    {
        public urunsatislar()
        {
            InitializeComponent();
        }

        private void urunsatislar_Load(object sender, EventArgs e)
        {
            KRYPTONContext db = new KRYPTONContext();
            var data=db.Satıslars.ToList();
            double ciro = 0;
            foreach (Satıslar element in data) 
            {
            ciro += Convert.ToDouble(element.SiparisTutar);


            }
            kryptonLabel1.Text ="Günlük cironuz "+ ciro.ToString();
            kryptonDataGridView1.DataSource = data;
        }


        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

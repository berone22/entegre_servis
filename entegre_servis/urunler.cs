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
    public partial class urunler : KryptonForm
    {
        public urunler()
        {
            InitializeComponent();
        }

        private void urunler_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                KRYPTONContext db = new KRYPTONContext();
                Urunler yeniUrun = new Urunler();

                yeniUrun.UrunIsim = kryptonTextBox1.Text;
                yeniUrun.UrunFiyati = kryptonTextBox2.Text;
                yeniUrun.UrunAdeti = kryptonTextBox3.Text;
                db.Urunlers.Add(yeniUrun);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Ürün Eklendi");
            }
            catch (Exception)
            {
               
                throw;
            }
        }
    }
}

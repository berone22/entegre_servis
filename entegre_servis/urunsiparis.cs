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
    public partial class urunsiparis : KryptonForm
    {
        public urunsiparis()
        {
            InitializeComponent();
        }
        List<Urunler> veriler;
        private void urunsiparis_Load(object sender, EventArgs e)
        {
            KRYPTONContext db = new KRYPTONContext();
            var urunler = db.Urunlers.ToList();
            veriler=urunler;
            foreach (var urun in urunler) 
            {
                kryptonComboBox2.Items.Add(urun.UrunIsim);

            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var urun in veriler)
            {
                if(kryptonComboBox2.Text==urun.UrunIsim)
                {
                  kryptonLabel2.Text = urun.UrunFiyati;

                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            KRYPTONContext db = new KRYPTONContext();
            Siparisler tb=new Siparisler();
            tb.SiparisTutarı = kryptonLabel2.Text;
            tb.MasaNo=kryptonComboBox1.Text;
            tb.SiparisIsmi=kryptonComboBox2.Text;
            tb.GarsonAdi = Properties.Settings.Default.isim;
            tb.SiparisAcıklama = textBox1.Text;
            db.Siparislers.Add(tb);
            Satıslar st=new Satıslar();
            st.SiparisTutar = kryptonLabel2.Text;
            st.GarsonAdi = Properties.Settings.Default.isim;
            db.Satıslars.Add(st);
            db.SaveChanges();
           
            MessageBox.Show("sipariş başarıyla oluşturuldu");
            

                

        }
    }
}

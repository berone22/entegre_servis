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
    public partial class kullanicilar : KryptonForm
    {
        public kullanicilar()
        {
            InitializeComponent();
        }

        private void kullanicilar_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            using (KRYPTONContext db = new KRYPTONContext())
            {
                //kodlarimiz
                var kullanıcılar = db.Kullanicis.ToList();
               
                foreach (var kullanici in kullanıcılar)
                {
                    if(kryptonTextBox1.Text == kullanici.KullaniciIsim)
                    {
                        if (kullanici != null)

                        {

                            if (kullanici.KullaniciSifre == kryptonTextBox2.Text)
                            {
                                urunlisteleme frm = new urunlisteleme();
                                Properties.Settings.Default.isim = kullanici.KullaniciIsim;
                                MessageBox.Show("Hoşgeldiniz " + kullanici.KullaniciIsim);
                                frm.Show();
                                this.Hide();






                            }

                        }
                        else
                        {
                            MessageBox.Show("Yanlış Kullanıcı veya Şifre Girdiniz");

                        }
                    } 
                    
                    
                }
            
                
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otel_otomasyonu
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        giris grs = new giris();
        Form2 frm = new Form2();



        private void button2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            if (txtkullanıcı.Text == string.Empty || txtsifre.Text == string.Empty)
            {
                MessageBox.Show("Lütfen kullanıcı adını  ve şifreni kontrol et !!!", "HATA | Otel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                grs.girisYap (txtkullanıcı.Text, txtsifre.Text, DateTime.Now);
                string bilgiTut = txtkullanıcı.Text + txtsifre.Text.ToString();
                if (grs.girisDurumu == bilgiTut)
                {

                    frm.Show();
                    this.Hide();
                }
            }
            
        }

        }
}
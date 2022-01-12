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
    public partial class Form2 : Form
    {
        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {
            müsteri mü = new müsteri();
            mü.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmodalar odalar = new Frmodalar();
            odalar.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MusteriEkranı me = new MusteriEkranı();
            me.Show();
            this.Hide();




        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            personel pr = new personel();
            pr.Show();
            this.Hide();
        }
    }
}

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
    public partial class personel : Form
    {
        public personel()
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
       
        private void btnekle_Click(object sender, EventArgs e)
        {
            personelekle pe = new personelekle();
            pe.ekle(txtTc.Text,txtAd.Text,txtSoyad.Text,txttel.Text,txtMaas.Text,txtGorev.Text);
            dataGridView1.DataSource = pe.tablolar();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
           string tc = Convert.ToString(txtTc.Text);
            personelekle pe = new personelekle();
            pe.personelSil(tc);
                dataGridView1.DataSource = pe.tablolar();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string tcNo= Convert.ToString(txtTc.Text);
            personelekle pe = new personelekle();
            pe.personelGuncelle(tcNo,txtAd.Text,txtSoyad.Text,txttel.Text,txtMaas.Text,txtGorev.Text);
            dataGridView1.DataSource = pe.tablolar();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
             personelekle pe = new personelekle();
            dataGridView1.DataSource = pe.personelAra(txtTc.Text);
        }

        private void personel_Load(object sender, EventArgs e)
        {
            personelekle me = new personelekle();
            dataGridView1.DataSource = me.tablolar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtTc.Text = dataGridView1.Rows[e.RowIndex].Cells["tcno"].Value.ToString();
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells["adi"].Value.ToString();
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells["soyadi"].Value.ToString();
                txttel.Text = dataGridView1.Rows[e.RowIndex].Cells["telno"].Value.ToString();//vs yi kendine göre mi ayarladın play stop falan nerede
                txtMaas.Text = dataGridView1.Rows[e.RowIndex].Cells["maas"].Value.ToString();
                txtGorev.Text = dataGridView1.Rows[e.RowIndex].Cells["gorev"].Value.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtSoyad.Text = "";  txttel.Text = ""; txtMaas.Text = "";
            txtTc.Text = ""; txtGorev.Text = ""; 
        }
    }
}

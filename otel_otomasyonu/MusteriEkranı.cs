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
    public partial class MusteriEkranı : Form
    {
        public MusteriEkranı()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MüsteriEkrani me = new MüsteriEkrani();
            dataGridView1.DataSource = me.tablolar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void MusteriEkranı_Load(object sender, EventArgs e)
        {

            MüsteriEkrani me = new MüsteriEkrani();
            dataGridView1.DataSource = me.tablolar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
           txtAdi.Text = dataGridView1.Rows[e.RowIndex].Cells["adi"].Value.ToString();
             txtSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells["soyadi"].Value.ToString();
             cmbCinsiyet.Text= dataGridView1.Rows[e.RowIndex].Cells["cinsiyet"].Value.ToString();
           txttelefon.Text = dataGridView1.Rows[e.RowIndex].Cells["telefon"].Value.ToString();
             txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells["mail"].Value.ToString();
             txtTc.Text= dataGridView1.Rows[e.RowIndex].Cells["tcno"].Value.ToString();
             txtOda.Text = dataGridView1.Rows[e.RowIndex].Cells["odano"].Value.ToString();
            txtUcret.Text= dataGridView1.Rows[e.RowIndex].Cells["ucret"].Value.ToString();
          dateTimePicker1.Value = Convert.ToDateTime( dataGridView1.Rows[e.RowIndex].Cells["giristarihi"].Value);
           dateTimePicker2.Value  = Convert.ToDateTime( dataGridView1.Rows[e.RowIndex].Cells["cıkıstarihi"].Value);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtAdi.Text = "";
            txtSoyadi.Text = "";   cmbCinsiyet.Text = ""; txttelefon.Text = ""; txtMail.Text = "";
            txtTc.Text = "";     txtOda.Text = ""; txtUcret.Text = ""; dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());

        }
        public DateTime giris_tarihi { get; set; }
        public DateTime cıkıs_tarihi { get; set; }
        private void button3_Click(object sender, EventArgs e)
        { giris_tarihi = Convert.ToDateTime(dateTimePicker1.Value);
            cıkıs_tarihi = Convert.ToDateTime(dateTimePicker2.Value);
            int id = Convert.ToInt16(lblID.Text);
            MüsteriEkrani me = new MüsteriEkrani();
            me.musteriGuncelle(id, txtAdi.Text, txtSoyadi.Text, cmbCinsiyet.Text, txttelefon.Text, txtMail.Text, txtTc.Text, txtOda.Text, txtUcret.Text,giris_tarihi,cıkıs_tarihi);
            dataGridView1.DataSource = me.tablolar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblID.Text);
            MüsteriEkrani me = new MüsteriEkrani();
            me.MusteriSil(id);
            dataGridView1.DataSource = me.tablolar();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MüsteriEkrani me = new MüsteriEkrani();
           dataGridView1.DataSource= me.MusteriAra(txtAra.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}

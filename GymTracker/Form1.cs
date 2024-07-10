using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace GymTracker
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-N3AECOR\\SQLEXPRESS;Initial Catalog=tracker;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter blg = new SqlDataAdapter();
        public Form1()
        {
            InitializeComponent();
            getir();
            

        }

        public void getir()
        {
            baglanti.Open();
            blg=new SqlDataAdapter("SELECT *FROM gymtable",baglanti);
            DataTable tablo= new DataTable();
            blg.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
        private void label1_Click(object sender, EventArgs e)
        {
            





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ekle = "INSERT INTO gymtable (adsoyad,hareketadi,kacset,kactekrar,tarih) values (@adsoyad,@hareketadi,@kacset,@kactekrar,@tarih)";
            komut = new SqlCommand(ekle, baglanti);
            komut.Parameters.AddWithValue("@adsoyad", textBox4.Text);
            komut.Parameters.AddWithValue("@hareketadi", comboBox1.Text);
            komut.Parameters.AddWithValue("@kacset", textBox2.Text);
            komut.Parameters.AddWithValue("@kactekrar", textBox3.Text);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

        public void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ekle = "UPDATE gymtable set adsoyad=@adsoyad,hareketadi=@hareketadi,kacset=@kacset,kactekrar=@kactekrar,tarih=@tarih where id=@id";
            komut=new SqlCommand(ekle,baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(label6.Text));
            komut.Parameters.AddWithValue("@hareketadi", comboBox1.Text);
            komut.Parameters.AddWithValue("@adsoyad", textBox4.Text);
            komut.Parameters.AddWithValue("@kactekrar", textBox3.Text);
            komut.Parameters.AddWithValue("@kacset", textBox2.Text);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();








        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ekle = "DELETE FROM gymtable where id=@id";
            komut=new SqlCommand(ekle,baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(label6.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();
        }
    }
}

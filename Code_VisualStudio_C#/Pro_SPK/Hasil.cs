using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pro_SPK
{
    public partial class Hasil : Form
    {
        private static Prioritas fPrioritas;
        MySqlConnection conn = new MySqlConnection();
        String connString = "server=127.0.0.1;uid=root;pwd=;database=dbwisatamalang;SslMode=none";
        public Hasil()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        void myConn()
        {
            try
            {
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Hasil_Load(object sender, EventArgs e)
        {
            masukkanData();
        }

        void masukkanData()
        {
            try
            {
                myConn();
                String sql = "SELECT nama,jarak,harga,rating,jam_op,jlh_pengunjung from wisata order by prioritas DESC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                this.dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fPrioritas = new Prioritas();
            this.Hide();
            fPrioritas.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            masukkanData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                myConn();
                String sql = "SELECT nama,jarak,harga,rating,jam_op,jlh_pengunjung from wisata order by prioritas ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                this.dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

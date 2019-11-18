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
    public partial class Prioritas : Form
    {
        private static Home fHome;
        private static Hasil fHasil;
        MySqlConnection conn = new MySqlConnection();
        String connString = "server=127.0.0.1;uid=root;pwd=;database=dbwisatamalang;SslMode=none";
        int jarak;
        int harga;
        int rating;
        int jam_op;
        int jlh_pengunjung;
        int tot_bobot;
        double pri_jarak;
        double pri_harga;
        double pri_rating;
        double pri_jam_op;
        double pri_jlh_pengunjung;
        int[,] data = new int[50, 6];
        double[,] dataSI = new double[50, 8];
        double totalSI;

        public Prioritas()
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

        private void Prioritas_Load(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            fHome = new Home();
            this.Hide();
            fHome.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void btnMasuk_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""  && textBox4.Text != "" && textBox5.Text != "")
            {
                jarak = int.Parse(textBox1.Text);
                harga = int.Parse(textBox2.Text);
                rating = int.Parse(textBox3.Text);
                jam_op = int.Parse(textBox4.Text);
                jlh_pengunjung = int.Parse(textBox5.Text);
                tot_bobot = (jarak + harga + rating + jam_op + jlh_pengunjung);
                if (tot_bobot == 0)
                {
                    MessageBox.Show("Tidak disarankan mengisi 0 (nol) semua!!");
                }
                pri_jarak = ((double)jarak / (double)tot_bobot);
                pri_harga = ((double)harga / (double)tot_bobot);
                pri_rating = ((double)rating / (double)tot_bobot);
                pri_jam_op = ((double)jam_op / (double)tot_bobot);
                pri_jlh_pengunjung = ((double)jlh_pengunjung / (double)tot_bobot);
                ambilNilai();
                /*Console.WriteLine(tot_bobot);
                Console.WriteLine(pri_jarak);
                Console.WriteLine(pri_harga);
                Console.WriteLine(pri_rating);
                Console.WriteLine(pri_jam_op);
                Console.WriteLine(pri_jlh_pengunjung);*/
                vektorSI();
                //cetak_array();
                vektorVI();
                setPrioritas();
                openpage();
            }

            else
            {
                MessageBox.Show("Nilai Harus diisi semua!!");
            }    
        }

        void setPrioritas()
        {
            myConn();
            
                try
                {
                for (int i = 0; i < 15; i++)
                {

                    String sql = "UPDATE wisata SET prioritas = '"+dataSI[i,7]+ "' where id_wisata='" + dataSI[i, 0] + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Data Selesai dihitung menggunakan weighted product !!!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
        }

        void vektorVI()
        {
            for (int i = 0; i < 15; i++)
            {
                dataSI[i, 7] = ((double)dataSI[i, 6] / (double)totalSI);
                //Console.WriteLine(dataSI[i, 7]);
            }
        }

        void vektorSI()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataSI[i, j] = data[i, j];
                }
            }

            
            for (int i = 0; i < 15; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    if (j == 1)
                    {
                        dataSI[i, j] = Math.Pow(dataSI[i, j], -(pri_harga));
                    }
                    else if (j == 2)
                    {
                        dataSI[i, j] = Math.Pow(dataSI[i, j], (pri_rating));
                    }
                    else if (j == 3)
                    {
                        dataSI[i, j] = Math.Pow(dataSI[i, j], (pri_jam_op));
                    }
                    else if (j == 4)
                    {
                        dataSI[i, j] = Math.Pow(dataSI[i, j], (pri_jlh_pengunjung));
                    }
                    else if (j == 5)
                    {
                        dataSI[i, j] = Math.Pow(dataSI[i, j], -(pri_jarak));
                    }
                    else if (j == 6)
                    {
                        dataSI[i, j] = (dataSI[i, 1]* dataSI[i, 2]* dataSI[i, 3]* dataSI[i, 4]* dataSI[i, 5]);
                    }
                }
            }
            for (int i = 0; i < 15; i++)
            {
                totalSI += dataSI[i, 6];
            }

        }

        void cetak_array()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.WriteLine(dataSI[i, j]);
                }
            }
        }

        void ambilNilai()
        {
            for (int i = 0; i < 15; i++)
            {
                myConn();
                String sql = "SELECT id_wisata,harga,rating,jam_op,jlh_pengunjung,jarak FROM wisata where id_wisata='"+(i+1)+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    
                    data[i, 0] = int.Parse(dataReader[0].ToString());
                    data[i, 1] = int.Parse(dataReader[1].ToString());
                    data[i, 2] = int.Parse(dataReader[2].ToString());
                    data[i, 3] = int.Parse(dataReader[3].ToString());
                    data[i, 4] = int.Parse(dataReader[4].ToString());
                    data[i, 5] = int.Parse(dataReader[5].ToString());
                }
                dataReader.Close();
                conn.Close();
            }
        }


         void openpage()
        {
            fHasil = new Hasil();
            this.Hide();
            fHasil.Show();
        }

         void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch!=8)
            {
                e.Handled = true;
            }
        }
    }
}

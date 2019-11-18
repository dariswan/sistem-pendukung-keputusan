using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_SPK
{
    public partial class Home : Form
    
    {
        private static Prioritas fPrioritas;
        public Home()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnMasuk_Click(object sender, EventArgs e)
        {
            fPrioritas = new Prioritas();
            this.Hide();
            fPrioritas.Show();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

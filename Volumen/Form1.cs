using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volumen
{
    public partial class Volumen : Form
    {
        public Volumen()
        {
            InitializeComponent();
        }

        private void volumen_control1_Load(object sender, EventArgs e)
        {

        }

        private void volumen_control1_MouseMove(object sender, MouseEventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = volumen_control1.Value;
            label1.Text= "Volume: " + volumen_control1.Value.ToString()+"%";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Volume : " + volumen_control1.Value.ToString() + "%";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
             
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }
    }
}

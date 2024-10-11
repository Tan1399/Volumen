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
    public partial class volumen_control : UserControl
    {
        public volumen_control()
        {
            InitializeComponent();
            this.Size = new Size(350,30);
            this.BackColor = Color.Black;
            DoubleBuffered = true;
        }
        int pb_value = 40, pb_Min = 0, pb_Max = 100;
        public int Max { get { return pb_Max; } set { pb_Max = value; Invalidate(); } }
        public int Min { get { return pb_Min; } set { pb_Min = value; Invalidate(); } }

        public int Value { get { return pb_value; } set { pb_value = value; Invalidate(); } }

        private void volumen_control_Load(object sender, EventArgs e)
        {
             
        }
        Color b_color = Color.Aqua;
        public Color Bar_color { get { return b_color; } set { b_color = value;Invalidate(); } }

        public int gap = 10;

        private void volumen_control_Paint(object sender, PaintEventArgs e)
        {
            int start_point = 40;
            SolidBrush sb = new SolidBrush(Color.DimGray);
            for (int j = 0; j < Max*ClientSize.Width/ Max - 75 / gap; j++)
            {
                e.Graphics.FillRectangle(sb, new Rectangle(start_point, 0, gap - 5, ClientSize.Height));
                start_point += gap;
            }
            int buffer_point = 40;
            SolidBrush br = new SolidBrush(b_color);
            for( int i=0; i < (pb_value * ClientSize.Width / Max - pb_value) / gap; i++)
            {
                e.Graphics.FillRectangle(br, new Rectangle(buffer_point, 0, gap - 2, ClientSize.Height));
                buffer_point += gap;

            }
            int thum_size = 25;
            SolidBrush thumb = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(thumb, new Rectangle(buffer_point, 0, thum_size, ClientSize.Height));


        }
        private void Bar_value(float value)
        {
            if (value < Min) value = Min;
            if (value > Max) value = Max;
            if (pb_value == value) return;
            pb_value = (int)value;
            this.Refresh();


        }
        private float thumb_value(int x)
        {
            return Min + (Max - Min) * x / (float)(ClientSize.Width);
        }

       

        bool mouse = false;

       
        private void volumen_control_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = true;
            Bar_value(thumb_value(e.X));

        }

        private void volumen_control_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouse) return;
            Bar_value(thumb_value(e.X));


        }

        private void volumen_control_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
        }






    }
}

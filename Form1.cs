using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawSheet
{
    public partial class Form1 : Form
    {
        List<Size> _rectangularDataSorted = new List<Size>();

        Form2 form2 = new Form2();

        //{new Size(10, 20), new Size(30, 40)};

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Point location;// = new Point();
            Size size; //= new Size
            int x = 0, y = 0, xRem, yRem, xTotal, yTotal;


            //List<Size> _rectangularDataSorted =
            //    _rectangleData.OrderBy(r => r.Width * r.Height);
            //var comparer = Comparer<Size>.Create((s1, s2) =>
            //                (s1.Width).CompareTo(s2.Width));



            //List<Size> _rectangularDataSorted = 
            //    (List<Size>)_rectangleData.OrderBy(r=> r.Width);
            xTotal = _rectangularDataSorted.Sum(x => x.Width);
            yTotal = _rectangularDataSorted.Sum(x => x.Height);

            for (int i = 0; i < _rectangularDataSorted.Count; i++)
            {

                if ((x + _rectangularDataSorted[i].Width) <= (xTotal - x))
                {
                    x = x + _rectangularDataSorted[i].Width;
                    y = y + _rectangularDataSorted[i].Height;
                    xRem = xTotal - x;
                    yRem = yTotal - y;
                }
                else if ((y + _rectangularDataSorted[i].Width) <= (yTotal - y))
                {
                    x = y + _rectangularDataSorted[i].Width;
                    y = x + _rectangularDataSorted[i].Height;
                    xRem = xTotal - y;
                    yRem = yTotal - x;
                }
              

                location = new Point(x, y);//(0, 20 + 50 * i);
                size = _rectangularDataSorted[i];
                e.Graphics.DrawRectangle(Pens.Red, new Rectangle(location, size));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2..Close();
            //check
            form2 = new Form2();

            _rectangularDataSorted.Clear();
           

            form2.panel1.Width = int.Parse(textBox1.Text);
            form2.panel1.Height = int.Parse(textBox2.Text);

            int width = 0, height = 0;
            //DataGridView dataGridView = new DataGridView();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                   
                if (!string.IsNullOrEmpty(dr.Cells["width"].FormattedValue.ToString())
                    && !string.IsNullOrEmpty(dr.Cells["height"].FormattedValue.ToString())) 
                {
                    width = int.Parse(dr.Cells["width"].Value.ToString());
                    height = int.Parse(dr.Cells["height"].Value.ToString());
                    _rectangularDataSorted.Add(new Size(width, height));
                }
                
            }


            form2.panel1.Paint += new PaintEventHandler(panel1_Paint);
            form2.panel1.Refresh();
            form2.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

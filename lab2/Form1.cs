

using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Bitmap inputImage;

        public Form1()
        {
            InitializeComponent();
        }


        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();

                if (res == DialogResult.OK)
                {
                    inputImage = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = inputImage;
                }
                else
                {
                    MessageBox.Show("���� �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Canny canny = new Canny(inputImage);
            pictureBox2.Image = canny.DisplayImage(canny.EdgeMap);

        }
    }
}
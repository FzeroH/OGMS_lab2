using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.Structure;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> inputImage;

        public Form1()
        {
            InitializeComponent();
        }


        private void îòêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();

                if (res == DialogResult.OK)
                {
                    inputImage = new Image<Bgr, byte>(openFileDialog1.FileName);
                    pictureBox1.Image = inputImage.ToBitmap();
                }
                else
                {
                    MessageBox.Show("Ôàéë íå âûáğàí", "Îøèáêà", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Îøèáêà", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Mat image = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255)).Mat;
            GpuMat gpOutputImage = new GpuMat();
            GpuMat<Gray> gpInputImage = new GpuMat<Gray> (image);
            CudaCannyEdgeDetector canny = new CudaCannyEdgeDetector(100.0,200.0);
            canny.Detect(gpInputImage, gpOutputImage);
            Mat outputImage = new Mat(gpOutputImage.ToString());
            pictureBox2.Image = outputImage.ToBitmap();
            //bool test = CudaInvoke.HasCuda;
            //MessageBox.Show(test.ToString());

        }
    }
}
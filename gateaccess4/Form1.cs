using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.OCR; // For Tesseract OCR support
using System.IO;
using Tesseract;

namespace gateaccess4
{
    public partial class Form1 : Form
    {
        private CascadeClassifier _licensePlateCascade;
        private TesseractEngine _tesseractEngine;

        public Form1()
        {
            InitializeComponent();
            LoadCascade();
            InitializeTesseract();
        }

        private void LoadCascade()
        {
            string cascadePath = @"C:\Users\jude\source\repos\gateaccess4\gateaccess4\Resource\cascade.xml";
            if (System.IO.File.Exists(cascadePath))
            {
                _licensePlateCascade = new CascadeClassifier(cascadePath);
                MessageBox.Show("Cascade loaded successfully.");
            }
            else
            {
                MessageBox.Show("Cascade XML file not found. Please check the path.");
            }
        }

        private void InitializeTesseract()
        {
            string tessdataPath = @"C:\Users\jude\source\repos\gateaccess4\gateaccess4\Resource";
            _tesseractEngine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default);
            _tesseractEngine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> image = new Image<Bgr, byte>(openFileDialog.FileName);
                    ShowImageInPictureBox(pbFrame, image);
                    DetectLicensePlates(image);
                }
            }
        }

        private void ShowImageInPictureBox(PictureBox pictureBox, Image<Bgr, byte> image)
        {
            pictureBox.Image = image.ToBitmap();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void DetectLicensePlates(Image<Bgr, byte> image)
        {
            if (_licensePlateCascade == null)
            {
                MessageBox.Show("Cascade not loaded. Cannot perform detection.");
                return;
            }

            using (Image<Gray, byte> grayImage = image.Convert<Gray, byte>())
            {
                double scaleFactor = 1.05;
                int minNeighbors = 5;
                Size minSize = new Size(20, 20);

                Rectangle[] plates = _licensePlateCascade.DetectMultiScale(grayImage, scaleFactor, minNeighbors, minSize);

                if (plates.Length == 0)
                {
                    MessageBox.Show("No license plates detected.");
                }
                else
                {
                    foreach (Rectangle plate in plates)
                    {
                        CvInvoke.Rectangle(image, plate, new MCvScalar(0, 0, 255), 2);
                        Image<Bgr, byte> croppedPlate = image.Copy(plate);
                        ShowImageInPictureBox(pbCropped, croppedPlate);
                        ExtractTextFromPlate(croppedPlate);
                    }
                    MessageBox.Show($"{plates.Length} license plates detected.");
                }

                ShowImageInPictureBox(pbFrame, image);
            }
        }

        private void PreprocessCroppedPlate(Image<Gray, byte> grayPlate)
        {
            grayPlate._SmoothGaussian(5);
            grayPlate._ThresholdBinary(new Gray(100), new Gray(255));
        }

        private void ExtractTextFromPlate(Image<Bgr, byte> croppedPlate)
        {
            using (Image<Gray, byte> grayPlate = croppedPlate.Convert<Gray, byte>())
            {
                PreprocessCroppedPlate(grayPlate);
                Bitmap plateBitmap = grayPlate.ToBitmap();

                using (var page = _tesseractEngine.Process(plateBitmap))
                {
                    string extractedText = page.GetText().Trim();
                    string cleanedText = PostprocessExtractedText(extractedText);
                    textBox1.Text = cleanedText;
                }
            }
        }

        private string PostprocessExtractedText(string text)
        {
            text = text.Replace("O", "0");
            text = text.Replace("I", "1");
            return text;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _licensePlateCascade?.Dispose();
            _tesseractEngine?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

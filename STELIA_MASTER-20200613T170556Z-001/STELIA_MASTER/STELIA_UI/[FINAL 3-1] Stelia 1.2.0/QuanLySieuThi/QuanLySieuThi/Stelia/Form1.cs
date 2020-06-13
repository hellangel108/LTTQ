using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.Barcode;
using Dynamsoft.Core;
using Dynamsoft.Forms;
using Dynamsoft.UVC;
using Dynamsoft.Common;

namespace WebcamBarcodeDemo
{
    public partial class Form1 : Form,Dynamsoft.PDF.IConvertCallback
    {
        private Dynamsoft.Core.ImageCore m_ImageCore = null;
        private CameraManager m_CameraManager = null;
        private Dynamsoft.PDF.PDFRasterizer m_PDFRasterizer = null;
        private string m_StrProductKey = "t0083xQAAAEw3yrtHW561JP9iTAOhp6CH//G/DbK0h/5wjMnAArdxTp2FfkY/duJ4Zz3V7RmGKefjkBh/wbO6nh/xqo4Ge/3V/DJ5xrhHif7uAEALJ3o=";
        public List<string> MaVach = new List<string>();
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            m_CameraManager = new CameraManager(m_StrProductKey);
            m_PDFRasterizer = new Dynamsoft.PDF.PDFRasterizer(m_StrProductKey);


            if (m_CameraManager.GetCameraNames()!=null)
            {
                List<String> tempCameraNames = m_CameraManager.GetCameraNames();
                foreach(string temp in tempCameraNames)
                {
                    comboBox1.Items.Add(temp);
                }
                Camera tempCamera = m_CameraManager.SelectCamera(0);
                comboBox1.SelectedIndex = 0;
                tempCamera.Open();
                tempCamera.SetVideoContainer(this.pictureBox1.Handle);
                ResizeVideoWindow();

                List<CamResolution> listCamResolutions = tempCamera.SupportedResolutions;
                comboResolution.Items.Clear();
                foreach (CamResolution temp in listCamResolutions)
                {
                    string tempHeight = temp.Height.ToString();
                    string tempWidth = temp.Width.ToString();
                    string tempResolution = tempWidth + " X " + tempHeight;
                    comboResolution.Items.Add(tempResolution);
                    comboResolution.SelectedIndex = 0;
                }
                btnAcquireSource.Enabled = true;
            }
            else
            {
                btnAcquireSource.Enabled = false;
            }

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                m_ImageCore.ImageBuffer.RemoveAllImages();
            }

            Camera tempCamera = m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName);
            Bitmap tempBit = tempCamera.GrabImage();
            m_ImageCore.IO.LoadImage(tempBit);

            BarcodeReader m_BarcodeReader = new BarcodeReader();
            m_BarcodeReader.LicenseKeys = m_StrProductKey;
            m_BarcodeReader.ReaderOptions.MaxBarcodesToReadPerPage = 100;
            m_BarcodeReader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD |
                Dynamsoft.Barcode.BarcodeFormat.PDF417 |
                Dynamsoft.Barcode.BarcodeFormat.QR_CODE |
                Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX;
            Bitmap bmp = null;
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0)
            {
                return;
            }
            bmp = (Bitmap)m_ImageCore.ImageBuffer.GetBitmap(this.m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            BarcodeResult[] aryResult = null;
            aryResult = m_BarcodeReader.DecodeBitmap(bmp);
            StringBuilder strText = new StringBuilder();
            if (aryResult == null)
            {
            }
            else
            {
                strText.AppendFormat(aryResult.Length + " total barcode" + (aryResult.Length == 1 ? ".\r\n" : "s" + " found.\r\n"));
                for (int i = 0; i < aryResult.Length; i++)
                {
                    BarcodeResult objResult = aryResult[i];
                    strText.AppendFormat("      Result " + (i + 1) + ":\r\n");
                    strText.AppendFormat("      BarcodeFormat: " + objResult.BarcodeFormat.ToString() + "\r\n");
                    strText.AppendFormat("      Text read: " + objResult.BarcodeText + "\r\n");

                    if (KiemTraMaVach(objResult.BarcodeText))
                    {
                        lblMaVach.Text += objResult.BarcodeText + "\r\n";
                        MaVach.Add(objResult.BarcodeText);
                    }
                }
            }
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CameraManager != null)
            {
                Camera tempCamera = m_CameraManager.SelectCamera((short)comboBox1.SelectedIndex);
                tempCamera.SetVideoContainer(pictureBox1.Handle);
                tempCamera.Open();
                ResizeVideoWindow();
                List<CamResolution> listCamResolutions = tempCamera.SupportedResolutions;
                comboResolution.Items.Clear();
                foreach (CamResolution temp in listCamResolutions)
                {
                    string tempHeight = temp.Height.ToString();
                    string tempWidth = temp.Width.ToString();
                    string tempResolution = tempWidth + " X " + tempHeight;
                    comboResolution.Items.Add(tempResolution);
                    comboResolution.SelectedIndex = 0;
                }
            }
        }

        private void comboResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            Camera tempCamera = m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName);
            if (comboResolution.Text != null)
            {
                string[] strResoultion = comboResolution.Text.Split(new char[] { 'X' });
                if (strResoultion.Length == 2)
                {
                    try
                    {
                        tempCamera.CurrentResolution = new CamResolution(
                            int.Parse(strResoultion[0]), int.Parse(strResoultion[1]));
                        ResizeVideoWindow();

                    }
                    catch { }
                }
            }
        }

        private void btnAcquireSource_Click(object sender, EventArgs e)
        {
            Camera tempCamera = m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName);
            Bitmap tempBit = tempCamera.GrabImage();
            m_ImageCore.IO.LoadImage(tempBit);
        }

        private void btnReadBarcode_Click(object sender, EventArgs e)
        {
            BarcodeReader m_BarcodeReader = new BarcodeReader();
            m_BarcodeReader.LicenseKeys = m_StrProductKey;
            m_BarcodeReader.ReaderOptions.MaxBarcodesToReadPerPage = 100;
            m_BarcodeReader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD |
                Dynamsoft.Barcode.BarcodeFormat.PDF417 |
                Dynamsoft.Barcode.BarcodeFormat.QR_CODE |
                Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX;
            Bitmap bmp = null;
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please acquire or load an image before reading barcode.");
                return;
            }
            bmp = (Bitmap)m_ImageCore.ImageBuffer.GetBitmap(this.m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            BarcodeResult[] aryResult = null;
            aryResult = m_BarcodeReader.DecodeBitmap(bmp);
            StringBuilder strText = new StringBuilder();
            if (aryResult == null)
            {
                //this.txtBarcode.Text = "No barcode found.";
                MessageBox.Show("No barcode found.");
            }
            else
            {
                strText.AppendFormat(aryResult.Length +" total barcode" + (aryResult.Length==1?".\r\n":"s"+" found.\r\n"));
                for (int i = 0; i < aryResult.Length; i++)
                {
                    BarcodeResult objResult = aryResult[i];
                    strText.AppendFormat("      Result " + (i + 1) + ":\r\n");
                    strText.AppendFormat("      BarcodeFormat: " + objResult.BarcodeFormat.ToString() + "\r\n");
                    strText.AppendFormat("      Text read: " + objResult.BarcodeText + "\r\n");
                }
                //this.txtBarcode.Text = strText.ToString();
                MessageBox.Show(strText.ToString());
            }
        }

        bool KiemTraMaVach(string st)
        {
            for (int i = 0; i < MaVach.Count; i++)
                if (MaVach[i] == st) return false;
            return true;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog filedlg = new OpenFileDialog();
                filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF";
                filedlg.FilterIndex = 0;

                filedlg.Multiselect = true;
                // try to locate images folder
                string imagesFolder = Application.StartupPath;

                // we assume we are running under the DotImage install folder
                imagesFolder = imagesFolder.Replace("/", "\\");
                int pos = imagesFolder.LastIndexOf("\\Samples\\");
                if (pos != -1)
                {
                    //strPDFDllFolder = strPDFDllFolder.Substring(0, strPDFDllFolder.IndexOf(@"\", pos)) + @"\Redistributable\Resources\PDF";
                    imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf(@"\", pos)) + @"\Bin\Images\BarcodeImages";
                }
                else
                {
                    pos = imagesFolder.LastIndexOf("\\");
                    imagesFolder = imagesFolder +@"\Bin\Images\BarcodeImages";
                }

                if (filedlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string strfilename in filedlg.FileNames)
                    {
                        pos = strfilename.LastIndexOf(".");
                        if (pos != -1)
                        {
                            string strSuffix = strfilename.Substring(pos, strfilename.Length - pos).ToLower();
                            if (strSuffix.CompareTo(".pdf") == 0)
                            {
                                m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                                m_PDFRasterizer.ConvertToImage(strfilename,"",200,this as Dynamsoft.PDF.IConvertCallback);
                                continue;
                            }
                        }
                        m_ImageCore.IO.LoadImage(strfilename);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void ResizeVideoWindow()
        {
            Camera tempCamera = m_CameraManager.SelectCamera(m_CameraManager.CurrentSourceName);
            CamResolution camResolution =  tempCamera.CurrentResolution;
            if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
            {
                ////if (iRotate % 2 == 0)
                {
                    int iVideoWidth = pictureBox1.Width;
                    int iVideoHeight = pictureBox1.Width * camResolution.Height / camResolution.Width;
                    int iContentHeight = pictureBox1.Height - pictureBox1.Margin.Top - pictureBox1.Margin.Bottom - pictureBox1.Padding.Top - pictureBox1.Padding.Bottom;
                    if (iVideoHeight < iContentHeight)
                        tempCamera.ResizeVideoWindow(0, (iContentHeight - iVideoHeight) / 2, iVideoWidth, iVideoHeight);
                    else
                        tempCamera.ResizeVideoWindow(0, 0, pictureBox1.Width, pictureBox1.Height);
                }

            }
        }

        #region IConvertCallback Members

        void Dynamsoft.PDF.IConvertCallback.LoadConvertResult(Dynamsoft.PDF.ConvertResult result)
        {
            m_ImageCore.IO.LoadImage(result.Image);
        }

        #endregion

        private void btnRemoveAllImages_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                m_ImageCore.ImageBuffer.RemoveAllImages();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LblMaVach_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            m_CameraManager.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeamCarvingAlgorithm;
using LaMLibrary;

namespace MainUI
{

    public partial class MainForm : Form
    {
        private static SeamCarving seamCarving;
        private static SeamDirection seamDirection;
        private static Bitmap _bmp;
        private static ISeamManipulator _seamManipulatorMark;
        private static ISeamManipulator _seamManipulator;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialogOpenFile.ShowDialog();
            
            if (LoadImage())
            {
                buttonEnergy.Enabled = true;

                //na razie statyczne seamy sa wylaczone
                buttonSeam.Enabled = false;
                buttonSeamDynamic.Enabled = true;
                comboBoxSeamDirection.Enabled = true;
            }
        }

        private bool LoadImage()
        {
            try
            {
                _bmp = (Bitmap)Bitmap.FromFile(openFileDialogOpenFile.FileName);
                seamCarving = new SeamCarving(LaMImageData.GdiImageProces.GetInstance(_bmp));
                LoadBmp();
                return true;
            }
            catch(ArgumentException a)
            {
                return false;
            }
        }


        private void buttonEnergy_Click(object sender, EventArgs e)
        {
            _bmp = seamCarving.Gradient(new LaMImageData.EnergyCalGradient());
            buttonEnergy.Enabled = false;
            LoadBmp();

        }

        private bool InitilizeSeamManipulators(object sender)
        {
            Button btn = (Button)sender;

            if (btn.Text == this.buttonSeam.Text)
            {
                _seamManipulatorMark =new StaticSeamManipulatorwithMark();
                _seamManipulator = new StaticSeamManipulator();
            }
            else if (btn.Text == this.buttonSeamDynamic.Text)
            {
                _seamManipulatorMark =new DynamicSeamManipulatorWithMark();
                _seamManipulator = new DynamicSeamManipulator();
            }
            else
            {
                throw new Exception("Button not Found");
            }

            return true;
        }

        private void LoadBmp()
        {
            int w =(_bmp.Width -pictureBoxMainBox.Width);
            if (w < 0)
                w = 0;

            int h =(_bmp.Height - pictureBoxMainBox.Height);
            if (h < 0)
                h = 0;

            Bitmap bmp = new Bitmap(_bmp, _bmp.Width - w, _bmp.Height-h);


            pictureBoxMainBox.BackgroundImage = bmp;
            pictureBoxMainBox.Update();
            pictureBoxMainBox.Refresh();
        }

        private void buttonSeam_Click(object sender, EventArgs e)
        {

            int delay;
            try
            {
                delay=Int32.Parse(textBoxDelay.Text);
            }
            catch(FormatException a)
            {
                // Jakims cudem jakby ktos wprowadzil jakies cudowne wartosci z kosmosu ;]
                delay = 0;
            }

            if (InitilizeSeamManipulators(sender))
            {
                int operations = Int32.Parse(textBoxSeamNumber.Text);

                if (checkBoxDrawSeam.Checked)
                {
                    for (int i = 0; i < operations; i++)
                    {
                        Bitmap tmp = (Bitmap)seamCarving._imgProcessor.GetBmp().Clone();

                        _bmp = seamCarving.SeamManipulation(_seamManipulatorMark, 1, seamDirection);

                        LoadBmp();
                        System.Threading.Thread.Sleep(delay);

                        seamCarving._imgProcessor.SetBmp(tmp);

                        _bmp = seamCarving.SeamManipulation(_seamManipulator, 1, seamDirection);
                        LoadBmp();
                    }
                }
                else
                {
                    _bmp = seamCarving.SeamManipulation(_seamManipulator, operations, seamDirection);
                    LoadBmp();
                }
            }
            else
            {
                throw new Exception("Seam Manipulators Initialization Failed");
            }
        }
        private void comboBoxSeamDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSeamDirection.SelectedIndex == 0)
            {
                seamDirection = SeamDirection.Vertical;
            }
            else if (comboBoxSeamDirection.SelectedIndex == 1)
            {
                seamDirection = SeamDirection.Horizontal;
            }
            else
            {
                throw new ArgumentException("Seam Direction Init Failed");
            }
        }

        private void textBoxDelay_TextChanged(object sender, EventArgs e)
        {
            int value;
            try
            {
                value = Int32.Parse(textBoxDelay.Text);
            }
            catch(FormatException f)
            {
                textBoxDelay.Text = "0";
                value = 0;
            }

            if (value >= 1000)
            {
                textBoxDelay.Text = "999";
            }
        }
    }
}

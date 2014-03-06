using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor
{
    public partial class StepViewer : Form
    {
        //Steps steps;
        sInterface steps = new SControl();
        List<Control> toEnable;
        int eIndex = 0;

        int _sIndex = 1;
        int sIndex         //Built-in bounds checking
        {
            get
            {
                if (_sIndex <= 0)
                    _sIndex = steps.count;
                else if (_sIndex > steps.count)
                    _sIndex = 1;

                return _sIndex;
            }
            set
            {
                _sIndex = value;
            }
        }

        public StepViewer()
        {
            InitializeComponent();

            steps.sChange += refresh;

            num.Text = "";
            denom.Text = "0";
            undoBut.Text = "\u21BA";
            redoBut.Text = "\u21BB";
            moveLeft.Text = "\u2190";
            moveRight.Text = "\u2192";

            // Controls to enable when loading a valid test case
            toEnable = new List<Control>()
            {
                StepPic, moveLeft, moveRight, StepsList, 
                eventText, updateEV, num, remove
            };
        }

        //Display click coordinates (relative to the original image) when the user click in the picture box
        private void StepPic_MouseClick(object sender, MouseEventArgs e)
        {
            double xRatio = steps[sIndex].image.Width / (double)StepPic.Width;
            double yRatio = steps[sIndex].image.Height / (double)StepPic.Height;
            xPos.Text = (Math.Floor(xRatio*e.X)).ToString();
            yPos.Text = (Math.Floor(yRatio*e.Y)).ToString();
        }

        //Event handler for if the form is resized
        private void StepPic_SizeChanged(object sender, EventArgs e)
        {
            ScaleBmp.setImg(StepPic, steps[sIndex].image);
        }

        //Get csv file path from user
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog fOpen = new OpenFileDialog();
            fOpen.Filter = "*.csv|*.csv";
            fOpen.ShowDialog();

            if (fOpen.FileName.Length == 0)
                return;

            string imDir = Path.Combine(Path.GetDirectoryName(fOpen.FileName), 
                                        Path.GetFileNameWithoutExtension(fOpen.FileName));

            if (File.Exists(fOpen.FileName) && Directory.Exists(imDir))
                dispTC(new SControl(fOpen.FileName));
            else
                MessageBox.Show("Associated image directory not found");
        }

        //Display test case
        private void dispTC(SControl s)
        {
            sIndex = 1;
            eIndex = 0;
            toEnable.ForEach((item) => { item.Enabled = true; });  // Enable list of controls
            steps.copy(s);                                         // Deallocates unused space and assigns s to steps

            save.Enabled = true;
        }

        //Disable controls
        private void remTC()
        {
            sIndex = 1;
            eIndex = 0;
            StepPic.Image.Dispose();
            toEnable.ForEach((item) => { item.Enabled = false; });
            save.Enabled = false;

            num.Text = "";
            denom.Text = "0";
        }

        //Refresh displays
        private void refresh()
        {
            if (steps.count == 0)
            {
                remTC();
                return;
            }

            denom.Text = steps.count.ToString();
            num.Text = sIndex.ToString();
            
            ScaleBmp.setImg(StepPic, steps[sIndex].image);          // Set current bitmap
            dispStep(steps[sIndex].events.ToList());                // Set events (in a step)

            StepsList.SelectedIndex = eIndex;              // Highlight selected event
            
            //Enable or disable revert button
            if (steps.canUndo())
                undoBut.Enabled = true;
            else
                undoBut.Enabled = false;
        }

        //Display steps in the list box
        private void dispStep(List<string> e)
        {
            StepsList.Items.Clear();

            foreach (string s in e)
                StepsList.Items.Add(s);
        }

        //Move to next step
        private void moveRight_Click(object sender, EventArgs e)
        {
            sIndex++;

            refresh();
        }

        //Move to previous step
        private void moveLeft_Click(object sender, EventArgs e)
        {
            sIndex--;

            refresh();
        }

        //Change picture by changing the index via a textbox
        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            uint key = 5;
            
            //Intercept all but integer input:
            if (!uint.TryParse(e.KeyChar.ToString(), out key))
                e.Handled = true;

            if (num.Text.Length == 0)
                return;

            //Allow enter and delete keys:
            switch ((int)e.KeyChar)
            {
                case (8):
                    e.Handled = false;
                    return;
                case (13):
                    sIndex = Math.Max(Math.Min(int.Parse(num.Text), steps.count), 1);
                    refresh();
                    return;
            }
        }

        //Select an event within a step
        private void StepsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            eIndex = StepsList.SelectedIndex;
            eventText.Text = StepsList.Items[eIndex].ToString();
        }

        //Update step with modified text
        private void updateEV_Click(object sender, EventArgs e)
        {
            if (eventText.Text.Length > 0)
                steps.modEvent(sIndex, eIndex, eventText.Text);
        }

        //Save new csv instructions file
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog fOpen = new SaveFileDialog();
            fOpen.Filter = "*.csv|*.csv";
            fOpen.ShowDialog();

            if (fOpen.FileName.Length == 0)
                return;

            steps.writeTo(fOpen.FileName);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            steps.remStep(sIndex);
        }

        // Undo user input
        private void undoBut_Click(object sender, EventArgs e)
        {
            steps.undo(out _sIndex);
        }
    }
}

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
        const string undoText = "\u21BA";
        const string redoText = "\u21BB";
        const string moveLText = "\u2190";
        const string moveRText = "\u2192";

        //Steps steps;
        sInterface steps = new SControl();
        List<Control> toEnable;
        Indices indices;
        public int sIndex { get { return indices.sIndex; } }
        public int eIndex { get { return indices.eIndex; } }

        public StepViewer()
        {
            InitializeComponent();

            steps.sChange += refresh;

            denom.Text = "0";
            undoBut.Text = undoText;
            redoBut.Text = redoText;
            moveLeft.Text = moveLText;
            moveRight.Text = moveRText;

            // Controls to enable when loading a valid test case
            toEnable = new List<Control>()
            {
                StepPic, moveLeft, moveRight, StepsList, 
                eventText, updateEV, num, remove
            };

            //Keep track of view indices
            indices = new Indices(steps, StepsList);
        }

        //Display click coordinates (relative to the original image) when the user click in the picture box
        private void StepPic_MouseClick(object sender, MouseEventArgs e)
        {
            double xRatio = steps[indices.sIndex].image.Width / (double)StepPic.Width;
            double yRatio = steps[indices.sIndex].image.Height / (double)StepPic.Height;
            xPos.Text = (Math.Floor(xRatio*e.X)).ToString();
            yPos.Text = (Math.Floor(yRatio*e.Y)).ToString();
        }

        //Event handler for if the form is resized
        private void StepPic_SizeChanged(object sender, EventArgs e)
        {
            ScaleBmp.setImg(StepPic, steps[indices.sIndex].image);
        }

        //Get csv file path from user
        private void Open_Click(object sender, EventArgs e)
        {
            string f;
            if ((f = GetFiles.GetTC()) == null)
                return;

            string imDir = Path.Combine(Path.GetDirectoryName(f), 
                                        Path.GetFileNameWithoutExtension(f));

            if (File.Exists(f) && Directory.Exists(imDir))
                dispTC(new SControl(f));
            else
                MessageBox.Show("Associated image directory not found");
        }

        //Save new csv instructions file
        private void save_Click(object sender, EventArgs e)
        {
            string f;
            if ((f = GetFiles.saveTC()) == null)
                return;

            steps.writeTo(f);
        }

        //Display test case
        private void dispTC(SControl s)
        {
            indices.sIndex = 1;
            toEnable.ForEach((item) => { item.Enabled = true; });  // Enable list of controls
            steps.copy(s);                                         // Deallocates unused space and assigns s to steps

            save.Enabled = true;
        }

        //Disable controls
        private void remTC()
        {
            indices.sIndex = 1;
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
            num.Text = indices.sIndex.ToString();
            
            ScaleBmp.setImg(StepPic, steps[indices.sIndex].image);      // Set current bitmap
            dispStep(steps[indices.sIndex].events.ToList());            // Set events (in a step)

            StepsList.SelectedIndex = indices.eIndex;                   // Highlight selected event
            
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
            indices.sIndex++;
            refresh();
        }

        //Move to previous step
        private void moveLeft_Click(object sender, EventArgs e)
        {
            indices.sIndex--;
            refresh();
        }

        //Change picture by changing the index via a textbox
        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            uint key;

            //Intercept all but integer input:
            if (!uint.TryParse(e.KeyChar.ToString(), out key))
                e.Handled = true;

            if (num.Text.Length == 0)
                return;
            else
            {
                //Allow enter and delete keys:
                switch ((int)e.KeyChar)
                {
                    case (8):
                        e.Handled = false;
                        return;
                    case (13):
                        indices.sIndex = Math.Max(Math.Min(int.Parse(num.Text), steps.count), 1);
                        refresh();
                        return;
                }
            }
        }

        //Select an event within a step
        private void StepsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            indices.eIndex = StepsList.SelectedIndex;
            eventText.Text = StepsList.Items[indices.eIndex].ToString();
        }

        //Update step with modified text
        private void updateEV_Click(object sender, EventArgs e)
        {
            if (eventText.Text.Length > 0)
                steps.modEvent(indices.sIndex, indices.eIndex, eventText.Text);
        }

        //Remove a step
        private void remove_Click(object sender, EventArgs e)
        {
            steps.remStep(indices.sIndex);
        }

        // Undo user input
        private void undoBut_Click(object sender, EventArgs e)
        {
            indices.sIndex = steps.undo();
            refresh();
        }
    }
}

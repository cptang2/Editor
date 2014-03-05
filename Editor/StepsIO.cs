using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Editor
{
    class StepsIO : Undo
    {
        public StepsIO() { }

        //Separate file into steps
        public void parse(List<Step> s, string file)
        {
            if (!File.Exists(file))
                return;

            string[] lns = File.ReadAllLines(file);
            string imDir = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file));

            if (!Directory.Exists(imDir))
            {
                MessageBox.Show("Associated image directory not found");
                return;
            }

            //Get events from the file
            foreach (string ln in lns)
                parseLn(s, ln, imDir);
        }

        //Line parse logic
        void parseLn(List<Step> s, string ln, string imDir)
        {
            if (ln.Split(',')[0] == "image")
            {
                s.Add(new Step());
                s[s.Count - 1].image = new Bitmap(imDir + "\\" + ln.Split(',')[1]);
                s[s.Count - 1].image.Tag = ln.Split(',')[1];         // Label image with its original name
            }
            else
                s[s.Count - 1].events.Add(ln);
        }

        //Write steps in memory into a file
        public void writeTo(List<Step> steps, string file)
        {
            StreamWriter sr = new StreamWriter(file);
            foreach (Step s in steps)
            {
                sr.WriteLine("image,{0}", s.image.Tag);
                s.events.ForEach((item) => { sr.WriteLine(item); });
            }

            sr.Close();
        }
    }
}

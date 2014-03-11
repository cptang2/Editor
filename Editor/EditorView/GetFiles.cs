using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Editor
{
    class GetFiles
    {
        readonly static string csvFilter = "*.csv|*.csv";

        //Get csv file path from user
        public static string GetTC()
        {
            OpenFileDialog fOpen = new OpenFileDialog();

            return dialog(fOpen);
        }

        //Save new csv instructions file
        public static string saveTC()
        {
            SaveFileDialog fOpen = new SaveFileDialog();

            return dialog(fOpen);
        }

        static string dialog(FileDialog fOpen)
        {
            fOpen.Filter = csvFilter;
            fOpen.ShowDialog();

            if (fOpen.FileName.Length != 0)
                return fOpen.FileName;

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace Editor
{
    class Steps
    {
        List<Step> steps = new List<Step>();
        readonly string file;
        StepsIO reader = new StepsIO();

        public int count
        {
            get { return steps.Count; }
        }

        public Steps(string file) 
        {
            this.file = file;
            reader.parse(steps, file);
        }

        // Prevent application from running out of memory (used primarily with +=)
        public static Steps operator +(Steps s1, Steps s2)
        {
            if (s1 != null)
                (new Thread(new ThreadStart(s1.free))).Start();

            return s2;
        }

        //Deallocate bitmaps
        void free()
        {
            steps.ForEach((item) =>
                {
                    if (item.image != null)
                        item.image.Dispose();
                });
        }

        //Get a copy of the step
        public Step this[int i]
        {
            get
            {
                return new Step(steps[i - 1]);
            }
        }

        //Write steps in memory into a file
        public void writeTo(string file)
        {
            reader.writeTo(steps, file);
        }

        //Modify event
        public void modEvent(int sIndex, int eIndex, string ev)
        {
            reader.uAdd(new Step(steps[sIndex - 1].events), sIndex, Undo.modified.events);
            steps[sIndex - 1].events[eIndex] = ev;
        }

        //Remove specified step
        public void remStep(int sIndex)
        {
            reader.uAdd(steps[sIndex - 1], sIndex, Undo.modified.both);
            steps.RemoveAt(sIndex - 1);
        }

        //Insert a step
        public void insert(int sIndex, Step s)
        {
            steps.Insert(sIndex - 1, s);
        }

        //Modify an event without adding an undo step
        public void modEvent(int sIndex, List<string> ev)
        {
            steps[sIndex - 1].events = ev;
        }

        //Replace a bitmap (not currently implemented)
        public void addBitmap(Bitmap bmp) { }

        //Check if user input can be undone
        public bool canUndo()
        {
            return reader.canUndo();
        }

        //Undo user input
        public int undo()
        {
            return reader.revert(this);
        }
    }
}

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
    class Steps : sInterface
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
            read(file);
        }
        
        #region public interface implementations

        public void read(string file)
        {
            reader.parse(steps, file);
        }

        public void copy(Steps s)
        {
            if (this.steps != null)
                (new Thread(new ThreadStart(this.free))).Start();

            this.steps = s.steps;
        }

        public Step this[int i]
        {
            get
            {
                return new Step(steps[i - 1]);
            }
        }

        public void writeTo(string file)
        {
            reader.writeTo(steps, file);
        }

        public void modEvent(int sIndex, int eIndex, string ev)
        {
            reader.uAdd(new Step(steps[sIndex - 1].events), sIndex, Undo.modified.events);
            steps[sIndex - 1].events[eIndex] = ev;
        }

        public void remStep(int sIndex)
        {
            reader.uAdd(steps[sIndex - 1], sIndex, Undo.modified.both);
            steps.RemoveAt(sIndex - 1);
        }

        public void insert(int sIndex, Step s)
        {
            steps.Insert(sIndex - 1, s);
        }

        public void modEvent(int sIndex, List<string> ev)
        {
            steps[sIndex - 1].events = ev;
        }

        public void addBitmap(Bitmap bmp) { }

        public bool canUndo()
        {
            return reader.canUndo();
        }

        public int undo()
        {
            return reader.revert(this);
        }

        #endregion

        //Deallocate bitmaps
        void free()
        {
            steps.ForEach((item) =>
            {
                if (item.image != null)
                    item.image.Dispose();
            });
        }
    }
}

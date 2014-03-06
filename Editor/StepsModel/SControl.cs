using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;


namespace Editor
{
    class SControl : sInterface
    {
        public event stepsChange sChange;
        List<Step> steps = new List<Step>();
        readonly string file;
        StepsIO reader = new StepsIO();

        public int count
        {
            get { return steps.Count; }
        }

        public SControl() { }

        public SControl(string file) 
        {
            this.file = file;
            read(file);
        }
       
        #region public interface implementations

        public void read(string file)
        {
            reader.parse(steps, file);
            onChange();
        }

        public void copy(SControl s)
        {
            List<Step> temp = this.steps;

            Action free = () =>
                {
                    temp.ForEach((item) =>
                        {
                            if (item.image != null)
                                item.image.Dispose();

                            item.events.Clear();
                        });
                };

            if (temp.Count > 0)
                (new Thread(new ThreadStart(free))).Start();

            this.steps = s.steps;
            onChange();
        }

        public void onChange()
        {
            if (sChange != null)
                sChange();
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

            onChange();
        }

        public void remStep(int sIndex)
        {
            reader.uAdd(steps[sIndex - 1], sIndex, Undo.modified.both);
            steps.RemoveAt(sIndex - 1);
            onChange();
        }

        public void insert(int sIndex, Step s)
        {
            steps.Insert(sIndex - 1, s);
            onChange();
        }

        public void modEvent(int sIndex, List<string> ev)
        {
            steps[sIndex - 1].events = ev;
            onChange();
        }

        public void addBitmap(Bitmap bmp) 
        {
            onChange();
        }

        public bool canUndo()
        {
            return reader.canUndo();
        }

        public void undo(out int index)
        {
            index = reader.revert(this);
            onChange();
        }

        #endregion
    }
}

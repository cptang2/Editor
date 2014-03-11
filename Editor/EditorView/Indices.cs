using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Editor
{
    class Indices
    {
        sInterface steps;
        ListBox StepsList;

        //Built-in bounds checking for events
        int _eIndex = 0;
        public int eIndex
        {
            get
            {
                if (_eIndex > StepsList.Items.Count)
                    _eIndex = -1;

                return _eIndex;
            }
            set
            {
                _eIndex = value;
            }
        }

        //Built-in bounds checking for steps
        int _sIndex = 1;
        public int sIndex
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

        public Indices(sInterface steps, ListBox stepsList)
        {
            this.steps = steps;
            this.StepsList = stepsList;
        }
    }
}

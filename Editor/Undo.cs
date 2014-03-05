using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Editor
{
    abstract class Undo
    {
        public enum modified
        {
            events,
            bitmap,
            both
        }

        //Store user input
        class uInput
        {
            public modified type;              //Specify what was modified

            readonly public Step step; // Step that was changed
            readonly public int stepNum;       // Step number of the step that was changed

            public uInput(Step step, int stepNum, modified type)
            {
                this.stepNum = stepNum;
                this.step = step;
                this.type = type;
            }
        }

        Stack<uInput> inputs = new Stack<uInput>();

        public Undo() { }

        // Called to clean up
        public void dispose()
        {
            uInput uI;

            while (inputs.Count > 0)
            {
                if ((uI = inputs.Pop()).step.image != null)
                    uI.step.image.Dispose();
            }
            inputs = null;
        }

        //Remove top element
        private void Pop()
        {
            if (inputs.Peek().step.image != null)
                inputs.Peek().step.image.Dispose();

            inputs.Pop();
        }

        //Add a step, remove all steps before the last revert
        public void uAdd(Step step, int stepNum, modified type)
        {
            inputs.Push(new uInput(step, stepNum, type));
        }
        
        // Revert one step back
        public int revert(Steps steps)
        {
            int stepNum = inputs.Peek().stepNum;

            switch (inputs.Peek().type)
            {
                case modified.bitmap:
                    revertBmp(steps);
                    break;
                case modified.events:
                    revertEvents(steps);
                    break;
                case modified.both:
                    revertStep(steps);
                    break;
            };

            Pop();

            return stepNum;
        }

        //Revert bitmap (not currently implemented)
        void revertBmp(Steps steps)
        {
        }

        void revertEvents(Steps steps)
        {
            steps.modEvent(inputs.Peek().stepNum, inputs.Peek().step.events);
        }

        void revertStep(Steps steps)
        {
            steps.insert(inputs.Peek().stepNum, new Step(inputs.Peek().step));
        }

        public bool canUndo()
        {
            return !(inputs.Count == 0);
        }
    }
}

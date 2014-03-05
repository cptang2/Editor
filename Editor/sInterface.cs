﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Editor
{
    interface sInterface
    {
        //Get steps count
        int count { get; }

        //Load steps from a file into memory
        void read(string file);

        //Copy a new steps object and deallocate the old immediately
        void copy(Steps s);

        //Write steps in memory into a file
        void writeTo(string file);

        //Modify an event
        void modEvent(int sIndex, int eIndex, string ev);

        //Remove a step
        void remStep(int sIndex);

        //Get a copy of a step
        Step this[int i] { get; }

        //Insert a step
        void insert(int sIndex, Step s);

        //Replace a bitmap (not currently implemented)
        void addBitmap(Bitmap bmp);

        //Check if user input can be undone
        bool canUndo();

        //Undo user input
        int undo();
    }
}

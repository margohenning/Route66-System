﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static public void style()
        {
            Application.EnableVisualStyles();
        }
    }
}

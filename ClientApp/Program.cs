﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(new Login().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Main());
            }
            
        }
    }
}

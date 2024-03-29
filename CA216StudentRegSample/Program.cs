﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA216StudentRegSample
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login = new LoginForm();
            Application.Run(login);
            if (login.loginSuccessful)
            {
                Application.Run(new DashboardForm());
            }
        }
    }
}

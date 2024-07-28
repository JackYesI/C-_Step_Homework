﻿using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new LibraryContext())
            {
                DbInitializer.Initialize(context);
            }

            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }
    }

}

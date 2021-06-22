﻿using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.ViewModels;
using System.Windows;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //new MajorIndexService().GetMajorIndex(Domain.Models.MajorIndexType.DowJones).ContinueWith((task) =>
            //{
            //    var index = task.Result;
            //});
            Window window = new MainWindow();
            window.DataContext = new MainWindowViewModel();
            window.Show();

            
            base.OnStartup(e);
        }
    }
}
